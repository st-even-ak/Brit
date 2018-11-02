using System.Collections.Generic;
using Brit.Service.Core;

namespace Brit.Service.Interfaces
{
    public interface ICalculator
    {
        IFileInput FileInput { get; set; }

        IStack Stack { get; set; }

        List<IFunction> FunctionList { get; set; }

        Request<Dictionary<string, double>> Apply(string filePath);

        Request<Dictionary<string, double>> Execute(Request<Dictionary<string, double>> request);
    }
}