using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SmartQA1._1._2.Models.Singletons.StatusesContainer;


namespace SmartQA1._1._2.Models
{
    public class StateCheckWrapper
    {
        public CheckListWrapperStatusCode status;

        //state of this object depends entirely on the state of its child objects
        private void SetStatus(CheckListWrapperStatusCode statusCode)
        {
            status = statusCode;
        }

        public void Issue()
        {
            if(status != CheckListWrapperStatusCode.Draft)
                throw new InvalidOperationException(
                    "Invalid operation: CheckListWrapper can be Issued only from Draft state. Current Status_Code: " +
                    status);
            SetStatus(CheckListWrapperStatusCode.Review);
        }

        public void CompleteReview()
        {
            if (status != CheckListWrapperStatusCode.Review)
                throw new InvalidOperationException(
                    "Invalid operation: CheckListWrapper review can be completed from Review state. Current Status_Code: " +
                    status);
            SetStatus(CheckListWrapperStatusCode.Review);
        }

        public void MarkFixed()
        {
            if(status != CheckListWrapperStatusCode.ReviewCompleted)
                throw new InvalidOperationException(
                    "Invalid operation: CheckListWrapper can be marked as Fixed only from ReviewCompleted state. Current Status_Code: " +
                    status);
            SetStatus(CheckListWrapperStatusCode.Review);
        }


    }
}