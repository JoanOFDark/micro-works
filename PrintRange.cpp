#include <iostream>

using namespace std;

template<typename Iterator>
void PrintRange(Iterator begin, Iterator end) {
    for (; begin!=end; ++begin) {
        cout << *begin << " "s;
    }
    cout << endl;
}