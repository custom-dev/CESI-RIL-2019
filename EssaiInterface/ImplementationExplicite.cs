using System;
using System.Collections.Generic;
using System.Text;

namespace EssaiInterface
{
	public class ImplementationExplicite : IMonInterface
	{
		void IMonInterface.Display()
		{
			Console.WriteLine("Implémentation explicite");
		}
	}
}
