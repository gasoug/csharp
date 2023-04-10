public static void fuel()
{
    Console.WriteLine("*******12. Calcular valor do combustível********");
    double gaso = 3.30;
    double alc = 2.90;
    double valor_pagar;
    double desc;
    int litros;
    string tipo;

    Console.WriteLine("Informe quantos litros de combústivel foram vendidos: ");
    litros = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Escolha o tipo de combustível:\nA = Álcool\nG = Gasolina");
    tipo = Console.ReadLine().ToUpper();

    while (tipo != "A" && tipo != "G")
    {
        Console.WriteLine("Tipo inválido. Escolha entre A ou G");
        Console.WriteLine("Escolha o tipo de combustível:\nA = Álcool\nGasolina = G");
        tipo = Console.ReadLine().ToUpper();
    }
    if (tipo == "A")
    {
        desc = (litros > 20) ? 0.05 : 0.03;
        valor_pagar = litros * alc;
        valor_pagar -= (valor_pagar * desc);
    }
    else
    {
        desc = (litros > 20) ? 0.06 : 0.04;
        valor_pagar = litros * gaso;
        valor_pagar -= valor_pagar * desc;
    }
    Console.WriteLine($"O valor total a ser pago pelo cliente é de R${valor_pagar.ToString("F")}");

}