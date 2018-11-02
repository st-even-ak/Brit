using System.Collections.Generic;

namespace Brit.Service.Interfaces
{
    public interface IStack
    {
        double CurrentValue { get; }
        
        Dictionary<string, double> Expressions { get; set; }

        bool HasException { get; }

        string Exception { get; set; }

        void SetCurrentValue(double value);

        void AddExpression(string expression, double result);
    }
}