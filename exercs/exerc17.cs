public static void table()
{
    Console.WriteLine("*******17. Mostrar valor de tabuada********");

    int num, opt;
    opt = 1;
    while (opt == 1) { 
        Console.WriteLine("Informe qual tabuada gostaria de ver:");
        num = Convert.ToInt32(Console.ReadLine());
        for (int count = 0; count <=10; count++)
        {
            Console.WriteLine($"{num} x {count} = {num * count}");
        }
        Console.WriteLine("Deseja ver outra tabuada?\n 0 - Não\n 1 = Sim");
        opt = Convert.ToInt32(Console.ReadLine());
    }
}