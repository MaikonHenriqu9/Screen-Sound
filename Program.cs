string mensagemBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> {"Morada", "FHOP"};
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>> (); 
bandasRegistradas.Add("FHOP", new List<int> {10, 8, 9});
bandasRegistradas.Add("Ministério Zoe", new List<int> {10, 10, 9, 8});
bandasRegistradas.Add("Resgate", new List<int>());

void ExibirLogo() {
    Console.WriteLine(@"
        
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine(mensagemBoasVindas);
}

void ExibirOpcoesDoMenu () {
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");
    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch(opcaoEscolhidaNumerica){
        case 1: 
            RegistrarBandas();
            break;
        case 2: 
            MostrarBandasRegistradas(); 
            break;
        case 3: 
            AvaliarUmaBanda();
            break;
        case 4:
            ExibirMediaDaBanda();
            break;
        case -1:
            Console.Clear();
            Console.WriteLine("Tchau tchau : )"); 
            break;
        default:
            Console.WriteLine("Opção Inválida");
            break;
    } 
}

void RegistrarBandas(){
    Console.Clear();
    ExibirTituloDaOpcao("Registrando novas bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    /*
     for (int i = 0; i < listaDasBandas.Count; i++){
         Console.WriteLine($"Banda: {listaDasBandas[i]}");
     }
    */
    foreach (string banda in bandasRegistradas.Keys){
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite alguma tecla  para sair");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
};

void ExibirTituloDaOpcao(string titulo){
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');

    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos+"\n");

}

void AvaliarUmaBanda(){
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar uma banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine();

    if(bandasRegistradas.ContainsKey(nomeDaBanda)){
        Console.Write($"Qual a nota que você deseja dar para a banda {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);

        /*Chamei o dicionário, chamei o nome da banda e em seguida atribui uma nota*/
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\n A nota {nota} foi registrada com sucesso!!");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    } else {
        Console.WriteLine($"{nomeDaBanda} não foi encontrado!!");
        Console.WriteLine("Digite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

void ExibirMediaDaBanda(){
    // Limpar a tela
    Console.Clear();
    // Titulo da opção escolhida
    ExibirTituloDaOpcao("Exibindo a média da banda");
    // Perguntar o nome da banda para exibir a média, caso essa banda esteja na lista
    Console.Write("Qual o nome da banda que você deseja saber a média: ");
    string nomeDaBanda = Console.ReadLine();

    if(bandasRegistradas.ContainsKey(nomeDaBanda)){
        double mediaDaBanda = bandasRegistradas[nomeDaBanda].Average();
        Console.WriteLine($"A méda da banda {nomeDaBanda} é : {mediaDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else {
        Console.WriteLine($"{nomeDaBanda} não foi encontrado!!");
        Console.WriteLine("Digite uma tecla para sair");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

    // Realizar o cálculo da média da banda
}

ExibirOpcoesDoMenu();