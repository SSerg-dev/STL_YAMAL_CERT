using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WEB_MainData_UnitTest
{
    [TestClass()]
    public class SystemTestRegister : SqlDatabaseTestClass
    {

        public SystemTestRegister()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction testInitializeAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemTestRegister));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t001_CleanUp_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition emptyResultSetCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t002_PrepareData_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition expectedSchemaCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t003_CreateDocuments_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t003_CreateDocuments_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t004_SetDocStatusToAccepted_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t004_SetDocStatusToAccepted_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t005_CreateRegisterDraft_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t005_CreateRegisterDraft_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t006_SetRegisterFromDraftToFirstReview_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t006_SetRegisterFromDraftToFirstReview_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t007_FillCheckListResp_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t007_FillCheckListResp_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t008_InsertCheckItemsFirstReview_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t008_InsertCheckItemsFirstReview_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t009_FinishFirstCheckReview_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t009_FinishFirstCheckReview_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t010_FinishSecondCheckReview_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t010_FinishSecondCheckReview_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t011_FinishThirdCheckReview_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t011_FinishThirdCheckReview_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t012_SetRegisterFromCommentsGivenToIncorporation_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t012_SetRegisterFromCommentsGivenToIncorporation_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t013_InsertNewDocsForRevision_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t013_InsertNewDocsForRevision_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t014_SetNewDocumentsStatusToAccepted_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t014_SetNewDocumentsStatusToAccepted_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t015_CreateRegisterRevision2_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t015_CreateRegisterRevision2_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t016_SendRegisterToSecondReview_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t016_SendRegisterToSecondReview_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t017_FirstCheckerAcceptCommentaAndFinishedReview_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t017_FirstCheckerAcceptCommentaAndFinishedReview_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t018_SecondCheckerAcceptCommentaAndFinishedReviewData_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition11;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t018_SecondCheckerAcceptCommentaAndFinishedReviewData_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition12;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition13;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t020_FillCheckListApproveingIncumbent_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition14;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t020_FillCheckListApproveingIncumbent_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t021_InsertCheckItemsFirstApprovement_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition15;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t021_InsertCheckItemsFirstApprovement_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t022_FinishFirstCheckApprovement_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition11;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t022_FinishFirstCheckApprovement_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t002_PrepareData_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t023_FinishSecondCheckApprovement_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition16;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition17;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t023_FinishSecondCheckApprovement_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t024_SetRegisterFromNotAcceptedToCommentsGiven_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition18;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t024_SetRegisterFromNotAcceptedToCommentsGiven_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t025_InsertNewDocsFor3revision_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition12;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t025_InsertNewDocsFor3revision_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t026_SetNewDocumentStatusToAccepted_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition13;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t026_SetNewDocumentStatusToAccepted_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t027_CreateRegisterRevision3_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition19;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t027_CreateRegisterRevision3_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t028_SendRegisterToSecondApprovement_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition14;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition15;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition16;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t028_SendRegisterToSecondApprovement_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t029_FirstCheckerAcceptCommentAndFinisheApprovement_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition20;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t029_FirstCheckerAcceptCommentAndFinisheApprovement_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t030_SecondCheckerAcceptCommentAndFinishedApprovement_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition21;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition22;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction t030_SecondCheckerAcceptCommentAndFinishedApprovement_PretestAction;
            this.t001_CleanUpData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t002_PrepareDataData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t003_CreateDocumentsData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t004_SetDocStatusToAcceptedData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t005_CreateRegisterDraftData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t006_SetRegisterFromDraftToFirstReviewData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t007_FillCheckListRespData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t008_InsertCheckItemsFirstReviewData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t009_FinishFirstCheckReviewData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t010_FinishSecondCheckReviewData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t011_FinishThirdCheckReviewData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t012_SetRegisterFromCommentsGivenToIncorporationData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t013_InsertNewDocsForRevisionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t014_SetNewDocumentsStatusToAcceptedData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t015_CreateRegisterRevision2Data = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t016_SendRegisterToSecondReviewData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t017_FirstCheckerAcceptCommentaAndFinishedReviewData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t018_SecondCheckerAcceptCommentaAndFinishedReviewDataData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataDataData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t020_FillCheckListApproveingIncumbentData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t021_InsertCheckItemsFirstApprovementData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t022_FinishFirstCheckApprovementData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t023_FinishSecondCheckApprovementData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t024_SetRegisterFromNotAcceptedToCommentsGivenData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t025_InsertNewDocsFor3revisionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t026_SetNewDocumentStatusToAcceptedData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t027_CreateRegisterRevision3Data = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t028_SendRegisterToSecondApprovementData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t029_FirstCheckerAcceptCommentAndFinisheApprovementData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.t030_SecondCheckerAcceptCommentAndFinishedApprovementData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            testInitializeAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            t001_CleanUp_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            emptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition();
            t002_PrepareData_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            expectedSchemaCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExpectedSchemaCondition();
            t003_CreateDocuments_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t003_CreateDocuments_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t004_SetDocStatusToAccepted_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t004_SetDocStatusToAccepted_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t005_CreateRegisterDraft_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t005_CreateRegisterDraft_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t006_SetRegisterFromDraftToFirstReview_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t006_SetRegisterFromDraftToFirstReview_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t007_FillCheckListResp_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t007_FillCheckListResp_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t008_InsertCheckItemsFirstReview_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t008_InsertCheckItemsFirstReview_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t009_FinishFirstCheckReview_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t009_FinishFirstCheckReview_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t010_FinishSecondCheckReview_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t010_FinishSecondCheckReview_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t011_FinishThirdCheckReview_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t011_FinishThirdCheckReview_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t012_SetRegisterFromCommentsGivenToIncorporation_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t012_SetRegisterFromCommentsGivenToIncorporation_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t013_InsertNewDocsForRevision_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t013_InsertNewDocsForRevision_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t014_SetNewDocumentsStatusToAccepted_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t014_SetNewDocumentsStatusToAccepted_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t015_CreateRegisterRevision2_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition9 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t015_CreateRegisterRevision2_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t016_SendRegisterToSecondReview_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition9 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t016_SendRegisterToSecondReview_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t017_FirstCheckerAcceptCommentaAndFinishedReview_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t017_FirstCheckerAcceptCommentaAndFinishedReview_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t018_SecondCheckerAcceptCommentaAndFinishedReviewData_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition11 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t018_SecondCheckerAcceptCommentaAndFinishedReviewData_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition12 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition13 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t020_FillCheckListApproveingIncumbent_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition14 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t020_FillCheckListApproveingIncumbent_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t021_InsertCheckItemsFirstApprovement_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition15 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t021_InsertCheckItemsFirstApprovement_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t022_FinishFirstCheckApprovement_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition11 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t022_FinishFirstCheckApprovement_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t002_PrepareData_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t023_FinishSecondCheckApprovement_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition16 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition17 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t023_FinishSecondCheckApprovement_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t024_SetRegisterFromNotAcceptedToCommentsGiven_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition18 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t024_SetRegisterFromNotAcceptedToCommentsGiven_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t025_InsertNewDocsFor3revision_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition12 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t025_InsertNewDocsFor3revision_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t026_SetNewDocumentStatusToAccepted_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition13 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t026_SetNewDocumentStatusToAccepted_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t027_CreateRegisterRevision3_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition19 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t027_CreateRegisterRevision3_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t028_SendRegisterToSecondApprovement_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition14 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition15 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition16 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            t028_SendRegisterToSecondApprovement_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t029_FirstCheckerAcceptCommentAndFinisheApprovement_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition20 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t029_FirstCheckerAcceptCommentAndFinisheApprovement_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            t030_SecondCheckerAcceptCommentAndFinishedApprovement_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition21 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            scalarValueCondition22 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            t030_SecondCheckerAcceptCommentAndFinishedApprovement_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // testInitializeAction
            // 
            testInitializeAction.Conditions.Add(notEmptyResultSetCondition1);
            resources.ApplyResources(testInitializeAction, "testInitializeAction");
            // 
            // notEmptyResultSetCondition1
            // 
            notEmptyResultSetCondition1.Enabled = true;
            notEmptyResultSetCondition1.Name = "notEmptyResultSetCondition1";
            notEmptyResultSetCondition1.ResultSet = 1;
            // 
            // t001_CleanUp_TestAction
            // 
            t001_CleanUp_TestAction.Conditions.Add(emptyResultSetCondition1);
            resources.ApplyResources(t001_CleanUp_TestAction, "t001_CleanUp_TestAction");
            // 
            // emptyResultSetCondition1
            // 
            emptyResultSetCondition1.Enabled = true;
            emptyResultSetCondition1.Name = "emptyResultSetCondition1";
            emptyResultSetCondition1.ResultSet = 1;
            // 
            // t002_PrepareData_TestAction
            // 
            t002_PrepareData_TestAction.Conditions.Add(expectedSchemaCondition1);
            resources.ApplyResources(t002_PrepareData_TestAction, "t002_PrepareData_TestAction");
            // 
            // expectedSchemaCondition1
            // 
            expectedSchemaCondition1.Enabled = true;
            expectedSchemaCondition1.Name = "expectedSchemaCondition1";
            resources.ApplyResources(expectedSchemaCondition1, "expectedSchemaCondition1");
            expectedSchemaCondition1.Verbose = false;
            // 
            // t003_CreateDocuments_TestAction
            // 
            t003_CreateDocuments_TestAction.Conditions.Add(rowCountCondition1);
            resources.ApplyResources(t003_CreateDocuments_TestAction, "t003_CreateDocuments_TestAction");
            // 
            // rowCountCondition1
            // 
            rowCountCondition1.Enabled = true;
            rowCountCondition1.Name = "rowCountCondition1";
            rowCountCondition1.ResultSet = 1;
            rowCountCondition1.RowCount = 3;
            // 
            // t003_CreateDocuments_PretestAction
            // 
            resources.ApplyResources(t003_CreateDocuments_PretestAction, "t003_CreateDocuments_PretestAction");
            // 
            // t004_SetDocStatusToAccepted_TestAction
            // 
            t004_SetDocStatusToAccepted_TestAction.Conditions.Add(rowCountCondition2);
            resources.ApplyResources(t004_SetDocStatusToAccepted_TestAction, "t004_SetDocStatusToAccepted_TestAction");
            // 
            // rowCountCondition2
            // 
            rowCountCondition2.Enabled = true;
            rowCountCondition2.Name = "rowCountCondition2";
            rowCountCondition2.ResultSet = 1;
            rowCountCondition2.RowCount = 3;
            // 
            // t004_SetDocStatusToAccepted_PretestAction
            // 
            resources.ApplyResources(t004_SetDocStatusToAccepted_PretestAction, "t004_SetDocStatusToAccepted_PretestAction");
            // 
            // t005_CreateRegisterDraft_TestAction
            // 
            t005_CreateRegisterDraft_TestAction.Conditions.Add(rowCountCondition3);
            resources.ApplyResources(t005_CreateRegisterDraft_TestAction, "t005_CreateRegisterDraft_TestAction");
            // 
            // rowCountCondition3
            // 
            rowCountCondition3.Enabled = true;
            rowCountCondition3.Name = "rowCountCondition3";
            rowCountCondition3.ResultSet = 1;
            rowCountCondition3.RowCount = 3;
            // 
            // t005_CreateRegisterDraft_PretestAction
            // 
            resources.ApplyResources(t005_CreateRegisterDraft_PretestAction, "t005_CreateRegisterDraft_PretestAction");
            // 
            // t006_SetRegisterFromDraftToFirstReview_TestAction
            // 
            t006_SetRegisterFromDraftToFirstReview_TestAction.Conditions.Add(rowCountCondition4);
            t006_SetRegisterFromDraftToFirstReview_TestAction.Conditions.Add(rowCountCondition5);
            resources.ApplyResources(t006_SetRegisterFromDraftToFirstReview_TestAction, "t006_SetRegisterFromDraftToFirstReview_TestAction");
            // 
            // rowCountCondition4
            // 
            rowCountCondition4.Enabled = true;
            rowCountCondition4.Name = "rowCountCondition4";
            rowCountCondition4.ResultSet = 1;
            rowCountCondition4.RowCount = 3;
            // 
            // rowCountCondition5
            // 
            rowCountCondition5.Enabled = true;
            rowCountCondition5.Name = "rowCountCondition5";
            rowCountCondition5.ResultSet = 2;
            rowCountCondition5.RowCount = 5;
            // 
            // t006_SetRegisterFromDraftToFirstReview_PretestAction
            // 
            resources.ApplyResources(t006_SetRegisterFromDraftToFirstReview_PretestAction, "t006_SetRegisterFromDraftToFirstReview_PretestAction");
            // 
            // t007_FillCheckListResp_TestAction
            // 
            t007_FillCheckListResp_TestAction.Conditions.Add(scalarValueCondition1);
            resources.ApplyResources(t007_FillCheckListResp_TestAction, "t007_FillCheckListResp_TestAction");
            // 
            // scalarValueCondition1
            // 
            scalarValueCondition1.ColumnNumber = 1;
            scalarValueCondition1.Enabled = true;
            scalarValueCondition1.ExpectedValue = "3";
            scalarValueCondition1.Name = "scalarValueCondition1";
            scalarValueCondition1.NullExpected = false;
            scalarValueCondition1.ResultSet = 1;
            scalarValueCondition1.RowNumber = 1;
            // 
            // t007_FillCheckListResp_PretestAction
            // 
            resources.ApplyResources(t007_FillCheckListResp_PretestAction, "t007_FillCheckListResp_PretestAction");
            // 
            // t008_InsertCheckItemsFirstReview_TestAction
            // 
            t008_InsertCheckItemsFirstReview_TestAction.Conditions.Add(scalarValueCondition2);
            resources.ApplyResources(t008_InsertCheckItemsFirstReview_TestAction, "t008_InsertCheckItemsFirstReview_TestAction");
            // 
            // scalarValueCondition2
            // 
            scalarValueCondition2.ColumnNumber = 1;
            scalarValueCondition2.Enabled = true;
            scalarValueCondition2.ExpectedValue = "12";
            scalarValueCondition2.Name = "scalarValueCondition2";
            scalarValueCondition2.NullExpected = false;
            scalarValueCondition2.ResultSet = 1;
            scalarValueCondition2.RowNumber = 1;
            // 
            // t008_InsertCheckItemsFirstReview_PretestAction
            // 
            resources.ApplyResources(t008_InsertCheckItemsFirstReview_PretestAction, "t008_InsertCheckItemsFirstReview_PretestAction");
            // 
            // t009_FinishFirstCheckReview_TestAction
            // 
            t009_FinishFirstCheckReview_TestAction.Conditions.Add(scalarValueCondition3);
            resources.ApplyResources(t009_FinishFirstCheckReview_TestAction, "t009_FinishFirstCheckReview_TestAction");
            // 
            // scalarValueCondition3
            // 
            scalarValueCondition3.ColumnNumber = 1;
            scalarValueCondition3.Enabled = true;
            scalarValueCondition3.ExpectedValue = "1";
            scalarValueCondition3.Name = "scalarValueCondition3";
            scalarValueCondition3.NullExpected = false;
            scalarValueCondition3.ResultSet = 1;
            scalarValueCondition3.RowNumber = 1;
            // 
            // t009_FinishFirstCheckReview_PretestAction
            // 
            resources.ApplyResources(t009_FinishFirstCheckReview_PretestAction, "t009_FinishFirstCheckReview_PretestAction");
            // 
            // t010_FinishSecondCheckReview_TestAction
            // 
            t010_FinishSecondCheckReview_TestAction.Conditions.Add(scalarValueCondition4);
            resources.ApplyResources(t010_FinishSecondCheckReview_TestAction, "t010_FinishSecondCheckReview_TestAction");
            // 
            // scalarValueCondition4
            // 
            scalarValueCondition4.ColumnNumber = 1;
            scalarValueCondition4.Enabled = true;
            scalarValueCondition4.ExpectedValue = "2";
            scalarValueCondition4.Name = "scalarValueCondition4";
            scalarValueCondition4.NullExpected = false;
            scalarValueCondition4.ResultSet = 1;
            scalarValueCondition4.RowNumber = 1;
            // 
            // t010_FinishSecondCheckReview_PretestAction
            // 
            resources.ApplyResources(t010_FinishSecondCheckReview_PretestAction, "t010_FinishSecondCheckReview_PretestAction");
            // 
            // t011_FinishThirdCheckReview_TestAction
            // 
            t011_FinishThirdCheckReview_TestAction.Conditions.Add(scalarValueCondition5);
            t011_FinishThirdCheckReview_TestAction.Conditions.Add(scalarValueCondition6);
            resources.ApplyResources(t011_FinishThirdCheckReview_TestAction, "t011_FinishThirdCheckReview_TestAction");
            // 
            // scalarValueCondition5
            // 
            scalarValueCondition5.ColumnNumber = 1;
            scalarValueCondition5.Enabled = true;
            scalarValueCondition5.ExpectedValue = "3";
            scalarValueCondition5.Name = "scalarValueCondition5";
            scalarValueCondition5.NullExpected = false;
            scalarValueCondition5.ResultSet = 1;
            scalarValueCondition5.RowNumber = 1;
            // 
            // scalarValueCondition6
            // 
            scalarValueCondition6.ColumnNumber = 1;
            scalarValueCondition6.Enabled = true;
            scalarValueCondition6.ExpectedValue = "1";
            scalarValueCondition6.Name = "scalarValueCondition6";
            scalarValueCondition6.NullExpected = false;
            scalarValueCondition6.ResultSet = 2;
            scalarValueCondition6.RowNumber = 1;
            // 
            // t011_FinishThirdCheckReview_PretestAction
            // 
            resources.ApplyResources(t011_FinishThirdCheckReview_PretestAction, "t011_FinishThirdCheckReview_PretestAction");
            // 
            // t012_SetRegisterFromCommentsGivenToIncorporation_TestAction
            // 
            t012_SetRegisterFromCommentsGivenToIncorporation_TestAction.Conditions.Add(scalarValueCondition7);
            t012_SetRegisterFromCommentsGivenToIncorporation_TestAction.Conditions.Add(scalarValueCondition8);
            resources.ApplyResources(t012_SetRegisterFromCommentsGivenToIncorporation_TestAction, "t012_SetRegisterFromCommentsGivenToIncorporation_TestAction");
            // 
            // scalarValueCondition7
            // 
            scalarValueCondition7.ColumnNumber = 1;
            scalarValueCondition7.Enabled = true;
            scalarValueCondition7.ExpectedValue = "1";
            scalarValueCondition7.Name = "scalarValueCondition7";
            scalarValueCondition7.NullExpected = false;
            scalarValueCondition7.ResultSet = 1;
            scalarValueCondition7.RowNumber = 1;
            // 
            // scalarValueCondition8
            // 
            scalarValueCondition8.ColumnNumber = 1;
            scalarValueCondition8.Enabled = true;
            scalarValueCondition8.ExpectedValue = "1";
            scalarValueCondition8.Name = "scalarValueCondition8";
            scalarValueCondition8.NullExpected = false;
            scalarValueCondition8.ResultSet = 2;
            scalarValueCondition8.RowNumber = 1;
            // 
            // t012_SetRegisterFromCommentsGivenToIncorporation_PretestAction
            // 
            resources.ApplyResources(t012_SetRegisterFromCommentsGivenToIncorporation_PretestAction, "t012_SetRegisterFromCommentsGivenToIncorporation_PretestAction");
            // 
            // t013_InsertNewDocsForRevision_TestAction
            // 
            t013_InsertNewDocsForRevision_TestAction.Conditions.Add(rowCountCondition6);
            resources.ApplyResources(t013_InsertNewDocsForRevision_TestAction, "t013_InsertNewDocsForRevision_TestAction");
            // 
            // rowCountCondition6
            // 
            rowCountCondition6.Enabled = true;
            rowCountCondition6.Name = "rowCountCondition6";
            rowCountCondition6.ResultSet = 1;
            rowCountCondition6.RowCount = 2;
            // 
            // t013_InsertNewDocsForRevision_PretestAction
            // 
            resources.ApplyResources(t013_InsertNewDocsForRevision_PretestAction, "t013_InsertNewDocsForRevision_PretestAction");
            // 
            // t014_SetNewDocumentsStatusToAccepted_TestAction
            // 
            t014_SetNewDocumentsStatusToAccepted_TestAction.Conditions.Add(rowCountCondition7);
            resources.ApplyResources(t014_SetNewDocumentsStatusToAccepted_TestAction, "t014_SetNewDocumentsStatusToAccepted_TestAction");
            // 
            // rowCountCondition7
            // 
            rowCountCondition7.Enabled = true;
            rowCountCondition7.Name = "rowCountCondition7";
            rowCountCondition7.ResultSet = 1;
            rowCountCondition7.RowCount = 5;
            // 
            // t014_SetNewDocumentsStatusToAccepted_PretestAction
            // 
            resources.ApplyResources(t014_SetNewDocumentsStatusToAccepted_PretestAction, "t014_SetNewDocumentsStatusToAccepted_PretestAction");
            // 
            // t015_CreateRegisterRevision2_TestAction
            // 
            t015_CreateRegisterRevision2_TestAction.Conditions.Add(scalarValueCondition9);
            resources.ApplyResources(t015_CreateRegisterRevision2_TestAction, "t015_CreateRegisterRevision2_TestAction");
            // 
            // scalarValueCondition9
            // 
            scalarValueCondition9.ColumnNumber = 1;
            scalarValueCondition9.Enabled = true;
            scalarValueCondition9.ExpectedValue = "3";
            scalarValueCondition9.Name = "scalarValueCondition9";
            scalarValueCondition9.NullExpected = false;
            scalarValueCondition9.ResultSet = 1;
            scalarValueCondition9.RowNumber = 1;
            // 
            // t015_CreateRegisterRevision2_PretestAction
            // 
            resources.ApplyResources(t015_CreateRegisterRevision2_PretestAction, "t015_CreateRegisterRevision2_PretestAction");
            // 
            // t016_SendRegisterToSecondReview_TestAction
            // 
            t016_SendRegisterToSecondReview_TestAction.Conditions.Add(rowCountCondition8);
            t016_SendRegisterToSecondReview_TestAction.Conditions.Add(rowCountCondition9);
            t016_SendRegisterToSecondReview_TestAction.Conditions.Add(rowCountCondition10);
            resources.ApplyResources(t016_SendRegisterToSecondReview_TestAction, "t016_SendRegisterToSecondReview_TestAction");
            // 
            // rowCountCondition8
            // 
            rowCountCondition8.Enabled = true;
            rowCountCondition8.Name = "rowCountCondition8";
            rowCountCondition8.ResultSet = 1;
            rowCountCondition8.RowCount = 1;
            // 
            // rowCountCondition9
            // 
            rowCountCondition9.Enabled = true;
            rowCountCondition9.Name = "rowCountCondition9";
            rowCountCondition9.ResultSet = 2;
            rowCountCondition9.RowCount = 3;
            // 
            // rowCountCondition10
            // 
            rowCountCondition10.Enabled = true;
            rowCountCondition10.Name = "rowCountCondition10";
            rowCountCondition10.ResultSet = 3;
            rowCountCondition10.RowCount = 0;
            // 
            // t016_SendRegisterToSecondReview_PretestAction
            // 
            resources.ApplyResources(t016_SendRegisterToSecondReview_PretestAction, "t016_SendRegisterToSecondReview_PretestAction");
            // 
            // t017_FirstCheckerAcceptCommentaAndFinishedReview_TestAction
            // 
            t017_FirstCheckerAcceptCommentaAndFinishedReview_TestAction.Conditions.Add(scalarValueCondition10);
            resources.ApplyResources(t017_FirstCheckerAcceptCommentaAndFinishedReview_TestAction, "t017_FirstCheckerAcceptCommentaAndFinishedReview_TestAction");
            // 
            // scalarValueCondition10
            // 
            scalarValueCondition10.ColumnNumber = 1;
            scalarValueCondition10.Enabled = true;
            scalarValueCondition10.ExpectedValue = "1";
            scalarValueCondition10.Name = "scalarValueCondition10";
            scalarValueCondition10.NullExpected = false;
            scalarValueCondition10.ResultSet = 1;
            scalarValueCondition10.RowNumber = 1;
            // 
            // t017_FirstCheckerAcceptCommentaAndFinishedReview_PretestAction
            // 
            resources.ApplyResources(t017_FirstCheckerAcceptCommentaAndFinishedReview_PretestAction, "t017_FirstCheckerAcceptCommentaAndFinishedReview_PretestAction");
            // 
            // t018_SecondCheckerAcceptCommentaAndFinishedReviewData_TestAction
            // 
            t018_SecondCheckerAcceptCommentaAndFinishedReviewData_TestAction.Conditions.Add(scalarValueCondition11);
            resources.ApplyResources(t018_SecondCheckerAcceptCommentaAndFinishedReviewData_TestAction, "t018_SecondCheckerAcceptCommentaAndFinishedReviewData_TestAction");
            // 
            // scalarValueCondition11
            // 
            scalarValueCondition11.ColumnNumber = 1;
            scalarValueCondition11.Enabled = true;
            scalarValueCondition11.ExpectedValue = "2";
            scalarValueCondition11.Name = "scalarValueCondition11";
            scalarValueCondition11.NullExpected = false;
            scalarValueCondition11.ResultSet = 1;
            scalarValueCondition11.RowNumber = 1;
            // 
            // t018_SecondCheckerAcceptCommentaAndFinishedReviewData_PretestAction
            // 
            resources.ApplyResources(t018_SecondCheckerAcceptCommentaAndFinishedReviewData_PretestAction, "t018_SecondCheckerAcceptCommentaAndFinishedReviewData_PretestAction");
            // 
            // t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_TestAction
            // 
            t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_TestAction.Conditions.Add(scalarValueCondition12);
            t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_TestAction.Conditions.Add(scalarValueCondition13);
            resources.ApplyResources(t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_TestAction, "t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_TestAction");
            // 
            // scalarValueCondition12
            // 
            scalarValueCondition12.ColumnNumber = 1;
            scalarValueCondition12.Enabled = true;
            scalarValueCondition12.ExpectedValue = "3";
            scalarValueCondition12.Name = "scalarValueCondition12";
            scalarValueCondition12.NullExpected = false;
            scalarValueCondition12.ResultSet = 1;
            scalarValueCondition12.RowNumber = 1;
            // 
            // scalarValueCondition13
            // 
            scalarValueCondition13.ColumnNumber = 1;
            scalarValueCondition13.Enabled = true;
            scalarValueCondition13.ExpectedValue = "1";
            scalarValueCondition13.Name = "scalarValueCondition13";
            scalarValueCondition13.NullExpected = false;
            scalarValueCondition13.ResultSet = 2;
            scalarValueCondition13.RowNumber = 1;
            // 
            // t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_PretestAction
            // 
            resources.ApplyResources(t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_PretestAction, "t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_PretestAction");
            // 
            // t020_FillCheckListApproveingIncumbent_TestAction
            // 
            t020_FillCheckListApproveingIncumbent_TestAction.Conditions.Add(scalarValueCondition14);
            resources.ApplyResources(t020_FillCheckListApproveingIncumbent_TestAction, "t020_FillCheckListApproveingIncumbent_TestAction");
            // 
            // scalarValueCondition14
            // 
            scalarValueCondition14.ColumnNumber = 1;
            scalarValueCondition14.Enabled = true;
            scalarValueCondition14.ExpectedValue = "2";
            scalarValueCondition14.Name = "scalarValueCondition14";
            scalarValueCondition14.NullExpected = false;
            scalarValueCondition14.ResultSet = 1;
            scalarValueCondition14.RowNumber = 1;
            // 
            // t020_FillCheckListApproveingIncumbent_PretestAction
            // 
            resources.ApplyResources(t020_FillCheckListApproveingIncumbent_PretestAction, "t020_FillCheckListApproveingIncumbent_PretestAction");
            // 
            // t021_InsertCheckItemsFirstApprovement_TestAction
            // 
            t021_InsertCheckItemsFirstApprovement_TestAction.Conditions.Add(scalarValueCondition15);
            resources.ApplyResources(t021_InsertCheckItemsFirstApprovement_TestAction, "t021_InsertCheckItemsFirstApprovement_TestAction");
            // 
            // scalarValueCondition15
            // 
            scalarValueCondition15.ColumnNumber = 1;
            scalarValueCondition15.Enabled = true;
            scalarValueCondition15.ExpectedValue = "8";
            scalarValueCondition15.Name = "scalarValueCondition15";
            scalarValueCondition15.NullExpected = false;
            scalarValueCondition15.ResultSet = 1;
            scalarValueCondition15.RowNumber = 1;
            // 
            // t021_InsertCheckItemsFirstApprovement_PretestAction
            // 
            resources.ApplyResources(t021_InsertCheckItemsFirstApprovement_PretestAction, "t021_InsertCheckItemsFirstApprovement_PretestAction");
            // 
            // t022_FinishFirstCheckApprovement_TestAction
            // 
            t022_FinishFirstCheckApprovement_TestAction.Conditions.Add(rowCountCondition11);
            resources.ApplyResources(t022_FinishFirstCheckApprovement_TestAction, "t022_FinishFirstCheckApprovement_TestAction");
            // 
            // rowCountCondition11
            // 
            rowCountCondition11.Enabled = true;
            rowCountCondition11.Name = "rowCountCondition11";
            rowCountCondition11.ResultSet = 1;
            rowCountCondition11.RowCount = 1;
            // 
            // t022_FinishFirstCheckApprovement_PretestAction
            // 
            resources.ApplyResources(t022_FinishFirstCheckApprovement_PretestAction, "t022_FinishFirstCheckApprovement_PretestAction");
            // 
            // t002_PrepareData_PretestAction
            // 
            resources.ApplyResources(t002_PrepareData_PretestAction, "t002_PrepareData_PretestAction");
            // 
            // t023_FinishSecondCheckApprovement_TestAction
            // 
            t023_FinishSecondCheckApprovement_TestAction.Conditions.Add(scalarValueCondition16);
            t023_FinishSecondCheckApprovement_TestAction.Conditions.Add(scalarValueCondition17);
            resources.ApplyResources(t023_FinishSecondCheckApprovement_TestAction, "t023_FinishSecondCheckApprovement_TestAction");
            // 
            // scalarValueCondition16
            // 
            scalarValueCondition16.ColumnNumber = 1;
            scalarValueCondition16.Enabled = true;
            scalarValueCondition16.ExpectedValue = "2";
            scalarValueCondition16.Name = "scalarValueCondition16";
            scalarValueCondition16.NullExpected = false;
            scalarValueCondition16.ResultSet = 1;
            scalarValueCondition16.RowNumber = 1;
            // 
            // scalarValueCondition17
            // 
            scalarValueCondition17.ColumnNumber = 1;
            scalarValueCondition17.Enabled = true;
            scalarValueCondition17.ExpectedValue = "1";
            scalarValueCondition17.Name = "scalarValueCondition17";
            scalarValueCondition17.NullExpected = false;
            scalarValueCondition17.ResultSet = 2;
            scalarValueCondition17.RowNumber = 1;
            // 
            // t023_FinishSecondCheckApprovement_PretestAction
            // 
            resources.ApplyResources(t023_FinishSecondCheckApprovement_PretestAction, "t023_FinishSecondCheckApprovement_PretestAction");
            // 
            // t024_SetRegisterFromNotAcceptedToCommentsGiven_TestAction
            // 
            t024_SetRegisterFromNotAcceptedToCommentsGiven_TestAction.Conditions.Add(scalarValueCondition18);
            resources.ApplyResources(t024_SetRegisterFromNotAcceptedToCommentsGiven_TestAction, "t024_SetRegisterFromNotAcceptedToCommentsGiven_TestAction");
            // 
            // scalarValueCondition18
            // 
            scalarValueCondition18.ColumnNumber = 1;
            scalarValueCondition18.Enabled = true;
            scalarValueCondition18.ExpectedValue = "1";
            scalarValueCondition18.Name = "scalarValueCondition18";
            scalarValueCondition18.NullExpected = false;
            scalarValueCondition18.ResultSet = 1;
            scalarValueCondition18.RowNumber = 1;
            // 
            // t024_SetRegisterFromNotAcceptedToCommentsGiven_PretestAction
            // 
            resources.ApplyResources(t024_SetRegisterFromNotAcceptedToCommentsGiven_PretestAction, "t024_SetRegisterFromNotAcceptedToCommentsGiven_PretestAction");
            // 
            // t025_InsertNewDocsFor3revision_TestAction
            // 
            t025_InsertNewDocsFor3revision_TestAction.Conditions.Add(rowCountCondition12);
            resources.ApplyResources(t025_InsertNewDocsFor3revision_TestAction, "t025_InsertNewDocsFor3revision_TestAction");
            // 
            // rowCountCondition12
            // 
            rowCountCondition12.Enabled = true;
            rowCountCondition12.Name = "rowCountCondition12";
            rowCountCondition12.ResultSet = 1;
            rowCountCondition12.RowCount = 1;
            // 
            // t025_InsertNewDocsFor3revision_PretestAction
            // 
            resources.ApplyResources(t025_InsertNewDocsFor3revision_PretestAction, "t025_InsertNewDocsFor3revision_PretestAction");
            // 
            // t026_SetNewDocumentStatusToAccepted_TestAction
            // 
            t026_SetNewDocumentStatusToAccepted_TestAction.Conditions.Add(rowCountCondition13);
            resources.ApplyResources(t026_SetNewDocumentStatusToAccepted_TestAction, "t026_SetNewDocumentStatusToAccepted_TestAction");
            // 
            // rowCountCondition13
            // 
            rowCountCondition13.Enabled = true;
            rowCountCondition13.Name = "rowCountCondition13";
            rowCountCondition13.ResultSet = 1;
            rowCountCondition13.RowCount = 6;
            // 
            // t026_SetNewDocumentStatusToAccepted_PretestAction
            // 
            resources.ApplyResources(t026_SetNewDocumentStatusToAccepted_PretestAction, "t026_SetNewDocumentStatusToAccepted_PretestAction");
            // 
            // t027_CreateRegisterRevision3_TestAction
            // 
            t027_CreateRegisterRevision3_TestAction.Conditions.Add(scalarValueCondition19);
            resources.ApplyResources(t027_CreateRegisterRevision3_TestAction, "t027_CreateRegisterRevision3_TestAction");
            // 
            // scalarValueCondition19
            // 
            scalarValueCondition19.ColumnNumber = 1;
            scalarValueCondition19.Enabled = true;
            scalarValueCondition19.ExpectedValue = "3";
            scalarValueCondition19.Name = "scalarValueCondition19";
            scalarValueCondition19.NullExpected = false;
            scalarValueCondition19.ResultSet = 1;
            scalarValueCondition19.RowNumber = 1;
            // 
            // t027_CreateRegisterRevision3_PretestAction
            // 
            resources.ApplyResources(t027_CreateRegisterRevision3_PretestAction, "t027_CreateRegisterRevision3_PretestAction");
            // 
            // t028_SendRegisterToSecondApprovement_TestAction
            // 
            t028_SendRegisterToSecondApprovement_TestAction.Conditions.Add(rowCountCondition14);
            t028_SendRegisterToSecondApprovement_TestAction.Conditions.Add(rowCountCondition15);
            t028_SendRegisterToSecondApprovement_TestAction.Conditions.Add(rowCountCondition16);
            resources.ApplyResources(t028_SendRegisterToSecondApprovement_TestAction, "t028_SendRegisterToSecondApprovement_TestAction");
            // 
            // rowCountCondition14
            // 
            rowCountCondition14.Enabled = true;
            rowCountCondition14.Name = "rowCountCondition14";
            rowCountCondition14.ResultSet = 1;
            rowCountCondition14.RowCount = 1;
            // 
            // rowCountCondition15
            // 
            rowCountCondition15.Enabled = true;
            rowCountCondition15.Name = "rowCountCondition15";
            rowCountCondition15.ResultSet = 2;
            rowCountCondition15.RowCount = 2;
            // 
            // rowCountCondition16
            // 
            rowCountCondition16.Enabled = true;
            rowCountCondition16.Name = "rowCountCondition16";
            rowCountCondition16.ResultSet = 3;
            rowCountCondition16.RowCount = 0;
            // 
            // t028_SendRegisterToSecondApprovement_PretestAction
            // 
            resources.ApplyResources(t028_SendRegisterToSecondApprovement_PretestAction, "t028_SendRegisterToSecondApprovement_PretestAction");
            // 
            // t029_FirstCheckerAcceptCommentAndFinisheApprovement_TestAction
            // 
            t029_FirstCheckerAcceptCommentAndFinisheApprovement_TestAction.Conditions.Add(scalarValueCondition20);
            resources.ApplyResources(t029_FirstCheckerAcceptCommentAndFinisheApprovement_TestAction, "t029_FirstCheckerAcceptCommentAndFinisheApprovement_TestAction");
            // 
            // scalarValueCondition20
            // 
            scalarValueCondition20.ColumnNumber = 1;
            scalarValueCondition20.Enabled = true;
            scalarValueCondition20.ExpectedValue = "4";
            scalarValueCondition20.Name = "scalarValueCondition20";
            scalarValueCondition20.NullExpected = false;
            scalarValueCondition20.ResultSet = 1;
            scalarValueCondition20.RowNumber = 1;
            // 
            // t029_FirstCheckerAcceptCommentAndFinisheApprovement_PretestAction
            // 
            resources.ApplyResources(t029_FirstCheckerAcceptCommentAndFinisheApprovement_PretestAction, "t029_FirstCheckerAcceptCommentAndFinisheApprovement_PretestAction");
            // 
            // t030_SecondCheckerAcceptCommentAndFinishedApprovement_TestAction
            // 
            t030_SecondCheckerAcceptCommentAndFinishedApprovement_TestAction.Conditions.Add(scalarValueCondition21);
            t030_SecondCheckerAcceptCommentAndFinishedApprovement_TestAction.Conditions.Add(scalarValueCondition22);
            resources.ApplyResources(t030_SecondCheckerAcceptCommentAndFinishedApprovement_TestAction, "t030_SecondCheckerAcceptCommentAndFinishedApprovement_TestAction");
            // 
            // scalarValueCondition21
            // 
            scalarValueCondition21.ColumnNumber = 1;
            scalarValueCondition21.Enabled = true;
            scalarValueCondition21.ExpectedValue = "5";
            scalarValueCondition21.Name = "scalarValueCondition21";
            scalarValueCondition21.NullExpected = false;
            scalarValueCondition21.ResultSet = 1;
            scalarValueCondition21.RowNumber = 1;
            // 
            // scalarValueCondition22
            // 
            scalarValueCondition22.ColumnNumber = 1;
            scalarValueCondition22.Enabled = true;
            scalarValueCondition22.ExpectedValue = "1";
            scalarValueCondition22.Name = "scalarValueCondition22";
            scalarValueCondition22.NullExpected = false;
            scalarValueCondition22.ResultSet = 2;
            scalarValueCondition22.RowNumber = 1;
            // 
            // t030_SecondCheckerAcceptCommentAndFinishedApprovement_PretestAction
            // 
            resources.ApplyResources(t030_SecondCheckerAcceptCommentAndFinishedApprovement_PretestAction, "t030_SecondCheckerAcceptCommentAndFinishedApprovement_PretestAction");
            // 
            // t001_CleanUpData
            // 
            this.t001_CleanUpData.PosttestAction = null;
            this.t001_CleanUpData.PretestAction = null;
            this.t001_CleanUpData.TestAction = t001_CleanUp_TestAction;
            // 
            // t002_PrepareDataData
            // 
            this.t002_PrepareDataData.PosttestAction = null;
            this.t002_PrepareDataData.PretestAction = t002_PrepareData_PretestAction;
            this.t002_PrepareDataData.TestAction = t002_PrepareData_TestAction;
            // 
            // t003_CreateDocumentsData
            // 
            this.t003_CreateDocumentsData.PosttestAction = null;
            this.t003_CreateDocumentsData.PretestAction = t003_CreateDocuments_PretestAction;
            this.t003_CreateDocumentsData.TestAction = t003_CreateDocuments_TestAction;
            // 
            // t004_SetDocStatusToAcceptedData
            // 
            this.t004_SetDocStatusToAcceptedData.PosttestAction = null;
            this.t004_SetDocStatusToAcceptedData.PretestAction = t004_SetDocStatusToAccepted_PretestAction;
            this.t004_SetDocStatusToAcceptedData.TestAction = t004_SetDocStatusToAccepted_TestAction;
            // 
            // t005_CreateRegisterDraftData
            // 
            this.t005_CreateRegisterDraftData.PosttestAction = null;
            this.t005_CreateRegisterDraftData.PretestAction = t005_CreateRegisterDraft_PretestAction;
            this.t005_CreateRegisterDraftData.TestAction = t005_CreateRegisterDraft_TestAction;
            // 
            // t006_SetRegisterFromDraftToFirstReviewData
            // 
            this.t006_SetRegisterFromDraftToFirstReviewData.PosttestAction = null;
            this.t006_SetRegisterFromDraftToFirstReviewData.PretestAction = t006_SetRegisterFromDraftToFirstReview_PretestAction;
            this.t006_SetRegisterFromDraftToFirstReviewData.TestAction = t006_SetRegisterFromDraftToFirstReview_TestAction;
            // 
            // t007_FillCheckListRespData
            // 
            this.t007_FillCheckListRespData.PosttestAction = null;
            this.t007_FillCheckListRespData.PretestAction = t007_FillCheckListResp_PretestAction;
            this.t007_FillCheckListRespData.TestAction = t007_FillCheckListResp_TestAction;
            // 
            // t008_InsertCheckItemsFirstReviewData
            // 
            this.t008_InsertCheckItemsFirstReviewData.PosttestAction = null;
            this.t008_InsertCheckItemsFirstReviewData.PretestAction = t008_InsertCheckItemsFirstReview_PretestAction;
            this.t008_InsertCheckItemsFirstReviewData.TestAction = t008_InsertCheckItemsFirstReview_TestAction;
            // 
            // t009_FinishFirstCheckReviewData
            // 
            this.t009_FinishFirstCheckReviewData.PosttestAction = null;
            this.t009_FinishFirstCheckReviewData.PretestAction = t009_FinishFirstCheckReview_PretestAction;
            this.t009_FinishFirstCheckReviewData.TestAction = t009_FinishFirstCheckReview_TestAction;
            // 
            // t010_FinishSecondCheckReviewData
            // 
            this.t010_FinishSecondCheckReviewData.PosttestAction = null;
            this.t010_FinishSecondCheckReviewData.PretestAction = t010_FinishSecondCheckReview_PretestAction;
            this.t010_FinishSecondCheckReviewData.TestAction = t010_FinishSecondCheckReview_TestAction;
            // 
            // t011_FinishThirdCheckReviewData
            // 
            this.t011_FinishThirdCheckReviewData.PosttestAction = null;
            this.t011_FinishThirdCheckReviewData.PretestAction = t011_FinishThirdCheckReview_PretestAction;
            this.t011_FinishThirdCheckReviewData.TestAction = t011_FinishThirdCheckReview_TestAction;
            // 
            // t012_SetRegisterFromCommentsGivenToIncorporationData
            // 
            this.t012_SetRegisterFromCommentsGivenToIncorporationData.PosttestAction = null;
            this.t012_SetRegisterFromCommentsGivenToIncorporationData.PretestAction = t012_SetRegisterFromCommentsGivenToIncorporation_PretestAction;
            this.t012_SetRegisterFromCommentsGivenToIncorporationData.TestAction = t012_SetRegisterFromCommentsGivenToIncorporation_TestAction;
            // 
            // t013_InsertNewDocsForRevisionData
            // 
            this.t013_InsertNewDocsForRevisionData.PosttestAction = null;
            this.t013_InsertNewDocsForRevisionData.PretestAction = t013_InsertNewDocsForRevision_PretestAction;
            this.t013_InsertNewDocsForRevisionData.TestAction = t013_InsertNewDocsForRevision_TestAction;
            // 
            // t014_SetNewDocumentsStatusToAcceptedData
            // 
            this.t014_SetNewDocumentsStatusToAcceptedData.PosttestAction = null;
            this.t014_SetNewDocumentsStatusToAcceptedData.PretestAction = t014_SetNewDocumentsStatusToAccepted_PretestAction;
            this.t014_SetNewDocumentsStatusToAcceptedData.TestAction = t014_SetNewDocumentsStatusToAccepted_TestAction;
            // 
            // t015_CreateRegisterRevision2Data
            // 
            this.t015_CreateRegisterRevision2Data.PosttestAction = null;
            this.t015_CreateRegisterRevision2Data.PretestAction = t015_CreateRegisterRevision2_PretestAction;
            this.t015_CreateRegisterRevision2Data.TestAction = t015_CreateRegisterRevision2_TestAction;
            // 
            // t016_SendRegisterToSecondReviewData
            // 
            this.t016_SendRegisterToSecondReviewData.PosttestAction = null;
            this.t016_SendRegisterToSecondReviewData.PretestAction = t016_SendRegisterToSecondReview_PretestAction;
            this.t016_SendRegisterToSecondReviewData.TestAction = t016_SendRegisterToSecondReview_TestAction;
            // 
            // t017_FirstCheckerAcceptCommentaAndFinishedReviewData
            // 
            this.t017_FirstCheckerAcceptCommentaAndFinishedReviewData.PosttestAction = null;
            this.t017_FirstCheckerAcceptCommentaAndFinishedReviewData.PretestAction = t017_FirstCheckerAcceptCommentaAndFinishedReview_PretestAction;
            this.t017_FirstCheckerAcceptCommentaAndFinishedReviewData.TestAction = t017_FirstCheckerAcceptCommentaAndFinishedReview_TestAction;
            // 
            // t018_SecondCheckerAcceptCommentaAndFinishedReviewDataData
            // 
            this.t018_SecondCheckerAcceptCommentaAndFinishedReviewDataData.PosttestAction = null;
            this.t018_SecondCheckerAcceptCommentaAndFinishedReviewDataData.PretestAction = t018_SecondCheckerAcceptCommentaAndFinishedReviewData_PretestAction;
            this.t018_SecondCheckerAcceptCommentaAndFinishedReviewDataData.TestAction = t018_SecondCheckerAcceptCommentaAndFinishedReviewData_TestAction;
            // 
            // t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataDataData
            // 
            this.t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataDataData.PosttestAction = null;
            this.t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataDataData.PretestAction = t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_PretestAction;
            this.t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataDataData.TestAction = t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData_TestAction;
            // 
            // t020_FillCheckListApproveingIncumbentData
            // 
            this.t020_FillCheckListApproveingIncumbentData.PosttestAction = null;
            this.t020_FillCheckListApproveingIncumbentData.PretestAction = t020_FillCheckListApproveingIncumbent_PretestAction;
            this.t020_FillCheckListApproveingIncumbentData.TestAction = t020_FillCheckListApproveingIncumbent_TestAction;
            // 
            // t021_InsertCheckItemsFirstApprovementData
            // 
            this.t021_InsertCheckItemsFirstApprovementData.PosttestAction = null;
            this.t021_InsertCheckItemsFirstApprovementData.PretestAction = t021_InsertCheckItemsFirstApprovement_PretestAction;
            this.t021_InsertCheckItemsFirstApprovementData.TestAction = t021_InsertCheckItemsFirstApprovement_TestAction;
            // 
            // t022_FinishFirstCheckApprovementData
            // 
            this.t022_FinishFirstCheckApprovementData.PosttestAction = null;
            this.t022_FinishFirstCheckApprovementData.PretestAction = t022_FinishFirstCheckApprovement_PretestAction;
            this.t022_FinishFirstCheckApprovementData.TestAction = t022_FinishFirstCheckApprovement_TestAction;
            // 
            // t023_FinishSecondCheckApprovementData
            // 
            this.t023_FinishSecondCheckApprovementData.PosttestAction = null;
            this.t023_FinishSecondCheckApprovementData.PretestAction = t023_FinishSecondCheckApprovement_PretestAction;
            this.t023_FinishSecondCheckApprovementData.TestAction = t023_FinishSecondCheckApprovement_TestAction;
            // 
            // t024_SetRegisterFromNotAcceptedToCommentsGivenData
            // 
            this.t024_SetRegisterFromNotAcceptedToCommentsGivenData.PosttestAction = null;
            this.t024_SetRegisterFromNotAcceptedToCommentsGivenData.PretestAction = t024_SetRegisterFromNotAcceptedToCommentsGiven_PretestAction;
            this.t024_SetRegisterFromNotAcceptedToCommentsGivenData.TestAction = t024_SetRegisterFromNotAcceptedToCommentsGiven_TestAction;
            // 
            // t025_InsertNewDocsFor3revisionData
            // 
            this.t025_InsertNewDocsFor3revisionData.PosttestAction = null;
            this.t025_InsertNewDocsFor3revisionData.PretestAction = t025_InsertNewDocsFor3revision_PretestAction;
            this.t025_InsertNewDocsFor3revisionData.TestAction = t025_InsertNewDocsFor3revision_TestAction;
            // 
            // t026_SetNewDocumentStatusToAcceptedData
            // 
            this.t026_SetNewDocumentStatusToAcceptedData.PosttestAction = null;
            this.t026_SetNewDocumentStatusToAcceptedData.PretestAction = t026_SetNewDocumentStatusToAccepted_PretestAction;
            this.t026_SetNewDocumentStatusToAcceptedData.TestAction = t026_SetNewDocumentStatusToAccepted_TestAction;
            // 
            // t027_CreateRegisterRevision3Data
            // 
            this.t027_CreateRegisterRevision3Data.PosttestAction = null;
            this.t027_CreateRegisterRevision3Data.PretestAction = t027_CreateRegisterRevision3_PretestAction;
            this.t027_CreateRegisterRevision3Data.TestAction = t027_CreateRegisterRevision3_TestAction;
            // 
            // t028_SendRegisterToSecondApprovementData
            // 
            this.t028_SendRegisterToSecondApprovementData.PosttestAction = null;
            this.t028_SendRegisterToSecondApprovementData.PretestAction = t028_SendRegisterToSecondApprovement_PretestAction;
            this.t028_SendRegisterToSecondApprovementData.TestAction = t028_SendRegisterToSecondApprovement_TestAction;
            // 
            // t029_FirstCheckerAcceptCommentAndFinisheApprovementData
            // 
            this.t029_FirstCheckerAcceptCommentAndFinisheApprovementData.PosttestAction = null;
            this.t029_FirstCheckerAcceptCommentAndFinisheApprovementData.PretestAction = t029_FirstCheckerAcceptCommentAndFinisheApprovement_PretestAction;
            this.t029_FirstCheckerAcceptCommentAndFinisheApprovementData.TestAction = t029_FirstCheckerAcceptCommentAndFinisheApprovement_TestAction;
            // 
            // t030_SecondCheckerAcceptCommentAndFinishedApprovementData
            // 
            this.t030_SecondCheckerAcceptCommentAndFinishedApprovementData.PosttestAction = null;
            this.t030_SecondCheckerAcceptCommentAndFinishedApprovementData.PretestAction = t030_SecondCheckerAcceptCommentAndFinishedApprovement_PretestAction;
            this.t030_SecondCheckerAcceptCommentAndFinishedApprovementData.TestAction = t030_SecondCheckerAcceptCommentAndFinishedApprovement_TestAction;
            // 
            // SystemTestRegister
            // 
            this.TestInitializeAction = testInitializeAction;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion
        [TestMethod()]
        public void t001_CleanUp()
        {
            SqlDatabaseTestActions testActions = this.t001_CleanUpData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t002_PrepareData()
        {
            SqlDatabaseTestActions testActions = this.t002_PrepareDataData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t003_CreateDocuments()
        {
            SqlDatabaseTestActions testActions = this.t003_CreateDocumentsData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t004_SetDocStatusToAccepted()
        {
            SqlDatabaseTestActions testActions = this.t004_SetDocStatusToAcceptedData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t005_CreateRegisterDraft()
        {
            SqlDatabaseTestActions testActions = this.t005_CreateRegisterDraftData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t006_SetRegisterFromDraftToFirstReview()
        {
            SqlDatabaseTestActions testActions = this.t006_SetRegisterFromDraftToFirstReviewData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t007_FillCheckListResp()
        {
            SqlDatabaseTestActions testActions = this.t007_FillCheckListRespData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t008_InsertCheckItemsFirstReview()
        {
            SqlDatabaseTestActions testActions = this.t008_InsertCheckItemsFirstReviewData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t009_FinishFirstCheckReview()
        {
            SqlDatabaseTestActions testActions = this.t009_FinishFirstCheckReviewData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t010_FinishSecondCheckReview()
        {
            SqlDatabaseTestActions testActions = this.t010_FinishSecondCheckReviewData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t011_FinishThirdCheckReview()
        {
            SqlDatabaseTestActions testActions = this.t011_FinishThirdCheckReviewData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t012_SetRegisterFromCommentsGivenToIncorporation()
        {
            SqlDatabaseTestActions testActions = this.t012_SetRegisterFromCommentsGivenToIncorporationData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t013_InsertNewDocsForRevision()
        {
            SqlDatabaseTestActions testActions = this.t013_InsertNewDocsForRevisionData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t014_SetNewDocumentsStatusToAccepted()
        {
            SqlDatabaseTestActions testActions = this.t014_SetNewDocumentsStatusToAcceptedData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t015_CreateRegisterRevision2()
        {
            SqlDatabaseTestActions testActions = this.t015_CreateRegisterRevision2Data;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t016_SendRegisterToSecondReview()
        {
            SqlDatabaseTestActions testActions = this.t016_SendRegisterToSecondReviewData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t017_FirstCheckerAcceptCommentaAndFinishedReview()
        {
            SqlDatabaseTestActions testActions = this.t017_FirstCheckerAcceptCommentaAndFinishedReviewData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t018_SecondCheckerAcceptCommentaAndFinishedReviewData()
        {
            SqlDatabaseTestActions testActions = this.t018_SecondCheckerAcceptCommentaAndFinishedReviewDataData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataData()
        {
            SqlDatabaseTestActions testActions = this.t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataDataData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t020_FillCheckListApproveingIncumbent()
        {
            SqlDatabaseTestActions testActions = this.t020_FillCheckListApproveingIncumbentData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t021_InsertCheckItemsFirstApprovement()
        {
            SqlDatabaseTestActions testActions = this.t021_InsertCheckItemsFirstApprovementData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t022_FinishFirstCheckApprovement()
        {
            SqlDatabaseTestActions testActions = this.t022_FinishFirstCheckApprovementData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t023_FinishSecondCheckApprovement()
        {
            SqlDatabaseTestActions testActions = this.t023_FinishSecondCheckApprovementData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t024_SetRegisterFromNotAcceptedToCommentsGiven()
        {
            SqlDatabaseTestActions testActions = this.t024_SetRegisterFromNotAcceptedToCommentsGivenData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t025_InsertNewDocsFor3revision()
        {
            SqlDatabaseTestActions testActions = this.t025_InsertNewDocsFor3revisionData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t026_SetNewDocumentStatusToAccepted()
        {
            SqlDatabaseTestActions testActions = this.t026_SetNewDocumentStatusToAcceptedData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t027_CreateRegisterRevision3()
        {
            SqlDatabaseTestActions testActions = this.t027_CreateRegisterRevision3Data;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t028_SendRegisterToSecondApprovement()
        {
            SqlDatabaseTestActions testActions = this.t028_SendRegisterToSecondApprovementData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t029_FirstCheckerAcceptCommentAndFinisheApprovement()
        {
            SqlDatabaseTestActions testActions = this.t029_FirstCheckerAcceptCommentAndFinisheApprovementData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void t030_SecondCheckerAcceptCommentAndFinishedApprovement()
        {
            SqlDatabaseTestActions testActions = this.t030_SecondCheckerAcceptCommentAndFinishedApprovementData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }





























        private SqlDatabaseTestActions t001_CleanUpData;
        private SqlDatabaseTestActions t002_PrepareDataData;
        private SqlDatabaseTestActions t003_CreateDocumentsData;
        private SqlDatabaseTestActions t004_SetDocStatusToAcceptedData;
        private SqlDatabaseTestActions t005_CreateRegisterDraftData;
        private SqlDatabaseTestActions t006_SetRegisterFromDraftToFirstReviewData;
        private SqlDatabaseTestActions t007_FillCheckListRespData;
        private SqlDatabaseTestActions t008_InsertCheckItemsFirstReviewData;
        private SqlDatabaseTestActions t009_FinishFirstCheckReviewData;
        private SqlDatabaseTestActions t010_FinishSecondCheckReviewData;
        private SqlDatabaseTestActions t011_FinishThirdCheckReviewData;
        private SqlDatabaseTestActions t012_SetRegisterFromCommentsGivenToIncorporationData;
        private SqlDatabaseTestActions t013_InsertNewDocsForRevisionData;
        private SqlDatabaseTestActions t014_SetNewDocumentsStatusToAcceptedData;
        private SqlDatabaseTestActions t015_CreateRegisterRevision2Data;
        private SqlDatabaseTestActions t016_SendRegisterToSecondReviewData;
        private SqlDatabaseTestActions t017_FirstCheckerAcceptCommentaAndFinishedReviewData;
        private SqlDatabaseTestActions t018_SecondCheckerAcceptCommentaAndFinishedReviewDataData;
        private SqlDatabaseTestActions t019_ThirdCheckerAcceptCommentaAndFinishedReviewDataDataData;
        private SqlDatabaseTestActions t020_FillCheckListApproveingIncumbentData;
        private SqlDatabaseTestActions t021_InsertCheckItemsFirstApprovementData;
        private SqlDatabaseTestActions t022_FinishFirstCheckApprovementData;
        private SqlDatabaseTestActions t023_FinishSecondCheckApprovementData;
        private SqlDatabaseTestActions t024_SetRegisterFromNotAcceptedToCommentsGivenData;
        private SqlDatabaseTestActions t025_InsertNewDocsFor3revisionData;
        private SqlDatabaseTestActions t026_SetNewDocumentStatusToAcceptedData;
        private SqlDatabaseTestActions t027_CreateRegisterRevision3Data;
        private SqlDatabaseTestActions t028_SendRegisterToSecondApprovementData;
        private SqlDatabaseTestActions t029_FirstCheckerAcceptCommentAndFinisheApprovementData;
        private SqlDatabaseTestActions t030_SecondCheckerAcceptCommentAndFinishedApprovementData;
    }
}
