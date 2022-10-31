#include<iostream>
#include<string>
#include<list>
#include<xtree>

using namespace std;

///////lex analiz
enum tok_names { semocolon, ident, num, asgn, parentheses, OR, XOR, AND, NOT, boolean, romnum };
struct token
{
	enum tok_names token_name;
	string token_names[11] = { "Semocolon", "Ident", "Number", "Assign", "Parentheses", "OR", "XOR", "AND", "NOT", "boolean", "RomanNumerals" };
	string token_value;
};
list<token> lexeme_table;

token add_token(tok_names a, string b) {
	token tok;

	tok.token_name = a;
	tok.token_value = b;

	return tok;
}
list<token> lexer(string str)
{
	list<token> lexeme_table;

	int i = 0; int value = 0;
	while (i < str.size())
	{
		/*if (str[i] == 't' and str[i + 1] == 'r' and str[i + 2] == 'u' and str[i + 3] == 'e') {
			lexeme_table.push_back(add_token(boolean, "1"));
			i += 4;
		}

		if (str[i] == 'f' and str[i + 1] == 'a' and str[i + 2] == 'l' and str[i + 3] == 's' and str[i + 4] == 'e') {
			lexeme_table.push_back(add_token(boolean, "0"));
			i += 5;
		}*/

		if (str[i] == ':' and str[i + 1] == '=') {
			lexeme_table.push_back(add_token(asgn, ":="));
		}

		if (str[i] == ':' and str[i + 1] == '=') {
			lexeme_table.push_back(add_token(asgn, ":="));
		}

		if (str[i] == ';') {
			lexeme_table.push_back(add_token(semocolon, ";"));
		}

		/*if (str[i] == '(') {
			lexeme_table.push_back(add_token(parentheses, "("));
		}
		if (str[i] == ')') {
			lexeme_table.push_back(add_token(parentheses, ")"));
		}*/

		if (str[i] == 'n' and str[i + 1] == 'o' and str[i + 2] == 't') {
			lexeme_table.push_back(add_token(NOT, "not"));
			i += 3;
		}

		if (str[i] == 'a' and str[i + 1] == 'n' and str[i + 2] == 'd') {
			lexeme_table.push_back(add_token(AND, "and"));
			i += 3;
		}

		if (str[i] == 'x' and str[i + 1] == 'o' and str[i + 2] == 'r') {
			lexeme_table.push_back(add_token(XOR, "xor"));
			i += 3;
		}

		if (str[i] == 'o' and str[i + 1] == 'r') {
			lexeme_table.push_back(add_token(OR, "or"));
			i += 2;
		}

		if ((str[i] >= 'a' and str[i] <= 'z') or (str[i] >= 'A' and str[i] <= 'Z') and (str[i] != 'X' and str[i] != 'V' and str[i] != 'I')) {
			string var = "";
			while ((str[i] >= 'a' and str[i] <= 'z') or (str[i] >= 'A' and str[i] <= 'Z') or (str[i] >= '0' and str[i] <= '9'))
			{
				var += str[i];
				i++;
			}
			i--;
			lexeme_table.push_back(add_token(ident, var));
		}

		if ((str[i] >= '0' and str[i] <= '9')) {
			string number = "";
			while (str[i] >= '0' and str[i] <= '9')
			{
				number += str[i];
				i++;
			}
			i--;
			lexeme_table.push_back(add_token(num, number));
		}

		if ((str[i] == 'I' or str[i] == 'V' or str[i] == 'X')) {
			string number = "";

			while (str[i] == 'I' or str[i] == 'V' or str[i] == 'X')
			{

				/*if (str[i] == 'I' and str[i + 1] == 'X') {
					number += str[i];
					number += str[i + 1];
					i += 2;
				}

				if (str[i] == 'I' and str[i + 1] == 'V') {
					number += str[i];
					number += str[i + 1];
					i += 2;
				}*/

				if (str[i] == 'I') {
					number += str[i];
					i++;
				}

				if (str[i] == 'X') {
					number += str[i];
					i++;
				}

				if (str[i] == 'V') {
					number += str[i];
					i++;
				}

				if (i > str.size()) break;
			}
			lexeme_table.push_back(add_token(romnum, number));
		}

		i++;
	}
	return lexeme_table;
}

////////tree
struct node
{
	token token;                           //Информационное поле
	node* l, * r;                        //Левая и Правая часть дерева
};
node* tree = NULL;                      //Объявляем переменную, тип которой структура Дерево

void pushTree(token token, node** t) //Add
{
	if ((*t) == NULL)                   //Если дерева не существует
	{
		(*t) = new node;                //Выделяем память
		(*t)->token = token;                 //Кладем в выделенное место аргумент a
		(*t)->l = (*t)->r = NULL;       //Очищаем память для следующего роста
		return;                         //Заложили семечко, выходим
	}
	//Дерево есть
	if (token.token_name == num or token.token_name == romnum) pushTree(token, &(*t)->l); //Если аргумент а больше чем текущий элемент, кладем его вправо
	else pushTree(token, &(*t)->r);         //Иначе кладем его влево
}

void printTree(node* t, int u) //Input
{
	if (t == NULL) return;                  //Если дерево пустое, то отображать нечего, выходим
	else //Иначе
	{
		
		printTree(t->l, ++u);                   //С помощью рекурсивного посещаем левое поддерево
		for (int i = 0; i < u; ++i) cout << "|";
		cout << t->token.token_names[t->token.token_name] << endl;            //И показываем элемент
		u--;
	}
	printTree(t->r, ++u);                       //С помощью рекурсии посещаем правое поддерево
}

//int main()
//{
//	int n;                              //Количество элементов
//	int s;                              //Число, передаваемое в дерево
//	cout << "введите количество элементов  ";
//	cin >> n;                           //Вводим количество элементов
//
//	for (int i = 0; i < n; ++i)
//	{
//		cout << "ведите число  ";
//		cin >> s;                       //Считываем элемент за элементом
//
//		pushTree(s, &tree);                 //И каждый кладем в дерево
//	}
//	cout << "ваше дерево\n";
//	printTree(tree, 0);
//	cin.ignore().get();
//}

int main()
{
	token tok;
	string str = "X or X and X";
	list<token> lexeme_table = lexer(str);

	/*while (lexeme_table.empty() == 0) {
		tok = lexeme_table.front();
		cout << "<TOKEN_NAME:" << tok.token_names[tok.token_name] << ",\t" << "TOKEN_VALUE:" << tok.token_value << ">" << endl;
		lexeme_table.pop_front();
	}*/

	list<token> znak;
	list<token> ident;

	list<token> temp = lexeme_table;

	while (temp.size() > 0)
	{
		if (temp.front().token_name == num or temp.front().token_name == romnum) {
			ident.push_back(temp.front());
			temp.pop_front();
		}
		else {
			znak.push_back(temp.front());
			temp.pop_front();
		}
	}
	
	node* sosna = NULL;

	while (znak.size() > 0 or ident.size() > 0)
	{
		if (znak.size() > 0) {
			pushTree(znak.front(), &sosna);
			znak.pop_front();
		}
		else
		{
			pushTree(ident.front(), &sosna);
			ident.pop_front();
		}
	}

	/*pushTree(lexeme_table.front(), &sosna);
	lexeme_table.pop_front();
	pushTree(lexeme_table.front(), &sosna);
	lexeme_table.pop_front();
	pushTree(lexeme_table.front(), &sosna);
	lexeme_table.pop_front();
	pushTree(lexeme_table.front(), &sosna);
	lexeme_table.pop_front();
	pushTree(lexeme_table.front(), &sosna);
	lexeme_table.pop_front();*/
	printTree(sosna, 0);
}
