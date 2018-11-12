using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SmartQA1._1._2.DB.EntityFramework;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.Models.Login;

namespace SmartQA1._1._2.BusinessModels
{
    //CLASS
    public class MarkaList : IModelCanBeFilled<Marka>
    {
        private ProcedureResult result = new ProcedureResult();

        public IList<Marka> fill(string searchParameter)
        {
            using (var context = new Entities())
            {
                var config = new MapperConfiguration
                (
                    cfg => cfg
                        .CreateMap<UI_Marka, Marka>()
                        .ForMember(x => x.Row_Status, opt => opt.Ignore())
                        .ForMember(x => x.Register_to_Marka_ID, opt => opt.Ignore())
                        .ReverseMap()
                );
                IMapper mapper = config.CreateMapper();

                return context.UI_Marka.ToList().Select(x=> mapper.Map<UI_Marka, Marka>(x)).ToList();
            }
        }
        public List<Marka> comingMarkasSplit(Register reg)
        {
            //splitting the string coming from the frontend and then putting brand new created objects into the List for further editing
            String[] asMarka_ID = reg.Marka_ID_Concatenated
                                            .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            List<Marka> frontEndMarka = new List<Marka>();
            foreach (var marka_ID in asMarka_ID) frontEndMarka.Add(new Marka(marka_ID));
            return frontEndMarka;
        }
        public IResult<T> createByRegister<T>(StoredProcedureAdapter spAdapter, IResult<T> proceduresResult, Register reg) where T : IDataSet<T>
        {
            if (!String.IsNullOrWhiteSpace(reg.Marka_ID_Concatenated))
            {
                var frontEndMarka = comingMarkasSplit(reg);
                foreach(var marka in frontEndMarka)
                {
                    marka.Create(spAdapter, proceduresResult, reg.Register_ID);
                }
            }
            return proceduresResult;
        }
        public IResult<T> updateByRegister<T>(StoredProcedureAdapter spAdapter, IResult<T> proceduresResult, Register reg) where T: IDataSet<T>
        {
            List<Marka> frontEndMarka = new List<Marka>();
            if (!String.IsNullOrWhiteSpace(reg.Marka_ID_Concatenated)) frontEndMarka = comingMarkasSplit(reg);
            
            var config = new MapperConfiguration(
                cfg => cfg
                .CreateMap<UI_RegisterList, Marka>()
                .ForMember(x => x.Row_Status, opt => opt.MapFrom(src => src.Register_to_Marka_ID))
                .ReverseMap()
            );
            IMapper mapper = config.CreateMapper();

            //assuming that this method will work only with Entities
            var context = spAdapter.GetContext() as Entities;
            Guid UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
            var allMarka = context.UI_RegisterList
                .Where(x => x.User_Id == UserId)
                .Where(x => x.Register_ID == reg.Register_ID)
                .ToList()
                .Select(x => mapper.Map<UI_RegisterList, Marka>(x))
                .ToList();
            var marka_0 = allMarka
                .Where(x => x.Row_Status == 0)
                .ToList();
            var marka_200 = allMarka
                .Where(x => x.Row_Status == 200)
                .ToList();

            //see the Handover explanations about this set operations
            foreach (var marka in marka_200.Intersect(frontEndMarka))
            {
                marka.Update(spAdapter, proceduresResult, reg.Register_ID);
            }
            foreach (var marka in marka_0.Except(frontEndMarka))
            {
                marka.Delete(spAdapter, proceduresResult);
            }
            frontEndMarka = frontEndMarka.Except(marka_200).ToList();
            frontEndMarka = frontEndMarka.Except(marka_0).ToList();
            foreach (var marka in frontEndMarka)
            {
                marka.Create(spAdapter, proceduresResult, reg.Register_ID);
            }
            return proceduresResult;
        }
    }
    //CLASS
    public class Marka : IEquatable<Marka>
    {
        public Guid Marka_ID { get; set; }
        public String Marka_Name { get; set; }
        public int? Row_Status { get; set; }
        public Guid Register_to_Marka_ID { get; set; }

        public Marka() { }

        public Marka(string itsGuid)
        {
            this.Marka_ID = Guid.Parse(itsGuid);
        }
        public bool Equals(Marka input)
        {
            if(this.Marka_ID != input.Marka_ID) return false;
            else return true;
        }
        public override int GetHashCode()
        {
            return Marka_ID.GetHashCode();
        }
        public IResult<T> Create<T>(StoredProcedureAdapter spa, IResult<T> procedureResult, Guid? Register_ID) where T : IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                procedureResult,
                "dbo",
                "Register_to_Marka_Insert",
                "0",
                "WebServerUser",
                Register_ID,
                Marka_ID
            );
        }
        public IResult<T> Update<T>(StoredProcedureAdapter spa, IResult<T> procedureResult, Guid? Register_ID) where T: IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                procedureResult,
                "dbo",
                "Register_to_Marka_Update",
                Register_to_Marka_ID,
                "0",
                "WebServerUser",
                Register_ID,
                Marka_ID
            );
        }
        public IResult<T> Delete<T>(StoredProcedureAdapter spa, IResult<T> procedureResult) where T: IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                procedureResult,
                "dbo",
                "Register_To_Marka_Delete",
                "WebServerUser",
                Register_to_Marka_ID
            );
        }

    }
}