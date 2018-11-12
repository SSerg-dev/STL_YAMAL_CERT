using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SmartQA1._1._2.DB.WebDb
{
    public partial class UI_Register_ListItem : ICloneable
    {
        public string DocNumberNameConcatenated { get; set; }

        /// <summary>
        /// Default constructor used by the AutoMapper:
        /// </summary>
        public UI_Register_ListItem()
        {

        }
        /// <summary>
        /// Constructor used by the Register class to add the existing document to Register Revision
        /// </summary>
        public UI_Register_ListItem(UI_Document_List document, int iteration)
        {
            //all main propery names must match
            //THIS PROPERTIES ARE USED IN REVISION TABLES:
            //Document_Code
            //Document_Issue_Date
            //Document_Date
            //Document_Number
            //Document_Name
            //Document_Comment

            var cfg = new MapperConfiguration(c=>
            {
                c.CreateMap<UI_Document_List, UI_Register_ListItem>()
                    .ForMember(dest => dest.Document_Issue_Date, opt => opt.MapFrom(src => src.Issue_Date));
            });

            IMapper mapper = new Mapper(cfg);
            mapper.Map(document, this);

            Document_Iteration = iteration;
        }

        public void ConcatDocumentName()
        {
            if(DocNumberNameConcatenated==null) DocNumberNameConcatenated = ConcatDocNumberName(Document_Number, Document_Name);
        }

        private string ConcatDocNumberName(string docNumber, string docName)
        {
            int maxLength = 30;

            if (docName != null)
            {
                if (docName.Length > maxLength) docName = docName.Substring(0, maxLength) + "...";
                if (docNumber == null) return @".../" + docName;
                return docNumber + @" / " + docName;
            }

            if (docName == null) return null;
            return docName + @"/...";
        }

        public object Clone()
        {
            var destination = (UI_Register_ListItem) MemberwiseClone();
            return destination;
        }
    }
}