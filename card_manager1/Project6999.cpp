#include <iostream>
#include "card_manager.h"


int main() {


	card b(type_card::credit,1978 ,999, 5169733212560895, "Akber", "Sharifov");
	card qw(type_card::credit,1979 ,999, 3169733212560895, "Akber", "Sharifov");
	check abc(700, days::day, board_categories::clothes);
	check adc(800, days::day, board_categories::food);
	check qwe(900, days::month, board_categories::clothes);
	check aaa(1000, days::month, board_categories::clothes);
	card_system q{};
	q.add_card(b); // delete -
	q.add_card(qw);//
	q.refill(5169733212560895, 100000);
	q.pay(abc, 0, 1978);
	q.pay(adc, 0, 1978);
	q.pay(qwe, 0, 1978);
	q.pay(aaa, 0, 1978);
	q.save_all();
	std::cout << q;
	return NULL;
}