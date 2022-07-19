#include <iostream>
#include "directory.h"

int main()
{
    Directory my_firma{ 994509708327 , new char[] {"blblb"} , new char[] {"ab"} , new char[] {"pspplewp"}, new char[] {"qwet"} , type_of_number::home }; 
    
    //char* my_search1 = my_firma.search_Directory(new char[] {"509708307"}); // false
    //char* my_search2 = my_firma.search_Directory(new char[]{"509708327"}); // true

    //std::cout << my_search1;
    //std::cout << my_search2;

    my_firma.print_all_Directory();

    //delete[] my_search1; //delete
    //delete[] my_search2;
    return NULL;
}

