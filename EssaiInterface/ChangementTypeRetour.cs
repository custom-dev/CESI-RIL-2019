using System;
using System.Collections.Generic;
using System.Text;

namespace EssaiInterface
{
	public class ChangementTypeRetour : IMonInterface
	{
		public string Display()
		{
			string hello = "Hello World !";
			Console.WriteLine(hello);
			return hello;
		}
		void IMonInterface.Display()
		{
			this.Display();
		}
	}
}
