using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartQA1._1._2.Models.Register
{
    internal class _context<T>
    {
        public static List<T> searchList = new List<T>();
        
        internal static object Execute(Expression expression, bool IsEnumerable)
        {
           if (!IsQueryOverDataSource(expression))
                throw new InvalidProgramException("No query over the data source was specified.");

            //searching for innerMost Queryable.Where call:
            InnerMostWhereOrderByFinder whereFinder = new InnerMostWhereOrderByFinder();
            MethodCallExpression whereExpression = whereFinder.GetWhereExpression(expression);

            //get the predicate from the whole where expression:
            var wherePredicate = (UnaryExpression) (whereExpression.Arguments[1]);

            //get the input Operand of where predicate (field on which we are searching)
            LambdaExpression whereOperand =
                (LambdaExpression) (wherePredicate).Operand;

            //passing predicate method to be parially evaluated:
            whereOperand = (LambdaExpression)Evaluator.PartialEval(wherePredicate);

            //result Where:
            IQueryable<T> resultWhere = searchList.Find(wherePredicate).ToList().AsQueryable();

            Func<T, bool > myFunc = (T) => false;

            IQueryable<T> resultOrderBy = searchList.Where(myFunc).ToList().AsQueryable();

            //replace the datasource:

            // Copy the expression tree that was passed in, changing only the first 
            // argument of the innermost MethodCallExpression.
            ExpressionTreeModifier treeCopier = new ExpressionTreeModifier(queryablePlaces);
            Expression newExpressionTree = treeCopier.Visit(expression);

            // This step creates an IQueryable that executes by replacing Queryable methods with Enumerable methods. 
            if (IsEnumerable)
                return queryablePlaces.Provider.CreateQuery(newExpressionTree);
            else
                return queryablePlaces.Provider.Execute(newExpressionTree);

        }
        private static bool IsQueryOverDataSource(Expression expression)
        {
            // If expression represents an unqueried IQueryable data source instance, 
            // expression is of type ConstantExpression, not MethodCallExpression. 
            return (expression is MethodCallExpression);
        }
    }
}