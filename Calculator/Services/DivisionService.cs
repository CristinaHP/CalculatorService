using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
	public class DivisionService : IDivisionService<DivisionOperands, DivisionResult>
	{
		public DivisionResult Operate(DivisionOperands operands)
		{
			DivisionResult result = new DivisionResult();

			result.Quotient = Math.DivRem(operands.Dividend, operands.Divisor, out int remainder);
			result.Remainder = remainder;

			return result;
		}
	}
}
