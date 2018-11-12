using AutoMapper;
using SmartQA1._1._2.DB.PermissionDb;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace SmartQA1._1._2.Models.Permission
{
    public class PersonDocument
    {
        public Guid? Person_ID { get; set; }
        public Guid? Employee_ID { get; set; }
        public int? P_ID { get; set; }
        public int? ID { get; set; }
        public string Name { get; set; }
        public Guid? Document_ID { get; set; }
        public Guid? DocumentType_ID { get; set; }
        public int? EntityType { get; set; }

        private IResult<MsgIdPair> result;
        private StoredProcedureAdapter spAdapter;
        private DEV_WEB_MainDataEntities context;

        private UserIdentity user => (UserIdentity)HttpContext.Current.Session["user"];

        /// <summary>
        /// Default parameterless constructor used by the AutoMapper
        /// </summary>
        public PersonDocument()
        {
        }
        /// <summary>
        /// Used by the controller to create new person documents or retrieve the existing person documents for editing
        /// </summary>
        public PersonDocument(DEV_WEB_MainDataEntities context, Guid? Employee_ID = null)
        {
            //this.context = context;
            //this.Employee_ID = Employee_ID;

            //if (Employee_ID.HasValue && Employee_ID.Value != Guid.Empty)
            //{
            //    RetrieveExistingPersonDocuments(Employee_ID);                
            //}
        }
        /// <summary>
        /// Used to retrieve the existing person documents for editings
        /// </summary>
        private void RetrieveExistingPersonDocuments(Guid? Employee_ID)
        {
            var dbPersonDocuments = context.UI_DocumentTree_Select(Employee_ID.ToString()).FirstOrDefault();
            var cfg = new MapperConfiguration(c => c.CreateMap<UI_DocumentTree_Select_Result, PersonDocument>());
            var mapper = cfg.CreateMapper();
            mapper.Map(dbPersonDocuments, this);
            this.Employee_ID = Employee_ID;
        }
        public static List<PersonDocument> GetList(Guid? Person_ID, Guid? Employee_ID)
        {
            using (DEV_WEB_MainDataEntities db = new DEV_WEB_MainDataEntities())
            {
                var mapper = new MapperConfiguration(c => c.CreateMap<UI_DocumentTree_Select_Result, PersonDocument>())
                    .CreateMapper();
                return db.UI_DocumentTree_Select(Employee_ID.ToString())
                    .Select(x => mapper.Map(x, new PersonDocument(){ Person_ID = Person_ID, Employee_ID = Employee_ID }))
                    .OrderBy(x => x.Name).ToList();
            }
        }
        ICommand _myShowGridMenuCommand;

        //public ICommand MyShowGridMenuCommand
        //{
        //    get
        //    {
        //        if (_myShowGridMenuCommand == null)
        //            _myShowGridMenuCommand = new DelegateCommand<GridMenuEventArgs>(MyShowGridMenu);
        //        return _myShowGridMenuCommand;
        //    }
        //}

        //private void MyShowGridMenu(GridMenuEventArgs e)
        //{
        //    e.Customizations.Add(new BarButtonItem() { Content = "test menu" });
        //}
    }
}