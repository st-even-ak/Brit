using System.Collections.Generic;
using Brit.Service.Interfaces;

namespace Brit.Service.Core
{
    public class Stack : IStack

    {
        public double CurrentValue { get; private set; }
        
        public Dictionary<string, double> Expressions { get; set; }

        public bool HasException => !Exception.Equals(string.Empty);

        public string Exception { get; set; }

        public void SetCurrentValue(double value)
        {
            CurrentValue = value;
        }

        public void AddExpression(string expression, double result)
        {
            Expressions.Add(expression, result);
        }
    }
}
