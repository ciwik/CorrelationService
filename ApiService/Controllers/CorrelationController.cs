using System;
using System.Diagnostics;
using Core;
using Core.Correlation;
using Microsoft.AspNetCore.Mvc;
using ScriptInterpretation;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    public class CorrelationController : Controller
    {
        [Route("analytic")]
        [HttpPost]
        public CorrelationResponse Post([FromBody] CorrelationRequestAnalytic request)
        {
            CorrelationResponse result = new CorrelationResponse();

            var watch = Stopwatch.StartNew();

            try
            {
                var correlationCalculator = CorrelationCalculator.Create(request.Type);
                var scriptCompilator = new ScriptCompilator();

                var function1 = Function.Create(scriptCompilator.GetFunc(request.Function1),
                    request.LeftBorder,
                    request.RightBorder,
                    request.PointsCount);
                var function2 = Function.Create(scriptCompilator.GetFunc(request.Function2),
                    request.LeftBorder,
                    request.RightBorder,
                    request.PointsCount);

                result.Value = correlationCalculator.GetCorrelation(function1, function2);
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }
            finally
            {
                watch.Stop();
                result.ExecutionTime = watch.ElapsedMilliseconds;
            }

            return result;
        }

        [Route("numeric")]
        [HttpPost]
        public CorrelationResponse Post([FromBody] CorrelationRequestNumeric request)
        {
            CorrelationResponse result = new CorrelationResponse();

            var watch = Stopwatch.StartNew();

            try
            {
                var correlationCalculator = CorrelationCalculator.Create(request.Type);
                result.Value = correlationCalculator.GetCorrelation(request.Function1, request.Function2);
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }
            finally
            {
                watch.Stop();
                result.ExecutionTime = watch.ElapsedMilliseconds;
            }

            return result;
        }
    }


}
