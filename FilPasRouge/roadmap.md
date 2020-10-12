## Feuille de route

1. [Objectif](#Objectif)
2. [Application console](#ApplicationConsole)
2. tet


### <a name="Objectif">Objectif</a>

L'objectif est de réaliser une application console qui va pouvoir accepter plusieurs commandes.

Au fur et à mesure des développements, de nouvelles commandes vont être rajoutées.

### <a name="APplicationConsole">Application console</a>
Réaliser une application console, qui effectue les deux opérations suivantes :
- lors d'un appel sans paramètre, affiche une aide
- lors d'un appel avec le paramètre "Hello", affiche "Hello World !"
- lors d'un appel avec un autre paramètre, affiche "Commande inconnue"

```
> FilPasRouge
Ceci est l'aide

> FilPasRouge Hello
Hello World !

> FilPasRouge GoodBye
Commande inconnue
```
### Opérations Add/Sub/Mul/Div
Maintenant, on va ajouter 4 opérations :
- Add
- Sub
- Mul
- Div
 
Chacune de ces opérations va prendre 2 paramètres, deux nombres flottant et réaliser renvoyer le résultat de la somme, la soustraction, la multiplication et la division

```
> FilPasRouge Add 5 10
15

> FilPasRouge Sub 5 10
-5

> FilPasRouge Mul 5 10
50

> FilPasRouge Div 5 10
0.5
```

### Mise à jour de l'aide
Mettre à jour l'aide afin d'afficher l'ensemble des commandes disponibles.

### Interface IAction

Ajouter des actions ainsi n'est pas simple. Cela nécessite de modifier le programme en plusieurs endroits.

Essayons de changer la conception et d'introduire une interface IAction. Cette interface va définir le contrat à respecter pour ajouter une opération.

Une opération sera simplement une classe implémentant cette interface.

Nous savons qu'une action correspond au moins à 3 choses :
- un nom, celui de la commande qui est appelée ;
- un description, pour l'afficher dans l'aide ;
- une action, qui est exécutée lors l'action est appelée ;
- une action peut avoir des paramètres.

Définissons donc une interface tenant compte de ces différentes contraintes :
```csharp
public interface IAction
{
	string Name {get;}
	string Description {get;}
	void Action(string[] parameters);
}
```

Ensuite, il faudra définir 5 classes, une pour chaque opération, qui implémentent cette interface.

On pourra ensuite définir une liste qui va contenir les différentes opérations disponibles, et qui pourra être utilisée afin de choisir l'opération à effectuer :
```csharp
List<IAction> availableActions = new List<IAction>()
{
   new OperationHello(),
   new OperationAdd(),
   new OperationSub(),
   new OperationMul(),
   new OperationDiv()
}
```

Cette liste pourra être utilisée dans une boucle pour vérifier la présence ou non de l'action demandée.

## (Optionnel) Linq
[Linq](https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries) est un système très puissant pour effectuer des requêtes

Précédemment, nous avons utiliser une boucle pour vérifier si l'action existait ou non.

Nous allons faire la même chose, mais avec une requête linq.

```csharp
IAction action = availableActions.Where(x => x.Name == actionName);
```

On peut également le faire avec une requête de type "SQL" :
```csharp
IAction action = (from a in availableActions 
                  where a.Name == actionName
                  select a).FirstOrDefault();
```

## Un peu de rélexion
Jusqu'à présent, nous avons construit la liste des actions disponibles à la main. Il serait très pratique que l'on puisse établir cette liste de manière automatique.

Quel est le point commun entre les différents actions ? Elles implémentent toutes l'interface IAction !

Y a-t-il un moyen de lister l'ensemble des classes implémentant l'interface IAcion ? Grâce à la refléxivité, la réponse est oui !

En programmation informatique, la réflexion est la capacité d'un programme à examiner, et éventuellement à modifier, ses propres structures internes de haut niveau lors de son exécution.

Voici comment lister l'ensemble des classes implémentant l'interface :
```chsarp
Type actionType = typeof(IAction);
IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(s => s.GetTypes())
    .Where(p => actionType.IsAssignableFrom(p));
IAction[] availableActions = types
    .Select(type => (IAction)Activator.CreateInstance(type))
    .ToArray();
```

Il ne reste plus qu'à mettre cela en place !

## Passons aux tests
Ecrire des tests pour les différentes opérations.

Faire les modifications nécessaires pour rendre les différents éléments du programme testable.

Indication : il se pourrait que l'interface `IServiceProvider` et une surcharge adéquat de `ActivatorUtilities.CreateInstance` aide à la résolution du problème... Il faudrait peut être également importer un paquet Nuget...