#include<iostream>
#include<string>

using namespace std;

int hash_function(string str);
//string multi_hash(string str, int id);

int main()
{
	string hash_table[200];
	int a[3];
	int b[3];
	//a = b;
	string str;
	//cin >> str;

	int id = hash_function(str), n = 1;
	for (int i = 0; i < 3; i++)
	{
		cin >> str;
		id = hash_function(str);
		while (1)
		{
			if (hash_table[id] == "")
			{
				hash_table[id] = str;
				break;
			}
			else id *= ++n;
		}
	}

	//hash_table = hash_function(hash_table, str);
	for (int i = 0; i < 200; i++)
	{
		if (hash_table[i] != "") cout << hash_table[i] << endl;
	}
	//cout << hash_table[hash_function(str)] << endl;
}

int hash_function(string str)
{
	int id = 0;

	for (int i = 0; i < str.size(); i++)
	{
		id += str[i];
	}

	id %= 200;
	//hash_table[id] = str;

	return id;
}