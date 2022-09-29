#include <iostream>
#include <stdlib.h>
#include <windows.h>
using namespace std;

string to2(float a); //lab1
float from2(string a);

string to10bi(float a); //lab2
int from10bi(string str);
int* toASCII(string str);
string fromASCII(int a[200]);
string reverseCode(string str);
string dopCode(string str);
string reverseplus(string str1, string str2);
string dopPlus(string str1, string str2);
string toBiTen(int a);
int fromBiTen(string str);

struct normalNumber {
	double number;
	int step;
};
normalNumber toNN(double a);
normalNumber plusNN(normalNumber a, normalNumber b);
normalNumber minusNN(normalNumber a, normalNumber b);
normalNumber xNN(normalNumber a, normalNumber b);
normalNumber divNN(normalNumber a, normalNumber b);

string reverse(string a); //help
long long StringToInt(string str);
string IntToString(long long a);
int Rank(int a);
void module();

string plus2(int a, int b);
string minus2(int a, int b);

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	/*while (1) {
		double b; cin >> b;
		normalNumber a = toNN(b);
		cout << "numb = " << a.number << " step = " << a.step << endl;
	}*/
	module();
}

void module()
{
	while (1)
	{
		cout << "--------------------------" << endl;
		cout << "0 - перевод из двоичной-десятичной " << endl;
		cout << "1 - перевод в двоично-десятичную" << endl;
		cout << "2 - операции над 2" << endl;
		cout << "3 - ASCII" << endl;
		cout << "4 - Прямой, обратный, дополнительный код " << endl;
		cout << "5 - Операции над числами с плавающей точкой" << endl;

		float to_number;
		string from_number;
		int choice = 0; cin >> choice;
		int sschoice;
		double first_number, second_number;
		string first_str_number, second_str_number;
		switch (choice)
		{
		case 0: // перевод из
			cout << "Введите число: "; cin >> from_number;
			cout << fromBiTen(from_number);
			break;
			//////////////////////
		case 1:
			cout << "Введите число: "; cin >> to_number;
			cout << toBiTen(to_number);
			break;
			////////////////////////
		case 2:
			cout << "1 - Обратное сложение, 2 - Дополнительное сложение: "; cin >> sschoice;
			cout << "Введите первое число: "; cin >> first_number;
			cout << "Введите второе число: "; cin >> second_number;
			switch (sschoice) //операции над 2 
			{
			case 1:
				cout << reverseplus(to10bi(first_number), to10bi(second_number)) << endl;
				cout << from10bi(reverseplus(to10bi(first_number), to10bi(second_number))) << endl;
				break;
			case 2:
				cout << dopPlus(to10bi(first_number), to10bi(second_number)) << endl;
				cout << from10bi(dopPlus(to10bi(first_number), to10bi(second_number))) << endl;
				break;
			}
			break;
		case 3:
			cout << "1 - В аски код, 2 - Из аски кода: "; cin >> sschoice;
			switch (sschoice) //операции над 2 
			{
			case 1:
				toASCII("Дешифруйте данный текст, используя таблицу ASCII-кодов");
				break;
			case 2:
				int a[200] = { -60, -27, -8, -24, -12, -16, -13, -23, -14, -27, 32, -28, -32, -19, -19, -5, -23, 32, -14, -27, -22, -15, -14, 44, 32, -24, -15, -17, -18, -21, -4, -25, -13, -1, 32, -14, -32, -31, -21, -24, -10, -13, 32, 65, 83, 67, 73, 73, 45, -22, -18, -28, -18, -30, -34 };
				cout << fromASCII(a) << endl;
				break;
			}
			break;
		case 4:
			cout << "Введите число: "; cin >> first_number;
			cout << "Прямой код: " << to10bi(first_number) << endl;
			cout << "Обратный код: " << reverseCode(to10bi(first_number)) << endl;
			cout << "Дополнительный код: " << dopCode(to10bi(first_number)) << endl;
			break;
		case 5:
			normalNumber a, b;
			cout << "1 - Сложение " << endl;
			cout << "2 - Вычитание " << endl;
			cout << "3 - Умножение " << endl;
			cout << "4 - Деление " << endl;
			cin >> sschoice;

			cout << "Введите первое число: "; cin >> first_number; a = toNN(first_number);
			cout << "Введите второе число: "; cin >> second_number; b = toNN(second_number);
			switch (sschoice) //операции над 2 
			{
			case 1:
				a = plusNN(a, b);
				cout << "Результат : " << a.number << " * 10^" << a.step << endl;
				break;
			case 2:
				a = minusNN(a, b);
				cout << "Результат : " << a.number << " * 10^" << a.step << endl;
				break;
			case 3:
				a = xNN(a, b);
				cout << "Результат : " << a.number << " * 10^" << a.step << endl;
				break;
			case 4:
				a = divNN(a, b);
				cout << "Результат : " << a.number << " * 10^" << a.step << endl;
				break;
			}
			break;
		}
		cout << endl;
	}
}

normalNumber minusNN(normalNumber a, normalNumber b)
{
	normalNumber Summa;
	Summa.number = (a.number * pow(10, a.step - b.step) - b.number) * pow(10, b.step);
	Summa = toNN(Summa.number);
	return Summa;
}
normalNumber xNN(normalNumber a, normalNumber b)
{
	normalNumber Summa;
	Summa.number = (a.number * b.number) * pow(10, b.step + a.step);
	Summa = toNN(Summa.number);
	return Summa;
}
normalNumber divNN(normalNumber a, normalNumber b)
{
	normalNumber Summa;
	Summa.number = (a.number / b.number) * pow(10, b.step - a.step);
	Summa = toNN(Summa.number);
	return Summa;
}
normalNumber plusNN(normalNumber a, normalNumber b)
{
	normalNumber Summa;
	Summa.number = (a.number * pow(10, a.step - b.step) + b.number) * pow(10, b.step);
	Summa = toNN(Summa.number);
	return Summa;
}
normalNumber toNN(double a)
{
	normalNumber num;
	num.number = a;
	num.step = 0;

	if (num.number == 0) return num;

	while (abs((int)num.number) > 0)
	{
		num.number /= 10;
		num.step++;
	}

	while (abs(num.number) < 0.1)
	{
		num.number *= 10;
		num.step--;
	}

	return num;
}

string reverse(string a) //perevernyt masiy
{
	int i = a.size() - 1;
	for (int j = 0; j <= i / 2; j++)
	{
		int temp = a[j];
		a[j] = a[i - j];
		a[i - j] = temp;
	}
	return a;
}

string reverseCode(string str)
{
	if (str[0] == '0') return str;
	else for (int i = 1; i < str.size(); i++) {
		if (str[i] == '1') str[i] = '0';
		else str[i] = '1';
	}
	return str;
}
string reverseplus(string str1, string str2)
{
	int cc = from10bi(str1) + from10bi(str2); // proverka znaka
	if (cc == 0) return "0";

	string str;
	if (str1[0] == '1') {
		str1 = reverseCode(str1);
	}
	if (str2[0] == '1') {
		str2 = reverseCode(str2);
	}

	str = plus2(StringToInt(str1), StringToInt(str2));

	if ((from10bi(str1) + from10bi(str2) < 0) and (str.size() > max(str1.size(), str2.size()) )) { //magick
			str = plus2(StringToInt(str), 1);
			str = plus2(StringToInt(str), pow(10, str.size() - 1) * -1);
			if (cc < 0) {
				str = reverseCode(str);
			}
		}
	else if (from10bi(str1) + from10bi(str2) < 0) str = reverseCode(str);

	if (cc < 0) return str;
	else return str = to10bi(from2(str));

	return str;
}

string dopCode(string str)
{
	//str = reverseCode(str);
	if (str[0] == '0') return str;
	str = reverseCode(str);

	long long a = StringToInt(str);
	str = plus2(a, 1);

	return str;
}
string dopPlus(string str1, string str2)
{
	int cc = from10bi(str1) + from10bi(str2); // proverka znaka
	if (cc == 0) return "0";

	string str;
	int rev = 0;
	if (str1[0] == '1') {
		str1 = reverseCode(str1);
		str1 = plus2(StringToInt(str1), 1);
	}
	if (str2[0] == '1') {
		str2 = reverseCode(str2);
		str2 = plus2(StringToInt(str2), 1);
	}
	str = plus2(StringToInt(str1), StringToInt(str2));

	if ((from10bi(str1) + from10bi(str2) < 0) and (str.size() > max(str1.size(), str2.size()))) { //magick
		str = plus2(StringToInt(str), pow(10, str.size() - 1) * -1);
		if (from10bi(str) < 0) { 
			str = minus2(StringToInt(str), 1);
			str = reverseCode(str); 
		}
	}
	else if (from10bi(str1) + from10bi(str2) < 0) {
		str = minus2(StringToInt(str), 1);
		str = reverseCode(str);
	}

	if (cc < 0) return str;
	else return str = to10bi(from2(str));

	return str;
}

long long StringToInt(string str)
{
	long long a = 0;
	for (int i = 0; i < str.size(); i++)
	{
		a += (str[i] - '0') * pow(10, str.size() - i - 1);
	}
	return a;
}
string IntToString(long long a)
{
	long long a2 = a;
	int counter = -1;
	while (a2 != 0) {
		a2 /= 10;
		counter++;
	}
	string str;
	for (int i = 0; i <= counter; i++)
	{
		str += a % 10 + '0';
		a /= 10;
	}
	str = reverse(str);
	return str;
}

int Rank(int a) {
	int rank = 0;

	while (a > 0) {
		rank++;
		a /= 10;
	}

	return rank;
}

int* toASCII(string str)
{
	int* a;
	a = new int[str.size()];

	for (int i = 0; i < str.size(); i++)
	{
		a[i] = str[i];
	}

	for (int i = 0; i < str.size(); i++)
	{
		cout << a[i] << ", ";
	}

	cout << endl;
	return a;
}
string fromASCII(int a[200])
{
	string str = "";

	int j = 0;
	while (a[j] != NULL) j++;
	j--;
	for (int i = 0; i < j; i++)
	{
		str += a[i];
	}

	//cout << str;

	return str;
}

string toBiTen(int a)
{
	string str;
	string temp_str;

	a = StringToInt(reverse(IntToString(a)));

	while (a > 0)
	{
		temp_str += to2(a % 10);
		temp_str = reverse(temp_str);
		while (temp_str.size() % 4 != 0)
		{
			temp_str += '0';
		}
		str += reverse(temp_str);
		temp_str = "";
		a /= 10;
	}

	return str;
}
int fromBiTen(string str)
{
	int a = 0;
	string temp_str;
	int step = 0;

	while (str.size() != 0)
	{
		for (int i = 0; i < 4; i++)
		{
			temp_str += str[0];
			str.erase(0, 1);
		}
		a += from2(temp_str) * pow(10, step);
		step++;
		temp_str = "";
	}

	a = StringToInt(reverse(IntToString(a)));

	return a;
}
string to10bi(float a)
{
	string str = "";
	str = to2(a);

	str = reverse(str);

	int aaa = str.size() % 4;
	if (str.size() > 4)
		for (int i = aaa; i < 3; ++i)
		{
			str.push_back('0');
		}
	else if (str.size() < 3)
		for (int i = str.size(); i < 3; i++)
		{
			str.push_back('0');
		}
	else if (str.size() == 4)
		for (int i = 0; i < 3; i++)
		{
			str.push_back('0');
		}
	if (a < 0) str.push_back('1');
	else str.push_back('0');

	str = reverse(str);
	return str;
}
int from10bi(string str)
{
	int minus = 1;
	if (str[0] == '1') {
		minus = -1;
		str[0] = '0';
	}

	int a = from2(str);
	return a * minus;
}

string plus2(int a, int b)
{
	int result;
	result = a + b;
	int temp = result;

a: //
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

	петя--;

	string str = IntToString(result);
	return str;
}
string minus2(int a, int b)
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
	string str = IntToString(result);
	return str;
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