## Feuille de route

1. [Objectif](#Objectif)
2. [Application console](#ApplicationConsole)
3. [Opérations](#Operations)


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
### <a name="Operations">Opérations</a> Add/Sub/Mul/Div
Maintenant, on va ajouter 4 opérations :
- Add
- Sub
- Mul
- Div
 
Chacune de ces opérations va prendre 2 paramètres, deux nombres flottants et renvoyer le résultat de la somme, la soustraction, la multiplication et la division

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

## VDM
Aujourd'hui, notre intervenant nous a demandé d'extraire les dernières publication du site viedemerde.fr. VDM.

L'objectif ici, va être multiple :
- utiliser le gestionnaire de paquet NuGet pour installer HtmlUtilityPack
- utiliser `WebClient` pour envoyer une requête et recevoir la réponse HTML du serveur
- parser la réponse du serveur pour en extraire les informations utiles.
- voir la sérialisation/désérialisation

Les informations a récupérer par VDM sont les suivantes :
- son contenu
- son auteur
- son titre
- le nombre de "Je valide"
- le nombre de "Tu l'as bien mérité".

3 actions à faire :
- "ShowVDM", qui affiche dans la console les VDM
- "WriteVDM", qui enregistre dans un fichier les vies de merde
- "ReadVDM", qui lit un fichier et affiche dans la console le contenu des VDM du fichier.


A noter qu'il n'existe pas d'API pour accéder aux différentes VDM (en fait, elles n'existent plus ! En cherchant vous pouvez trouver des références, mais les API ne sont pas fonctionnelles).

L'objctif est donc bien de récupérer le code HTML de la page principale et de le parser pour en extraire les informations.
## Calcul de hash

Ajouter les actions suivantes :
- calcul du MD5
- calcul du SHA1
- calcul du SHA256

Afficher le hash en hexadécimal.

Indice : voici des classes qui pourront vous aider :
- System.Security.Cryptography.MD5
- System.Security.Cryptography.SHA1
- System.Security.Cryptography.SHA256


## (Dé)cryptons
Passons au chiffrement. Il existe deux grands types de chiffrement :
- le chiffrement symmetrique
- le chiffrement asymmetrique.

Le chiffrement symmétrique est le plus utilisé.

En réalité, même lorsque le chiffrement asymétrique est utilisé, du chiffrement symmétrique est utilisé (pour des raisons notamment de performances). Le chiffrement asymétrique sert à l'échange d'une clé symmétrique, et c'est ensuite cette clé symmétrique qui est utilisée pour chiffrer/déchiffrer les données.

Commençons donc par du chiffrement symmetrique.

Pour cela, nous allons mettre en place 3 nouvelles actions :
- "GenKey" : pour générer une clé de chiffrement. La clé de chiffrement sera sauvegardé dans un fichier
- "Encrypt" : chiffre un fichier. Prend en paramètre la clé de chiffrement, puis le fichier à chiffrer. Génère un fichier du même nom, suffixé par .encrypted qui est chiffré
- "Decrypt" : déchiffre un fichier .encrypted. Génère un fichier du même nom, suffixé par .decrypted dont le contenu est déchiffré.

## (Optionnel) (Dé)cryptions
Pour les plus rapides, faire la même chose, mais avec un algorithme asymétrique.

Pour se faire, 3 actions encore à générer :
- "GenKeyRsa" : génère 2 clés de chiffrement, une publique, et une privée. Les deux seront stockée dans des fichiers à part. La clé publique sera dans un fichier .pub, la clé privé dans un fichier .key
- "EncryptRsa" : Chiffre un fichier en utilisant la clé privée
- "DecryptRsa" : Déchiffre un fichier en utilisant la clé publique. 

## (Optionnale) Générer une signature
A faire seulement si le chiffrement en utilisant un algorithme asymétrique a été fait.

Que pourrait-on mettre en place pour mettre en place un système de signature d'un fichier ? Appelez moi quand vous avez une idée (avant de le mettre en place), puis une fois que c'est fait :)


## Client / Serveur

On va mettre en place un socket 
Mise en place des évènements. Création, écoute, utilisation.


Ajouter une commande "Serveur" et une autre "Client".

La commande "Serveur" se met en attente de la connextion d'un client.

Quand un client est connecté, le serveur peut recevoir des messages.

Quand un message est reçu, il est transmis à l'ensemble des clients connectés.

Le serveur peut également envoyer des messages à l'intégralité des clients.

## Sérialisation / Désérialisation