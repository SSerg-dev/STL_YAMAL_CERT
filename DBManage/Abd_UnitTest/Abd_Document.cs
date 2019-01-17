using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abd_UnitTest
{
    [TestClass()]
    public class Abd_Document : SqlDatabaseTestClass
    {

        public Abd_Document()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction abd_Document_DeleteTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abd_Document));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction abd_Document_InsertTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction abd_Document_UpdateTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction abd_Document_InsertTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction testInitializeAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction abd_Document_InsertTest_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction abd_AttributeType_Insert_01_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction abd_AttributeType_Insert_01_PretestAction;
            this.abd_Document_DeleteTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.abd_Document_InsertTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.abd_Document_UpdateTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.abd_AttributeType_Insert_01Data = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            abd_Document_DeleteTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            abd_Document_InsertTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            abd_Document_UpdateTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            abd_Document_InsertTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            testInitializeAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            abd_Document_InsertTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            abd_AttributeType_Insert_01_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            abd_AttributeType_Insert_01_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // abd_Document_DeleteTest_TestAction
            // 
            abd_Document_DeleteTest_TestAction.Conditions.Add(rowCountCondition1);
            resources.ApplyResources(abd_Document_DeleteTest_TestAction, "abd_Document_DeleteTest_TestAction");
            // 
            // rowCountCondition1
            // 
            rowCountCondition1.Enabled = true;
            rowCountCondition1.Name = "rowCountCondition1";
            rowCountCondition1.ResultSet = 1;
            rowCountCondition1.RowCount = 0;
            // 
            // abd_Document_InsertTest_TestAction
            // 
            abd_Document_InsertTest_TestAction.Conditions.Add(inconclusiveCondition2);
            resources.ApplyResources(abd_Document_InsertTest_TestAction, "abd_Document_InsertTest_TestAction");
            // 
            // inconclusiveCondition2
            // 
            inconclusiveCondition2.Enabled = true;
            inconclusiveCondition2.Name = "inconclusiveCondition2";
            // 
            // abd_Document_UpdateTest_TestAction
            // 
            abd_Document_UpdateTest_TestAction.Conditions.Add(inconclusiveCondition3);
            resources.ApplyResources(abd_Document_UpdateTest_TestAction, "abd_Document_UpdateTest_TestAction");
            // 
            // inconclusiveCondition3
            // 
            inconclusiveCondition3.Enabled = true;
            inconclusiveCondition3.Name = "inconclusiveCondition3";
            // 
            // abd_Document_InsertTest_PretestAction
            // 
            resources.ApplyResources(abd_Document_InsertTest_PretestAction, "abd_Document_InsertTest_PretestAction");
            // 
            // testInitializeAction
            // 
            resources.ApplyResources(testInitializeAction, "testInitializeAction");
            // 
            // abd_Document_InsertTest_PosttestAction
            // 
            resources.ApplyResources(abd_Document_InsertTest_PosttestAction, "abd_Document_InsertTest_PosttestAction");
            // 
            // abd_Document_DeleteTestData
            // 
            this.abd_Document_DeleteTestData.PosttestAction = null;
            this.abd_Document_DeleteTestData.PretestAction = null;
            this.abd_Document_DeleteTestData.TestAction = abd_Document_DeleteTest_TestAction;
            // 
            // abd_Document_InsertTestData
            // 
            this.abd_Document_InsertTestData.PosttestAction = abd_Document_InsertTest_PosttestAction;
            this.abd_Document_InsertTestData.PretestAction = abd_Document_InsertTest_PretestAction;
            this.abd_Document_InsertTestData.TestAction = abd_Document_InsertTest_TestAction;
            // 
            // abd_Document_UpdateTestData
            // 
            this.abd_Document_UpdateTestData.PosttestAction = null;
            this.abd_Document_UpdateTestData.PretestAction = null;
            this.abd_Document_UpdateTestData.TestAction = abd_Document_UpdateTest_TestAction;
            // 
            // abd_AttributeType_Insert_01Data
            // 
            this.abd_AttributeType_Insert_01Data.PosttestAction = null;
            this.abd_AttributeType_Insert_01Data.PretestAction = abd_AttributeType_Insert_01_PretestAction;
            this.abd_AttributeType_Insert_01Data.TestAction = abd_AttributeType_Insert_01_TestAction;
            // 
            // abd_AttributeType_Insert_01_TestAction
            // 
            abd_AttributeType_Insert_01_TestAction.Conditions.Add(inconclusiveCondition1);
            resources.ApplyResources(abd_AttributeType_Insert_01_TestAction, "abd_AttributeType_Insert_01_TestAction");
            // 
            // inconclusiveCondition1
            // 
            inconclusiveCondition1.Enabled = true;
            inconclusiveCondition1.Name = "inconclusiveCondition1";
            // 
            // abd_AttributeType_Insert_01_PretestAction
            // 
            resources.ApplyResources(abd_AttributeType_Insert_01_PretestAction, "abd_AttributeType_Insert_01_PretestAction");
            // 
            // Abd_Document
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
        public void abd_Document_DeleteTest()
        {
            SqlDatabaseTestActions testActions = this.abd_Document_DeleteTestData;
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
        public void abd_Document_InsertTest()
        {
            SqlDatabaseTestActions testActions = this.abd_Document_InsertTestData;
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
        public void abd_Document_UpdateTest()
        {
            SqlDatabaseTestActions testActions = this.abd_Document_UpdateTestData;
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
        public void abd_AttributeType_Insert_01()
        {
            SqlDatabaseTestActions testActions = this.abd_AttributeType_Insert_01Data;
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


        private SqlDatabaseTestActions abd_Document_DeleteTestData;
        private SqlDatabaseTestActions abd_Document_InsertTestData;
        private SqlDatabaseTestActions abd_Document_UpdateTestData;
        private SqlDatabaseTestActions abd_AttributeType_Insert_01Data;
    }
}
