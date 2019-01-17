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
    public class Architecture : SqlDatabaseTestClass
    {

        public Architecture()
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

        [TestMethod()]
        public void arch_001_TableName()
        {
            SqlDatabaseTestActions testActions = this.arch_001_TableNameData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            // Execute the test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
            SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            // Execute the post-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
            SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
        }
        [TestMethod()]
        public void arch_002_ViewExists()
        {
            SqlDatabaseTestActions testActions = this.arch_002_ViewExistsData;
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
        public void arch_003_PrimaryKeyCheck()
        {
            SqlDatabaseTestActions testActions = this.arch_003_PrimaryKeyCheckData;
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



        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction arch_001_TableName_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Architecture));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition emptyResultSetCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction arch_001_TableName_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction arch_002_ViewExists_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition emptyResultSetCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction arch_002_ViewExists_PosttestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction arch_003_PrimaryKeyCheck_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction arch_003_PrimaryKeyCheck_PosttestAction;
            this.arch_001_TableNameData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.arch_002_ViewExistsData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.arch_003_PrimaryKeyCheckData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            arch_001_TableName_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            emptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition();
            arch_001_TableName_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            arch_002_ViewExists_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            emptyResultSetCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.EmptyResultSetCondition();
            arch_002_ViewExists_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            arch_003_PrimaryKeyCheck_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            arch_003_PrimaryKeyCheck_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // arch_001_TableName_TestAction
            // 
            arch_001_TableName_TestAction.Conditions.Add(emptyResultSetCondition1);
            resources.ApplyResources(arch_001_TableName_TestAction, "arch_001_TableName_TestAction");
            // 
            // emptyResultSetCondition1
            // 
            emptyResultSetCondition1.Enabled = true;
            emptyResultSetCondition1.Name = "emptyResultSetCondition1";
            emptyResultSetCondition1.ResultSet = 1;
            // 
            // arch_001_TableName_PosttestAction
            // 
            resources.ApplyResources(arch_001_TableName_PosttestAction, "arch_001_TableName_PosttestAction");
            // 
            // arch_002_ViewExists_TestAction
            // 
            arch_002_ViewExists_TestAction.Conditions.Add(emptyResultSetCondition2);
            resources.ApplyResources(arch_002_ViewExists_TestAction, "arch_002_ViewExists_TestAction");
            // 
            // emptyResultSetCondition2
            // 
            emptyResultSetCondition2.Enabled = true;
            emptyResultSetCondition2.Name = "emptyResultSetCondition2";
            emptyResultSetCondition2.ResultSet = 1;
            // 
            // arch_002_ViewExists_PosttestAction
            // 
            resources.ApplyResources(arch_002_ViewExists_PosttestAction, "arch_002_ViewExists_PosttestAction");
            // 
            // arch_003_PrimaryKeyCheck_TestAction
            // 
            arch_003_PrimaryKeyCheck_TestAction.Conditions.Add(inconclusiveCondition1);
            resources.ApplyResources(arch_003_PrimaryKeyCheck_TestAction, "arch_003_PrimaryKeyCheck_TestAction");
            // 
            // inconclusiveCondition1
            // 
            inconclusiveCondition1.Enabled = true;
            inconclusiveCondition1.Name = "inconclusiveCondition1";
            // 
            // arch_003_PrimaryKeyCheck_PosttestAction
            // 
            resources.ApplyResources(arch_003_PrimaryKeyCheck_PosttestAction, "arch_003_PrimaryKeyCheck_PosttestAction");
            // 
            // arch_001_TableNameData
            // 
            this.arch_001_TableNameData.PosttestAction = arch_001_TableName_PosttestAction;
            this.arch_001_TableNameData.PretestAction = null;
            this.arch_001_TableNameData.TestAction = arch_001_TableName_TestAction;
            // 
            // arch_002_ViewExistsData
            // 
            this.arch_002_ViewExistsData.PosttestAction = arch_002_ViewExists_PosttestAction;
            this.arch_002_ViewExistsData.PretestAction = null;
            this.arch_002_ViewExistsData.TestAction = arch_002_ViewExists_TestAction;
            // 
            // arch_003_PrimaryKeyCheckData
            // 
            this.arch_003_PrimaryKeyCheckData.PosttestAction = arch_003_PrimaryKeyCheck_PosttestAction;
            this.arch_003_PrimaryKeyCheckData.PretestAction = null;
            this.arch_003_PrimaryKeyCheckData.TestAction = arch_003_PrimaryKeyCheck_TestAction;
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

        private SqlDatabaseTestActions arch_001_TableNameData;
        private SqlDatabaseTestActions arch_002_ViewExistsData;
        private SqlDatabaseTestActions arch_003_PrimaryKeyCheckData;
    }
}
