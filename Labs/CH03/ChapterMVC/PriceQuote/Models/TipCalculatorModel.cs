namespace PriceQuotePROJ.Models
{
	public class TipCalculatorModel
	{
		public  double CostOfMeals {  get; set; }
		public  double Percent15Tip { get; set; }
		public double Percent20Tip { get; set; }
		public double Percent25Tip { get; set; }

		public void CalcTip()
		{
			Percent15Tip = (0.15) * CostOfMeals;
			Percent20Tip = (0.20) * CostOfMeals;
			Percent25Tip = (0.25) * CostOfMeals;
		}
	}

	
}
