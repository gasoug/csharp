public static void ages()
{
    Console.WriteLine("*******13. Calcular a soma e o produto de idades distintas********");
    int age_man1, age_man2;
    int age_woman1, age_woman2;
    int sum, product;
    int older_man, older_woman, young_man, young_woman;

    Console.WriteLine("Informa a idade do primeiro homem: ");
    age_man1 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Informa a idade do segundo homem: ");
    age_man2 = Convert.ToInt32(Console.ReadLine());

    while (age_man2 == age_man1)
    {
        Console.WriteLine("As idade do segundo homem deve ser diferente do primeiro!");
        Console.WriteLine("Informa a idade do segundo homem: ");
        age_man2 = Convert.ToInt32(Console.ReadLine());
    }

    Console.WriteLine("Informa a idade da primeira mulher: ");
    age_woman1 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Informa a idade da segunda mulher: ");
    age_woman2 = Convert.ToInt32(Console.ReadLine());

    while (age_woman2 == age_woman1)
    {
        Console.WriteLine("As idade da segunda mulher deve ser diferente da primeira!");
        Console.WriteLine("Informa a idade da segunda mulher: ");
        age_woman2 = Convert.ToInt32(Console.ReadLine());
    }

    older_man = (age_man1 > age_man2) ? age_man1 : age_man2;
    older_woman = (age_woman1 > age_woman2) ? age_woman1 : age_woman2;
    young_man = (age_man1 > age_man2) ? age_man2 : age_man1;
    young_woman = (age_woman1 > age_woman2) ? age_woman2 : age_woman1;

    sum = older_man + young_woman;
    product = young_man * older_woman;

    Console.WriteLine($"A soma das idades entre o homem mais velho e a mulher mais nova é de {sum}.\n O produto das idades entre o homem mais novo e a mulher mais velha é de {product}.");
}