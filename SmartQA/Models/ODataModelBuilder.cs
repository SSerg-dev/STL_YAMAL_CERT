﻿using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Query;
using Microsoft.OData.Edm;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.People;
using SmartQA.DB.Models.PermissionDocuments;
using SmartQA.DB.Models.Reftables;
using SmartQA.DB.Models.Shared;
using SmartQA.Models.Forms;
using System;
using SmartQA.DB.Models.Documents;
using SmartQA.DB.Models.Files;
using SmartQA.Models;

namespace SmartQA.DB
{
    public class ODataModelBuilder
    {
        private StructuralTypeConfiguration<TEntityType> BuildCommon<TEntityType>(ODataConventionModelBuilder builder, string name=null) where TEntityType : CommonEntity
        {
            if (name == null) name = typeof(TEntityType).Name;

            var entitySet = (EntitySetConfiguration<TEntityType>)builder.GetType().GetMethod("EntitySet")
                .MakeGenericMethod(typeof(TEntityType))
                .Invoke(builder, new object[]{ name });            
            
            var conf = entitySet
                .EntityType
                .Filter()
                .Count()                
                .Expand()
                .OrderBy()
                .Page()
                .Select();  
            
            conf.Ignore(x => x.Created_User_ID);           
            conf.Ignore(x => x.Modified_User_ID);
            conf.Ignore(x => x.Insert_DTS);
            conf.Ignore(x => x.Update_DTS);
            conf.Ignore(x => x.RowStatus);
        
            return conf;
        }

        public StructuralTypeConfiguration<TEntityType>
            BuildReftableEntity<TEntityType>(ODataConventionModelBuilder builder)
            where TEntityType : CommonEntity, IReftableEntity
        {
            var conf = BuildCommon<TEntityType>(builder);
            conf.Property(x => x.Description);
            conf.Property(x => x.Title);
            return conf;
        }

        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            BuildCommon<FileDesc>(builder);
            
            var att = BuildCommon<DocumentAttachment>(builder);
            att.Expand(SelectExpandType.Automatic, new string [] {"FileDesc"});
            att.Property(x => x.Insert_DTS);
            
            BuildCommon<Employee>(builder);
            var person = BuildCommon<Person>(builder);
            person.Property(p => p.FullName);                
                
            BuildCommon<Contragent>(builder);
            
            var user = BuildCommon<AppUser>(builder);
            user.Ignore(u => u.User_Password);            
            user.CollectionProperty(u => u.Role_IDs);
            user.ContainsMany(u => u.RoleSet);
            
            var role = BuildCommon<Role>(builder);

            BuildCommon<Status>(builder);

            var document = BuildCommon<Document>(builder);
            document.Ignore(d => d.Issue_Date_DT);
            document.Property(d => d.Status_ID);
            document.HasOptional(d => d.Status);
            document.CollectionProperty(d => d.GOST_IDs);
            document.CollectionProperty(d => d.PID_IDs);
            document.ContainsMany(d => d.GOSTSet);
            document.ContainsMany(d => d.PIDSet);
            
            builder.EntityType<Document>()
                .Action("UploadAttachments")
                .ReturnsCollectionFromEntitySet<DocumentAttachment>("DocumentAttachment");                            
                        
            var documentUI = builder.EntitySet<DocumentUI>("DocumentUI")
                .EntityType
                .Filter()
                .Count()                
                .Expand()
                .OrderBy()
                .Page()
                .Select();
            
            documentUI.Expand(SelectExpandType.Automatic,                
                "DocumentType",
                "Status"
            );           
            
            BuildCommon<DocumentStatus>(builder);
            BuildCommon<GOST>(builder);
            BuildCommon<PID>(builder);
            
            var naks = BuildCommon<DocumentNaks>(builder);
            naks.CollectionProperty(x => x.HIFGroup_IDs);
            naks.ContainsMany(x => x.HIFGroupSet);

            var attest = BuildCommon<DocumentNaksAttest>(builder);
            attest.CollectionProperty(x => x.DetailsType_IDs);
            attest.CollectionProperty(x => x.SeamsType_IDs);
            attest.CollectionProperty(x => x.JointKind_IDs);
            attest.CollectionProperty(x => x.WeldMaterialGroup_IDs);
            attest.CollectionProperty(x => x.WeldPosition_IDs);
            attest.CollectionProperty(x => x.WeldMaterial_IDs);
            attest.CollectionProperty(x => x.WeldGOST14098_IDs);
            attest.CollectionProperty(x => x.JointType_IDs);

            attest.ContainsMany(x => x.DetailsTypeSet);
            attest.ContainsMany(x => x.SeamsTypeSet);
            attest.ContainsMany(x => x.JointKindSet);
            attest.ContainsMany(x => x.WeldMaterialGroupSet);
            attest.ContainsMany(x => x.WeldPositionSet);
            attest.ContainsMany(x => x.WeldMaterialSet);
            attest.ContainsOptional(x => x.WeldingEquipmentAutomationLevel);
            attest.ContainsMany(x => x.WeldGOST14098Set);
            attest.ContainsMany(x => x.JointTypeSet);

            attest.Expand(SelectExpandType.Automatic, new[]
            {
                "DetailsTypeSet"                       ,
                "SeamsTypeSet"                         ,
                "JointKindSet"                         ,
                "WeldMaterialGroupSet"                 ,
                "WeldPositionSet"                      ,
                "WeldMaterialSet"                      ,
                "WeldingEquipmentAutomationLevel"      ,
                "WeldGOST14098Set"                     ,
                "JointTypeSet"                         ,
                "DetailsTypeSet"
            });

            //ndt
            var ndt = BuildCommon<DocumentNDT>(builder);

            var it = BuildCommon<DocumentNDTIT>(builder);
            it.CollectionProperty(x => x.InspectionSubject_IDs);
            

            it.ContainsMany(x => x.InspectionSubjectSet);
            it.ContainsOptional(x => x.Level);
            it.ContainsOptional(x => x.InspectionTechnique);


            it.Expand(SelectExpandType.Automatic, new[]
            {
                "InspectionSubjectSet",
                "Level",
                "InspectionTechnique"

            });

            // create models  for reftables

            foreach (var reftableType in Reftable.GetReftableTypes())
            {
                GetType()
                    .GetMethod("BuildReftableEntity")                    
                    .MakeGenericMethod(reftableType)
                    .Invoke(this, new object []{ builder });                    
            }
                        
            builder.EntitySet<Reftable>(nameof(Reftable)).EntityType.Count().Filter().OrderBy().Page().Select();

            return builder.GetEdmModel();
        }
    }
}
