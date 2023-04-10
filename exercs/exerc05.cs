public static string EvenOdd()
{
    Console.WriteLine("*******5. Número par ou ímpar********");
    Console.WriteLine("Digite um número para saber se é ímpar ou par: ");
    int num = Convert.ToInt32(Console.ReadLine());
    string res = "";
    int iseven = num % 2;
    res = iseven == 0 ? "par" :  "ímpar";
    return res;
}