using System;

namespace Exercice05
{
	/// <summary>
	/// Calcul de mention. Après avoir demandé une note, donner une mention selon les critères
	/// suivants :
	/// - x <= 5 : nul à chier
	/// - 6 <= x <= 9 : passable
	/// - 10 <= x <= 12 : correct
	/// - 13 <= x <= 15 : bien
	/// - 16 <= x <= 19 : très bien
	/// - x = 20 : perfect !
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			// 1) récupérer une saisie utilisateur, et la convertir en entier
			AfficherAvecIf(note);
			AfficherAvecSwitch(note);
		}

		private static void AfficherAvecIf(int note)
		{
			// calculer la mention en n'utilisant que des if
		}

		private static void AfficherAvecSwitch(int note)
		{
			// calculer la mention en utilisant un switch
		}
	}
}
