using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
	public class MultiplicationService : IMultiplicationService<MultiplicationOperands, MultiplicationResult>
	{
		public MultiplicationResult Operate(MultiplicationOperands operands)
		{
			MultiplicationResult result = new MultiplicationResult();
			int accumulator = operands.Factors[0];

			for (int i = 1; i < operands.Factors.Count; i++)
			{
				accumulator *= operands.Factors[i];
			}

			result.Product = accumulator;

			return result;
		}
	}
}
