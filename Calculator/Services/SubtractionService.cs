using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
	public class SubtractionService : ISubtractionService<SubtractionOperands, SubtractionResult>
	{
		public SubtractionResult Operate(SubtractionOperands operands)
		{
			SubtractionResult result = new SubtractionResult();

			result.Difference = operands.Minuend - operands.Subtrahend;

			return result;
		}
	}
}
