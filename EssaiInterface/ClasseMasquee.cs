using System;
using System.Collections.Generic;
using System.Text;

namespace EssaiInterface
{
	public class ClasseMasquee : IMonInterface
	{
		public void DisplayInFrench()
		{
			Console.WriteLine("Bonjour !");
		}

		public void DisplayInEnglish()
		{
			Console.WriteLine("Hello !");
		}

		public void DisplayInOok()
		{
			Console.WriteLine("Ook ook ook !");
		}

		void IMonInterface.Display()
		{
			this.DisplayInEnglish();
		}
	}
}
