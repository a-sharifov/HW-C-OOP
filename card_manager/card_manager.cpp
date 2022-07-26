#include "card_manager.h"
#include <iostream>
#include <vector>

card::card() = default;
card::card(type_card _type_card,unsigned short code,unsigned short cvv, long long card_number,  std::string name_user, std::string surname_user) {
	if (cvv < 1000 && 1000000000000000 <= card_number && card_number < 10000000000000000) {
		this->cvv = cvv;
		this->card_number = card_number;
		this->code = code;
		this->name_user = new std::string(name_user);
		this->surname_user = new std::string(surname_user);
		switch (this->_type_card) {
		case type_card::credit:
			this->user_type_card = new std::string("credit");
			break;
		case type_card::debit: //решил не использовать default чтоб понятнее было
			this->user_type_card = new std::string("debit");
		}
	}
	else { throw std::exception("user entered the information incorrectly", 406); }
}

card::~card() {
	if (this->use_card-- == 0) {
		delete name_user;
		delete surname_user;
		delete user_type_card;
	}
}

std::ostream& operator<<(std::ostream& out, card& other){

	std::string tmp_card_number{};
	long long a = 1000000000000000 , b = other.card_number;
	for (int i = 1 ; i <= 20; i++){ // для красивого вывода
		if (i % 5 == 0) { tmp_card_number += ' '; }
		else {
			tmp_card_number += static_cast<char>((b / a)+48 );
			b -= b / a * a;
			a /= 10;
		}
	}

	out << "type card : " << *other.user_type_card << std::endl
		<< "user name : " << *other.name_user << std::endl
		<< "user surname : " << *other.surname_user << std::endl
		<< "card number : " << tmp_card_number << std::endl
		<< "cvv : " << other.cvv << std::endl
		<< "balance : " << other.balance << std::endl << std::endl;
	
	return out;
}


check::check(unsigned long total_sum, days day, board_categories category){
	this->total_sum = total_sum;
	this->day = day;
	this->category = category;
}
bool check::operator<(check other){return this->total_sum < other.total_sum;}

//enum board_categories { food, taxi, clothes, communal_apartment, video_games };

std::ostream& operator <<(std::ostream& out, check other){
	std::string tmp{};
	switch (other.category){
	case board_categories::food:
		tmp += "food";
		break;
	case board_categories::taxi:
		tmp += "taxi";
		break;
	case board_categories::clothes:
		tmp += "clothes";
		break;
	case board_categories::communal_apartment:
		tmp += "comunal";
		break;
	case board_categories::video_games:
		tmp += "video games";
	}
	out << "pay card : " << other.pay_card << std::endl
		<< "category : " << tmp << std::endl
		<< "day : " << (other.day == 1 ? "day" : other.day == 2 ? "week" : "month") << std::endl
		<< "total : " << other.total_sum;
	return out;
}



card_system::card_system(){
	this->user_cards = new std::vector <card>{};
	this->check_history = new std::vector<check>{};///
	this->check_history->reserve(40); //для удобство
	this->list_category =new std::pair<std::string, int>*[3]{};
	for (size_t i = 0; i < 3; i++) this->list_category[i] = new std::pair<std::string, int>[5]{ {"food",{}}, {"taxi",{}}, {"clothes",{}}, {"comunal apartment",{}}, {"video games",{}} };
}

void card_system::add_card(card other) {
	other.use_card++;
	this->user_cards->push_back(other);
}

card_system::~card_system(){
	for (size_t i = 0; i < 3; i++)
		delete[] this->list_category[i];
	delete[] this->list_category;
}

void card_system::pay(check &other, unsigned short index, unsigned short code){
	if (index < this->user_cards->size() && other.status == false) {
		if (code == (this->user_cards->begin() + index)._Ptr->code) {
			other.status = true;
			other.pay_card = (this->user_cards->begin() + index)._Ptr->card_number;
			(this->user_cards->begin() + index)._Ptr->balance -= other.total_sum;
			this->list_category[other.day][other.category].second++;
			this->check_history->push_back(other);
		}
	}
}

std::ostream& operator<<(std::ostream& out, card_system other){
	for (auto& i : *other.user_cards) out << i;
	for (auto& i : *other.check_history) out << i;
	return out;
}

void sort_category(std::pair<std::string , int> *other){
	for (size_t i = 0; i < 5; i++){
		for (size_t j = 0; j < 5; j++){
			if (other[i].second < other[j].second)
				swap(other[i], other[j]);
		}
	}
}
