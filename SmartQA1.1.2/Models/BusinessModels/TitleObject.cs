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
    public class TitleObjectList : IModelCanBeFilled<TitleObject>
	{
        public IList<TitleObject> fill(string searchParameter)
		{
            using (var context = new Entities())
            {
                var config = new MapperConfiguration
                    (
                        cfg => cfg
                        .CreateMap<UI_TitleObject_to_Phase, TitleObject>()
                        .ForMember(x => x.Row_Status, opt => opt.Ignore())
                        .ForMember(x => x.Register_to_TitleObject_ID, opt => opt.Ignore())
                        .ReverseMap()
                    );
                IMapper mapper = config.CreateMapper();

                return context.UI_TitleObject_to_Phase.ToList().Select(x => mapper.Map<UI_TitleObject_to_Phase, TitleObject>(x)).ToList();
            }
        }
        public List<TitleObject> comingTitlesSplit(Register reg)
        {
            //splitting the string coming from the frontend and then putting brand new created objects into the List for further editing
            String[] asTitleObject_ID = reg.TitleObject_ID_Concatenated
                                        .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            List<TitleObject> frontEndTitles = new List<TitleObject>();
            foreach (var titleObject_ID in asTitleObject_ID) frontEndTitles.Add(new TitleObject(titleObject_ID));
            return frontEndTitles;
        }
        public IResult<T> createByRegister<T>(StoredProcedureAdapter spa, IResult<T> proceduresResult, Register reg) where T: IDataSet<T>
        {
            if (!String.IsNullOrWhiteSpace(reg.TitleObject_ID_Concatenated))
            {
                var frontEndTitles = comingTitlesSplit(reg);

                foreach(var title in frontEndTitles)
                {
                    title.Create(spa, proceduresResult, reg.Register_ID);
                }
            }
            return proceduresResult;
        }
        public IResult<T> updateByRegister<T>(StoredProcedureAdapter spa, IResult<T> proceduresResult, Register reg) where T: IDataSet<T>
        {
            List<TitleObject> frontEndTitles = new List<TitleObject>();
            if (!String.IsNullOrWhiteSpace(reg.TitleObject_ID_Concatenated)) frontEndTitles = comingTitlesSplit(reg);
            
            //retrieving two sets of the Register titleObjects with different Row_Status
            var config = new MapperConfiguration(
                    cfg => cfg
                    .CreateMap<UI_RegisterList, TitleObject>()
                    .ForMember(x => x.Row_Status, opt => opt.MapFrom(src => src.Register_to_TitleObject_Row_status))
                    .ReverseMap()
                );
            IMapper mapper = config.CreateMapper();

            //assuming that this procedures will be used only with Entities context
            var context = spa.GetContext() as Entities;
            Guid UserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());

            var allTitles = context.UI_RegisterList
                .Where(x => x.User_Id == UserId)
                .Where(x => x.Register_ID == reg.Register_ID)
                .ToList()
                .Select(x => mapper.Map<UI_RegisterList, TitleObject>(x))
                .ToList();
            var titles_0 = allTitles
                .Where(x => x.Row_Status == 0)
                .ToList();
            var titles_200 = allTitles
                .Where(x => x.Row_Status == 200)
                .ToList();

            //see the Handover explanations about this set operations
            foreach (var title in titles_200.Intersect(frontEndTitles))
            {
                title.Update(spa, proceduresResult, reg.Register_ID);
            }
            foreach (var title in titles_0.Except(frontEndTitles))
            {
                title.Delete(spa, proceduresResult);
            }
            frontEndTitles = frontEndTitles.Except(titles_200).ToList();
            frontEndTitles = frontEndTitles.Except(titles_0).ToList();

            foreach (var title in frontEndTitles)
            {
                title.Create(spa, proceduresResult, reg.Register_ID);
            }
            return proceduresResult;
        }
	}
    //CLASS
	public class TitleObject : IEquatable<TitleObject>
    {
        public String Phase_Name { get; set; }
        public Guid Phase_ID { get; set; }
        public Guid TitleObject_ID { get; set; }
        public String TitleObject_Name { get; set; }
        public int? Row_Status { get; set; }
        public Guid Register_to_TitleObject_ID { get; set; }

        public TitleObject() { }

        public TitleObject(String itsGuid)
        {
            this.TitleObject_ID = Guid.Parse(itsGuid);
        }
        public bool Equals(TitleObject input)
        {
            if(this.TitleObject_ID != input.TitleObject_ID) return false;
            else return true;
        }
        public override int GetHashCode()
        {
            return TitleObject_ID.GetHashCode();
        }
        public IResult<T> Create<T>(StoredProcedureAdapter spa, IResult<T> procedureResult, Guid? Register_ID) where T: IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                procedureResult,
                "dbo",
                "Register_to_TitleObject_Insert",
                "0",
                "WebServerUser",
                Register_ID.ToString(),
                TitleObject_ID
            );
        }
        public IResult<T> Update<T>(StoredProcedureAdapter spa, IResult<T> procedureResult, Guid? Register_ID) where T: IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                procedureResult,
                "dbo",
                "Register_to_TitleObject_Update",
                Register_to_TitleObject_ID,
                "0",
                "WebServerUser",
                Register_ID.ToString(),
                TitleObject_ID
            );
        }
        public IResult<T> Delete<T>(StoredProcedureAdapter spa, IResult<T> procedureResult) where T: IDataSet<T>
        {
            return spa.ExecuteStoredProcedure(
                procedureResult,
                "dbo",
                "Register_To_TitleObject_Delete",
                "WebServerUser",
                Register_to_TitleObject_ID
            );
        }
    }
}