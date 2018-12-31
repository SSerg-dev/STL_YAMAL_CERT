using System;
using Microsoft.EntityFrameworkCore.Query.Expressions;

namespace SmartQA.DB.Models.Shared
{
    public class M2MAttribute : Attribute
    {
        public Type Left { get; }
        public Type Right { get; }
        public String LeftFKey { get; }
        public String RightFKey { get; }

        public M2MAttribute(Type left, Type right, string leftFKey = null, string rightFKey = null)
        {
            Left = left;
            Right = right;
            LeftFKey = leftFKey ?? $"{Left.Name}_ID";
            RightFKey = rightFKey ?? $"{Right.Name}_ID";            
        }
    }
}