using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
	public class SqrtOperand
	{
		public int Number { get; set; }

		public SqrtOperand()
		{
			Number = 0;
		}

		public SqrtOperand(int number)
		{
			Number = number;
		}
	}
}
