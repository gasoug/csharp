public static string Situation(int res)
{
    Console.WriteLine("*******6 Imprimir Situação do aluno********");
    string resul = "";

    if (res < 5)
    {
        resul = "Reprovado!";
    }
    else if (res >= 5 || res <= 7 )
    {
        resul = "Recuperação!";
    }
    else
    {
        resul = "Aprovado!";
    }
    return resul;
}