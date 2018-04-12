using System;
using ApiService.Controllers;
using Core;
using Core.Correlation;
using ScriptInterpretation;
using Xunit;

namespace ApiService.Tests
{
    public class CorrelationControllerTests
    {
        [Fact]
        public void ControllerReturnsErrorWhenSyntaxErrorInAnalyticFunction()
        {
            var controller = new CorrelationController();
            var request = new CorrelationRequestAnalytic()
            {
                Type = CorrelationType.Kendall,
                Function1 = "x+1",
                Function2 = "*Pow(x) + 1",  //Error here
                LeftBorder = -Math.PI,
                RightBorder = Math.PI,
                PointsCount = 100
            };

            CorrelationResponse response = controller.Post(request);

            Assert.NotEqual(response.Error, null);
        }

        [Fact]
        public void ControllerWorksIdenticallyForAnalyticAndNumericFunctions()
        {
            var controller = new CorrelationController();
            var scriptCompiler = new ScriptCompiler();
            
            string funcDesc1 = "Cos(x)";
            string funcDesc2 = "Sin(x)";

            double leftBorder = -1, rightBorder = 1;
            int pointsCount = 20;

            var function1 = Function.Create(scriptCompiler.GetFunc(funcDesc1), leftBorder, rightBorder, pointsCount);
            var function2 = Function.Create(scriptCompiler.GetFunc(funcDesc2), leftBorder, rightBorder, pointsCount);

            var requestAnalytic = new CorrelationRequestAnalytic()
            {
                Type = CorrelationType.Pearson,
                Function1 = funcDesc1,
                Function2 = funcDesc2,  //Error here
                LeftBorder = leftBorder,
                RightBorder = rightBorder,
                PointsCount = pointsCount
            };

            var requestNumeric = new CorrelationRequestNumeric()
            {
                Type = CorrelationType.Pearson,
                Function1 = function1,
                Function2 = function2
            };

            CorrelationResponse response1 = controller.Post(requestAnalytic);
            CorrelationResponse response2 = controller.Post(requestNumeric);

            Assert.Equal(response1.Value, response2.Value);
        }
    }
}
