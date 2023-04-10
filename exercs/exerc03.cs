public static double ReturnAverage()
{
    Console.WriteLine("*******3. Valor da média de quatro números********");
    Console.WriteLine("Primeiro número: ");
    int v1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Segundo número: ");
    int v2 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Terceiro número: ");
    int v3 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Quarto número: ");
    int v4 = Convert.ToInt32(Console.ReadLine());
    double average = (v1 + v2 + v3 + v4)/4;
    return average;
}