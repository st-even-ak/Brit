using Brit.Service.Interfaces;
using System;

namespace Brit.Service.Functions
{
    public class RootFunction : IFunction
    {
        public IExpressionBuilder ExpressionBuilder { get; set; }

        public string FunctionIdentifier => "root";

        public string Operand => ((char)0x221A).ToString();
    
        public void ExecuteFunction(double value, IStack stack)
        {
            var initialValue = stack.CurrentValue;
            stack.SetCurrentValue(Math.Pow(stack.CurrentValue, 1/value));
            stack.AddExpression(ExpressionBuilder.BuildExpression(initialValue, value, Operand, FunctionIdentifier), stack.CurrentValue);
        }
    }
}
