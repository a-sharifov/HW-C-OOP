#include "card_manager.h"
#include <iostream>
#include <algorithm>
#include <fstream>
#include <vector>
#include <functional>

card::card() = default;
card::card(type_card _type_card, unsigned short code, unsigned short cvv, long long card_number, std::string name_user, std::string surname_user) {
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
		case type_card::debit:
			this->user_type_card = new std::string("debit");
		}
	}
	else { throw std::exception("user entered the information incorrectly", 406); }
}

std::ostream& operator<<(std::ostream & out, card & other) {

	std::string tmp_card_number{};
	long long a = 1000000000000000, b = other.card_number;
	for (int i = 1; i <= 20; i++) {
		if (i % 5 == 0) { tmp_card_number += ' '; }
		else {
			tmp_card_number += static_cast<char>((b / a) + 48);
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


check::check(unsigned long total_sum, days day, board_categories category) {
	this->total_sum = total_sum;
	this->day = day;
	this->category = category;
}
bool check::operator<(check other) { return this->total_sum < other.total_sum; }

std::ostream& operator <<(std::ostream & out, check other) {
	std::string tmp{};
	switch (other.category) {
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
		<< "day : " << (other.day == 0 ? "day" : other.day == 1 ? "week" : "month") << std::endl
		<< "total : " << other.total_sum << std::endl << std::endl;
	return out;
}

card_system::card_system() {
	this->user_cards = new std::vector <std::shared_ptr<card>>{};
	this->check_history = new std::vector<std::shared_ptr<check>>{};///
	this->check_history->reserve(40); //для удобство
	this->list_category = new std::pair<std::string, int>*[3]{};
	for (size_t i = 0; i < 3; i++) this->list_category[i] = new std::pair<std::string, int>[] { {"food", {}}, { "taxi",{} }, { "clothes",{} }, { "comunal apartment",{} }, { "video games",{} } };
}


void card_system::refill(long long number, unsigned long sum){
	for (auto& i : *this->user_cards){
		if (i.get()->card_number == number) {
			i.get()->balance += sum;
			return;
		}
	}
	throw std::exception{ "not found card" , 404 };
}

void card_system::add_card(card other) { this->user_cards->push_back(std::shared_ptr<card>(&other)); }

void card_system::save_status_check() {
	std::sort(this->check_history->begin(), this->check_history->end());
	std::reverse(this->check_history->begin(), this->check_history->end());
	std::ofstream out{ "save.txt" , std::ios::app };
	if (out.is_open()) {
		out << "\ntop 3 sum :";
		out << "\nday :\n";
		for (int i = 0, j{}; i < this->check_history->size() && j < 3; i++)
			if ((this->check_history->begin() + i)._Ptr->get()->day == 0) out << (j++) + 1 << ". " << *(this->check_history->begin() + i)._Ptr->get() << '\n';
		out << "\nweek :\n";
		for (int i = 0, j{}; i < this->check_history->size() && j < 3; i++)
			if ((this->check_history->begin() + i)._Ptr->get()->day <= 1) out << (j++) + 1 << ". " << *(this->check_history->begin() + i)._Ptr->get() << '\n';
		out << "\nmonth :\n";
		for (int i = 0, j{}; i < this->check_history->size() && j < 3; i++)
			if ((this->check_history->begin() + i)._Ptr->get()->day <= 2) out << (j++) + 1 << ". " << *(this->check_history->begin() + i)._Ptr->get() << '\n';
	}
	out.close();
}

void card_system::save_all() { //при желании можно добавить функтор
	std::ofstream out{ "save.txt" , std::ios::app };
	if (out.is_open()) {
		for (size_t i = 0; i < this->user_cards->size(); i++)
			out << *(this->user_cards->begin() + i)._Ptr->get() << std::endl;
		out << "user check : \n";
		for (size_t i = 0; i < this->check_history->size(); i++)
			out << *(this->check_history->begin() + i)._Ptr->get() << std::endl;

		this->save_status_check();
		this->save_status_category();
	}
	out.close();
}

void card_system::save_status_category() { 

	std::function<void(std::pair<std::string, int>* other)> my_sort{}; //функция эта тоже переменная значит ее можно хранить
	my_sort = [](std::pair<std::string, int>* other) { //функция эта тоже переменная значит ее можно хранить
		for (size_t i = 0; i < 5; i++) {
			for (size_t j = 0; j < 5; j++) {
				if (other[i].second > other[j].second)
					swap(other[i], other[j]);
			}
		}
	};

	for (size_t i = 0; i < 3; i++) my_sort(this->list_category[i]);
	std::ofstream out{ "save.txt" , std::ios::app };
	if (out.is_open()) {
		out << "\ntop 3 category :";
		out << "\nday :\n";
		for (size_t i = 0; i < 3; i++) { out << (i)+1 << ". " << this->list_category[days::day][i].first << ' ' << this->list_category[0][i].second << "\n\n"; }
		out << "\nweek :\n";
		for (size_t i = 0; i < 3; i++) { out << (i)+1 << ". " << this->list_category[days::week][i].first << ' ' << this->list_category[1][i].second << "\n\n"; }
		out << "\nmonth :\n";
		for (size_t i = 0; i < 3; i++) { out << (i)+1 << ". " << this->list_category[days::month][i].first << ' ' << this->list_category[2][i].second << "\n\n"; }
		out << "\n////////////////\n";
	}
	out.close();
}

void card_system::pay(check & other, unsigned short index, unsigned short code) {
	if (index < this->user_cards->size() && other.status == false) {
		if (code == (this->user_cards->begin() + index)._Ptr->get()->code && other.total_sum <= (this->user_cards->begin() + index)._Ptr->get()->balance) {
			other.status = true;
			other.pay_card = (this->user_cards->begin() + index)._Ptr->get()->card_number;
			(this->user_cards->begin() + index)._Ptr->get()->balance -= other.total_sum;
			for (size_t i = other.day; i < 3; i++)
				this->list_category[i][other.category].second++;
			this->check_history->push_back(std::shared_ptr<check>(&other));
		}
		else throw std::exception{"insufficient funds"};
	}
	else throw std::exception{ "went beyond" };
}

std::ostream& operator<<(std::ostream & out, card_system other) {
	for (auto& i : *other.user_cards) out << *i;
	for (auto& i : *other.check_history) out << *i;
	return out;
}