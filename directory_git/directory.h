enum type_of_number{ home = 1 , state, mobile };

class Directory{
public:
	Directory();
	Directory(unsigned long long, char*, char*, char*, char*, type_of_number);
	~Directory();

	void print_all_Directory();
	char* search_Directory(char*);
private:
	void save_as();
	unsigned long long phone_number{};
	type_of_number typenumber = type_of_number::home;
	char* company_name = nullptr;
	char* owner = nullptr;
	char* address = nullptr;
	char* occupation = nullptr;	
};

