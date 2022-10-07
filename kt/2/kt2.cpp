#include<iostream>
#include<string>
#include<list>

using namespace std;

int hash_function(string str);

int main()
{
	int const AMOUNT = 100;
	string hash_table1[AMOUNT];
	list<string> hash_table2;
	

	string str;

	int id = hash_function(str), n = 1;
	for (int i = 0; i < AMOUNT; i++)
	{
		for (int j = 0; j < 5; j++) str += (rand() % 26) + 97;
		hash_table2.push_back(str);

		id = hash_function(str);
		int breaker = 0;
		while (1)
		{
			if (hash_table1[id] == "")
			{
				hash_table1[id] = str;

				breaker = 0;
				break;
			}
			else if (breaker < 50) id = (id * ++n) % AMOUNT;
			else id = (id + 1) % AMOUNT;

			breaker++;
		}
		str = "";
	}


	//hash_table2.sort(hash_table2.front(), hash_table2.back());
	//hash_table = hash_function(hash_table, str);

	for (int i = 0; i < AMOUNT; i++)
	{
		if (hash_table1[i] != "") cout << hash_table1[i] << " | ";
	}
	cout << endl;

	string search = ""; cin >> search;

	n = 0; id = hash_function(search);
	int breaker = 0;
	int counter = 0;
	while (1)
	{
		if (search == hash_table1[id])
		{
			cout << "Rehashing with multiplication" << endl;
			cout << "\t" << search << " was Found" << endl;
			cout << "\tCounts = "<< counter + 1<< endl;
			break;
		}
		else if (breaker < 50)id = (id * ++n) % AMOUNT;
		if (breaker > 50) id = (id + 1) % AMOUNT;

		counter++;
		breaker++;
	}
	
	counter = 0;
	while (1)
	{
		if (search == hash_table2.front())
		{
			cout << "List" << endl;
			cout << "\t" << search << " was Found" << endl;
			cout << "\tCounts = " << counter + 1<< endl;
			break;
		}
		else hash_table2.pop_front();

		counter++;
	}
}

int hash_function(string str)
{
	int id = 0;

	for (int i = 0; i < str.size(); i++)
	{
		id += str[i];
	}
	id %= 100;

	return id;
}