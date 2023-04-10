public static string ReturnString()
{
    Console.WriteLine("*******1. Concatenar duas palavras********");
    Console.WriteLine("Primeira palavra");
    string fstring = Console.ReadLine();
    Console.WriteLine("Segunda palavra");
    string sstring = Console.ReadLine();
    string concat = fstring + sstring;
    return concat;
}