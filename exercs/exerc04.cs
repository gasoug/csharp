public static char ReturnFruit()
{
    Console.WriteLine("*******4. Primeira letra do nome de uma fruta********");
    Console.WriteLine("Digite o nome de uma fruta: ");
    string fruit = Console.ReadLine();
    char fletter = fruit[0];
    return fletter;
}