using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brit.Service.Functions;
using Brit.Service.Interfaces;

namespace Brit.Service.Core
{
    public class Calculator : ICalculator
    {
        public IFileInput FileInput { get; set; }
         
        public IStack Stack { get; set; }

        public List<IFunction> FunctionList { get; set; }

        public Request<Dictionary<string, double>> Apply(string filePath)
        {
            var request = new Request<Dictionary<string, double>>();//"Request");

            var fileInput = FileInput.ReadFile(filePath);

            // if the input file raised exceptions exit
            if (fileInput.HasException)
            {
                return request;
            }

            // check file contains seed value (Apply)
            if (!fileInput.CalcFunctions.Any(x => x.ToLower().Contains("apply")))
            {
                request.Exception = @"No seed value provided, review the file and include 'Apply' statement";
                return request;
            }

            // check the Apply value is present
            if (!fileInput.CalcFunctions.Any(x => x.ToLower().Contains("apply") && x.Split((char) 32).Length == 2))
            {
                request.Exception = @"Invalid 'Apply' statement, no value supplied";
                return request;
            }

            // check the supplied seed value is numeric
            if (!double.TryParse(fileInput.CalcFunctions.First(x => x.ToLower().Contains("apply")).Split((char) 32)[1],
                                 out var seedValue))
            {
                request.Exception = @"Invalid 'Apply' statement, value supplied is non numeric";
                return request;
            }

            // load function list into calcRequest, fail if only 'Apply' statement present
            if (fileInput.CalcFunctions
                         .GetRange(0, fileInput.CalcFunctions.FindIndex(x => x.ToLower().Contains("apply")))
                         .Count.Equals(0))
            {
                request.Exception = @"No functions included, before the 'Apply' statement";
                return request;
            }

            // check 

            // all checks out, continue - load function list
            request.CalcFunctions =
                fileInput.CalcFunctions.GetRange(0,
                                                 fileInput.CalcFunctions.FindIndex(x => x.ToLower().Contains("apply")));

            //set the seed value for the stack, and add the initial descriptor for the expressions list
            Stack.SetCurrentValue(seedValue);
            Stack.AddExpression(@"Initial Value", seedValue);

            return Execute(request);
        }

        public Request<Dictionary<string, double>> Execute(Request<Dictionary<string, double>> request) { 

            foreach (var functionTxt in request.CalcFunctions)
            {
                var functionItems = functionTxt.Split((char)32);

                if (functionItems.Length != 2)
                {
                    request.Exception = @"Function string is empty or contain an incorrect number of elements";
                    return request;
                }

                var function =
                    FunctionList.FirstOrDefault(x => x.FunctionIdentifier.ToLower().Equals(functionItems[0].ToLower()));

                if (function == null)
                {
                    request.Exception = $"The function '{functionItems[0]}', is not available in this tool";
                    return request;
                }

                if (!double.TryParse(functionItems[1], out var functionValue))
                {
                    request.Exception = $"The value '{functionItems[1]}', cannot be converted to a number";
                    return request;
                }

                // we come this far do the calculation
                function.ExecuteFunction(functionValue, Stack);
            }

            request.SetResult(Stack.Expressions);

            return request;
        }
    }
}
