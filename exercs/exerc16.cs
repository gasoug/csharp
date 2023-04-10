public static void retirement()
{
    Console.WriteLine("*******16. Verificar direito a aposentadoria********");

    int cod, year_born, year_entry, age, worked;
    int now = Convert.ToInt32(DateTime.Now.ToString("yyyy"));

    Console.WriteLine("Informe o código do empregado: ");
    cod = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Informe o ANO de nascimento do empregado: ");
    year_born = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Informe o ANO de ingresso do empregado na empresa: ");
    year_entry = Convert.ToInt32(Console.ReadLine());

    age = now - year_born;
    worked = now - year_entry;

    if ((age >= 65) || (worked >= 30) || (age == 60 && worked >= 25))
    {
        Console.WriteLine("Requerer aposentadoria");
    }else
    {
        Console.WriteLine("Não requerer");
    }

}