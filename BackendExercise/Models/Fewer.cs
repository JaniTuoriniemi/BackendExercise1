namespace BackendExercise.Models
{
	public class Methods
	{
		
			public static string FewerControll(double temperature)
			{
				string _Isfewer;
				if (temperature < 37)
				{ _Isfewer = "You don´t have fewer!"; }
				else { _Isfewer = "You have fewer!"; }
				return _Isfewer;
			}
		}
	}

