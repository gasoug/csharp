public static void login()
{
    Console.WriteLine("*******15. Verificar login de usuário e senha********");

    string cod = "1234";
    string pass = "9999";
    string cod_user, pass_user;

    Console.WriteLine("Informe o código de usuário: ");
    cod_user = Console.ReadLine();

    while (cod_user != cod)
    {
        Console.WriteLine("Usuário inválido!");
        Console.WriteLine("Informe o código de usuário: ");
        cod_user = Console.ReadLine();
    }
    Console.WriteLine("Informe a senha de usuário: ");
    pass_user = Console.ReadLine();
    while (pass != pass_user)
    {
        Console.WriteLine("Senha incorreta!");
        Console.WriteLine("Informe a senha de usuário: ");
        pass_user = Console.ReadLine();
    }
    Console.WriteLine("Acesso permitido");
}