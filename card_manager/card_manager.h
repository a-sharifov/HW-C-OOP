#include <iostream>
#include <string>
#include <vector>

enum type_card { debit = 1, credit };
enum days { day, week, month };
enum board_categories { food, taxi, clothes , communal_apartment , video_games };


class check;
class card_system;
class card {
public:
	card();
	card(type_card ,unsigned short ,unsigned short , long long , std::string , std::string);
	~card();
	friend std::ostream& operator << (std::ostream&, card&);
	friend card_system;
private:
	char use_card{};
	unsigned short cvv{};
	unsigned short code{};
	type_card _type_card = type_card::credit;			
	long long balance{};//желательно float но я решил так 
	long long card_number{}; 
	std::string* user_type_card{};
	std::string* name_user{};
	std::string* surname_user{};
};

class check {
public:
	check(unsigned long , days , board_categories);
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
	~card_system();
	void add_card(card);
	void pay(check& , unsigned short , unsigned short);
	friend std::ostream& operator <<(std::ostream&, card_system);
private:
	std::vector <card> *user_cards{};
	std::vector <check> *check_history{};
	std::pair<std::string, int>** list_category{};
};

