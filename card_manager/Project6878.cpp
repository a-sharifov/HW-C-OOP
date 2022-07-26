#include <iostream>
#include "card_manager.h"
#include <vector>


int main(){
	

	card b(type_card::credit,1978 ,999, 5169733212560895, "Akber", "Sharifov");
	card qw(type_card::credit,1979 ,999, 3169733212560895, "Akber", "Sharifov");
	check abc(100, days::day, board_categories::clothes);
	check adc(100, days::day, board_categories::clothes);
	check qwe(100, days::day, board_categories::clothes);
	card_system q{};
	q.add_card(b);
	q.add_card(qw);
	q.pay(abc, 1, 1979);
	std::cout << q;
	return NULL;
}