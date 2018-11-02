using Brit.Service.Interfaces;

namespace Brit.Service.Functions
{
    public class MultiplyFunction : IFunction
    {
        public IExpressionBuilder ExpressionBuilder { get; set; }

        public string FunctionIdentifier => "multiply";

        public string Operand => "*";
    
        public void ExecuteFunction(double value, IStack stack)
        {
            var initialValue = stack.CurrentValue;
            stack.SetCurrentValue(initialValue * value);
            stack.AddExpression(ExpressionBuilder.BuildExpression(initialValue, value, Operand, FunctionIdentifier), stack.CurrentValue);
        }
    }
}
