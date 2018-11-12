using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartQA1._1._2.DB.StoredProcedures;
using SmartQA1._1._2.DB.WebDb;
using SmartQA1._1._2.Models.Singletons;
using static SmartQA1._1._2.Models.Singletons.StatusesContainer;

namespace SmartQA1._1._2.Models
{
    public class StateCheckItem
    {
        //state of the buttons:
        public bool isSaveButtonEnabled;
        public bool isApproveButtonEnabled;
        public bool isSendButtonEnabled;
        public bool isCancelDeficiencyButtonEnabled;
        public readonly bool isCancelButtonEnabled = true;
        public bool showCheckBox = false;
        public bool isFixed = false;
        public bool checkBoxReadOnly = true;
          
        public Status Status;
        public List<Status> Statuses;

        //constructor is called when CheckItems are retrieved from the 
        public StateCheckItem(string Status_Code)
        {
            CheckItemStatusCode statusEnum;
            Enum.TryParse(Status_Code, out statusEnum);

            Statuses = CheckItemStatus;

            SetStatus(statusEnum);
        }

        public void ApproveButtonPressed()
        {
            //Approve button can be pressed only in Fixed state:
            if(Status.Status_Code != CheckItemStatusCode.wCLIf.ToString())
                throw new InvalidOperationException(
                    "Invalid operation: Approve button can be pressed only in Fixed state. Current Status_Code: "
                    + Status.Status_Code);

            SetStatus(CheckItemStatusCode.wCLIa);
            isSaveButtonEnabled = true;
        }

        public void CancelDeficiencyButtonPressed()
        {
            //Deficiency can be cancelled only from Issued state:
            if(Status.Status_Code != CheckItemStatusCode.wCLIss.ToString())
                throw new InvalidOperationException(
                    "Invalid operation: CancelDeficiency button can be pressed only in Issued state. Current Status_Code: "
                    + Status.Status_Code);

            SetStatus(CheckItemStatusCode.wCLIc);
            isSaveButtonEnabled = true;
        }

        public void SendButtonPressed()
        {
            //Deficiencies could be send only from Canceled or Draft State:
            if(Status.Status_Code != CheckItemStatusCode.wCLIc.ToString() &&
               Status.Status_Code != CheckItemStatusCode.wCLId.ToString())
                throw new InvalidOperationException(
                    "Invalid operation: CancelDeficiency button can be pressed only in Draft state. Current Status_Code: "
                    + Status.Status_Code);

            SetStatus(CheckItemStatusCode.wCLIss);
        }

        public void CheckBoxPressed()
        {
            //CheckBox could be pressed only in Issued state and Fixed State:
            if (Status.Status_Code == CheckItemStatusCode.wCLIss.ToString())
            {
                SetStatus(CheckItemStatusCode.wCLIf);
            }
            else
            {
                if (Status.Status_Code == CheckItemStatusCode.wCLIf.ToString())
                {
                    SetStatus(CheckItemStatusCode.wCLIss);
                }
                else 
                    throw new InvalidOperationException(
                        "Invalid operation: CheckBox can be pressed only in Fixed and Issued state. Current Status_Code: "+
                        Status.Status_Code);
            }
        }

        private void SetStatus(CheckItemStatusCode statusEnum)
        {
            switch (statusEnum)
            {
                case CheckItemStatusCode.wCLId: //Draft
                {
                    isSaveButtonEnabled = true;
                    isApproveButtonEnabled = false;
                    isSendButtonEnabled = true;
                    isCancelDeficiencyButtonEnabled = false;
                    checkBoxReadOnly = true;
                    showCheckBox = false;
                    isFixed = false;
                    break;
                }
                case CheckItemStatusCode.wCLIss: //Issued
                {
                    isSaveButtonEnabled = false;
                    isApproveButtonEnabled = false;
                    isSendButtonEnabled = false;
                    isCancelDeficiencyButtonEnabled = true;
                    showCheckBox = true;
                    isFixed = false;
                    checkBoxReadOnly = false;
                    break;
                }
                case CheckItemStatusCode.wCLIf: //Fixed
                {
                    isSaveButtonEnabled = false;
                    isApproveButtonEnabled = true;
                    isSendButtonEnabled = false;
                    isCancelDeficiencyButtonEnabled = false;
                    showCheckBox = true;
                    isFixed = true;
                    checkBoxReadOnly = false;
                    break;
                }
                case CheckItemStatusCode.wCLIa: //Approved 
                {
                    isSaveButtonEnabled = false;
                    isApproveButtonEnabled = false;
                    isSendButtonEnabled = false;
                    isCancelDeficiencyButtonEnabled = false;
                    showCheckBox = true;
                    isFixed = true;
                    checkBoxReadOnly = true;
                    break;
                }
                case CheckItemStatusCode.wCLIc: //Cancelled
                {
                    isSaveButtonEnabled = false;
                    isApproveButtonEnabled = false;
                    isSendButtonEnabled = true;
                    isCancelDeficiencyButtonEnabled = false;
                    showCheckBox = false;
                    isFixed = false;
                    checkBoxReadOnly = true;
                    break;
                }
            }
            Status = CheckItemStatus.Single(x => x.Status_Code == statusEnum.ToString());
        }

        public void Update(string command)
        {
            if (command == "SendButton") SendButtonPressed();

            if (command == "CancelDeficiency") CancelDeficiencyButtonPressed();

            if (command == "Approve") ApproveButtonPressed();

            if (command == "CheckFixedItem") CheckBoxPressed();

            if(command == "Save") throw new InvalidOperationException("Save command shouldn't leak into State object method Update()");
        }
    }
}