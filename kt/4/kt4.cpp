#include<iostream>
#include<string>
#include<list>

#include <vector>
#include <functional>
#include <tuple>

using namespace std;

///////lex analiz
static string Ident = "Ident", Number = "Number", Math = "Math", Assign = "Assign", RomeNumerals = "RomeNumerals";
struct token
{
	string token_name;
	string token_value;
};

token add_token(string token_name, string token_value) {
	token tok;

	tok.token_name = token_name;
	tok.token_value = token_value;

	return tok;
}

//list<token> lexeme_table;
list<token> lexer(string str)
{
	list<token> lexeme_table;

	int i = 0; int value = 0;
	while (i < str.size())
	{

		if (str[i] == ':' and str[i + 1] == '=') { lexeme_table.push_back(add_token(Assign, ":=")); }

		if (str[i] == '+') { lexeme_table.push_back(add_token(Math, "+")); }
		if (str[i] == '-') { lexeme_table.push_back(add_token(Math, "-")); }
		if (str[i] == '*') { lexeme_table.push_back(add_token(Math, "*")); }
		if (str[i] == '/') { lexeme_table.push_back(add_token(Math, "/")); }

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
			lexeme_table.push_back(add_token(RomeNumerals, number));
		}

		if ((str[i] >= 'a' and str[i] <= 'z') or (str[i] >= 'A' and str[i] <= 'Z') and str[i] != 'I' and str[i] != 'V' and str[i] != 'X') {
			string var = "";
			while ((str[i] >= 'a' and str[i] <= 'z') or (str[i] >= 'A' and str[i] <= 'Z') or (str[i] >= '0' and str[i] <= '9'))
			{
				var += str[i];
				i++;
			}
			i--;
			lexeme_table.push_back(add_token(Ident, var));
		}

		if ((str[i] >= '0' and str[i] <= '9')) {
			string number = "";
			while (str[i] >= '0' and str[i] <= '9')
			{
				number += str[i];
				i++;
			}
			i--;
			lexeme_table.push_back(add_token(Number, number));
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

void pushTree(token token, node** t) //dobavlenie ddlya +/- i operandov
{
	if ((*t) == NULL)
	{
		(*t) = new node;
		(*t)->token = token;
		(*t)->l = (*t)->r = NULL;
		return;
	}

	if (token.token_name != Number and token.token_name != Ident and token.token_name != RomeNumerals) //ostalnoje pravo
	{
		pushTree(token, &(*t)->r);
		return;
	}
	if ((token.token_name == Number or token.token_name == Ident or token.token_name == RomeNumerals) and (*t)->l == NULL) //esli identificator i levo pusto to levo
	{
		pushTree(token, &(*t)->l);
		return;
	}
	else {
		pushTree(token, &(*t)->r); // esli levo zanyato to pravo
		return;
	}
}

void printTriad(node** t, int u)
{
	if ((*t)->r->token.token_name == Math)
	{
		printTriad(&(*t)->r, ++u);
		cout << u << ". ";

		cout << (*t)->token.token_value;
		if ((*t)->l->token.token_name != Math) cout << '(' << u + 1 << '^' << ',' << (*t)->l->token.token_value << ')' << endl;
		else cout << '(' << u + 1 << "^," << u << '^' << ')' << endl;

		if ((*t)->l->token.token_name == Math)
		{
			cout << u << ". ";
			cout << (*t)->l->token.token_value;
			cout << '(' << (*t)->l->r->token.token_value << ',' << (*t)->l->l->token.token_value << ')' << endl;
		}
	}
	else
	{
		u++;
		cout << u << ". ";
		cout << (*t)->token.token_value << '(' << (*t)->r->token.token_value << ',' << (*t)->l->token.token_value << ')' << endl;
		return;
	}
}

void printTreeOld(node* t, int u, bool Direction) //Input
{
	if (t == NULL) return;                  //Если дерево пустое, то отображать нечего, выходим
	else //Иначе
	{
		printTreeOld(t->l, ++u, 1);                   //С помощью рекурсивного посещаем левое поддерево
		for (int i = 0; i < u; ++i) cout << "/";
		if (u != 1) Direction == 1 ? cout << "<left>" : cout << "<right>";
		cout << "\t" << t->token.token_value << endl;
		u--;
	}
	printTreeOld(t->r, ++u, 0);                       //С помощью рекурсии посещаем правое поддерево
}

void printTree(node const* t) {
	static std::string ch_hor = "-", ch_ver = "|", ch_ddia = "/", ch_rddia = "\\", ch_udia = "\\", ch_ver_hor = "|-", ch_udia_hor = "\\-", ch_ddia_hor = "/-", ch_ver_spa = "| ";
#define _MAX(x, y) ((x) > (y) ? (x) : (y))
#define _MIN(x, y) ((x) < (y) ? (x) : (y))

	auto RepStr = [](std::string const& s, size_t cnt) {
		if (ptrdiff_t(cnt) < 0)
			throw std::runtime_error("RepStr: Bad value " + std::to_string(ptrdiff_t(cnt)) + "!");
		std::string r;
		for (size_t i = 0; i < cnt; ++i)
			r += s;
		return r;
	};
	std::function<std::tuple<std::vector<std::string>, size_t, size_t>(node const* t, bool)> Rec;
	Rec = [&RepStr, &Rec](node const* t, bool left) {
		std::vector<std::string> lines;
		if (!t)
			return std::make_tuple(lines, size_t(0), size_t(0));
		auto sval = (t->token.token_value);
		//if (sval.size() % 2 != 1) sval += " ";
		auto resl = Rec(t->l, true), resr = Rec(t->r, false);
		auto const& vl = std::get<0>(resl);
		auto const& vr = std::get<0>(resr);
		auto cl = std::get<1>(resl), cr = std::get<1>(resr), lss = std::get<2>(resl), rss = std::get<2>(resr);
		size_t lv = sval.size();
		size_t ls = vl.size() > 0 ? lss : size_t(0);
		size_t rs = vr.size() > 0 ? rss : size_t(0);
		size_t lis = ls == 0 ? lv / 2 : _MAX(int(lv / 2 + 1 - (ls - cl)), 0);
		size_t ris = rs == 0 ? (lv + 1) / 2 : _MAX(int((lv + 1) / 2 - cr), (lis > 0 ? 0 : 1));
		size_t dashls = (ls == 0 ? 0 : ls - cl - 1 + lis - lv / 2), dashrs = (rs == 0 ? 0 : cr + ris - (lv + 1) / 2);
		//DEB(node->value); DEB(lv); DEB(ls); DEB(rs); DEB(cl); DEB(cr); DEB(lis); DEB(ris); DEB(dashls); DEB(dashrs); std::cout << std::endl;
		lines.push_back(
			(ls == 0 ? "" : (RepStr(" ", cl) + ch_ddia + RepStr(ch_hor, dashls))) +
			sval + (rs == 0 ? "" : (RepStr(ch_hor, dashrs) + ch_rddia + RepStr(" ", rs - cr - 1)))
		);
		//if (lines.back().size() != ls + lis + ris + rs)
		//    throw std::runtime_error("Dump: First line wrong size, got " + std::to_string(lines.back().size()) + ", expected " + std::to_string(ls + lis + ris + rs));
		for (size_t i = 0; i < _MAX(vl.size(), vr.size()); ++i) {
			std::string sl = RepStr(" ", ls), sr = RepStr(" ", rs);
			if (i < vl.size()) sl = vl[i];
			if (i < vr.size()) sr = vr[i];
			sl = sl + RepStr(" ", lis);
			sr = RepStr(" ", ris) + sr;
			lines.push_back(sl + sr);
		}
		return std::make_tuple(lines, (left || ls + lis == 0 || lv % 2 == 1) ? ls + lis : ls + lis - 1, ls + lis + ris + rs);
	};
	auto v = std::get<0>(Rec(t, true));
	for (size_t i = 0; i < v.size(); ++i)
		std::cout << v[i] << std::endl;

#undef _MAX
#undef _MIN
}

int main()
{
	setlocale(LC_ALL, "");
	token tok;
	string str = "A := B * 12 * IX + C"; //A + B + 12 * 13 + C + D //1 * 2 + A
	list<token> lexeme_table = lexer(str);

	list<token> temp = lexeme_table;
	while (temp.empty() == 0) {
		tok = temp.front();
		cout << "<TOKEN_NAME:" << tok.token_name << ",\t" << "TOKEN_VALUE:" << tok.token_value << ">" << endl;
		temp.pop_front();
	}
	cout << endl;

	list<token> znak; //tyt znaki
	list<token> identif; //tyt cifri
	temp = lexeme_table;
	while (temp.size() > 0) //razdelyaet identifikatori i operatori(cifri i znaki)
	{
		if (temp.front().token_name == Number or temp.front().token_name == Ident or temp.front().token_name == RomeNumerals) {
			identif.push_back(temp.front());
			temp.pop_front();
		}
		else {
			znak.push_back(temp.front());
			temp.pop_front();
		}
	}
	node* sosna = NULL;

	while (znak.size() > 0)
	{
		pushTree(znak.front(), &sosna); //dobavlyet operandi v derevo
		znak.pop_front();
	}

	while (identif.size() > 0)
	{
		pushTree(identif.front(), &sosna); //dobavlyaet slogaemie v derevo
		identif.pop_front();
	}

	printTree(sosna);
	cout << endl;
	printTriad(&sosna, 0);
}
