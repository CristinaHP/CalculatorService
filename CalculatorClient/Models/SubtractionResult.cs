﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorClient.Models
{
	public class SubtractionResult
	{
		public int Difference { get; set; }

		public SubtractionResult()
		{
			Difference = 0;
		}

		public override string ToString()
		{
			return $"Difference: {Difference}";
		}
	}
}
