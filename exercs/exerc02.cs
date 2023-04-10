public static int ReturnSum()
{
    Console.WriteLine("*******2. Soma de dois números********");
    Console.WriteLine("Primeiro número: ");
    int v1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Segundo número: ");
    int v2 = Convert.ToInt32(Console.ReadLine());
    int sum = v1 + v2;
    return sum;
}