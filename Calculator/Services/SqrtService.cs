using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
	public class SqrtService : ISqrtService<SqrtOperand, SqrtResult>
	{
		public SqrtResult Operate(SqrtOperand operands)
		{
			SqrtResult result = new SqrtResult();

			result.Square = Math.Round(Math.Sqrt(operands.Number), 4);

			return result;
		}
	}
}
