using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Extensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// Throws ArgumentOutOfRangeException if parameter is null or whitespace.
		/// </summary>
		/// <param name="parameter"></param>
		/// <param name="parameterName">Parameter name used for exception message.</param>
		public static void ThrowIfParameterIsNullOrWhiteSpace(this string parameter, string parameterName)
		{
			if (string.IsNullOrWhiteSpace(parameter))
			{
				throw new ArgumentOutOfRangeException(parameterName, "Cannot be null or whitespace.");
			}
		}
	}
}
