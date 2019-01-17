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
    public class dboDocument : SqlDatabaseTestClass
    {

        public dboDocument()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_Document_Insert_Positive_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dboDocument));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition emptyResultSetCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_Document_Insert_Positive_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_Document_Insert_Positive_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Prepare_Test_Environment_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Prepare_Test_Environment_PosttestAction;
            this.dbo_Document_Insert_PositiveData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Prepare_Test_EnvironmentData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_Document_Insert_Positive_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            emptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition();
            dbo_Document_Insert_Positive_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_Document_Insert_Positive_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Prepare_Test_Environment_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            Prepare_Test_Environment_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // dbo_Document_Insert_Positive_TestAction
            // 
            dbo_Document_Insert_Positive_TestAction.Conditions.Add(emptyResultSetCondition1);
            resources.ApplyResources(dbo_Document_Insert_Positive_TestAction, "dbo_Document_Insert_Positive_TestAction");
            // 
            // emptyResultSetCondition1
            // 
            emptyResultSetCondition1.Enabled = true;
            emptyResultSetCondition1.Name = "emptyResultSetCondition1";
            emptyResultSetCondition1.ResultSet = 1;
            // 
            // dbo_Document_Insert_Positive_PosttestAction
            // 
            resources.ApplyResources(dbo_Document_Insert_Positive_PosttestAction, "dbo_Document_Insert_Positive_PosttestAction");
            // 
            // dbo_Document_Insert_Positive_PretestAction
            // 
            resources.ApplyResources(dbo_Document_Insert_Positive_PretestAction, "dbo_Document_Insert_Positive_PretestAction");
            // 
            // dbo_Document_Insert_PositiveData
            // 
            this.dbo_Document_Insert_PositiveData.PosttestAction = dbo_Document_Insert_Positive_PosttestAction;
            this.dbo_Document_Insert_PositiveData.PretestAction = dbo_Document_Insert_Positive_PretestAction;
            this.dbo_Document_Insert_PositiveData.TestAction = dbo_Document_Insert_Positive_TestAction;
            // 
            // Prepare_Test_EnvironmentData
            // 
            this.Prepare_Test_EnvironmentData.PosttestAction = Prepare_Test_Environment_PosttestAction;
            this.Prepare_Test_EnvironmentData.PretestAction = null;
            this.Prepare_Test_EnvironmentData.TestAction = Prepare_Test_Environment_TestAction;
            // 
            // Prepare_Test_Environment_TestAction
            // 
            Prepare_Test_Environment_TestAction.Conditions.Add(inconclusiveCondition1);
            resources.ApplyResources(Prepare_Test_Environment_TestAction, "Prepare_Test_Environment_TestAction");
            // 
            // inconclusiveCondition1
            // 
            inconclusiveCondition1.Enabled = true;
            inconclusiveCondition1.Name = "inconclusiveCondition1";
            // 
            // Prepare_Test_Environment_PosttestAction
            // 
            resources.ApplyResources(Prepare_Test_Environment_PosttestAction, "Prepare_Test_Environment_PosttestAction");
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
        public void dbo_Document_Insert_Positive()
        {
            SqlDatabaseTestActions testActions = this.dbo_Document_Insert_PositiveData;
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
        public void Prepare_Test_Environment()
        {
            SqlDatabaseTestActions testActions = this.Prepare_Test_EnvironmentData;
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

        private SqlDatabaseTestActions dbo_Document_Insert_PositiveData;
        private SqlDatabaseTestActions Prepare_Test_EnvironmentData;
    }
}
