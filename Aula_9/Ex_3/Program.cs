/*Construa um dicionário de X pares chave-valor
onde as chaves são nomes de pessoas e os
valores são suas respectivas idades.
Encontre e imprima todos os nomes de
pessoas com idade acima da média.
Encontre e imprima o nome da pessoa mais
velha e o nome da pessoa mais nova.
Remova todas as pessoas com idade igual a
um valor Y (fornecido pelo usuário) e imprima
o dicionário atualizado.*/

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Digite o número de pessoas: ");
        int quantidade;
        while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
        {
            Console.Write("Valor inválido. Digite um número inteiro positivo: ");
        }

        var pessoas = new Dictionary<string, int>();
        for (int i = 0; i < quantidade; i++)
        {
            Console.Write($"Digite o nome da pessoa {i + 1}: ");
            string? nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nome) || pessoas.ContainsKey(nome))
            {
                Console.Write("Nome inválido ou repetido. Digite novamente: ");
                nome = Console.ReadLine();
            }
            Console.Write($"Digite a idade de {nome}: ");
            int idade;
            while (!int.TryParse(Console.ReadLine(), out idade) || idade < 0)
            {
                Console.Write("Idade inválida. Digite novamente: ");
            }
            pessoas.Add(nome!, idade);
        }

        double media = pessoas.Values.Average();
        Console.WriteLine($"\nIdade média: {media:F2}");
        Console.WriteLine("Nomes com idade acima da média:");
        foreach (var par in pessoas)
        {
            if (par.Value > media)
                Console.WriteLine(par.Key);
        }

        int maiorIdade = pessoas.Values.Max();
        int menorIdade = pessoas.Values.Min();
        var maisVelhos = pessoas.Where(p => p.Value == maiorIdade).Select(p => p.Key);
        var maisNovos = pessoas.Where(p => p.Value == menorIdade).Select(p => p.Key);
        Console.WriteLine($"\nPessoa(s) mais velha(s): {string.Join(", ", maisVelhos)}");
        Console.WriteLine($"Pessoa(s) mais nova(s): {string.Join(", ", maisNovos)}");

        Console.Write("\nDigite a idade Y para remover: ");
        int idadeRemover;
        while (!int.TryParse(Console.ReadLine(), out idadeRemover) || idadeRemover < 0)
        {
            Console.Write("Idade inválida. Digite novamente: ");
        }
        var nomesRemover = pessoas.Where(p => p.Value == idadeRemover).Select(p => p.Key).ToList();
        foreach (var nome in nomesRemover)
        {
            pessoas.Remove(nome);
        }
        Console.WriteLine("\nDicionário atualizado:");
        foreach (var par in pessoas)
        {
            Console.WriteLine($"{par.Key}: {par.Value}");
        }
    }
}