#include<iostream>
#include<string>
#include<list>

using namespace std;

enum tok_names {semocolon, ident, num, asgn, parentheses, OR, XOR, AND, NOT };

struct token
{
	enum tok_names token_name;
	string token_names[9] = { "Semocolon", "Ident", "Number", "Assign", "Parentheses", "OR", "XOR", "AND", "NOT"};
	int token_value;
};

list<token> lexeme_table;

token add_token(tok_names a, int b) {
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
			lexeme_table.push_back(add_token(asgn, 0));
		}

		if (str[i] == ';') {
			lexeme_table.push_back(add_token(semocolon, 0));
		}

		if (str[i] == '(' or str[i] == ')') {
			lexeme_table.push_back(add_token(parentheses, 0));
		}

		if (str[i] == 'n' and str[i + 1] == 'o' and str[i + 2] == 't') {
			lexeme_table.push_back(add_token(NOT, 0));
			i += 3;
		}

		if (str[i] == 'a' and str[i + 1] == 'n' and str[i + 2] == 'd') {
			lexeme_table.push_back(add_token(AND, 0));
			i += 3;
		}

		if (str[i] == 'x' and str[i + 1] == 'o' and str[i + 2] == 'r') {
			lexeme_table.push_back(add_token(XOR, 0));
			i += 3;
		}

		if (str[i] == 'o' and str[i + 1] == 'r') {
			lexeme_table.push_back(add_token(OR, 0));
			i += 2;
		}

		if ((str[i] >= 'a' and str[i] <= 'z') or (str[i] >= 'A' and str[i] <= 'Z')) {
			lexeme_table.push_back(add_token(ident, str[i]));
		}

		if ((str[i] >= '0' and str[i] <= '9')) {
			lexeme_table.push_back(add_token(num, str[i]));
		}

		i++;
	}
	return lexeme_table;
}

int main()
{
	//lexeme_table table;
	token tok;
	string str = "a := 2";
	list<token> lexeme_table = lexer(str);

	while (lexeme_table.empty() == 0) {
		tok = lexeme_table.front();
		cout << "<TOKEN_NAME:" << tok.token_names[tok.token_name] << ",\t" << "TOKEN_VALUE:" << tok.token_value << ">" << endl;
		lexeme_table.pop_front();
	}
}