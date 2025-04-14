using System;

class Program
{
    static void Main(string[] args)
    {
        menuPrincipal();
    }

    static void menuPrincipal()
    {
        string[] nomes = new string[5];
        string[] poderes = new string[5];
        int[] pontuacoes = new int[5];
        int contadorHerois = 0;
        int[] equipe = new int[3];
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Cadastrar Heróis");
            Console.WriteLine("2. Selecionar Equipe");
            Console.WriteLine("3. Exibir Equipe");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    if (contadorHerois < 5)
                    {
                        cadastrarHeroi(nomes, poderes, pontuacoes, contadorHerois);
                        contadorHerois++;
                    }
                    else
                    {
                        Console.WriteLine("Limite de heróis cadastrados atingido.");
                    }
                    break;
                case "2":
                    if (contadorHerois > 0)
                    {
                        selecionarEquipe(nomes, contadorHerois, equipe);
                    }
                    else
                    {
                        Console.WriteLine("Nenhum herói cadastrado.");
                    }
                    break;
                case "3":
                    exibirEquipe(nomes, poderes, pontuacoes, equipe);
                    break;
                case "0":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void cadastrarHeroi(string[] nomes, string[] poderes, int[] pontuacoes, int index)
    {
        Console.Write("Digite o nome do herói: ");
        nomes[index] = Console.ReadLine();
        Console.Write("Digite o poder do herói: ");
        poderes[index] = Console.ReadLine();
        Console.Write("Digite a pontuação do herói: ");
        pontuacoes[index] = int.Parse(Console.ReadLine());
        Console.WriteLine("Herói cadastrado com sucesso!");
    }

    static void selecionarEquipe(string[] nomes, int contadorHerois, int[] equipe)
    {
        Console.WriteLine("Heróis cadastrados:");
        for (int i = 0; i < contadorHerois; i++)
        {
            Console.WriteLine($"{i + 1}. {nomes[i]}");
        }

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Selecione o herói {i + 1} para a equipe (1 a {contadorHerois}): ");
            equipe[i] = int.Parse(Console.ReadLine()) - 1;
        }
    }

    static void exibirEquipe(string[] nomes, string[] poderes, int[] pontuacoes, int[] equipe)
    {
        Console.WriteLine("Equipe selecionada:");
        int pontuacaoTotal = 0;

        for (int i = 0; i < 3; i++)
        {
            int index = equipe[i];
            Console.WriteLine($"Herói: {nomes[index]}, Poder: {poderes[index]}, Pontuação: {pontuacoes[index]}");
            pontuacaoTotal += pontuacoes[index];
        }

        Console.WriteLine($"Pontuação Total da Equipe: {pontuacaoTotal}");
    }
}