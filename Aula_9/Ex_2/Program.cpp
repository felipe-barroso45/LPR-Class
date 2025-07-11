/*Construa uma lista de 100 números
aleatórios
Crie um algoritmo que coloque-os em
ordem crescente e imprima-os
A partir dessa lista ordenada, remova
todos os números pares e imprima a lista
novamente.
Por fim imprima quais números se
repetem, se existe algum número
repetido.*/

#include <iostream>
#include <vector>
#include <algorithm>
#include <random>
#include <unordered_map>

int main() {
    std::vector<int> numeros;
    std::random_device rd;
    std::mt19937 gen(rd());
    std::uniform_int_distribution<> dis(0, 999);
    for (int i = 0; i < 100; ++i) {
        numeros.push_back(dis(gen));
    }

    std::sort(numeros.begin(), numeros.end());
    std::cout << "Lista ordenada:\n";
    for (int n : numeros) std::cout << n << " ";
    std::cout << "\n\n";

    std::vector<int> impares;
    for (int n : numeros) {
        if (n % 2 != 0) impares.push_back(n);
    }
    std::cout << "Lista sem pares:\n";
    for (int n : impares) std::cout << n << " ";
    std::cout << "\n\n";

    std::unordered_map<int, int> contagem;
    for (int n : numeros) contagem[n]++;
    bool temRepetidos = false;
    std::cout << "Números repetidos:\n";
    for (const auto& par : contagem) {
        if (par.second > 1) {
            std::cout << par.first << " aparece " << par.second << " vezes\n";
            temRepetidos = true;
        }
    }
    if (!temRepetidos) std::cout << "Nenhum número repetido.\n";
    return 0;
}
