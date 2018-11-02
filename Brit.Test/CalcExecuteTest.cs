using System;
using System.Collections.Generic;
using System.Linq;
using Brit.Service.Core;
using Brit.Service.Functions;
using Brit.Service.Helpers;
using Brit.Service.Interfaces;
using Xunit;

namespace Brit.Test
{
    public class CalcExecuteTest
    {
        private ICalculator InitialiseMockCalculator(double seedValue)
        {
            var calculator = new Calculator {FunctionList = new List<IFunction>()};
            calculator.Stack = InitialiseMockStack(seedValue);

            calculator.FunctionList.Add(InitialiseMockFunction<AddFunction>());
            calculator.FunctionList.Add(InitialiseMockFunction<SubtractFunction>());
            calculator.FunctionList.Add(InitialiseMockFunction<MultiplyFunction>());
            calculator.FunctionList.Add(InitialiseMockFunction<DivideFunction>());
            calculator.FunctionList.Add(InitialiseMockFunction<PowerFunction>());
            calculator.FunctionList.Add(InitialiseMockFunction<RootFunction>());

            return calculator;
        }

        private IFunction InitialiseMockFunction<T>() where T : IFunction
        {
            var function = Activator.CreateInstance<T>() as IFunction;
            function.ExpressionBuilder = new ExpressionBuilder();

            return function;
        }
        private IStack InitialiseMockStack(double seedValue)
        {
            var mockStack = new Stack();

            mockStack.SetCurrentValue(seedValue);
            mockStack.Expressions = new Dictionary<string, double>();

            return mockStack;
        }
        
        private Request<Dictionary<string, double>> InitialiseMockRequest(List<string> functions)
        {
            var request = new Request<Dictionary<string, double>>();
            request.CalcFunctions = functions;

            return request;
        }

        [Fact]
        public void ExecuteSingleAdd()
        {
            var calculator = InitialiseMockCalculator(10);
            var request = InitialiseMockRequest(new List<string>() {"add 10"});

            calculator.Execute(request);

            Assert.Equal(20, calculator.Stack.CurrentValue);
            Assert.True(calculator.Stack.Expressions.Count == 1);
            Assert.True(calculator.Stack.Expressions.Last().Key == "10+10");
            Assert.True(calculator.Stack.Expressions.Last().Value == calculator.Stack.CurrentValue);
        }

        [Fact]
        public void ExecuteSingleSubtract()
        {
            var calculator = InitialiseMockCalculator(10);
            var request = InitialiseMockRequest(new List<string>() { "subtract 5" });

            calculator.Execute(request);

            Assert.Equal(5, calculator.Stack.CurrentValue);
            Assert.True(calculator.Stack.Expressions.Count == 1);
            Assert.True(calculator.Stack.Expressions.Last().Key == "10-5");
            Assert.True(calculator.Stack.Expressions.Last().Value == calculator.Stack.CurrentValue);
        }

        [Fact]
        public void ExecuteSingleMultiply()
        {
            var calculator = InitialiseMockCalculator(10);
            var request = InitialiseMockRequest(new List<string>() { "multiply 10" });

            calculator.Execute(request);

            Assert.Equal(100, calculator.Stack.CurrentValue);
            Assert.True(calculator.Stack.Expressions.Count == 1);
            Assert.True(calculator.Stack.Expressions.Last().Key == "10*10");
            Assert.True(calculator.Stack.Expressions.Last().Value == calculator.Stack.CurrentValue);
        }

        [Fact]
        public void ExecuteSingleDivide()
        {
            var calculator = InitialiseMockCalculator(10);
            var request = InitialiseMockRequest(new List<string>() { "divide 10" });

            calculator.Execute(request);

            Assert.Equal(1, calculator.Stack.CurrentValue);
            Assert.True(calculator.Stack.Expressions.Count == 1);
            Assert.True(calculator.Stack.Expressions.Last().Key == "10/10");
            Assert.True(calculator.Stack.Expressions.Last().Value == calculator.Stack.CurrentValue);
        }

        [Fact]
        public void ExecuteSinglePower()
        {
            var calculator = InitialiseMockCalculator(10);
            var request = InitialiseMockRequest(new List<string>() { "power 2" });

            calculator.Execute(request);

            Assert.Equal(100, calculator.Stack.CurrentValue);
            Assert.True(calculator.Stack.Expressions.Count == 1);
            Assert.True(calculator.Stack.Expressions.Last().Key == "10^2");
            Assert.True(calculator.Stack.Expressions.Last().Value == calculator.Stack.CurrentValue);
        }

        [Fact]
        public void ExecuteSingleRoot()
        {
            var calculator = InitialiseMockCalculator(1000);
            var request = InitialiseMockRequest(new List<string>() { "root 3" });

            calculator.Execute(request);

            Assert.Equal(10, calculator.Stack.CurrentValue, 1);
            Assert.True(calculator.Stack.Expressions.Count == 1);
            Assert.True(calculator.Stack.Expressions.Last().Key == $"3{(char)0x221A}1000");
            Assert.True(calculator.Stack.Expressions.Last().Value == calculator.Stack.CurrentValue);
        }


        [Fact]
        public void ExecuteAddMultiplyDivide()
        {
            var calculator = InitialiseMockCalculator(10);
            var request = InitialiseMockRequest(new List<string>() { "add 10", "multiply 5", "divide 3" });

            calculator.Execute(request);

            Assert.Equal(33.3333333333333, calculator.Stack.CurrentValue, 1);
            Assert.True(calculator.Stack.Expressions.Count == 3);
            Assert.True(calculator.Stack.Expressions.Last().Value == calculator.Stack.CurrentValue);
        }

        [Fact]
        public void ExecuteAddMultiplyDivideMissingValueOnMultiple()
        {
            var calculator = InitialiseMockCalculator(10);
            var request = InitialiseMockRequest(new List<string>() { "add 10", "multiply", "divide 3" });

            calculator.Execute(request);

            Assert.Equal(20, calculator.Stack.CurrentValue);
            Assert.True(calculator.Stack.Expressions.Count == 1);
            Assert.True(calculator.Stack.Expressions.Last().Value == calculator.Stack.CurrentValue);
        }

        [Fact]
        public void ExecuteDivideByZero()
        {
            var calculator = InitialiseMockCalculator(10);
            var request = InitialiseMockRequest(new List<string>() { "divide 0" });

            calculator.Execute(request);
            
            Assert.True(calculator.Stack.Expressions.Count == 0);
            Assert.True(calculator.Stack.Exception == @"Divide by Zero error");
        }

        [Fact]
        public void ExecutePowerAddMultiplyDivideMissingValueOnMultiple()
        {
            var calculator = InitialiseMockCalculator(10);
            var request = InitialiseMockRequest(new List<string>() { "power 2", "add 10", "multiply", "divide 3" });

            calculator.Execute(request);

            Assert.Equal(110, calculator.Stack.CurrentValue);
            Assert.True(calculator.Stack.Expressions.Count == 2);
            Assert.True(calculator.Stack.Expressions.Last().Value == calculator.Stack.CurrentValue);
            Assert.True(request.Exception == @"Divide by Zero error");
        }
    }
}
