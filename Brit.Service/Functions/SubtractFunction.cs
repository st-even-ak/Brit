using Brit.Service.Interfaces;

namespace Brit.Service.Functions
{
    public class SubtractFunction : IFunction
    {
        public IExpressionBuilder ExpressionBuilder { get; set; }

        public string FunctionIdentifier => "subtract";

        public string Operand => "-";
    
        public void ExecuteFunction(double value, IStack stack)
        {
            var initialValue = stack.CurrentValue;
            stack.SetCurrentValue(initialValue - value);
            stack.AddExpression(ExpressionBuilder.BuildExpression(initialValue, value, Operand, FunctionIdentifier), stack.CurrentValue);
        }
    }
}
