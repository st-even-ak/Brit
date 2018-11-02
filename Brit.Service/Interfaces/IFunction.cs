namespace Brit.Service.Interfaces
{
    public interface IFunction
    {
        IExpressionBuilder ExpressionBuilder { get; set; }

        string FunctionIdentifier { get; }

        string Operand { get; }

        void ExecuteFunction(double value, IStack stack);
    }
}