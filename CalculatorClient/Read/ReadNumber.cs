using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Read
{
	public class ReadNumber
	{
		public static int Read()
		{
			string numberString = string.Empty;
			int numberInt = 0;
			bool wrongType = true;

			do
			{
				try
				{
					wrongType = false;
					numberString = Console.ReadLine();
					numberInt = int.Parse(numberString);
				}
				catch (Exception e)
				{
					wrongType = true;
					Console.WriteLine(e.Message);
				}
			} while (wrongType);

			return numberInt;
		}
	}
}
