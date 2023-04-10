public static int Average()
{
    Console.WriteLine("*******9. Imprimir a média da soma dos números de 10 a 90********");
    int start = 10;
    int result = start;
    int count = 0;
    int average;
    for (start = 11; start <=90; start++)
    {
        result += start;
        count++;
    }
    average = result / count;
    return average;
}