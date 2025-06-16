/*Defina uma struct Livro com os seguintes
campos: Titulo, Autor, AnoPublicacao,
NumeroPaginas e Preco. Crie um
programa que permita ao usuário inserir
dados de 3 livros e, em seguida, calcule e
exiba o preço total dos livros cadastrados
e a média de páginas dos livros.*/

#include <iostream>
#include <string>
using namespace std;

struct Livro {
    string Titulo;
    string Autor;
    int AnoPublicacao;
    int NumeroPaginas;
    double Preco;
};

int main() {
    Livro Livros[3];
    double precoTotal = 0.0;
    int paginasTotal = 0;
    int numeroLivros = 3;

    for (int i = 0; i < numeroLivros; i++) {
        cout << "Digite os dados do livro " << i+1 << ":" << endl;
        cout << "Título: ";
        cin.ignore(); 
        getline(cin, Livros[i].Titulo);
        cout << "Autor: ";
        getline(cin, Livros[i].Autor);
        cout << "Ano de publicação: ";
        cin >> Livros[i].AnoPublicaca;
        cout << "Número de páginas: ";
        cin >> Livros[i].NumeroPaginas;
        cout << "Preço: ";
        cin >> Livros[i].Preco;

        precoTotal += Livros[i].Preco;
        paginasTotal += Livros[i].NumeroPaginas;
    }
    int mediaPaginas = paginasTotal / numeroLivros;
    cout << "\nPreço total dos livros: R$ " << precoTotal << endl;
    cout << "Média de páginas dos livros: " << mediaPaginas << endl;
    return 0;
}