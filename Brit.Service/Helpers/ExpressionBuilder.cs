using Brit.Service.Interfaces;

namespace Brit.Service.Helpers
{
    public class ExpressionBuilder : IExpressionBuilder
    {
        public string BuildExpression(double initialValue, double appliedValue, string function, string functionIdentifier)
        {
            var result = string.Empty;
            result = functionIdentifier.Substring(0, 1).ToUpper() + functionIdentifier.Substring(1) + (char) 32 +
                     appliedValue;

            if (function.Equals("\u221A"))
            {
                result += $"\t||\t({appliedValue + function + initialValue})";
            }
            else
            {
                result += $"\t||\t({initialValue + function + appliedValue})";
            }

            return result;
        }
    }
}