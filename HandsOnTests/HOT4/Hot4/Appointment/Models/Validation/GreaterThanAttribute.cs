﻿using System.ComponentModel.DataAnnotations;

namespace Appointment.Models.Validation
{
	public class GreaterThanAttribute : ValidationAttribute
	{
		private object compareValue;

		public GreaterThanAttribute(object val)
		{
			compareValue = val;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext ctx)
		{
			if (value is int)
			{
				int intToCheck = (int)value;
				int intToCompare = (int)compareValue;

				if (intToCheck > intToCompare)
				{
					return ValidationResult.Success!;
				}
			}
			else if (value is DateTime)
			{
				DateTime dateTimeToCheck = (DateTime)value;
				DateTime dateToCompare = new DateTime();
				DateTime.TryParse(compareValue.ToString(), out dateToCompare);

				if (dateTimeToCheck > dateToCompare)
				{
					return ValidationResult.Success!;
				}
			}
			else if (value is double)
			{
				double doubleToCheck = (double)value;
				double doubleToCompare = (double)compareValue;
				if (doubleToCheck > doubleToCompare)
				{
					return ValidationResult.Success!;
				}
			}

			string msg = base.ErrorMessage ?? $"{ctx.DisplayName} must be greater than {compareValue?.ToString()}";
			return new ValidationResult(msg);
		}

	}
}

