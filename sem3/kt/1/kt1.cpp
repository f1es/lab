#include<iostream>
#include<string>
#include<list>

using namespace std;

enum tok_names { semocolon, ident, num, asgn, parentheses, OR, XOR, AND, NOT, boolean };

struct token
{
	enum tok_names token_name;
	string token_names[10] = { "Semocolon", "Ident", "Number", "Assign", "Parentheses", "OR", "XOR", "AND", "NOT", "boolean"};
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
		if (str[i] == 't' and str[i + 1] == 'r' and str[i + 2] == 'u' and str[i + 3] == 'e') {
			lexeme_table.push_back(add_token(boolean, "1"));
			i += 4;
		}

		if (str[i] == 'f' and str[i + 1] == 'a' and str[i + 2] == 'l' and str[i + 3] == 's' and str[i + 4] == 'e') {
			lexeme_table.push_back(add_token(boolean, "0"));
			i += 5;
		}

		if (str[i] == ':' and str[i + 1] == '=') {
			lexeme_table.push_back(add_token(asgn, ":="));
		}

		if (str[i] == ':' and str[i + 1] == '=') {
			lexeme_table.push_back(add_token(asgn, ":="));
		}

		if (str[i] == ';') {
			lexeme_table.push_back(add_token(semocolon, ";"));
		}

		if (str[i] == '(') {
			lexeme_table.push_back(add_token(parentheses, "("));
		}
		if (str[i] == ')') {
			lexeme_table.push_back(add_token(parentheses, ")"));
		}

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

		if ((str[i] >= 'a' and str[i] <= 'z') or (str[i] >= 'A' and str[i] <= 'Z')) {
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

		i++;
	}
	return lexeme_table;
}

int main()
{
	token tok;
	string str = " (ab1a := 23) and (true) xor (false)";
	list<token> lexeme_table = lexer(str);

	while (lexeme_table.empty() == 0) {
		tok = lexeme_table.front();
		cout << "<TOKEN_NAME:" << tok.token_names[tok.token_name] << ",\t" << "TOKEN_VALUE:" << tok.token_value << ">" << endl;
		lexeme_table.pop_front();
	}
}
