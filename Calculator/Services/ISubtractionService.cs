using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Services
{
	public interface ISubtractionService<SubtractionOperands, SubtractionResult>
	{
		SubtractionResult Operate(SubtractionOperands operands);
	}
}
