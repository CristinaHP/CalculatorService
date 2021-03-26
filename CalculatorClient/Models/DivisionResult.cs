﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClient.Models
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

		public DivisionResult(int quotient, int remainder)
		{
			Quotient = quotient;
			Remainder = remainder;
		}

		public override string ToString()
		{
			return $"Quotient: {Quotient}, Remainder: {Remainder}";
		}
	}
}