#include <iostream>
#include <vector>
using namespace std;

vector<vector<int>> multiplyMatrices(const vector<vector<int>>& A, const vector<vector<int>>& B) {
    int rowsA = A.size();
    int colsA = A[0].size();
    int rowsB = B.size();
    int colsB = B[0].size();

    if (colsA != rowsB) {
        throw invalid_argument("O número de colunas em A deve ser o mesmo que em B.");
    }

    vector<vector<int>> result(rowsA, vector<int>(colsB, 0));

    for (int i = 0; i < rowsA; ++i) {
        for (int j = 0; j < colsB; ++j) {
            for (int k = 0; k < colsA; ++k) {
                result[i][j] += A[i][k] * B[k][j];
            }
        }
    }
    return result;
}

int main() {
    vector<vector<int>> A = {
        {1, 2, 8},
        {3, 4, 5},
        {4, 5, 6}
    };

    vector<vector<int>> B = {
        {7, 8, 9},
        {1, 2, 3},
        {9, 10, 11}
    };

    try {
        vector<vector<int>> C = multiplyMatrices(A, B);
        cout << "Resultado da multiplicação de matrizes:" << endl;
        for (const auto& row : C) {
            for (int val : row) {
                cout << val << " ";
            }
            cout << endl;
        }
    } catch (const invalid_argument& e) {
        cout << "Erro: " << e.what() << endl;
    }

    return 0;
}
