using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice04
{
	/// <summary>
	/// Classe de base pour vos figures génometiques.
	/// 
	/// Il faudra implémenter le périmètre et l'aire.
	/// </summary>
	public abstract class FigureGeometrique
	{
		public abstract string NomForme { get; }
		public abstract float Perimetre { get; }
		public abstract float Aire { get; }
	}
}
