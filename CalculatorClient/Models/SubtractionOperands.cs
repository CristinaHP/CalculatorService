using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClient.Models
{
	public class SubtractionOperands
	{
		public int Minuend { get; set; }
		public int Subtrahend { get; set; }

		public SubtractionOperands()
		{
			Minuend = 0;
			Subtrahend = 0;
		}
	}
}
