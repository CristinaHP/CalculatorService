using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Services
{
	public interface IDivisionService<DivisionOperands, DivisionResult>
	{
		DivisionResult Operate(DivisionOperands operands);
	}
}
