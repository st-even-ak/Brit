using Brit.Service.Interfaces;

namespace Brit.Service.Functions
{
    public class DivideFunction : IFunction
    {
        public IExpressionBuilder ExpressionBuilder { get; set; }

        public string FunctionIdentifier => "divide";

        public string Operand => "/";
    
        public void ExecuteFunction(double value, IStack stack)
        {
            if (value == 0)
            {
                stack.Exception = @"Divide by Zero error";
            }
            else
            {
                var initialValue = stack.CurrentValue;
                stack.SetCurrentValue(initialValue / value);
                stack.AddExpression(ExpressionBuilder.BuildExpression(initialValue, value, Operand, FunctionIdentifier), stack.CurrentValue);   
            }
        }
    }
}
