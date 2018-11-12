using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SmartQA1._1._2.Models.Register
{
    public class InnerMostWhereOrderByFinder : ExpressionVisitor
    {
        private MethodCallExpression targetExpression;

        private string nameMethod = null;

        public MethodCallExpression GetWhereExpression(Expression expression)
        {
            nameMethod = "Where";
            Visit(expression);
            return targetExpression;
        }

        public MethodCallExpression GetOrderByExpression(Expression expression)
        {
            nameMethod = "OrderBy";
            Visit(expression);
            return targetExpression;
        }

        protected override Expression VisitMethodCall(MethodCallExpression expression)
        {
            if (expression.Method.Name == nameMethod)
                targetExpression = expression;
            Visit(expression.Arguments[0]); 

            return expression;
        }
    }
}