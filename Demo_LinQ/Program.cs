using Demo_LinQ.Extensions;
using Demo_LinQ.Models;

List<Student> students = [
    new Student(1, "Zaza", "Vanderquack", 75),
    new Student(2, "Lena", "Sabrewing", 85),
    new Student(3, "Riri", "Duck", 55),
    new Student(4, "Fifi", "Duck", 80),
    new Student(5, "Loulou", "Duck", 2.5),
];
/**********************************************************************************/
// Intro à LinQ


// Obtenir la liste des étudiants qui on la moyenne (Min 50)

// - Classique
List<Student> result1 = new List<Student>();

foreach (Student student in students)
{
    if (student.Result >= 50) {
        result1.Add(student);
    }
}

Console.WriteLine(string.Join(" > ", result1));

// - LinQ
IEnumerable<Student> result2 = students.Where(student => student.Result >= 50);
Console.WriteLine(string.Join(" > ", result2));


/**********************************************************************************/
// Le mot clef "var"
// → Type défini par le compilateur lors du build.
var test1 = 42;             // int
var test2 = 3_000_000_000;  // uint  (╯°□°）╯︵ ┻━┻
var test3 = 9_000_000_000;  // long

// → Utilisation des types annonymes (type connu uniquement lors de la compilation)
var person = new { Firstname = "Balthazar", Lastname = "Picsou" };
var people = students.Select(s => new { Name = s.Firstname + " " + s.Lastname, s.Result });

// Bonne pratique : Quand c'est possible, utiliser le type explicit et non le mot clef "var"


/**********************************************************************************/
// Les méthodes d'extension

Student gontran = new Student(6, "Gontran", "Bonheur", 45);

// Une méthode statique avec comme 1er parametre le type "student"
string msg1 = StudentExtension.SayHello(gontran);

// Une méthode d'extension peut être utiliser directement sur l'instance
string msg2 = gontran.SayHello();


/**********************************************************************************/

Console.WriteLine("List VS IEnumerable");

// Opération en mode « Immédiat »
// - Le resultat est directement calculé et stocké
List<string> result3 = students.OrderByDescending(s => s.Firstname)
                               .Select(s => s.SayHello())
                               .ToList(); 

// Opération en mode « Différé »
// - Le code est executé uniquement quand on exploite la requete
IEnumerable<string> result4 = students.OrderByDescending(s => s.Firstname)
                                      .Select(s => s.SayHello());

Console.WriteLine("1)");
foreach (string msg in result3) {
    Console.WriteLine(msg);
}
students.Add(gontran);
Console.WriteLine("2)");
foreach (string msg in result3)
{
    Console.WriteLine(msg);
}
Console.WriteLine("3)");
foreach (string msg in result4)
{
    Console.WriteLine(msg);
}
students.Add(new Student(7, "Archibald", "Gripsou", 0));
Console.WriteLine("4)");
foreach (string msg in result4)
{
    Console.WriteLine(msg);
}

