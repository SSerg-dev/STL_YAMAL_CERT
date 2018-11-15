﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartQA.DB;

namespace SmartQA.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartQA.DB.Models.Auth.AppUser", b =>
                {
                    b.Property<Guid>("AppUser_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppUser_Code");

                    b.Property<string>("Comment");

                    b.Property<Guid>("Created_User_ID");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.Property<byte[]>("User_Password");

                    b.HasKey("AppUser_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_AppUser");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Auth.AppUser_to_Role", b =>
                {
                    b.Property<Guid>("AppUser_to_Role_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AppUser_ID");

                    b.Property<Guid>("Created_User_ID");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<Guid>("Role_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("AppUser_to_Role_ID");

                    b.HasIndex("AppUser_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.HasIndex("Role_ID");

                    b.ToTable("p_AppUser_to_Role");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Auth.Role", b =>
                {
                    b.Property<Guid>("Role_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<string>("Role_Code");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("Role_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_Role");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.DetailsType", b =>
                {
                    b.Property<Guid>("DetailsType_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<string>("DetailsType_Code")
                        .IsRequired();

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("DetailsType_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_DetailsType");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.HIFGroup", b =>
                {
                    b.Property<Guid>("HIFGroup_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<string>("HIFGroup_Code")
                        .IsRequired();

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("HIFGroup_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_HIFGroup");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.JointKind", b =>
                {
                    b.Property<Guid>("JointKind_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<string>("JointKind_Code")
                        .IsRequired();

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("JointKind_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_JointKind");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.JointType", b =>
                {
                    b.Property<Guid>("JointType_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<string>("JointType_Code")
                        .IsRequired();

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("JointType_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_JointType");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.SeamsType", b =>
                {
                    b.Property<Guid>("SeamsType_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<string>("SeamsType_Code")
                        .IsRequired();

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("SeamsType_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_SeamsType");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldGOST14098", b =>
                {
                    b.Property<Guid>("WeldGOST14098_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.Property<string>("WeldGOST14098_Code")
                        .IsRequired();

                    b.HasKey("WeldGOST14098_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_WeldGOST14098");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldingEquipmentAutomationLevel", b =>
                {
                    b.Property<Guid>("WeldingEquipmentAutomationLevel_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.Property<string>("WeldingEquipmentAutomationLevel_Code")
                        .IsRequired();

                    b.HasKey("WeldingEquipmentAutomationLevel_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_WeldingEquipmentAutomationLevel");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldMaterial", b =>
                {
                    b.Property<Guid>("WeldMaterial_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.Property<string>("WeldMaterial_Code")
                        .IsRequired();

                    b.HasKey("WeldMaterial_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_WeldMaterial");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldMaterialGroup", b =>
                {
                    b.Property<Guid>("WeldMaterialGroup_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.Property<string>("WeldMaterialGroup_Code")
                        .IsRequired();

                    b.HasKey("WeldMaterialGroup_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_WeldMaterialGroup");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldPosition", b =>
                {
                    b.Property<Guid>("WeldPosition_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.Property<string>("WeldPosition_Code")
                        .IsRequired();

                    b.HasKey("WeldPosition_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_WeldPosition");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldType", b =>
                {
                    b.Property<Guid>("WeldType_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Rus");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.Property<string>("WeldType_Code")
                        .IsRequired();

                    b.HasKey("WeldType_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_WeldType");
                });

            modelBuilder.Entity("SmartQA.DB.Models.People.Contragent", b =>
                {
                    b.Property<Guid>("Contragent_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contragent_Code")
                        .IsRequired();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Eng");

                    b.Property<string>("Description_Rus");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("Contragent_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_Contragent");
                });

            modelBuilder.Entity("SmartQA.DB.Models.People.Division", b =>
                {
                    b.Property<Guid>("Division_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("Contragent_ID");

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Division_Code")
                        .IsRequired();

                    b.Property<string>("Division_Name");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("Division_ID");

                    b.HasIndex("Contragent_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_Division");
                });

            modelBuilder.Entity("SmartQA.DB.Models.People.Employee", b =>
                {
                    b.Property<Guid>("Employee_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AppUser_ID")
                        .HasColumnName("AppUser_Id");

                    b.Property<Guid?>("Contragent_ID");

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Employee_Code")
                        .IsRequired();

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<Guid>("Person_ID");

                    b.Property<Guid?>("Position_ID")
                        .HasColumnName("Position_Id");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("Employee_ID");

                    b.HasIndex("AppUser_ID");

                    b.HasIndex("Contragent_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.HasIndex("Person_ID");

                    b.HasIndex("Position_ID");

                    b.ToTable("p_Employee");
                });

            modelBuilder.Entity("SmartQA.DB.Models.People.Person", b =>
                {
                    b.Property<Guid>("Person_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<string>("Person_Code")
                        .IsRequired();

                    b.Property<int>("RowStatus");

                    b.Property<string>("SecondName");

                    b.Property<string>("ShortName");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("Person_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_Person");
                });

            modelBuilder.Entity("SmartQA.DB.Models.People.Position", b =>
                {
                    b.Property<Guid>("Position_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<string>("Description_Eng");

                    b.Property<string>("Description_Rus");

                    b.Property<Guid>("Division_ID");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<string>("Position_Code")
                        .IsRequired();

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("Position_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Division_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_Position");
                });

            modelBuilder.Entity("SmartQA.DB.Models.PermissionDocuments.DocumentNaks", b =>
                {
                    b.Property<Guid>("DocumentNaks_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("Date");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<Guid>("Person_ID");

                    b.Property<int>("RowStatus");

                    b.Property<string>("Schifr")
                        .IsRequired();

                    b.Property<DateTime>("Update_DTS");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("Date");

                    b.Property<Guid>("WeldType_ID");

                    b.HasKey("DocumentNaks_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("Modified_User_ID");

                    b.HasIndex("WeldType_ID");

                    b.ToTable("p_DocumentNaks");
                });

            modelBuilder.Entity("SmartQA.DB.Models.PermissionDocuments.DocumentNaks_to_HIFGroup", b =>
                {
                    b.Property<Guid>("DocumentNaks_to_HIFGroup_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Created_User_ID");

                    b.Property<Guid>("DocumentNaks_ID");

                    b.Property<Guid>("HIFGroup_ID");

                    b.Property<DateTime>("Insert_DTS");

                    b.Property<Guid>("Modified_User_ID");

                    b.Property<int>("RowStatus");

                    b.Property<DateTime>("Update_DTS");

                    b.HasKey("DocumentNaks_to_HIFGroup_ID");

                    b.HasIndex("Created_User_ID");

                    b.HasIndex("DocumentNaks_ID");

                    b.HasIndex("HIFGroup_ID");

                    b.HasIndex("Modified_User_ID");

                    b.ToTable("p_DocumentNaks_to_HIFGroup");
                });

            modelBuilder.Entity("SmartQA.DB.Models.Auth.AppUser", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Auth.AppUser_to_Role", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUser_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.Role", "Role")
                        .WithMany("AppUser_to_Roles")
                        .HasForeignKey("Role_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Auth.Role", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.DetailsType", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.HIFGroup", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.JointKind", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.JointType", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.SeamsType", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldGOST14098", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldingEquipmentAutomationLevel", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldMaterial", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldMaterialGroup", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldPosition", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.Dictionaries.WeldType", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.People.Contragent", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.People.Division", b =>
                {
                    b.HasOne("SmartQA.DB.Models.People.Contragent", "Contragent")
                        .WithMany()
                        .HasForeignKey("Contragent_ID");

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.People.Employee", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUser_ID");

                    b.HasOne("SmartQA.DB.Models.People.Contragent", "Contragent")
                        .WithMany()
                        .HasForeignKey("Contragent_ID");

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.People.Person", "Person")
                        .WithMany("Employees")
                        .HasForeignKey("Person_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartQA.DB.Models.People.Position", "Position")
                        .WithMany()
                        .HasForeignKey("Position_ID");
                });

            modelBuilder.Entity("SmartQA.DB.Models.People.Person", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.People.Position", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.People.Division", "Division")
                        .WithMany()
                        .HasForeignKey("Division_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartQA.DB.Models.PermissionDocuments.DocumentNaks", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.Dictionaries.WeldType", "WeldType")
                        .WithMany()
                        .HasForeignKey("WeldType_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartQA.DB.Models.PermissionDocuments.DocumentNaks_to_HIFGroup", b =>
                {
                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Created_User")
                        .WithMany()
                        .HasForeignKey("Created_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartQA.DB.Models.PermissionDocuments.DocumentNaks", "DocumentNaks")
                        .WithMany("DocumentNaks_to_HIFGroupSet")
                        .HasForeignKey("DocumentNaks_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartQA.DB.Models.Dictionaries.HIFGroup", "HIFGroup")
                        .WithMany()
                        .HasForeignKey("HIFGroup_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartQA.DB.Models.Auth.AppUser", "Modified_User")
                        .WithMany()
                        .HasForeignKey("Modified_User_ID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
