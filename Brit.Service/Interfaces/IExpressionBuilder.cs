namespace Brit.Service.Interfaces
{
    public interface IExpressionBuilder
    {
         string BuildExpression(double initialValue, double appliedValue, string function, string functionIdentifier);
    }
}