#include <iostream>
#include <fstream>
#include "directory.h"

Directory::Directory() = default;

Directory::Directory(unsigned long long  phone_number, char* company_name, char* owner, char* address, char* occupation , type_of_number typenumber){
	this->phone_number = phone_number;
	this->typenumber = typenumber;
	this->company_name = new char[25]{};
	this->owner = new char[20]{};
	this->address = new char[25]{};
	this->occupation = new char[30]{};

	for (size_t i = 0; *(i + company_name) != '\0'; i++)
		this->company_name[i] = company_name[i];
	for (size_t i = 0; *(i + owner) != '\0'; i++)
		this->owner[i] = owner[i];
	for (size_t i = 0; *(i + address) != '\0'; i++)
		this->address[i] = address[i];
	for (size_t i = 0; *(i + occupation) != '\0'; i++)
		this->occupation[i] = occupation[i];
	this->save_as();
}

Directory::~Directory(){
	delete[] this->owner;
	delete[] this->address;
	delete[] this->occupation;
	delete[] this->company_name;
}

void Directory::print_all_Directory(){
	std::ifstream my_print;
	my_print.open("Directory.txt");
	if (my_print.is_open()) {
		char* all_directory = new char[720] {};
		my_print.read(all_directory, 720);
		std::cout << all_directory;
		delete[] all_directory;
	}
	my_print.close();
}

char* Directory::search_Directory(char* search){
	std::ifstream all_Directory_save;
	all_Directory_save.open("Directory.txt");
	char* save_Directory = new char[150]{}; //return object
	if (all_Directory_save.is_open()) { 

		char* all_Directory = new char[720]{};
		all_Directory_save.read(all_Directory, 720); //res
		char* check_point = all_Directory; // checkpoint - '\n'
		unsigned short checkpoint_DATA{};
		bool save{};

		for (size_t i = 0; all_Directory[i] != '\0'; i++){ //search all
			if (all_Directory[i] == '\n') {
				if (++checkpoint_DATA == 6) {
					check_point = all_Directory + i;
					checkpoint_DATA = 0;
				}
			}
			for (size_t j = 0; search[j] != '\0'; j++) {
				if (all_Directory[i] != search[j]) { break; }
				else if (search[j + 1] == '\0' && !isalnum(all_Directory[i + 1])) { save = true; } // isalnum - num - alpha
				i++;
			}
			if (save == true) break; 
		}

		if (save == true) {
			checkpoint_DATA = 0;
			int i{};
			while (checkpoint_DATA < 6) {
				save_Directory[i] = check_point[i++];
				if (check_point[i] == '\n') checkpoint_DATA++;
			}
		}
		delete[] all_Directory;
	}
	all_Directory_save.close();
	return save_Directory;
}

void Directory::save_as(){
	std::ofstream my_save;
	my_save.open("Directory.txt", std::ios::app);
	if (my_save.is_open()) {
		char* number_tmp{};
		switch (this->typenumber){
		case type_of_number::home:
			number_tmp = new char[] {"home"};
			break;
		case type_of_number::state:
			number_tmp = new char[] {"state"};
			break;
		default:
			number_tmp = new char[] {"mobile"};
		}
		my_save << this->company_name << '\n' <<
			this->owner << '\n' <<
			this->occupation << '\n' <<
			number_tmp << " : " << this->phone_number << '\n' <<
			this->address << std::endl << std::endl;
	}
}

