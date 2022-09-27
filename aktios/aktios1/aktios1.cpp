#include <iostream>
#include <stdlib.h>
#include <windows.h>
using namespace std;

string to10bi(float a); //lab2
int from10bi(string str);
int* toASCII(string str);
string fromASCII(int a[200]);
string reverse2code(string str);
string dopcode(string str);

string reverse(string a); //perevernyt masiy

int plus2(int a, int b);
int minus2(int a, int b);
long long x2(int a, int b);

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	//setlocale(LC_ALL, "Russian");

	//while (1)
	//{
	//	string b; cin >> b;
	//	cout << dopcode(b) << endl;
	//	//cout << b << endl;
	//}

	while (1)
	{
		cout << "--------------------------" << endl;
		cout << "0 - перевод из 2,8,16 в 10 " << endl;
		cout << "1 - перевод из 10 в 2,8,16 " << endl;
		cout << "2 - операции над 2" << endl;
		cout << "3 - операции над 16" << endl;
		cout << "4 - операции над 8" << endl;

		float to_number;
		string from_number;
		int choice = 0; cin >> choice;
		int sschoice;
		int first_number, second_number;
		string first_str_number, second_str_number;
		switch (choice)
		{
		case 0: // перевод из
			cout << "Введите систему счисления(2,8,16): "; cin >> sschoice;
			cout << "Введите число: "; cin >> from_number;
			switch (sschoice)
			{
			case 2:
				cout << from2(from_number);
				break;
			case 8:
				cout << from8(from_number);
				break;
			case 16:
				cout << from16(from_number);
				break;
			}
			break;
			//////////////////////
		case 1:
			cout << "Введите систему счисления(2,8,16): "; cin >> sschoice;
			cout << "Введите число: "; cin >> to_number;
			switch (sschoice) //перевод в 
			{
			case 2:
				cout << to2(to_number);
				break;
			case 8:
				cout << to8(to_number);
				break;
			case 16:
				cout << to16(to_number);
				break;
			}
			break;
			////////////////////////
		case 2:
			cout << "1 - Сложение, 2 - Вычитание, 3 - Умножение: "; cin >> sschoice;
			cout << "Введите первое число: "; cin >> first_number;
			cout << "Введите второе число: "; cin >> second_number;
			switch (sschoice) //операции над 2 
			{
			case 1:
				cout << plus2(first_number, second_number);
				break;
			case 2:
				cout << minus2(first_number, second_number);
				break;
			case 3:
				cout << x2(first_number, second_number);
				break;
			}
			break;
		case 3:
			cout << "1 - Сложение, 2 - Вычитание, 3 - Умножение: "; cin >> sschoice;
			cout << "Введите первое число: "; cin >> first_str_number;
			cout << "Введите второе число: "; cin >> second_str_number;
			switch (sschoice) //операции над 16
			{
			case 1:
				cout << to16(from16(first_str_number) + from16(second_str_number));
				break;
			case 2:
				cout << to16(from16(first_str_number) - from16(second_str_number));
				break;
			case 3:
				cout << to16(from16(first_str_number) * from16(second_str_number));
				break;
			}
			break;
		case 4:
			cout << "1 - Сложение, 2 - Вычитание, 3 - Умножение: "; cin >> sschoice;
			cout << "Введите первое число: "; cin >> first_str_number;
			cout << "Введите второе число: "; cin >> second_str_number;
			switch (sschoice) //операции над 8
			{
			case 1:
				cout << to8(from8(first_str_number) + from8(second_str_number));
				break;
			case 2:
				cout << to8(from8(first_str_number) - from8(second_str_number));
				break;
			case 3:
				cout << to8(from8(first_str_number) * from8(second_str_number));
				break;
			}
			break;
		}
		cout << endl;
	}
}

int plus2(int a, int b)
{
	int result;
	result = a + b;
	int temp = result;

	int петя = 0;
	while (temp != 0)
	{
		if (temp % 10 >= 2)
		{
			result += 1 * pow(10, петя + 1);
			temp += 10;
			result -= 2 * pow(10, петя);
		}
		temp /= 10;
		петя++;
	}
	return result;
}

int minus2(int a, int b)
{
	int result;
	result = a - b;

	int temp = result;

	int i = 0;
	while (temp != 0)
	{
		if (temp % 10 == 9)
		{
			result -= 8 * pow(10, i);
		}
		temp /= 10;
		i++;
	}
	return result;
}

long long x2(int a, int b)
{
	long long result = 0;
	long long temp = a;

	int i = 0;
	while (temp != 0)
	{
		if (temp % 10 == 1)
		{
			result += b * pow(10, i);
		}
		temp /= 10;
		i++;
	}

	i = 0;
	temp = result;
	while (temp != 0)
	{
		if (temp % 10 >= 2)
		{
			result += (temp % 10) / 2 * pow(10, i + 1);
			result -= (temp % 10) * pow(10, i);
			result += temp % 2 * pow(10, i);
			temp += (temp % 10) / 2 * 10;
		}
		temp /= 10;
		i++;
	}
	return result;
}

string to2(float a)
{
	char b[99];
	int i = 0;
	float a2 = a;

	if (a < 0) a = abs(a);
	if (a == 1) b[0] = '1'; //просто 1 и 0
	if (a == 0) b[0] = '0';

	while (a != 1 and a != 0) //целая часть
	{
		if ((int)a % 2 == 0)
			b[i] = '0';
		else b[i] = '1';

		i++;
		a = (int)a / 2;
		if (a == 1) b[i] = '1';
	}

	int i2 = i;
	if (i2 % 2 == 1) i2++;
	for (int k = 0; k < i2 / 2; k++) //perevernyt masiy
	{
		int temp = b[k];
		b[k] = b[i - k];
		b[i - k] = temp;
	}

	i2 = 0;
	if (a2 - (int)a2 > 0)  //дробная часть 
	{

		i++; b[i] = '.'; //geroicheskiy dot

		a2 = a2 - (int)a2;
		for (int j = 0; j < 4; j++)
		{
			i++;
			a2 *= 2;

			if (a2 == 1)
			{
				b[i] = '1';
				break;
			}

			if (a2 > 1)
			{
				b[i] = '1';
				a2 -= 1;
			}
			else
			{
				b[i] = '0';
			}
		}
	}



	string s;
	for (int j = 0; j <= i; j++)
	{
		s += b[j];
	}
	return s;
}

float from2(string a)
{
	float b = 0; int i = 0;
	while (a[i] == '1' or a[i] == '0')
	{
		if (a[i] == '1') b = b * 2 + 1; //esli 1 x2+1 esli 0 x2
		if (a[i] == '0') b = b * 2;
		i++;
	}

	if (a[i] == '.') i++;

	int step = 0;
	while (a[i] == '1' or a[i] == '0')
	{
		step--;
		if (a[i] == '1') b = b + pow(2, step); //esli 1 x2+1 esli 0 x2
		//if (a[i] == '0') b = b * 2;
		i++;
	}
	return b;
}

string to16(float a)
{
	char b[99]; int i = 0;
	float a2 = a - (int)a;
	float ost;

	while (a >= 16) //ostatok
	{
		ost = (int)a % 16; //zapominaem ostatok ot a/16
		if (ost < 10) b[i] = ost + '0'; //zapisivaem v b[], esli >10 perevodim v bykvi
		else b[i] = ost + 'A' - 10;
		i++;
		a = (int)a / 16;

	}
	if (a < 10) b[i] = a + '0'; //poslednee chastnoe, esli >10 perevodim v bykvi
	else b[i] = a + 'A' - 10;

	int i2 = i;
	if (i2 % 2 == 1) i2++;

	for (int k = 0; k < i2 / 2; k++) //perevernyt masiy
	{
		int temp = b[k];
		b[k] = b[i - k];
		b[i - k] = temp;
	}

	if (a2 - (int)a2 > 0) //elsi float
	{
		i++;
		b[i] = '.';

		for (int j = 0; j < 6; j++)
		{
			a2 *= 16;
			ost = (int)a2;
			i++;

			if (ost >= 10)//bykvi
			{
				b[i] = ost + 55;
			}
			else //cifri
			{
				b[i] = ost + '0';
			}
			a2 = a2 - (int)a2;
		}
	}

	string s;
	for (int j = 0; j <= i; j++)
	{
		s += b[j];
	}
	return s;
}

float from16(string a)
{
	float number = 0;
	int i = 0;
	int step = 0;

	int dotcheck = 0;

	while (1)
	{
		if (a[i] == '.') dotcheck = 1;

		if (a[i] != NULL && dotcheck != 1)
		{
			i++;
			step++;
		}
		if (a[i] != NULL and dotcheck != 0)
		{
			i++;
		}
		if (a[i] == NULL) break;
	}

	for (int j = 0; j < i; j++)
	{
		if (a[j] != '.')
		{
			step--;
			if (a[j] >= 'A' and a[j] <= 'F')
			{
				number = number + pow(16, step) * (a[j] - 55);
			}
			else
				number = number + pow(16, step) * (a[j] - 48);
		}
	}
	//cout << number << endl;
	return number;
}

string to8(float a)
{
	char b[99]; int i = 0;
	float a2 = a - (int)a;
	float ost;

	while (a >= 8) //ostatok
	{
		ost = (int)a % 8; //zapominaem ostatok ot a/8
		if (ost < 8) b[i] = ost + '0'; //zapisivaem v b[], esli >10 perevodim v bykvi
		i++;
		a = (int)a / 8;

	}
	if (a < 10) b[i] = a + '0'; //poslednee chastnoe, esli >10 perevodim v bykvi

	int i2 = i;
	if (i2 % 2 == 1) i2++;

	for (int k = 0; k < i2 / 2; k++) //perevernyt masiy
	{
		int temp = b[k];
		b[k] = b[i - k];
		b[i - k] = temp;
	}

	if (a2 - (int)a2 > 0) //elsi float
	{
		i++;
		b[i] = '.';

		for (int j = 0; j < 6; j++)
		{
			a2 *= 8;
			ost = (int)a2;
			i++;
			{
				b[i] = ost + '0';
			}
			a2 = a2 - (int)a2;
		}
	}

	string s;
	for (int j = 0; j <= i; j++)
	{
		s += b[j];
	}
	return s;
}

float from8(string a)
{
	float number = 0;
	int i = 0;
	int step = 0;

	int dotcheck = 0;

	while (1)
	{
		if (a[i] == '.') dotcheck = 1;

		if (a[i] != NULL && dotcheck != 1)
		{
			i++;
			step++;
		}
		if (a[i] != NULL and dotcheck != 0)
		{
			i++;
		}
		if (a[i] == NULL) break;
	}

	for (int j = 0; j < i; j++)
	{
		if (a[j] != '.')
		{
			step--;
			number = number + pow(8, step) * (a[j] - 48);
		}
	}
	//cout << number << endl;
	return number;
}