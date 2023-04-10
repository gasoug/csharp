public static void Prime()
{
    Console.WriteLine("*******11. Imprimir os números de 0 a 100 se é primo ou não********");
    int count;
    for (count = 0; count <= 100; count++)
    {
        if ((count > 2 && count % 2 == 0 || count > 3 && count % 3 == 0 || count > 5 && count % 5 == 0 || count > 7 && count % 7 == 0))
        {
            Console.WriteLine($"{count} não é um número primo.");
        }
        else if (count < 2)
        {
            Console.WriteLine($"{count} não é um número primo.");
        }                
        else 
        {
            Console.WriteLine($"{count} é um número primo.");
        }
    }

}