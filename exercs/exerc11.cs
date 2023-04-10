public static int Factory()
{
    Console.WriteLine("*******11. Calcular o fatorial de um número inteiro********");
    int num;
    int count;
    int resu = 0;
    
    Console.WriteLine("Digite um valor para saber seu fatorial: ");
    num = Convert.ToInt32(Console.ReadLine());
    count = num - 1;
    resu = count * num;
    while (count > 1)
    {
        count--;
        resu *= count;
    }
    return resu;
}