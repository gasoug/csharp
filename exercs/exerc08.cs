public static void UntilHundredIsOdd()
{
    Console.WriteLine("*******8. Imprimir os números de 0 a 100 se é ímpar ou par********");
    int init;
    for (init = 0; init <= 100; init++)
    {
        if (init % 2 == 0) { 
            Console.WriteLine(init + " Par");
        }
        else {
            Console.WriteLine(init + " Ímpar");
        }
    }
}