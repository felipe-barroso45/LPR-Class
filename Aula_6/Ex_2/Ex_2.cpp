#include <iostream>
using namespace std;

void exercicio1();
void exercicio3();
void exercicio4();

int main() {
    int opcao;

    do {
        cout << "Menu de Exercícios" << endl;
        cout << "1 - Exercício 1" << endl;
        cout << "3 - Exercício 3" << endl;
        cout << "4 - Exercício 4" << endl;
        cout << "0 - Sair" << endl;
        cout << "Escolha uma opção: ";
        cin >> opcao;

        switch (opcao) {
            case 1:
                exercicio1();
                break;
            case 3:
                exercicio3();
                break;
            case 4:
                exercicio4();
                break;
            case 0:
                cout << "Saindo do programa..." << endl;
                break;
            default:
                cout << "Opção inválida! Tente novamente." << endl;
        }
    } while (opcao != 0);

    return 0;
}

void exercicio1() {
    cout << "Executando o Exercício 1..." << endl;
    int quantidade, numero, soma = 0, contadorPares = 0;

    cout << "Digite a quantidade de números: ";
    cin >> quantidade;

    int i = 0;
    while (i < quantidade) {
        cout << "Digite um número: ";
        cin >> numero;

        if (numero % 2 == 0) { 
            soma += numero;   
            contadorPares++;  
        }
        i++;
    }

    if (contadorPares > 0) {
        double media = static_cast<double>(soma) / contadorPares; 
        cout << "A média dos números pares é: " << media << endl;
    } else {
        cout << "Nenhum número par foi digitado." << endl;
    }

}

void exercicio3() {
    cout << "Executando o Exercício 3..." << endl;
    int soma = 0;

    for (int i = 50; i <= 500; i++) {
        if (i % 2 != 0 && i % 3 == 0) { 
            soma += i; 
        }
    }

    cout << "A soma de todos os números ímpares múltiplos de 3 no intervalo de 50 a 500 é: " << soma << endl;

}

void exercicio4() {
    cout << "Executando o Exercício 4..." << endl;
    int numero, quadrado, soma = 0;

    cout << "Digite um número: ";
    cin >> numero;

    quadrado = numero * numero;

    cout << "O quadrado de " << numero << " é: " << quadrado << endl;

    while (quadrado > 0) {
        soma += quadrado % 10; 
        quadrado /= 10;        
    }

    cout << "A soma dos dígitos do quadrado é: " << soma << endl;

}