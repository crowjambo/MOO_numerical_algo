#include <stdio.h>

//write program to calculate the third order determinant
//test

int determinantCalc(int m[]) {
	return m[0]*(m[4] * m[8] - m[5] * m[7]) - m[1] * (m[3] * m[8] - m[5] * m[6]) + m[2] * (m[3] * m[7] - m[4] * m[6]);
}

void drawMatrix(int m[]) {
	int i;
	system("cls");
	printf("\n\n\n\n");
	for (i = 0; i < 9; i++) {
		if (i == 3 || i == 6) {
			printf("\n%d ", m[i]);
		}
		else {
			printf("%d ", m[i]);
		}
	};
	printf("\n\n\n\n");
}

int main() {
	//matrix
	int matrix[10];
	for (int i = 0; i < 9; i++) {
		matrix[i] = 0;
	}


	//take in input of numbers +add to array (left to right)
	for (int i = 0; i < 9; i++) {
		//show it
		drawMatrix(matrix);

		//input
		printf("input number : %d : ", i+1);
		scanf_s("%d", &matrix[i]);

	}
	


	//give output using formula (print out)
	drawMatrix(matrix);
	printf("determinant = %d \n", determinantCalc(matrix));

	system("pause");
	return 0;
}