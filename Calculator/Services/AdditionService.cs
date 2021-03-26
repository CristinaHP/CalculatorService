using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
	public class AdditionService : IAdditionService<AdditionOperands, AdditionResult>
	{
		public AdditionResult Operate(AdditionOperands operands)
		{
			AdditionResult result = new AdditionResult();

			result.Sum = operands.Addends.Sum();

			return result;
		}
	}
}
