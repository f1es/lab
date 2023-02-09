#include<iostream>
#include<string>
#include<list>

using namespace std;

///////lex analiz
enum tok_names { semocolon, ident, num, asgn, parentheses, OR, boolean, romnum, cycle, DO, math };
struct token
{
	enum tok_names token_name;
	string token_names[11] = { "Semocolon", "ident", "Number", "Assign", "Parentheses", "OR", "boolean", "RomanNumerals", "Cycle", "Do", "Math"};
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
		if (str[i] == ':' and str[i + 1] == '=') {
			lexeme_table.push_back(add_token(asgn, ":="));
			i += 2;
		}

		if (str[i] == ';') {lexeme_table.push_back(add_token(semocolon, ";"));}

		if (str[i] == '(') {lexeme_table.push_back(add_token(parentheses, "("));}
		if (str[i] == ')') {lexeme_table.push_back(add_token(parentheses, ")"));}

		if (str[i] == 'o' and str[i + 1] == 'r') {
			lexeme_table.push_back(add_token(OR, "or"));
			i += 2;
		}

		if (str[i] == '|') {lexeme_table.push_back(add_token(OR, "or"));}

		if (str[i] == '+' ) {lexeme_table.push_back(add_token(math, "+"));}
		if (str[i] == '-') { lexeme_table.push_back(add_token(math, "-")); }
		if (str[i] == '*') { lexeme_table.push_back(add_token(math, "*")); }
		if (str[i] == '/') { lexeme_table.push_back(add_token(math, "/")); }

		if (str[i] == 'f' and str[i + 1] == 'o' and str[i + 2] == 'r') {
			lexeme_table.push_back(add_token(cycle, "for"));
			i += 3;
		}

		if (str[i] == 'd' and str[i + 1] == 'o') {
			lexeme_table.push_back(add_token(DO, "do"));
			i += 2;
		}

		if ((str[i] == 'I' or str[i] == 'V' or str[i] == 'X')) {
			string number = "";

			while (str[i] == 'I' or str[i] == 'V' or str[i] == 'X')
			{

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
			while ((str[i] >= '0' and str[i] <= '9') or str[i] == '.')
			{
				number += str[i];
				i++;
			}
			i--;
			lexeme_table.push_back(add_token(num, number));
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
	if (token.token_name != romnum and token.token_name != num and token.token_name != ident) {
		pushTree(token, &(*t)->r);
		return;
	}
	if ((token.token_name == romnum or token.token_name == num or token.token_name == ident) and (*t)->l == NULL) {
		pushTree(token, &(*t)->l);
		return;
	}
	else {
		pushTree(token, &(*t)->r);
		return;
	}
}

void printTree(node* t, int u, bool Direction) //Input
{
	if (t == NULL) return;                  //Если дерево пустое, то отображать нечего, выходим
	else //Иначе
	{

		printTree(t->l, ++u, 1);                   //С помощью рекурсивного посещаем левое поддерево
		for (int i = 0; i < u; ++i) cout << "|";
		//cout << ' ';
		if (u != 1) Direction == 1 ? cout << "<left>" : cout << "<right>";
		//cout << t->token.token_names[t->token.token_name] << endl;            //И показываем элемент
		cout << "\t" << t->token.token_value << endl;
		u--;
	}
	printTree(t->r, ++u, 0);                       //С помощью рекурсии посещаем правое поддерево
}

int main()
{
	token tok;
	string str = "A + 12.1 + XVI";
	list<token> lexeme_table = lexer(str);


	list<token> temp = lexeme_table;
	while (temp.empty() == 0) {
		tok = temp.front();
		cout << "<TOKEN_NAME:" << tok.token_names[tok.token_name] << ",\t" << "TOKEN_VALUE:" << tok.token_value << ">" << endl;
		temp.pop_front();
	}
	cout << endl;

	list<token> znak;
	list<token> identif;
	temp = lexeme_table;
	while (temp.size() > 0)
	{
		if (temp.front().token_name == num or temp.front().token_name == romnum or temp.front().token_name == ident) {
			identif.push_back(temp.front());
			temp.pop_front();
		}
		else {
			znak.push_back(temp.front());
			temp.pop_front();
		}
	}

	node* sosna = NULL;

	while (znak.size() > 0 or identif.size() > 0)
	{
		if (znak.size() > 0) {
			pushTree(znak.front(), &sosna);
			znak.pop_front();
		}
		else
		{
			pushTree(identif.front(), &sosna);
			identif.pop_front();
		}
	}


	printTree(sosna, 0, 1);
}
