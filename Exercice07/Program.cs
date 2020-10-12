using System;

namespace Exercice07
{
	/// <summary>
	/// Jouons avec les énumérations.
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			DayOfWeek[] jours = new DayOfWeek[]
			{ 
				DayOfWeek.Monday, 
				DayOfWeek.Tuesday,
				DayOfWeek.Wednesday,
				DayOfWeek.Thursday,
				DayOfWeek.Friday,
				DayOfWeek.Saturday,
				DayOfWeek.Sunday
			};


			// 1) Utiliser une boucle pour afficher l'ensemble des jours
		}

		private static string ToString(DayOfWeek day)
		{
			// 2) Utiliser un switch pour convertir les jours en chaine de caractères
			//    - Monday = lundi, 
			//    - Tuesday = mardi, 
			//    - etc...
		}
	}
}
