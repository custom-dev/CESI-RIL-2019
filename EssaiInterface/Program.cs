using System;

namespace EssaiInterface
{
	class Program
	{
		static void Main(string[] args)
		{
			AvecImplementationImplicite();
			AvecImplementationExplicite();
			AvecMasque();
			AvecChangementTypeRetour();
		}

		private static void AvecImplementationImplicite()
		{
			ImplementationImplicite unObjet = new ImplementationImplicite();
			IMonInterface monInterface = unObjet;
			unObjet.Display();
			monInterface.Display();
		}

		private static void AvecImplementationExplicite()
		{
			ImplementationExplicite unObjet = new ImplementationExplicite();
			IMonInterface monInterface = unObjet;
			//unObjet.Display();
			monInterface.Display();
		}

		private static void AvecMasque()
		{
			ClasseMasquee masquee = new ClasseMasquee();
			IMonInterface monInterface = masquee;

			masquee.DisplayInEnglish();
			masquee.DisplayInFrench();
			masquee.DisplayInOok();
			//masquee.Display();

			monInterface.Display();
		}

		private static void AvecChangementTypeRetour()
		{
			ChangementTypeRetour changementType = new ChangementTypeRetour();
			IMonInterface monInterface = changementType;
			string hello = changementType.Display();

			//hello = monInterface.Display();
		}
	}
}
