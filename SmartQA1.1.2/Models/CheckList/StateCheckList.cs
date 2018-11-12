using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.WebDb;
using static SmartQA1._1._2.Models.Singletons.StatusesContainer;

namespace SmartQA1._1._2.Models
{
    public class StateCheckList
    {
        public bool isCompleted;
        public bool noMoreDeficiencies;
        public bool isCheckBoxReadOnly = true;
        public bool isFixed;

        public Status Status;
        public List<Status> Statuses;

        public StateCheckList(string Status_Code)
        {
            CheckListStatusCode statusEnum;

            Enum.TryParse(Status_Code, out statusEnum);

            Statuses = CheckListStatus;

            SetStatus(statusEnum);
        }
        /// <summary>
        /// Used to change status from Draft to Review
        /// </summary>
        public void Issue()
        {
            if(Status.Status_Code != CheckListStatusCode.wСLd.ToString())
                throw new InvalidOperationException(
                    "Invalid operation: CheckList status can be changed to Review state only from Draft state. Current Status_Code: "
                    + Status.Status_Code);

            SetStatus(CheckListStatusCode.wСLr);
        }

        /// <summary>
        /// Used to change status from 
        /// </summary>
        public void Complete()
        {
            if (Status.Status_Code != CheckListStatusCode.wСLr.ToString())
                throw new InvalidOperationException(
                    "Invalid operation: CheckList status can be changed to Completed state only from Review state. Current Status_Code: "
                        + Status.Status_Code);

            SetStatus(CheckListStatusCode.wСLc);
        }

        private void SetStatus(CheckListStatusCode statusEnum)
        {
            switch (statusEnum)
            {
                case CheckListStatusCode.wСLd: //Draft
                {
                    isCompleted = false;
                    noMoreDeficiencies = false;
                    isCheckBoxReadOnly = true;
                    isFixed = false;
                    break;
                }
                case CheckListStatusCode.wСLr: //Review
                {
                    isCompleted = false;
                    noMoreDeficiencies = false;
                    isCheckBoxReadOnly = false;
                    isFixed = false;
                    break;
                }
                case CheckListStatusCode.wСLc: //Completed
                {
                    isCompleted = true;
                    noMoreDeficiencies = true;
                    isCheckBoxReadOnly = true;
                    isFixed = false;
                    break;
                }
                case CheckListStatusCode.wCLf: //Fixed
                {
                    isCompleted = true;
                    noMoreDeficiencies = true;
                    isCheckBoxReadOnly = true;
                    isFixed = false;
                    break;
                }
            }
            Status = CheckListStatus.Single(x => x.Status_Code == statusEnum.ToString());
        }
        public IResult<MsgIdPair> UpdateStatus(string command, IResult<MsgIdPair> result)
        {
            if (command == "isCompleted")
            {
                if (noMoreDeficiencies) isCompleted = !isCompleted;
                else
                {
                    result.AddError("Сначала необходимо подтвердить, что замечания отсутствуют");
                    return result;
                }
            }
            else
            {
                if (command == "noMoreDeficiencies")
                {
                    noMoreDeficiencies = !noMoreDeficiencies;
                    isCompleted = false;
                }
                else throw new InvalidOperationException("Unknow command from FE: "+command);
            }
            return result;

        }

    }
}