using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice04
{
	public class Rectangle : FigureGeometrique
	{
		private float _coteLong;
		private float _coteCourt;

		public Rectangle(float coteLong, float coteCourt)
		{

		}

		public Rectangle(float cote) : this(cote, cote)
		{

		}

		public override string NomForme
		{
			get
			{
				if (_coteCourt == _coteLong)
				{
					return "Carre";
				}
				else
				{
					return "Rectangle";
				}
			}
		}

		public override float Perimetre => throw new NotImplementedException();

		public override float Aire => throw new NotImplementedException();
	}
}
