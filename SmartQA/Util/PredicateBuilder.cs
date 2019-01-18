using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using SmartQA.DB.Models.PermissionDocuments;

namespace SmartQA.Util
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T> ()  { return f => true;  }
        public static Expression<Func<T, bool>> False<T> () { return f => false; }
 
        public static Expression<Func<T, bool>> Or<T> (this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
            return Expression.Lambda<Func<T, bool>>
                (Expression.OrElse (expr1.Body, invokedExpr), expr1.Parameters);
        }
 
        public static Expression<Func<T, bool>> And<T> (this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
            return Expression.Lambda<Func<T, bool>>
                (Expression.AndAlso (expr1.Body, invokedExpr), expr1.Parameters);
        }

        public class OperationNotSupported : Exception
        {
            public OperationNotSupported(Expression propertyExpr, string operator_, object value)
                : base($"Operation not supported: {propertyExpr} {operator_} {value}")
            {
                
            }
        }

        public static readonly Type[] PropertyTypesSupported = new[]
        {
            typeof(Guid), typeof(string), typeof(int), typeof(long), typeof(bool), typeof(DateTime), typeof(DateTimeOffset)
        };
        
        public static Expression<Func<TParam, bool>> MakePropertyFilterExpr<TParam, TValue>(
            Expression<Func<TParam, TValue>> propertyExpr, string operator_, TValue value
        ) 
        {                        
            Expression expr = null;

            var valueTrueType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);

            if (valueTrueType == typeof(bool) || valueTrueType == typeof(Guid))
            {
                switch (operator_)
                {
                    case "=":
                        expr = Expression.Equal(propertyExpr.Body, Expression.Constant(value));
                        break;

                    case "<>":
                        expr = Expression.NotEqual(propertyExpr.Body, Expression.Constant(value));
                        break;
                }
            }
            else if (valueTrueType == typeof(string))
            {
                switch (operator_)
                {
                    case "=":
                        expr = Expression.Equal(propertyExpr.Body, Expression.Constant(value));
                        break;

                    case "<>":
                        expr = Expression.NotEqual(propertyExpr.Body, Expression.Constant(value));
                        break;

                    case "contains":
                        expr = Expression.Call(propertyExpr.Body,
                            typeof(string).GetMethod("Contains", new[] {typeof(string)}),
                            Expression.Constant(value));
                        break;

                    case "notcontains":
                        expr = Expression.Not(Expression.Call(propertyExpr.Body,
                            typeof(string).GetMethod("Contains", new[] {typeof(string)}),
                            Expression.Constant(value)));
                        break;

                    case "startswith":
                        expr = Expression.Call(propertyExpr.Body,
                            typeof(string).GetMethod("StartsWith", new[] {typeof(string)}),
                            Expression.Constant(value));
                        break;

                    case "endswith":
                        expr = Expression.Call(propertyExpr.Body,
                            typeof(string).GetMethod("EndsWith", new[] {typeof(string)}),
                            Expression.Constant(value));
                        break;
                }
            }
            else if (PropertyTypesSupported.Contains(valueTrueType))
            {
//                object val;                
//                if (Nullable.GetUnderlyingType(propertyExpr.ReturnType) != null
//                    && Nullable.GetUnderlyingType(typeof(TValue)) == null)
//                {                                         
//                    val = Convert.ChangeType(value, typeof(Nullable<>).MakeGenericType(typeof(TValue)));
//                }
//                else
//                {
//                    val = value;
//                }
                
                switch (operator_)
                {
                    case "=":                    
                        expr = Expression.Equal(propertyExpr.Body, Expression.Constant(value, typeof(TValue)));
                        break;                                
                    case "<>":                    
                        expr = Expression.NotEqual(propertyExpr.Body, Expression.Constant(value, typeof(TValue)));
                        break;
                    case ">":                    
                        expr = Expression.GreaterThan(propertyExpr.Body, Expression.Constant(value, typeof(TValue)));
                        break;
                    case "<":                    
                        expr = Expression.LessThan(propertyExpr.Body, Expression.Constant(value, typeof(TValue)));
                        break;
                    case ">=":                    
                        expr = Expression.GreaterThanOrEqual(propertyExpr.Body, Expression.Constant(value, typeof(TValue)));
                        break;
                    case "<=":                    
                        expr = Expression.LessThanOrEqual(propertyExpr.Body, Expression.Constant(value, typeof(TValue)));
                        break;                                 
                }
            }

            if (expr == null)
            {
                throw new OperationNotSupported(propertyExpr, operator_, value);
            }

            return Expression.Lambda<Func<TParam, bool>>(expr, propertyExpr.Parameters);            
        }

        public static Expression<Func<DocumentNaks, bool>> MakePropertyFilterExprTyped(
            Type argType, Type propertyType, Expression propertyExpr,
            string operator_, object value)
        {
            return typeof(PredicateBuilder).GetMethod("MakePropertyFilterExpr").MakeGenericMethod(
                argType, propertyType).Invoke(null, new[] {propertyExpr, operator_, value}) 
                as Expression<Func<DocumentNaks, bool>>;
        }
    }
}