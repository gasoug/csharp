public static void fruits()
{
    Console.WriteLine("*******14. Calcular valor a pagar das frutas********");

    int kg_strawberry, kg_apple;
    double val_strawberry, val_apple;
    double to_pay, sale;

    Console.WriteLine("Informe a quantidade de quilos de maçã: ");
    kg_strawberry = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Informe a quantidade de quilos de morango: ");
    kg_apple = Convert.ToInt32(Console.ReadLine());

    val_strawberry = (kg_strawberry > 5) ? 2.20 : 2.50;
    val_apple = (kg_apple > 5) ? 1.50 : 1.80;

    to_pay = (kg_apple * val_apple) + (kg_strawberry * val_strawberry);
    
    sale = (((kg_apple + kg_strawberry) > 8) || to_pay > 25) ? 0.1 : 0;

    to_pay -= (to_pay * sale);

    Console.WriteLine($"Valor total a ser pago é de R${to_pay.ToString("F")}");
}