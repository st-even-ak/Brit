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
    public class CalcFunctionTest
    {
        private IStack InitialiseMockStack(double seedValue)
        {
            var mockStack = new Stack();

            mockStack.SetCurrentValue(seedValue);
            mockStack.Expressions = new Dictionary<string, double>();

            return mockStack;
        }

        private IFunction InitialisMockFunction<T>() where T : IFunction
        {
            var instance = Activator.CreateInstance<T>() as IFunction;

            instance.ExpressionBuilder = new ExpressionBuilder();

            return instance;
        }

        [Fact]
        public void AddFunctionIncludedInMockStack()
        {
            var function = InitialisMockFunction<AddFunction>();
            var request = InitialiseMockStack(10);

            function.ExecuteFunction(10, request);

            Assert.True(request.Expressions.Count == 1);
            Assert.Equal(@"10+10", request.Expressions.Keys.First());
            Assert.Equal(20, request.Expressions.Values.First());
        }

        [Fact]
        public void SubtractFunctionIncludedInMockStack()
        {
            var function = InitialisMockFunction<SubtractFunction>();
            var request = InitialiseMockStack(30);

            function.ExecuteFunction(10, request);

            Assert.True(request.Expressions.Count == 1);
            Assert.Equal(@"30-10", request.Expressions.Keys.First());
            Assert.Equal(20, request.Expressions.Values.First());
        }

        [Fact]
        public void MultiplyFunctionIncludedInMockStack()
        {
            var function = InitialisMockFunction<MultiplyFunction>();
            var request = InitialiseMockStack(10);

            function.ExecuteFunction(10, request);

            Assert.True(request.Expressions.Count == 1);
            Assert.Equal(@"10*10", request.Expressions.Keys.First());
            Assert.Equal(100, request.Expressions.Values.First());
        }

        [Fact]
        public void DivideFunctionIncludedInMockStack()
        {
            var function = InitialisMockFunction<DivideFunction>();
            var request = InitialiseMockStack(10);

            function.ExecuteFunction(10, request);

            Assert.True(request.Expressions.Count == 1);
            Assert.Equal(@"10/10", request.Expressions.Keys.First());
            Assert.Equal(1, request.Expressions.Values.First());
        }

        [Fact]
        public void PowerFunctionIncludedInMockStack()
        {
            var function = InitialisMockFunction<PowerFunction>();
            var request = InitialiseMockStack(2);

            function.ExecuteFunction(2, request);

            Assert.True(request.Expressions.Count == 1);
            Assert.Equal(@"2^2", request.Expressions.Keys.First());
            Assert.Equal(4, request.Expressions.Values.First());
        }

        [Fact]
        public void RootFunctionIncludedInMockStack()
        {
            var function = InitialisMockFunction<RootFunction>();
            var request = InitialiseMockStack(4);

            function.ExecuteFunction(2, request);

            Assert.True(request.Expressions.Count == 1);
            Assert.Equal("2\u221A4", request.Expressions.Keys.First());
            Assert.Equal(2, request.Expressions.Values.First());
        }

        [Fact]
        public void AddFunctionReturnCorrectResults()
        {
            var function = InitialisMockFunction<AddFunction>();
            var request = InitialiseMockStack(10);

            function.ExecuteFunction(10, request);

            Assert.Equal(20, request.CurrentValue);
        }

        [Fact]
        public void SubtractFunctionReturnCorrectResults()
        {
            var function = InitialisMockFunction<SubtractFunction>();
            var request = InitialiseMockStack(30);

            function.ExecuteFunction(10, request);

            Assert.Equal(20, request.CurrentValue);
        }

        [Fact]
        public void MultiplyFunctionReturnCorrectResults()
        {
            var function = InitialisMockFunction<MultiplyFunction>();
            var request = InitialiseMockStack(10);

            function.ExecuteFunction(10, request);

            Assert.Equal(100, request.CurrentValue);
        }

        [Fact]
        public void DivideFunctionReturnCorrectResults()
        {
            var function = InitialisMockFunction<DivideFunction>();
            var request = InitialiseMockStack(10);

            function.ExecuteFunction(10, request);

            Assert.Equal(1, request.CurrentValue);
        }

        [Fact]
        public void PowerFunctionReturnCorrectResults()
        {
            var function = InitialisMockFunction<PowerFunction>();
            var request = InitialiseMockStack(2);

            function.ExecuteFunction(2, request);

            Assert.Equal(4, request.CurrentValue);
        }

        [Fact]
        public void RootFunctionReturnCorrectResults()
        {
            var function = InitialisMockFunction<RootFunction>();
            var request = InitialiseMockStack(4);

            function.ExecuteFunction(2, request);

            Assert.Equal(2, request.CurrentValue);
        }
    }
}
