#include <iostream>
using namespace std;

int numeroReverso(int num) {
    int reverso = 0;
    while (num != 0) {
       int digit = num % 10;
       reverso = reverso*10 + digit;
       num /= 10; 
    }
    return reverso;
}

int main() {
    int number;
    count << "Digite um número inteiro: ";
    cin >> number;

    int reverso = numeroReverso(number);
    count << "O reverso do número é: " << reverso << endl;

    return 0;
}