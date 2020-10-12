using System;
using System.Collections.Generic;

namespace Exercice04
{
	/// <summary>
	/// Un peu de géométrie, une boucle et du polymorphisme.
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			List<FigureGeometrique> figures = new List<FigureGeometrique>();

			// 1) écrire les 3 classes Rectangle, Cercle et Triangle pour que le code suivant compile
			figures.Add(new Rectangle(10, 5));
			figures.Add(new Cercle(10));
			figures.Add(new Triangle(base: 10, hauteur: 20));

			// 2) utiliser une boucle pour afficher toutes les info de chaque figure
			Console.WriteLine($"{figure.NomForme}: Aire = {figures.Aire}, Périmètre = {figure.Perimetre}");

			// Variante :
			//Console.WriteLine(String.Format("{0} : Aire = {1}, Périmètre = {2}", figure.NomForme, figure.Aire, figure.Perimetre));

			// 3)
			// Vous êtes à l'aise ? Parfait !
			// Rajoutez une classe Carré, qui dérive de Rectangle. Serait-il possible d'appeler le constructeur de rectangle dans le constructeur de carré ?
		}
	}
}
