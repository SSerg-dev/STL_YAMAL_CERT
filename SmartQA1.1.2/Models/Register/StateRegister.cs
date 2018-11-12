using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.WebDb;
using static SmartQA1._1._2.Models.Singletons.StatusesContainer;

namespace SmartQA1._1._2.Models.Register
{
    public class StateRegister
    {
        public bool isEditEnabled;
        public bool isDeficiencyVisible;
        public bool isDocumentEditingEnabled =>isEditEnabled; //dublicates isEditEnabled
        public bool isRespEditEnabled =>isEditEnabled; //dublicates isEditEnabled

        public Status Status;

        public StateRegister(string Status_Code)
        {
            RegisterStatusCode _temp;

            Enum.TryParse(Status_Code, out _temp);

            SetStatus(_temp);
        }

        private void SetStatus(RegisterStatusCode statusEnum)
        {
            switch (statusEnum)
            {
                case RegisterStatusCode.wSCd: //Draft - auto
                {
                    isEditEnabled = true;
                    isDeficiencyVisible = false;
                    break;
                }
                case RegisterStatusCode.wSCci: //CommentsIncorporation - auto
                {
                    isEditEnabled = true;
                    isDeficiencyVisible = true;
                    break;
                }
                default:
                {
                    isEditEnabled = false;
                    isDeficiencyVisible = true;
                    break;
                }
            }

            Status = RegisterStatus.Single(x => x.Status_Code == statusEnum.ToString());
        }

        public void Issue()
        {
            throw new NotImplementedException();
        }


    }
}