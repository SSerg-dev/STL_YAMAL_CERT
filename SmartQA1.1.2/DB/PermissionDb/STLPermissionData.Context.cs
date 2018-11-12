﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartQA1._1._2.DB.PermissionDb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DEV_WEB_MainDataEntities : DbContext
    {
        public DEV_WEB_MainDataEntities()
            : base("name=DEV_WEB_MainDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<permDbMarka> Marka { get; set; }
        public virtual DbSet<permDbTitleObject> TitleObject { get; set; }
        public virtual DbSet<UI_Contragent> UI_Contragent { get; set; }
        public virtual DbSet<UI_Personal> UI_Personal { get; set; }
        public virtual DbSet<UI_Position> UI_Position { get; set; }
        public virtual DbSet<EAVDocumentType> EAVDocumentTypes { get; set; }
        public virtual DbSet<EAVDocument> EAVDocuments { get; set; }
        public virtual DbSet<DocumentAttribute> DocumentAttributes { get; set; }
        public virtual DbSet<AttributeType> AttributeTypes { get; set; }
        public virtual DbSet<WeldType> WeldTypes { get; set; }
        public virtual DbSet<HIFGroup> HIFGroups { get; set; }
        public virtual DbSet<DocumentRelation> DocumentRelations { get; set; }
        public virtual DbSet<DetailsType> DetailsTypes { get; set; }
        public virtual DbSet<JointKind> JointKinds { get; set; }
        public virtual DbSet<JointType> JointTypes { get; set; }
        public virtual DbSet<SeamsType> SeamsTypes { get; set; }
        public virtual DbSet<WeldGOST14098> WeldGOST14098 { get; set; }
        public virtual DbSet<WeldingEquipmentAutomationLevel> WeldingEquipmentAutomationLevels { get; set; }
        public virtual DbSet<WeldMaterial> WeldMaterials { get; set; }
        public virtual DbSet<WeldMaterialGroup> WeldMaterialGroups { get; set; }
        public virtual DbSet<WeldPosition> WeldPositions { get; set; }
        public virtual DbSet<Contragent> Contragents { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
    
        public virtual ObjectResult<Employee_Delete_Result> Employee_Delete(string i_Employee_ID, string i_AppUser_ID, ObjectParameter o_IsError)
        {
            var i_Employee_IDParameter = i_Employee_ID != null ?
                new ObjectParameter("i_Employee_ID", i_Employee_ID) :
                new ObjectParameter("i_Employee_ID", typeof(string));
    
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee_Delete_Result>("Employee_Delete", i_Employee_IDParameter, i_AppUser_IDParameter, o_IsError);
        }
    
        public virtual ObjectResult<Employee_Insert_Result> Employee_Insert(string i_RowStatus, string i_AppUser_ID, string i_Employee_Code, string i_Person_Id, string i_Position_Id, string i_AppUserRef_Id, string i_Contragent_ID, ObjectParameter o_Entity_ID, ObjectParameter o_IsError)
        {
            var i_RowStatusParameter = i_RowStatus != null ?
                new ObjectParameter("i_RowStatus", i_RowStatus) :
                new ObjectParameter("i_RowStatus", typeof(string));
    
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            var i_Employee_CodeParameter = i_Employee_Code != null ?
                new ObjectParameter("i_Employee_Code", i_Employee_Code) :
                new ObjectParameter("i_Employee_Code", typeof(string));
    
            var i_Person_IdParameter = i_Person_Id != null ?
                new ObjectParameter("i_Person_Id", i_Person_Id) :
                new ObjectParameter("i_Person_Id", typeof(string));
    
            var i_Position_IdParameter = i_Position_Id != null ?
                new ObjectParameter("i_Position_Id", i_Position_Id) :
                new ObjectParameter("i_Position_Id", typeof(string));
    
            var i_AppUserRef_IdParameter = i_AppUserRef_Id != null ?
                new ObjectParameter("i_AppUserRef_Id", i_AppUserRef_Id) :
                new ObjectParameter("i_AppUserRef_Id", typeof(string));
    
            var i_Contragent_IDParameter = i_Contragent_ID != null ?
                new ObjectParameter("i_Contragent_ID", i_Contragent_ID) :
                new ObjectParameter("i_Contragent_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee_Insert_Result>("Employee_Insert", i_RowStatusParameter, i_AppUser_IDParameter, i_Employee_CodeParameter, i_Person_IdParameter, i_Position_IdParameter, i_AppUserRef_IdParameter, i_Contragent_IDParameter, o_Entity_ID, o_IsError);
        }
    
        public virtual ObjectResult<Nullable<long>> Employee_SequenceNumber()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("Employee_SequenceNumber");
        }
    
        public virtual ObjectResult<Employee_Update_Result> Employee_Update(string i_Employee_ID, string i_RowStatus, string i_AppUser_ID, string i_Employee_Code, string i_Person_Id, string i_Position_Id, string i_AppUserRef_Id, string i_Contragent_ID, ObjectParameter o_IsError)
        {
            var i_Employee_IDParameter = i_Employee_ID != null ?
                new ObjectParameter("i_Employee_ID", i_Employee_ID) :
                new ObjectParameter("i_Employee_ID", typeof(string));
    
            var i_RowStatusParameter = i_RowStatus != null ?
                new ObjectParameter("i_RowStatus", i_RowStatus) :
                new ObjectParameter("i_RowStatus", typeof(string));
    
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            var i_Employee_CodeParameter = i_Employee_Code != null ?
                new ObjectParameter("i_Employee_Code", i_Employee_Code) :
                new ObjectParameter("i_Employee_Code", typeof(string));
    
            var i_Person_IdParameter = i_Person_Id != null ?
                new ObjectParameter("i_Person_Id", i_Person_Id) :
                new ObjectParameter("i_Person_Id", typeof(string));
    
            var i_Position_IdParameter = i_Position_Id != null ?
                new ObjectParameter("i_Position_Id", i_Position_Id) :
                new ObjectParameter("i_Position_Id", typeof(string));
    
            var i_AppUserRef_IdParameter = i_AppUserRef_Id != null ?
                new ObjectParameter("i_AppUserRef_Id", i_AppUserRef_Id) :
                new ObjectParameter("i_AppUserRef_Id", typeof(string));
    
            var i_Contragent_IDParameter = i_Contragent_ID != null ?
                new ObjectParameter("i_Contragent_ID", i_Contragent_ID) :
                new ObjectParameter("i_Contragent_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee_Update_Result>("Employee_Update", i_Employee_IDParameter, i_RowStatusParameter, i_AppUser_IDParameter, i_Employee_CodeParameter, i_Person_IdParameter, i_Position_IdParameter, i_AppUserRef_IdParameter, i_Contragent_IDParameter, o_IsError);
        }
    
        public virtual ObjectResult<Person_Delete_Result> Person_Delete(string i_AppUser_ID, string i_Person_ID, ObjectParameter o_IsError)
        {
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            var i_Person_IDParameter = i_Person_ID != null ?
                new ObjectParameter("i_Person_ID", i_Person_ID) :
                new ObjectParameter("i_Person_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person_Delete_Result>("Person_Delete", i_AppUser_IDParameter, i_Person_IDParameter, o_IsError);
        }
    
        public virtual ObjectResult<Person_Insert_Result> Person_Insert(string i_RowStatus, string i_AppUser_ID, string i_Person_Code, string i_FirstName, string i_SecondName, string i_LastName, string i_ShortName, string i_BirthDate, ObjectParameter o_Entity_ID, ObjectParameter o_IsError)
        {
            var i_RowStatusParameter = i_RowStatus != null ?
                new ObjectParameter("i_RowStatus", i_RowStatus) :
                new ObjectParameter("i_RowStatus", typeof(string));
    
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            var i_Person_CodeParameter = i_Person_Code != null ?
                new ObjectParameter("i_Person_Code", i_Person_Code) :
                new ObjectParameter("i_Person_Code", typeof(string));
    
            var i_FirstNameParameter = i_FirstName != null ?
                new ObjectParameter("i_FirstName", i_FirstName) :
                new ObjectParameter("i_FirstName", typeof(string));
    
            var i_SecondNameParameter = i_SecondName != null ?
                new ObjectParameter("i_SecondName", i_SecondName) :
                new ObjectParameter("i_SecondName", typeof(string));
    
            var i_LastNameParameter = i_LastName != null ?
                new ObjectParameter("i_LastName", i_LastName) :
                new ObjectParameter("i_LastName", typeof(string));
    
            var i_ShortNameParameter = i_ShortName != null ?
                new ObjectParameter("i_ShortName", i_ShortName) :
                new ObjectParameter("i_ShortName", typeof(string));
    
            var i_BirthDateParameter = i_BirthDate != null ?
                new ObjectParameter("i_BirthDate", i_BirthDate) :
                new ObjectParameter("i_BirthDate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person_Insert_Result>("Person_Insert", i_RowStatusParameter, i_AppUser_IDParameter, i_Person_CodeParameter, i_FirstNameParameter, i_SecondNameParameter, i_LastNameParameter, i_ShortNameParameter, i_BirthDateParameter, o_Entity_ID, o_IsError);
        }
    
        public virtual ObjectResult<Person_Update_Result> Person_Update(string i_Person_ID, string i_RowStatus, string i_AppUser_ID, string i_Person_Code, string i_FirstName, string i_SecondName, string i_LastName, string i_ShortName, string i_BirthDate, ObjectParameter o_IsError)
        {
            var i_Person_IDParameter = i_Person_ID != null ?
                new ObjectParameter("i_Person_ID", i_Person_ID) :
                new ObjectParameter("i_Person_ID", typeof(string));
    
            var i_RowStatusParameter = i_RowStatus != null ?
                new ObjectParameter("i_RowStatus", i_RowStatus) :
                new ObjectParameter("i_RowStatus", typeof(string));
    
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            var i_Person_CodeParameter = i_Person_Code != null ?
                new ObjectParameter("i_Person_Code", i_Person_Code) :
                new ObjectParameter("i_Person_Code", typeof(string));
    
            var i_FirstNameParameter = i_FirstName != null ?
                new ObjectParameter("i_FirstName", i_FirstName) :
                new ObjectParameter("i_FirstName", typeof(string));
    
            var i_SecondNameParameter = i_SecondName != null ?
                new ObjectParameter("i_SecondName", i_SecondName) :
                new ObjectParameter("i_SecondName", typeof(string));
    
            var i_LastNameParameter = i_LastName != null ?
                new ObjectParameter("i_LastName", i_LastName) :
                new ObjectParameter("i_LastName", typeof(string));
    
            var i_ShortNameParameter = i_ShortName != null ?
                new ObjectParameter("i_ShortName", i_ShortName) :
                new ObjectParameter("i_ShortName", typeof(string));
    
            var i_BirthDateParameter = i_BirthDate != null ?
                new ObjectParameter("i_BirthDate", i_BirthDate) :
                new ObjectParameter("i_BirthDate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Person_Update_Result>("Person_Update", i_Person_IDParameter, i_RowStatusParameter, i_AppUser_IDParameter, i_Person_CodeParameter, i_FirstNameParameter, i_SecondNameParameter, i_LastNameParameter, i_ShortNameParameter, i_BirthDateParameter, o_IsError);
        }
    
        public virtual ObjectResult<DocumentAttribute_Insert_Result> DocumentAttribute_Insert(string i_RowStatus, string i_AppUser_ID, string i_DocumentAttribute_Value, string i_AttributeType_ID, string i_Document_ID, string i_DocumentAttribute_Order, ObjectParameter o_Entity_ID, ObjectParameter o_IsError)
        {
            var i_RowStatusParameter = i_RowStatus != null ?
                new ObjectParameter("i_RowStatus", i_RowStatus) :
                new ObjectParameter("i_RowStatus", typeof(string));
    
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            var i_DocumentAttribute_ValueParameter = i_DocumentAttribute_Value != null ?
                new ObjectParameter("i_DocumentAttribute_Value", i_DocumentAttribute_Value) :
                new ObjectParameter("i_DocumentAttribute_Value", typeof(string));
    
            var i_AttributeType_IDParameter = i_AttributeType_ID != null ?
                new ObjectParameter("i_AttributeType_ID", i_AttributeType_ID) :
                new ObjectParameter("i_AttributeType_ID", typeof(string));
    
            var i_Document_IDParameter = i_Document_ID != null ?
                new ObjectParameter("i_Document_ID", i_Document_ID) :
                new ObjectParameter("i_Document_ID", typeof(string));
    
            var i_DocumentAttribute_OrderParameter = i_DocumentAttribute_Order != null ?
                new ObjectParameter("i_DocumentAttribute_Order", i_DocumentAttribute_Order) :
                new ObjectParameter("i_DocumentAttribute_Order", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DocumentAttribute_Insert_Result>("DocumentAttribute_Insert", i_RowStatusParameter, i_AppUser_IDParameter, i_DocumentAttribute_ValueParameter, i_AttributeType_IDParameter, i_Document_IDParameter, i_DocumentAttribute_OrderParameter, o_Entity_ID, o_IsError);
        }
    
        public virtual ObjectResult<Employee_to_Document_Insert_Result> Employee_to_Document_Insert(string i_RowStatus, string i_AppUser_ID, string i_Employee_ID, string i_Document_ID, ObjectParameter o_Entity_ID, ObjectParameter o_IsError)
        {
            var i_RowStatusParameter = i_RowStatus != null ?
                new ObjectParameter("i_RowStatus", i_RowStatus) :
                new ObjectParameter("i_RowStatus", typeof(string));
    
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            var i_Employee_IDParameter = i_Employee_ID != null ?
                new ObjectParameter("i_Employee_ID", i_Employee_ID) :
                new ObjectParameter("i_Employee_ID", typeof(string));
    
            var i_Document_IDParameter = i_Document_ID != null ?
                new ObjectParameter("i_Document_ID", i_Document_ID) :
                new ObjectParameter("i_Document_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee_to_Document_Insert_Result>("Employee_to_Document_Insert", i_RowStatusParameter, i_AppUser_IDParameter, i_Employee_IDParameter, i_Document_IDParameter, o_Entity_ID, o_IsError);
        }
    
        public virtual ObjectResult<permDbDocument_Insert_Result> Document_Insert(string i_RowStatus, string i_AppUser_ID, string i_DocumentType_ID, string i_Document_Name, string i_Document_Title, string i_Document_Revision, string i_Reponsible_Employee_ID, string i_Document_Number, string i_Document_Date, string i_Document_Parent_ID, ObjectParameter o_Entity_ID, ObjectParameter o_IsError)
        {
            var i_RowStatusParameter = i_RowStatus != null ?
                new ObjectParameter("i_RowStatus", i_RowStatus) :
                new ObjectParameter("i_RowStatus", typeof(string));
    
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            var i_DocumentType_IDParameter = i_DocumentType_ID != null ?
                new ObjectParameter("i_DocumentType_ID", i_DocumentType_ID) :
                new ObjectParameter("i_DocumentType_ID", typeof(string));
    
            var i_Document_NameParameter = i_Document_Name != null ?
                new ObjectParameter("i_Document_Name", i_Document_Name) :
                new ObjectParameter("i_Document_Name", typeof(string));
    
            var i_Document_TitleParameter = i_Document_Title != null ?
                new ObjectParameter("i_Document_Title", i_Document_Title) :
                new ObjectParameter("i_Document_Title", typeof(string));
    
            var i_Document_RevisionParameter = i_Document_Revision != null ?
                new ObjectParameter("i_Document_Revision", i_Document_Revision) :
                new ObjectParameter("i_Document_Revision", typeof(string));
    
            var i_Reponsible_Employee_IDParameter = i_Reponsible_Employee_ID != null ?
                new ObjectParameter("i_Reponsible_Employee_ID", i_Reponsible_Employee_ID) :
                new ObjectParameter("i_Reponsible_Employee_ID", typeof(string));
    
            var i_Document_NumberParameter = i_Document_Number != null ?
                new ObjectParameter("i_Document_Number", i_Document_Number) :
                new ObjectParameter("i_Document_Number", typeof(string));
    
            var i_Document_DateParameter = i_Document_Date != null ?
                new ObjectParameter("i_Document_Date", i_Document_Date) :
                new ObjectParameter("i_Document_Date", typeof(string));
    
            var i_Document_Parent_IDParameter = i_Document_Parent_ID != null ?
                new ObjectParameter("i_Document_Parent_ID", i_Document_Parent_ID) :
                new ObjectParameter("i_Document_Parent_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<permDbDocument_Insert_Result>("Document_Insert", i_RowStatusParameter, i_AppUser_IDParameter, i_DocumentType_IDParameter, i_Document_NameParameter, i_Document_TitleParameter, i_Document_RevisionParameter, i_Reponsible_Employee_IDParameter, i_Document_NumberParameter, i_Document_DateParameter, i_Document_Parent_IDParameter, o_Entity_ID, o_IsError);
        }
    
        public virtual ObjectResult<Nullable<long>> Document_SequenceNumber()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("Document_SequenceNumber");
        }
    
        public virtual ObjectResult<UI_DocumentTree_Select_Result> UI_DocumentTree_Select(string i_Employee_ID)
        {
            var i_Employee_IDParameter = i_Employee_ID != null ?
                new ObjectParameter("i_Employee_ID", i_Employee_ID) :
                new ObjectParameter("i_Employee_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UI_DocumentTree_Select_Result>("UI_DocumentTree_Select", i_Employee_IDParameter);
        }
    
        [DbFunction("DEV_WEB_MainDataEntities", "f_GetTemplate_Attr")]
        public virtual IQueryable<f_GetTemplate_Attr_Result> f_GetTemplate_Attr(string documentType_Code)
        {
            var documentType_CodeParameter = documentType_Code != null ?
                new ObjectParameter("DocumentType_Code", documentType_Code) :
                new ObjectParameter("DocumentType_Code", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<f_GetTemplate_Attr_Result>("[DEV_WEB_MainDataEntities].[f_GetTemplate_Attr](@DocumentType_Code)", documentType_CodeParameter);
        }
    
        public virtual ObjectResult<DocumentAttribute_Delete_Result> DocumentAttribute_Delete(string i_DocumentAttribute_ID, string i_AppUser_ID, ObjectParameter o_IsError)
        {
            var i_DocumentAttribute_IDParameter = i_DocumentAttribute_ID != null ?
                new ObjectParameter("i_DocumentAttribute_ID", i_DocumentAttribute_ID) :
                new ObjectParameter("i_DocumentAttribute_ID", typeof(string));
    
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DocumentAttribute_Delete_Result>("DocumentAttribute_Delete", i_DocumentAttribute_IDParameter, i_AppUser_IDParameter, o_IsError);
        }
    
        public virtual ObjectResult<permDbDocument_Update_Result> Document_Update(string i_Document_ID, string i_RowStatus, string i_AppUser_ID, string i_DocumentType_ID, string i_Document_Name, string i_Document_Title, string i_Document_Revision, string i_Reponsible_Employee_ID, string i_Document_Number, string i_Document_Date, string i_Document_Parent_ID, ObjectParameter o_IsError)
        {
            var i_Document_IDParameter = i_Document_ID != null ?
                new ObjectParameter("i_Document_ID", i_Document_ID) :
                new ObjectParameter("i_Document_ID", typeof(string));
    
            var i_RowStatusParameter = i_RowStatus != null ?
                new ObjectParameter("i_RowStatus", i_RowStatus) :
                new ObjectParameter("i_RowStatus", typeof(string));
    
            var i_AppUser_IDParameter = i_AppUser_ID != null ?
                new ObjectParameter("i_AppUser_ID", i_AppUser_ID) :
                new ObjectParameter("i_AppUser_ID", typeof(string));
    
            var i_DocumentType_IDParameter = i_DocumentType_ID != null ?
                new ObjectParameter("i_DocumentType_ID", i_DocumentType_ID) :
                new ObjectParameter("i_DocumentType_ID", typeof(string));
    
            var i_Document_NameParameter = i_Document_Name != null ?
                new ObjectParameter("i_Document_Name", i_Document_Name) :
                new ObjectParameter("i_Document_Name", typeof(string));
    
            var i_Document_TitleParameter = i_Document_Title != null ?
                new ObjectParameter("i_Document_Title", i_Document_Title) :
                new ObjectParameter("i_Document_Title", typeof(string));
    
            var i_Document_RevisionParameter = i_Document_Revision != null ?
                new ObjectParameter("i_Document_Revision", i_Document_Revision) :
                new ObjectParameter("i_Document_Revision", typeof(string));
    
            var i_Reponsible_Employee_IDParameter = i_Reponsible_Employee_ID != null ?
                new ObjectParameter("i_Reponsible_Employee_ID", i_Reponsible_Employee_ID) :
                new ObjectParameter("i_Reponsible_Employee_ID", typeof(string));
    
            var i_Document_NumberParameter = i_Document_Number != null ?
                new ObjectParameter("i_Document_Number", i_Document_Number) :
                new ObjectParameter("i_Document_Number", typeof(string));
    
            var i_Document_DateParameter = i_Document_Date != null ?
                new ObjectParameter("i_Document_Date", i_Document_Date) :
                new ObjectParameter("i_Document_Date", typeof(string));
    
            var i_Document_Parent_IDParameter = i_Document_Parent_ID != null ?
                new ObjectParameter("i_Document_Parent_ID", i_Document_Parent_ID) :
                new ObjectParameter("i_Document_Parent_ID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<permDbDocument_Update_Result>("Document_Update", i_Document_IDParameter, i_RowStatusParameter, i_AppUser_IDParameter, i_DocumentType_IDParameter, i_Document_NameParameter, i_Document_TitleParameter, i_Document_RevisionParameter, i_Reponsible_Employee_IDParameter, i_Document_NumberParameter, i_Document_DateParameter, i_Document_Parent_IDParameter, o_IsError);
        }
    }
}
