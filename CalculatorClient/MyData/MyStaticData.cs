using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClient.MyData
{
	/* 
	 * I use this class so that when I want to change, for example, the name of the tracking id
	 * I just have to change it here and not revise all the parts where it's being used
	 */
	public static class MyStaticData
	{
		public const string ADDITION_MENU_OPTION = "1. Addition";
		public const string SUBTRACTION_MENU_OPTION = "2. Subtraction";
		public const string MULTIPLICATION_MENU_OPTION = "3. Multiplication";
		public const string DIVISION_MENU_OPTION = "4. Division";
		public const string SQRT_MENU_OPTION = "5. Square root";
		public const string QUERY_MENU_OPTION = "6. Query of operations";

		public const string READ_OPTION_FROM_KEYBOARD = "Option:";
		public const string READ_NUMBER_FROM_KEYBOARD = "Number:";
		public const string READ_TRACKING_ID_FROM_KEYBOARD = "Tracking ID:";

		public const string ASK_IF_TRACKING_ID = "Do you have tracking ID? (Y/N)";
		public const string ASK_FOR_ANOTHER_NUMBER = "Another number? (Y/N)";

		public const string YES = "Y";
		public const string NO = "N";

		public const string HEADER_TRACKING_ID = "X-Evi-Tracking-Id";

		public const string DISPLAY_ALL_OPERATIONS_STRING = "Operations:";

		public const string MIME_TYPE_JSON = "application/json";

		public const string BASE_API_URL = "https://localhost:44382/api/calculator/";
	}
}
