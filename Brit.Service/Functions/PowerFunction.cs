using Brit.Service.Interfaces;
using System;

namespace Brit.Service.Functions
{
    public class PowerFunction : IFunction
    {
        public IExpressionBuilder ExpressionBuilder { get; set; }

        public string FunctionIdentifier => "power";

        public string Operand => "^";
    
        public void ExecuteFunction(double value, IStack stack)
        {
            var initialValue = stack.CurrentValue;
            stack.SetCurrentValue(Math.Pow(stack.CurrentValue, value));
            stack.AddExpression(ExpressionBuilder.BuildExpression(initialValue, value, Operand, FunctionIdentifier), stack.CurrentValue);
        }
    }
}
