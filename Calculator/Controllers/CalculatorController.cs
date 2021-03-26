using Calculator.Models;
using Calculator.MyData;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CalculatorController : Controller
	{
		private readonly IAdditionService<AdditionOperands, AdditionResult> additionService = new AdditionService();
		private readonly ISubtractionService<SubtractionOperands, SubtractionResult> subtractionService = new SubtractionService();
		private readonly IMultiplicationService<MultiplicationOperands, MultiplicationResult> multiplicationService = new MultiplicationService();
		private readonly IDivisionService<DivisionOperands, DivisionResult> divisionService = new DivisionService();
		private readonly ISqrtService<SqrtOperand, SqrtResult> sqrtService = new SqrtService();
		private readonly OperationService operationService = new OperationService();

		[HttpPost("addition")]
		public JsonResult PostAddition([FromBody] AdditionOperands additionOperands)
		{
			AdditionResult result = new AdditionResult();
			string trackingId = Request.Headers[MyStaticData.HEADER_TRACKING_ID];

			result = additionService.Operate(additionOperands); 

			if (trackingId != string.Empty)
			{
				Operation operation = new Operation("Sum", string.Join(" + ", additionOperands.Addends) + " = " + result.Sum, DateTime.Now);
				User user = new User(new TrackingId(trackingId), operation);
				operationService.SaveOperations(user);
			}

			return Json(result);
		}


		[HttpPost("subtraction")]
		public JsonResult PostSubtraction([FromBody] SubtractionOperands subtractionOperands)
		{
			SubtractionResult result = new SubtractionResult();
			string trackingId = Request.Headers[MyStaticData.HEADER_TRACKING_ID];

			result = subtractionService.Operate(subtractionOperands);

			if (trackingId != string.Empty)
			{
				Operation operation = new Operation("Sub", string.Join(" - ", subtractionOperands.Minuend, subtractionOperands.Subtrahend) + " = " + result.Difference, DateTime.Now);
				User user = new User(new TrackingId(trackingId) , operation);
				operationService.SaveOperations(user);
			}

			return Json(result);
		}

		[HttpPost("multiplication")]
		public JsonResult PostMultiplication([FromBody] MultiplicationOperands multiplicationOperands)
		{
			MultiplicationResult result = new MultiplicationResult();
			string trackingId = Request.Headers[MyStaticData.HEADER_TRACKING_ID];

			result = multiplicationService.Operate(multiplicationOperands);

			if (trackingId != string.Empty)
			{
				Operation operation = new Operation("Mul", string.Join(" * ", multiplicationOperands.Factors) + " = " + result.Product, DateTime.Now);
				User user = new User(new TrackingId(trackingId), operation);
				operationService.SaveOperations(user);
			}

			return Json(result);
		}

		[HttpPost("division")]
		public JsonResult PostDivision([FromBody] DivisionOperands divisionOperands)
		{
			DivisionResult result = new DivisionResult();
			string trackingId = Request.Headers[MyStaticData.HEADER_TRACKING_ID];

			result = divisionService.Operate(divisionOperands);

			if (trackingId != string.Empty)
			{
				Operation operation = new Operation("Div", string.Join(" / ", divisionOperands.Dividend, divisionOperands.Divisor) + " = " + result.Quotient + " R= " + result.Remainder, DateTime.Now);
				User user = new User(new TrackingId(trackingId), operation);
				operationService.SaveOperations(user);
			}

			return Json(result);
		}

		[HttpPost("sqrt")]
		public JsonResult PostSqrt([FromBody] SqrtOperand sqrtOperand)
		{
			SqrtResult result = new SqrtResult();
			string trackingId = Request.Headers[MyStaticData.HEADER_TRACKING_ID];

			result = sqrtService.Operate(sqrtOperand);

			if (trackingId != string.Empty)
			{
				Operation operation = new Operation("Sqrt", string.Join("sqrt", sqrtOperand.Number) + " = " + result.Square, DateTime.Now);
				User user = new User(new TrackingId(trackingId), operation);
				operationService.SaveOperations(user);
			}

			return Json(result);
		}

		[HttpPost("query")]
		public JsonResult PostQuery([FromBody] TrackingId id)
		{
			string trackingId = id.Id;
			List<Operation> operationsList = new List<Operation>();

			if (trackingId != string.Empty)
			{
				operationsList = operationService.GetOperationsByTrackingId(trackingId);
			}

			return Json(operationsList);
		}
	}
}
