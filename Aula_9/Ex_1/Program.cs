/*Construa uma lista de X nomes aleatórios
A saída deve ser mostrada em uma ou
mais linhas. Cada linha tem uma lista de
nomes ordenados por tamanho,
começando com o menor. Em cada linha,
só pode ser mostrado um nome de
determinado tamanho, e os demais
nomes com o mesmo tamanho devem ser
apresentados nas linhas seguintes. Você
deve seguir a ordem de digitação.*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        Console.Write("Digite o número de nomes: ");
        int quantidade;
        while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
        {
            Console.Write("Valor inválido. Digite um número inteiro positivo: ");
        }
    
        var nomes = new List<string>();
        for (int i = 0; i < quantidade; i++)
        {
            Console.Write($"Digite o nome {i + 1}: ");
            string? nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.Write("Nome não pode ser vazio. Digite novamente: ");
                nome = Console.ReadLine();
            }
            nomes.Add(nome!);
        }

        var nomesOrdenados = new List<string>(nomes);
        nomesOrdenados.Sort((x, y) => x.Length.CompareTo(y.Length));

        var usados = new HashSet<int>();
        while (usados.Count < nomes.Count)
        {
            int ultimoTamanho = -1;
            for (int i = 0; i < nomesOrdenados.Count; i++)
            {
                if (usados.Contains(i)) continue;
                int tamanhoAtual = nomesOrdenados[i].Length;
                if (tamanhoAtual != ultimoTamanho)
                {
                    Console.Write(nomesOrdenados[i] + " ");
                    usados.Add(i);
                    ultimoTamanho = tamanhoAtual;
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nLista original:");
        foreach (var nome in nomes)
            Console.Write(nome + " ");
        Console.WriteLine();
    }
}