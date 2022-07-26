#include <iostream>
#include <string>
#include <vector>

enum type_card { debit = 1, credit };
enum days { day, week, month };
enum board_categories { food, taxi, clothes, communal_apartment, video_games };


class check;
class card_system;
class card {
public:
	card();
	card(type_card, unsigned short, unsigned short, long long, std::string, std::string);
	friend std::ostream& operator << (std::ostream&, card&);
	friend card_system;
private:
	char use_card{};
	unsigned short cvv{};
	unsigned short code{};
	type_card _type_card = type_card::credit;
	long long balance{};//use to float
	long long card_number{};
	std::string* user_type_card{};
	std::string* name_user{};
	std::string* surname_user{};
};

class check {
public:
	check(unsigned long, days, board_categories);
	friend card_system;
	bool operator  <(check);
	friend std::ostream& operator <<(std::ostream&, check);
private:
	bool status{};
	board_categories category;
	days day;
	unsigned long total_sum;
	unsigned long long pay_card{};
};

class card_system {
public:
	card_system();
	void refill(long long,unsigned long);
	void add_card(card);
	void pay(check&, unsigned short, unsigned short);
	friend std::ostream& operator <<(std::ostream&, card_system);
	void save_all();
private:
	void save_status_check();
	void save_status_category();
	std::vector <std::shared_ptr<card>>* user_cards{};
	std::vector <std::shared_ptr<check>>* check_history{};
	std::pair<std::string, int>** list_category{};
};
