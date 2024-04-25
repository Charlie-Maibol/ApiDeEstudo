//Sreen Sound
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";

void ExibirLogo()
{
    Console.WriteLine(@"

█▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀
");

    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para listar as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {

        case 1: RegistrarBanda();
            break;
        case 2:
            Console.WriteLine("Você escolheu a opção " + opcaoEscolhida);
            break;
        case 3:
            Console.WriteLine("Você escolheu a opção " + opcaoEscolhida);
            break;
        case 4:
            Console.WriteLine("Você escolheu a opção " + opcaoEscolhida);
            break;
        case 0:
            Console.WriteLine("\nAdeus");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }

}
void RegistrarBanda()
{

    Console.Clear();
    Console.WriteLine("Registro de bandas");
    Console.Write("\nDigite o nome da banda que deseja registrar: ");
    string NomeDaBanda = Console.ReadLine()!;
    Console.WriteLine($"A banda {NomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear() ;   
    ExibirMenu();
           
}

ExibirMenu();
