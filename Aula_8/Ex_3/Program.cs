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
    static Heroi[] heroisCadastrados;
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

    public static void Main(string[] args)
    {
        Console.WriteLine("Quantos heróis deseja cadastrar?");
        int quantidade = 0;
        while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 3)
        {
            Console.WriteLine("Digite um número válido (mínimo 3):");
        }
        heroisCadastrados = new Heroi[quantidade];
        totalHerois = quantidade;
        for (int i = 0; i < quantidade; i++)
        {
            Console.WriteLine($"\nCadastro do herói {i + 1}:");
            cadastrarHeroi(i);
        }
        selecionarEquipe();
    }
}
