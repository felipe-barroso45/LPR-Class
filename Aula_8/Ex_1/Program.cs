using System
using Microsoft.AspNetCore.Mvc.ModelBinding;:

public struct Produto {
    public string Nome;
    public int Codigo;
    public double Preco;
    public int Quantidade;
}

class Program {
    static void Mains()
    {
        const int quantidadeProdutos = 3;
        Produto[] produtos = new Produto[quantidadeProdutos];

        for (int i = 0; i < quantidadeProdutos; i++)
        {
            Console.WriteLine($"Digite o nome do produto {i + 1}:");
            produtos[i].Nome = Console.ReadLine();

            Console.WriteLine($"Digite o código do produto {i + 1}:");
            produtos[i].Codigo = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o preço do produto {i + 1}:");
            produtos[i].Preco = double.Parse(Console.ReadLine());

            Console.WriteLine($"Digite a quantidade do produto {i + 1}:");
            produtos[i].Quantidade = int.Parse(Console.ReadLine());

            produtos[i] = new Produto(nome, codigo, preco, quantidade);
        }
        double totalValorEstoque = 0;
        foreach (var produto in produtos)
        {
            totalValorEstoque += produto.Preco * produto.Quantidade;
        }
        Console.WriteLine($"O valor total do estoque é: {totalValorEstoque:C}");
    }
}