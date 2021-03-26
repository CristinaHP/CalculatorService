using Calculator.Read;
using CalculatorClient.Models;
using CalculatorClient.MyData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClient
{
	public class Program
	{
        public const string BASE_URL = MyStaticData.BASE_API_URL;
        public const int EXIT = 0;
        public const int LAST_MENU_OPTION = 6;
        public static string trackingId;
        public static readonly HttpClient client = new HttpClient();

        public static void Main(string[] args)
        {
            trackingId = string.Empty;
            int option;
            bool isTrackingId = false;

            client.DefaultRequestHeaders.Add("Accept", MyStaticData.MIME_TYPE_JSON);

            isTrackingId = AskIfTrackingId();

            if (isTrackingId)
            {
                trackingId = AskTrackingId();
			}
            else
            {
                trackingId = string.Empty;
			}

            client.DefaultRequestHeaders.Add(MyStaticData.HEADER_TRACKING_ID, trackingId);

            do
            {
                ShowMenu();
                option = ChooseOperation();
                EvaluateOption(option);
            } while (option != EXIT);
        }

        private static bool AskIfTrackingId()
        {
            string ifTrackingId = string.Empty;
            bool isTrackingId = false;
            bool askAgain = false;

            do
            {
                Console.WriteLine(MyStaticData.ASK_IF_TRACKING_ID);
                ifTrackingId = Console.ReadLine();

                if (ifTrackingId.Equals(MyStaticData.YES, StringComparison.OrdinalIgnoreCase))
                {
                    isTrackingId = true;
				}
                else if (ifTrackingId.Equals(MyStaticData.NO, StringComparison.OrdinalIgnoreCase))
                {
                    isTrackingId = false;
				}
                else
                {
                    askAgain = true;
				}
            } while (askAgain);

            return isTrackingId;
        }

        private static string AskTrackingId()
        {
            string trackingId = string.Empty;

            Console.WriteLine(MyStaticData.READ_TRACKING_ID_FROM_KEYBOARD);
            trackingId = Console.ReadLine();

            return trackingId;
		}

        private static void ShowMenu()
        {
            Console.WriteLine(MyStaticData.ADDITION_MENU_OPTION);
            Console.WriteLine(MyStaticData.SUBTRACTION_MENU_OPTION);
            Console.WriteLine(MyStaticData.MULTIPLICATION_MENU_OPTION);
            Console.WriteLine(MyStaticData.DIVISION_MENU_OPTION);
            Console.WriteLine(MyStaticData.SQRT_MENU_OPTION);
            Console.WriteLine(MyStaticData.QUERY_MENU_OPTION);
        }

        private static int ChooseOperation()
        {
            string optionString = string.Empty;
            int optionInt = -1;
            bool wrongType = true;

            do
            {
                Console.WriteLine(MyStaticData.READ_OPTION_FROM_KEYBOARD);

                try
                {
                    wrongType = false;
                    optionString = Console.ReadLine();
                    optionInt = int.Parse(optionString);
                }
                catch (Exception e)
                {
                    wrongType = true;
                    Console.WriteLine(e.Message);
                }
            } while (wrongType || (optionInt < EXIT || optionInt > LAST_MENU_OPTION));

            return optionInt;
        }

        private static void EvaluateOption(int option)
        {
            switch (option)
            {
                case 1:
                    {
                        Add();
                        break;
                    }
                case 2:
                    {
                        Subtract();
                        break;
                    }
                case 3:
                    {
                        Multiply();
                        break;
                    }
                case 4:
                    {
                        Divide();
                        break;
                    }
                case 5:
                    {
                        SquareRoot();
                        break;
                    }
                case 6:
                    {
                        Query();
                        break;
                    }
            }
        
        }

        private static List<int> AskForOperands()
        {
            List<int> operandsList = new List<int>();

            // I ask for the first number
            Console.WriteLine(MyStaticData.READ_NUMBER_FROM_KEYBOARD);
            int operand = ReadNumber.Read();
            operandsList.Add(operand);

            // I use a loop so the user can keep submiting numbers in the case of the addition and the multiplication
            do
            {
                Console.WriteLine(MyStaticData.READ_NUMBER_FROM_KEYBOARD);
                operand = ReadNumber.Read();
                operandsList.Add(operand);
                Console.WriteLine(MyStaticData.ASK_FOR_ANOTHER_NUMBER);
            } while (Console.ReadLine().Equals(MyStaticData.YES, StringComparison.OrdinalIgnoreCase));

            return operandsList;
        }

        private static async void Add()
        {
            string url = BASE_URL + "addition";
            AdditionOperands additionOperands = new AdditionOperands();
            HttpContent content;
            HttpResponseMessage response = new HttpResponseMessage();

            additionOperands.Addends = AskForOperands();

            string json = JsonConvert.SerializeObject(additionOperands);
            content = new StringContent(json, Encoding.UTF8, MyStaticData.MIME_TYPE_JSON);

            response = await client.PostAsync(url, content);

            Stream responseStream = await response.Content.ReadAsStreamAsync();
            string streamContent = new StreamReader(responseStream).ReadToEnd();
            AdditionResult resultJson = JsonConvert.DeserializeObject<AdditionResult>(streamContent);

            Console.WriteLine(resultJson.ToString());
		}

        private static async void Subtract()
        {
            string url = BASE_URL + "subtraction";
            SubtractionOperands subtractionOperands = new SubtractionOperands();
            HttpContent content;
            HttpResponseMessage response = new HttpResponseMessage();

            Console.WriteLine(MyStaticData.READ_NUMBER_FROM_KEYBOARD);
            subtractionOperands.Minuend = ReadNumber.Read();
            Console.WriteLine(MyStaticData.READ_NUMBER_FROM_KEYBOARD);
            subtractionOperands.Subtrahend = ReadNumber.Read();

            string json = JsonConvert.SerializeObject(subtractionOperands);
            content = new StringContent(json, Encoding.UTF8, MyStaticData.MIME_TYPE_JSON);
            
            response = await client.PostAsync(url, content);

            Stream responseStream = await response.Content.ReadAsStreamAsync();
            string streamContent = new StreamReader(responseStream).ReadToEnd();
            SubtractionResult resultJson = JsonConvert.DeserializeObject<SubtractionResult>(streamContent);

            Console.WriteLine(resultJson.ToString());
        }

        private static async void Multiply()
        {
            string url = BASE_URL + "multiplication";
            MultiplicationOperands multiplicationOperands = new MultiplicationOperands();
            HttpContent content;
            HttpResponseMessage response = new HttpResponseMessage();

            multiplicationOperands.Factors = AskForOperands();

            string json = JsonConvert.SerializeObject(multiplicationOperands);
            content = new StringContent(json, Encoding.UTF8, MyStaticData.MIME_TYPE_JSON);

            response = await client.PostAsync(url, content);

            Stream responseStream = await response.Content.ReadAsStreamAsync();
            string streamContent = new StreamReader(responseStream).ReadToEnd();
            MultiplicationResult resultJson = JsonConvert.DeserializeObject<MultiplicationResult>(streamContent);

            Console.WriteLine(resultJson.ToString());
        }

        private static async void Divide()
        {
            string url = BASE_URL + "division";
            DivisionOperands divisionOperands = new DivisionOperands();
            HttpContent content;
            HttpResponseMessage response = new HttpResponseMessage();

            Console.WriteLine(MyStaticData.READ_NUMBER_FROM_KEYBOARD);
            divisionOperands.Dividend = ReadNumber.Read();
            Console.WriteLine(MyStaticData.READ_NUMBER_FROM_KEYBOARD);
            divisionOperands.Divisor = ReadNumber.Read();

            string json = JsonConvert.SerializeObject(divisionOperands);
            content = new StringContent(json, Encoding.UTF8, MyStaticData.MIME_TYPE_JSON);

            response = await client.PostAsync(url, content);

            Stream responseStream = await response.Content.ReadAsStreamAsync();
            string streamContent = new StreamReader(responseStream).ReadToEnd();
            DivisionResult resultJson = JsonConvert.DeserializeObject<DivisionResult>(streamContent);

            Console.WriteLine(resultJson.ToString());
        }

        private static async void SquareRoot()
        {
            string url = BASE_URL + "sqrt";
            SqrtOperand sqrtOperand = new SqrtOperand();
            HttpContent content;
            HttpResponseMessage response = new HttpResponseMessage();

            Console.WriteLine(MyStaticData.READ_NUMBER_FROM_KEYBOARD);
            sqrtOperand.Number = ReadNumber.Read();

            string json = JsonConvert.SerializeObject(sqrtOperand);
            content = new StringContent(json, Encoding.UTF8, MyStaticData.MIME_TYPE_JSON);

            response = await client.PostAsync(url, content);

            Stream responseStream = await response.Content.ReadAsStreamAsync();
            string streamContent = new StreamReader(responseStream).ReadToEnd();
            SqrtResult resultJson = JsonConvert.DeserializeObject<SqrtResult>(streamContent);

            Console.WriteLine(resultJson.ToString());
        }

        private static async void Query()
        {
            string url = BASE_URL + "query";
            List<Operation> operationsList = new List<Operation>();
            TrackingId id = new TrackingId(trackingId);
            HttpContent content;
            HttpResponseMessage response = new HttpResponseMessage();

            string json = JsonConvert.SerializeObject(id);
            content = new StringContent(json, Encoding.UTF8, MyStaticData.MIME_TYPE_JSON);

            response = await client.PostAsync(url, content);

            Stream responseStream = await response.Content.ReadAsStreamAsync();
            string streamContent = new StreamReader(responseStream).ReadToEnd();
            List<Operation> resultJson = JsonConvert.DeserializeObject<List<Operation>>(streamContent);

            Console.WriteLine(MyStaticData.DISPLAY_ALL_OPERATIONS_STRING);
            resultJson.ForEach(x => Console.WriteLine(x));
        }
	}
}
