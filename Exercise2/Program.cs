using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise2
{
	public class Program
	{
		private const string OPERATOR_ADDITION = "+";
		private const string OPERATOR_MULTIPLICATION = "*";
		private const string OPERATOR_DIVISION = "/";
		private const string OPERATOR_SUBSTRACTION = "-";
		private const string OPERATOR_REMAINDER = "%";
		private const string OPERATOR_POW = "^";

		static void Main()
		{
			while (true)
			{
				try
				{
					startingpoint: Console.WriteLine($"\nWrite your operands and operators... And press ENTER\n");

					var input = Console.ReadLine();
					var stringArray = input.ToCharArray();

					var intValuesStack = new Stack<int>();

					foreach (char character in stringArray)
					{
						int digit;
						var c = character.ToString();

						if (string.IsNullOrWhiteSpace(c))
						{
							WriteResult(0); goto startingpoint;
						}

						if (int.TryParse(c, out digit))
						{
							intValuesStack.Push(digit);
						}
						else
						{
							if (!intValuesStack.Any())
								throw new ArgumentException($"Stack is empty, nothing left to pop. Too many operators");

							int rightHandSide = intValuesStack.Pop();

							if (!intValuesStack.Any())
								throw new ArgumentException($"Stack is empty, nothing left to pop. Too many operators");
							int leftHandSide = intValuesStack.Pop();

							switch (c)
							{
								case OPERATOR_ADDITION:
									intValuesStack.Push(leftHandSide + rightHandSide);
									break;
								case OPERATOR_SUBSTRACTION:
									intValuesStack.Push(leftHandSide - rightHandSide);
									break;
								case OPERATOR_DIVISION:
									if (rightHandSide == 0)
									{
										throw new DivideByZeroException();
									}
									intValuesStack.Push(leftHandSide / rightHandSide);
									break;
								case OPERATOR_MULTIPLICATION:
									intValuesStack.Push(leftHandSide * rightHandSide);
									break;
								case OPERATOR_REMAINDER:
									intValuesStack.Push(leftHandSide % rightHandSide);
									break;
								case OPERATOR_POW:
									intValuesStack.Push(leftHandSide ^ rightHandSide);
									break;
								default:
									throw new ArgumentException($"The \"{character}\" is not a known operator by the system");
							}
						}
					}
					int result = intValuesStack.Pop();
					WriteResult(result);
				}
				catch (Exception exc)
				{
					Console.WriteLine($"\nError: {exc.Message}. Starting over...\n");
				}
			}			
		}

		private static void WriteResult(int result)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"\n\tResult is {result}\n");
			Console.ResetColor();
		}
	}
}
