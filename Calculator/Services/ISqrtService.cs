using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Services
{
	public interface ISqrtService<SqrtOperand, SqrtResult>
	{
		SqrtResult Operate(SqrtOperand operand);
	}
}
