using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
	public class DivisionResult
	{
		public int Quotient { get; set; }
		public int Remainder { get; set; }

		public DivisionResult()
		{
			Quotient = 0;
			Remainder = 0;
		}
	}
}
