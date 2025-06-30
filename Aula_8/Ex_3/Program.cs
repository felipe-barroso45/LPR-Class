/* Desenvolva um programa em C# que
simule um sistema de seleção de heróis da
Marvel para uma equipe. O programa deve
ter as seguintes funcionalidades: */

using System;
using System.Collections.Generic;

public struct Heroi
{
    public string Nome;
    public string Poder;
    public int Nivel;
}

public class Program
{
    static Heroi[] heroisCadastrados = new Heroi[5];
    static int totalHerois = 0;

    static void cadastrarHeroi(int index)
    {
        Console.WriteLine("Digite o nome do herói:");
        string nome = Console.ReadLine() ?? "Desconhecido";

        Console.WriteLine("Digite o poder do herói:");
        string poder = Console.ReadLine() ?? "Desconhecido";

        int nivel = 0;
        while (true)
        {
            Console.WriteLine("Digite o nível do herói (1 a 10):");
            string nivelInput = Console.ReadLine() ?? "";
            if (int.TryParse(nivelInput, out nivel) && nivel >= 1 && nivel <= 10)
                break;
            Console.WriteLine("Nível inválido. Tente novamente.");
        }

        heroisCadastrados[index] = new Heroi { Nome = nome, Poder = poder, Nivel = nivel };
        Console.WriteLine($"Herói {nome} cadastrado com sucesso!\n");
    }

    static void selecionarEquipe()
    {
        if (totalHerois < 3)
        {
            Console.WriteLine("Cadastre pelo menos 3 heróis antes de montar a equipe.\n");
            return;
        }

        Console.WriteLine("Heróis cadastrados:");
        for (int i = 0; i < totalHerois; i++)
        {
            Console.WriteLine($"{i + 1}. {heroisCadastrados[i].Nome} (Poder: {heroisCadastrados[i].Poder}, Nível: {heroisCadastrados[i].Nivel})");
        }

        Heroi[] equipe = new Heroi[3];
        bool[] escolhido = new bool[totalHerois];
        int count = 0;
        while (count < 3)
        {
            Console.Write($"Selecione o número do {count + 1}º herói para a equipe: ");
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int escolha) && escolha >= 1 && escolha <= totalHerois && !escolhido[escolha - 1])
            {
                equipe[count] = heroisCadastrados[escolha - 1];
                escolhido[escolha - 1] = true;
                count++;
            }
            else
            {
                Console.WriteLine("Escolha inválida ou repetida. Tente novamente.");
            }
        }

        Console.WriteLine("\nEquipe selecionada:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"- {equipe[i].Nome} (Poder: {equipe[i].Poder}, Nível: {equipe[i].Nivel})");
        }
    }

    static void calcularPontuacaoTotal()
    {
        int pontuacaoTotal = 0;
        foreach (var heroi in heroisCadastrados)
        {
            pontuacaoTotal += heroi.Nivel;
        }
        Console.WriteLine($"Pontuação total dos heróis cadastrados: {pontuacaoTotal}");
    }

    static void exibirEquipe()
    {
        Console.WriteLine("Equipe atual:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"- {heroisCadastrados[i].Nome} (Poder: {heroisCadastrados[i].Poder}, Nível: {heroisCadastrados[i].Nivel})");
        }
    }

    static void exibirMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1. Cadastrar herói");
        Console.WriteLine("2. Selecionar equipe");
        Console.WriteLine("3. Calcular pontuação total");
        Console.WriteLine("4. Exibir equipe");
        Console.WriteLine("5. Sair");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Cadastro de heróis Marvel (máximo 5 heróis)");
        totalHerois = 0;
        bool equipeSelecionada = false;
        Heroi[] equipe = new Heroi[3];
        bool[] escolhido = new bool[5];

        while (true)
        {
            exibirMenu();
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? "";
            Console.WriteLine();
            if (opcao == "1")
            {
                if (totalHerois >= 5)
                {
                    Console.WriteLine("Limite de heróis cadastrados atingido.");
                }
                else
                {
                    Console.WriteLine($"\nCadastro do herói {totalHerois + 1}:");
                    cadastrarHeroi(totalHerois);
                    totalHerois++;
                }
            }
            else if (opcao == "2")
            {
                if (totalHerois < 3)
                {
                    Console.WriteLine("Cadastre pelo menos 3 heróis antes de montar a equipe.\n");
                }
                else
                {
                    Console.WriteLine("Heróis cadastrados:");
                    for (int i = 0; i < totalHerois; i++)
                    {
                        Console.WriteLine($"{i + 1}. {heroisCadastrados[i].Nome} (Poder: {heroisCadastrados[i].Poder}, Nível: {heroisCadastrados[i].Nivel})");
                    }
                    Array.Clear(escolhido, 0, escolhido.Length);
                    int count = 0;
                    while (count < 3)
                    {
                        Console.Write($"Selecione o número do {count + 1}º herói para a equipe: ");
                        string input = Console.ReadLine() ?? "";
                        if (int.TryParse(input, out int escolha) && escolha >= 1 && escolha <= totalHerois && !escolhido[escolha - 1])
                        {
                            equipe[count] = heroisCadastrados[escolha - 1];
                            escolhido[escolha - 1] = true;
                            count++;
                        }
                        else
                        {
                            Console.WriteLine("Escolha inválida ou repetida. Tente novamente.");
                        }
                    }
                    equipeSelecionada = true;
                    Console.WriteLine("\nEquipe selecionada:");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine($"- {equipe[i].Nome} (Poder: {equipe[i].Poder}, Nível: {equipe[i].Nivel})");
                    }
                }
            }
            else if (opcao == "3")
            {
                calcularPontuacaoTotal();
            }
            else if (opcao == "4")
            {
                if (!equipeSelecionada)
                {
                    Console.WriteLine("Nenhuma equipe foi selecionada ainda.");
                }
                else
                {
                    Console.WriteLine("Equipe atual:");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine($"- {equipe[i].Nome} (Poder: {equipe[i].Poder}, Nível: {equipe[i].Nivel})");
                    }
                }
            }
            else if (opcao == "5")
            {
                Console.WriteLine("Saindo...");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }
}
