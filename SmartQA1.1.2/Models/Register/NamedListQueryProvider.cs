using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SmartQA1._1._2.Models.Register
{
    public class NamedListQueryProvider : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            Type expressionType = expression.Type.GetElementType();
            try
            {
                return (IQueryable) Activator
                    .CreateInstance(
                        typeof(NamedList<>).MakeGenericType(expressionType), new object[] {this, expression}
                    );
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        public IQueryable<TResult> CreateQuery<TResult>(Expression expression)
        {
            return new NamedList<TResult>(this, expression);
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
            //return _context.Execute(expression, false);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
            //bool IsEnumerable = (typeof(TResult).Name == "IEnumerable`1");
            //return (TResult) _context.Execute(expression, IsEnumerable);
        }
    }
}