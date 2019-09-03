using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise1
{
	public class Program
	{		
		static void Main()
		{
			#region Read the file

			char[] charsToTrim = { '"', '\'' };

			var keyValuePairs = new Dictionary<int, string>();

			var linesFromCsv = ReadLinesFromCsv();

			foreach (var line in linesFromCsv)
			{
				var key = int.Parse(line.Split(',')[0]);
				var value = line.Split(',')[1].Trim(charsToTrim);
				keyValuePairs.Add(key, value);
			}
			#endregion

			#region Print the longest title.


			var longestTitle = keyValuePairs.Values
											.OrderByDescending(x => x.Length)
											.FirstOrDefault();

			Console.WriteLine(longestTitle);
			#endregion

			#region Print for each line the ID and the number word in the titles
			
			foreach (var item in keyValuePairs)
			{
				Console.WriteLine($"ID: {item.Key}, number of words in title: {item.Value.Count()}");
			}
			#endregion


			#region Create a new CSV file with the format ID, "WORD" for all words in the title.
			
			using (StreamWriter sw = new StreamWriter(@"C:\Users\root\source\repos\RAWDATA\Resources\modifiedData.csv"))
			{
				foreach (var item in keyValuePairs)
				{
					// Split the title to string array by whitespaces
					var originalWordsInTitle = item.Value.Split(' ');

					// Create a new string array of the size of the original
					var newWordsInTitle = new string[originalWordsInTitle.Length];

					// Iterate through the array one by one
					for (int i = 0; i < originalWordsInTitle.Length; i++)
					{
						// Get the first word's characters
						var oldChars = originalWordsInTitle[i];

						// Write to the new string array by replacing the word characters with the characters of string "WORD"
						newWordsInTitle[i] = originalWordsInTitle[i].Replace(oldChars, "WORDS");
					}
					
					// Create new line, append ID, new string array and the quotation marks
					var modifiedLine = $"{item.Key},\"{string.Join(" ", newWordsInTitle)}\"";

					// Write the line to the new file
					sw.WriteLine(modifiedLine);
				}
			}
			#endregion

			Console.ReadKey();
		}

		public static IEnumerable<string> ReadLinesFromCsv()
		{
			var line = string.Empty;

			using (StreamReader sr = new StreamReader(@"C:\Users\root\source\repos\RAWDATA\Resources\data.csv"))
			{
				while ((line = sr.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}
	}
}
