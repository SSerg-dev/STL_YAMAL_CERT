using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.DB.Models.Auth;
using SmartQA.DB.Models.Common;
using SmartQA.DB.Models.Documents;
using SmartQA.Util;
using Role = SmartQA.DB.Models.Auth.Role;

namespace SmartQA.DB
{
    public partial class DataContext
    {
        private static void SetupInitialData(ModelBuilder modelBuilder)
        {
            var fakeDate = new DateTimeOffset(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 0, 0, 0));

            modelBuilder.Entity<Parameter>()
                .HasData(
                    new Parameter
                    {
                        RowStatus = 0,
                        ID = Guid.Parse("c2a74178-34ae-407d-af20-bcbcf8be649f"),
                        Created_User_ID = rootUserId,
                        Modified_User_ID = rootUserId,
                        Insert_DTS = fakeDate,
                        Update_DTS = fakeDate,
                        Parameter_Code = "SiteTimezone",
                        Parameter_Value = "Ekaterinburg Standard Time",
                        Description_Rus =  "UTC часовой пояс строительной площадки"

                    }
                );
            
            
            modelBuilder.Entity<RowStatus>()
                .HasData(
                    new RowStatus
                    {
                        ID = 0,
                        Status_Name_Eng = "Basic_Row",
                        Status_Name_Rus = "Базовое состояние строки",
                        Description_Eng = "Basic row",
                        Description_Rus = "Действующие данные"
                    },
                    new RowStatus
                    {
                        ID = 120,
                        Status_Name_Eng = "Historical_Row",
                        Status_Name_Rus = "Историческая строка",
                        Description_Eng = "Previous condition of row",
                        Description_Rus = "Предыдущие состояния строки"
                    },
                    new RowStatus
                    {
                        ID = 200,
                        Status_Name_Eng = "Deleted",
                        Status_Name_Rus = "Удалённая строка",
                        Description_Eng = "Deleted row",
                        Description_Rus = "Удалённая строка"
                    }
                );


            modelBuilder.Entity<AppUser>()
                .HasData(
                    new AppUser
                    {
                        RowStatus = 0,
                        AppUser_Code = "root",
                        ID = rootUserId,
                        Comment = "superuser",
                        Created_User_ID = rootUserId,
                        Modified_User_ID = rootUserId,
                        Insert_DTS = fakeDate,
                        Update_DTS = fakeDate,
                        
                        // "root_user_18"
                        User_Password = new byte[] { 154, 188, 48, 112, 67, 142, 69, 201, 80, 125, 104, 193, 197, 212, 204, 212 }
                    }
                );

            modelBuilder.Entity<Role>()
                .HasData(new Role
                {
                    ID = Guid.Parse("CCD8C1EE-F6A8-E811-AA0B-005056947B15"),
                    RowStatus = 0,
                    Created_User_ID = rootUserId,
                    Modified_User_ID = rootUserId,
                    Insert_DTS = fakeDate,
                    Update_DTS = fakeDate,
                    Role_Code = "Administrator"
                });

            
            // admin rights for root user
            modelBuilder.Entity<AppUser_to_Role>()
                .HasData(new AppUser_to_Role()
                {
                    ID = Guid.Parse("C2D77D20-D557-4291-8DA8-5B6765256A95"),
                    RowStatus = 0,
                    Created_User_ID = rootUserId,
                    Modified_User_ID = rootUserId,
                    Insert_DTS = fakeDate,
                    Update_DTS = fakeDate,
                    AppUser_ID = rootUserId,
                    Role_ID = Guid.Parse("CCD8C1EE-F6A8-E811-AA0B-005056947B15")
                });


            var statuses = new[]
            {
                new Status
                {
                    ID = Guid.Parse("5E1A9818-F8A5-481C-20F0-C16D362DF87A"), Status_Code = "wDd",
                    StatusEntity = "Document", Description_Eng = "Draft",
                    Description_Rus = "Черновик", EntityLocked = false
                },
                new Status
                {
                    ID = Guid.Parse("12C12FE0-2085-5D30-87A5-5D98BA3C6ED8"), Status_Code = "wDa",
                    StatusEntity = "Document", Description_Eng = "Accepted",
                    Description_Rus = "Действующий", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("EC3DFDB9-2C7A-9A45-9CED-FDE8E9FE7617"),
                    Status_Code = "wSCd", StatusEntity = "Register", Description_Eng = "Draft",
                    Description_Rus = "Черновик", EntityLocked = false
                },
                new Status
                {
                    ID = Guid.Parse("E65BD063-4B28-9174-DB6D-83319A90AD76"),
                    Status_Code = "wCCuAr", StatusEntity = "Register", Description_Eng = "Review",
                    Description_Rus = "Проверка", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("81F3EF08-BFA7-4176-E0C1-54EF6D687B6B"),
                    Status_Code = "wSCce", StatusEntity = "Register", Description_Eng = "ComentsExists",
                    Description_Rus = "Выданы замечания", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("28FE952A-5094-3F4E-96CF-F9CDDFAE5E74"),
                    Status_Code = "wSCci", StatusEntity = "Register", Description_Eng = "CommentsIncorporation",
                    Description_Rus = "Устранение замечаний", EntityLocked = false
                },
                new Status
                {
                    ID = Guid.Parse("BCFD9A12-A2D8-F81C-C7D5-D43F190ED507"),
                    Status_Code = "wCCuAsr", StatusEntity = "Register", Description_Eng = "SecondReview",
                    Description_Rus = "Повторная проверка", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("2E96FF56-A2C3-7E5F-D06F-28EB06F8106F"),
                    Status_Code = "wCCua", StatusEntity = "Register", Description_Eng = "Approvement",
                    Description_Rus = "Утверждение", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("E10CD869-3878-29B0-1B30-A4A2855C6986"),
                    Status_Code = "wCCuna", StatusEntity = "Register", Description_Eng = "NotApproved",
                    Description_Rus = "Отказано в утверждении", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("55BC74C0-937A-1691-9C19-4D40D6028C96"),
                    Status_Code = "wCwsmr", StatusEntity = "Register", Description_Eng = "WaitingSMR",
                    Description_Rus = "Ожидание завершения СМР", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("95E4F0EA-9378-DC03-CF36-EB9EFA314512"),
                    Status_Code = "wCarh", StatusEntity = "Register", Description_Eng = "Archived",
                    Description_Rus = "Архивирование", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("C0327B4C-B2EB-32DC-CE07-80F23940350A"),
                    Status_Code = "wCcan", StatusEntity = "Register", Description_Eng = "Cancelled",
                    Description_Rus = "Аннулирован", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("86CB8686-6B39-13C9-BF28-70CF2D6D62EF"),
                    Status_Code = "wСLd", StatusEntity = "CheckList", Description_Eng = "Draft",
                    Description_Rus = "Черновик", EntityLocked = false
                },
                new Status
                {
                    ID = Guid.Parse("3DBFCB25-3EC5-F5F6-B619-43A6E0F73926"),
                    Status_Code = "wСLr", StatusEntity = "CheckList", Description_Eng = "Review",
                    Description_Rus = "Проверка", EntityLocked = false
                },
                new Status
                {
                    ID = Guid.Parse("4F24B41A-DAC7-3E73-9C0D-B31FB2F19D56"),
                    Status_Code = "wСLc", StatusEntity = "CheckList", Description_Eng = "Completed",
                    Description_Rus = "Проверка завершена", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("60486E51-EF01-2480-9E25-7AE2F56F034D"),
                    Status_Code = "wCLf", StatusEntity = "CheckList", Description_Eng = "Fixed",
                    Description_Rus = "Замечания устранены", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("6E2D4292-5383-BD3A-24FC-E67857FBF182"),
                    Status_Code = "wCLId", StatusEntity = "CheckItem", Description_Eng = "Draft",
                    Description_Rus = "Черновик", EntityLocked = false
                },
                new Status
                {
                    ID = Guid.Parse("9AC37FD3-B2C2-C309-5F39-69FB7150A824"),
                    Status_Code = "wCLIss", StatusEntity = "CheckItem", Description_Eng = "Issued",
                    Description_Rus = "Выпущено", EntityLocked = false
                },
                new Status
                {
                    ID = Guid.Parse("27D94262-2830-1D24-5764-2A90AE9094E7"),

                    Status_Code = "wCLIf", StatusEntity = "CheckItem", Description_Eng = "Fixed",
                    Description_Rus = "Исправлено", EntityLocked = false
                },
                new Status
                {
                    ID = Guid.Parse("CE34A401-3DEA-C8EB-F304-86C73E9FFD9A"),
                    Status_Code = "wCLIa", StatusEntity = "CheckItem", Description_Eng = "Approved",
                    Description_Rus = "Утверждено", EntityLocked = true
                },
                new Status
                {
                    ID = Guid.Parse("2192A6B9-D13B-3E13-597C-CDD6EBED10DF"),
                    Status_Code = "wCLIc", StatusEntity = "CheckItem", Description_Eng = "Cancelled",
                    Description_Rus = "Отменено", EntityLocked = true
                }
            };
            foreach (var status in statuses)
            {                
                status.RowStatus = 0;
                status.Created_User_ID = rootUserId;
                status.Modified_User_ID = rootUserId;
                status.Insert_DTS = fakeDate;
                status.Update_DTS = fakeDate;
            }

            modelBuilder.Entity<Status>()
                .HasData(statuses);

            modelBuilder.Entity<DocumentType>()
                .HasData(new DocumentType
                {
                    ID = Guid.Parse("724b20fd-df8d-4b4c-8afc-d54fe796f254"),
                    RowStatus = 0,
                    Created_User_ID = rootUserId,
                    Modified_User_ID = rootUserId,
                    Insert_DTS = fakeDate,
                    Update_DTS = fakeDate,
                    Title = "N/A"
                });
        }
    }
}