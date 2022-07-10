// search_server_s3_t3_v3.cpp

#include <algorithm>
#include <iostream>
#include <vector>
#include <iterator>

using namespace std;

template <typename Iterator>
class IteratorRange {
public:
    IteratorRange(Iterator begin, Iterator end) : begin_page_(begin), end_page_(end) {}

    Iterator begin() const {
        return begin_page_;
    }

    Iterator end() const {
        return end_page_;
    }

    size_t size() {
        return distance(begin_page_, end_page_);
    }

private:
    Iterator begin_page_;
    Iterator end_page_;
};

template <typename Iterator>
class Paginator {
public:
    // тело класса
    Paginator(Iterator begin, Iterator end, size_t page_size) {
        size_t container_size = distance(begin, end);
        auto page_end = begin;
        size_t i = page_size;
        while (i < container_size) {
            auto page_begin = page_end;
            advance(page_end, page_size);
            pages_.push_back(IteratorRange<Iterator>(page_begin, page_end));
            i += page_size;
        }
        pages_.push_back(IteratorRange<Iterator>(page_end, end));
    }

    size_t size() const {
        return pages_.size();
    }

    auto begin() const {
        return pages_.begin();
    }

    auto end() const {
        return pages_.end();
    }
private:
    vector<IteratorRange<Iterator>> pages_;
};

template <typename Container>
auto Paginate(const Container& c, size_t page_size) {
    return Paginator(begin(c), end(c), page_size);
}


template <typename Iterator>
ostream& operator<<(ostream& out, IteratorRange<Iterator> range) {
    for (auto it = range.begin(); it != range.end(); ++it) {
        out << *it;
    }
    return out;
}

int main() {
    int page_size1 = 1;
    vector<int> arr1{ 1,2,3,4,5,6,7,8,9,10 };
    const auto pages1 = Paginate(arr1, page_size1);

    int page_size2 = 4;
    vector<int> arr2{ 1,2,3,4,5,6,7,8,9,10 };
    const auto pages2 = Paginate(arr2, page_size2);

    int page_size3 = 6;
    vector<int> arr3{ 1,2,3,4,5,6,7,8,9,10 };
    const auto pages3 = Paginate(arr3, page_size3);

    int page_size4 = 10;
    vector<int> arr4{ 1,2,3,4,5,6,7,8,9,10 };
    const auto pages4 = Paginate(arr4, page_size4);

    // Выводим найденные документы по страницам

    for (auto page = pages1.begin(); page != pages1.end(); ++page) {
        cout << *page << endl;
        cout << "Page break"s << endl << endl;
    }

    for (auto page = pages2.begin(); page != pages2.end(); ++page) {
        cout << *page << endl;
        cout << "Page break"s << endl << endl;
    }

    for (auto page = pages3.begin(); page != pages3.end(); ++page) {
        cout << *page << endl;
        cout << "Page break"s << endl << endl;
    }

    for (auto page = pages4.begin(); page != pages4.end(); ++page) {
        cout << *page << endl;
        cout << "Page break"s << endl;
    }
}