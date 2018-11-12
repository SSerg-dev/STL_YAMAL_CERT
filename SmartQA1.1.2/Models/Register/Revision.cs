using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Exceptions;

namespace SmartQA1._1._2.Models.Register
{
    public class Revision
    {
        private Register register;

        public uint Current_Iteration;
        public List<UI_Register_ListItem> Documents => (_documents.Values.ToList());
        public Dictionary<Guid, UI_Register_ListItem> _documents;
        public List<Guid> Markas;
        public List<Guid> TitleObjects;
        public string Name;

        public bool IsLatest = false;
        public bool IsEditEnabled = false;

        public Revision(Register register, uint iteration, WEB_MainDataEntities context)
        {
            Name = "Ревизия " + iteration;
            _documents = new Dictionary<Guid, UI_Register_ListItem>();

            this.register = register;
            this.register.CheckCriticalProperties();

            Current_Iteration = iteration;

            IsLatest = register.Current_Iteration == Current_Iteration;
            IsEditEnabled = IsLatest && this.register.IsEditEnabled;

            List<Guid> _documentsId = Documents.Select(x => x.Document_ID).ToList();

            //retrieving all markas:
            Markas = context.UI_Document_to_Marka
                .Where(x => _documentsId.Contains(x.Document_ID))
                .Distinct()
                .Select(x => x.Marka_ID)
                .ToList();

            //retrieving all titleObjects:
            TitleObjects = context.UI_Document_to_TitleObject
                .Where(x => _documentsId.Contains(x.Document_ID))
                .Distinct()
                .Select(x => x.TitleObject_ID)
                .ToList();
        }

        public void AddDocument(UI_Register_ListItem documentToAdd)
        {
            documentToAdd.ConcatDocumentName();
            //throws ArgumentException if element with the same key already exists in the current document Dictionary
            //and this is NOT NORMAL OPERATING MODE OF THE APPLICATION
            try
            {
                _documents.Add(documentToAdd.Document_ID, documentToAdd);
            }
            catch(ArgumentException ae)
            {
                throw new DatabaseStateException("The document has been attached twice to the Register. Document_ID: "+documentToAdd.Document_ID);
            }
        }

        public bool AddDocument(WEB_MainDataEntities context, Guid Document_ID)
        {
            //check if the document has already been added:
            if (_documents.ContainsKey(Document_ID)) return false;
            
            UI_Document_List documentToAdd = context.UI_Document_List.Single(x => x.Document_ID == Document_ID);

            //convert it from UI_Document_List so it can be represented in Revision View
            UI_Register_ListItem documentToAddConverted = new UI_Register_ListItem(documentToAdd, (int)Current_Iteration);

            _documents.Add(Document_ID, documentToAddConverted);

            return true;
        }

        public void RemoveDocument(Guid Document_ID)
        {
            //delete after testing:
            if(!_documents.ContainsKey(Document_ID))
                throw new ApplicationException($"No document found with Guid {Document_ID} in current Revision");

            _documents.Remove(Document_ID);
        }
    }
}