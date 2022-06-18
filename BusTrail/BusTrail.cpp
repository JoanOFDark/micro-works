#include <cassert>
#include <iostream>
#include <map>
#include <string>
#include <vector>
#include <sstream>

using namespace std;

enum class QueryType {
    NewBus,
    BusesForStop,
    StopsForBus,
    AllBuses,
};

struct Query {
    QueryType type;
    string bus;
    string stop;
    vector<string> stops;
};

istream& operator>>(istream& is, Query& q) {
    // Реализуйте эту функцию
    string query_type;
    is >> query_type;

    if (query_type == "NEW_BUS"s) {
        q.type = QueryType::NewBus;
        is >> q.bus;

        int n;
        is >> n;
        for (int i = 0; i < n; ++i) {
            is >> q.stop;
            q.stops.push_back(q.stop);
        }
    }

    else if (query_type == "BUSES_FOR_STOP"s) {
        q.type = QueryType::BusesForStop;
        is >> q.stop;
    }
    else if (query_type == "STOPS_FOR_BUS"s) {
        q.type = QueryType::StopsForBus;
        is >> q.bus;
    }
    else {
        q.type = QueryType::AllBuses;
    }
    return is;
}

struct BusesForStopResponse {
    // Наполните полями эту структуру
    string stop;
    vector<string> buses;
};

ostream& operator<<(ostream& os, const BusesForStopResponse& r) {
    // Реализуйте эту функцию
    if (r.buses.empty()) {
        os << "No stop"s;
        return os;
    }
    bool first_el = true;
    for (const auto& bus : r.buses) {
        if (!first_el) {
            os << " "s;
        }
        first_el = false;
        os << bus;
    }
    return os;
}

struct StopsForBusResponse {
    // Наполните полями эту структуру
    string bus;
    vector<string> stops;
    map<string, vector<string>> buses_to_stops;
};

ostream& operator<<(ostream& os, const StopsForBusResponse& r) {
    // Реализуйте эту функцию
    if (!r.buses_to_stops.count(r.bus)) {
        os << "No bus"s;
        return os;
    }

    bool first_line = true;
    for (const auto& stop : r.stops) {
        if (!first_line) {
            os << endl;
        }
        first_line = false;
        os << "Stop "s << stop << ":"s;
        bool interchange_exist = false;
        for (const auto& [bus, stops] : r.buses_to_stops) {
            if (r.bus != bus && count(stops.begin(), stops.end(), stop)) {
                os << " "s << bus;
                interchange_exist = true;
            }
        }

        if (interchange_exist == false) {
            os << " no interchange"s;
        }
    }
    return os;
}

struct AllBusesResponse {
    // Наполните полями эту структуру
    map<string, vector<string>> buses_to_stops;
};

ostream& operator<<(ostream& os, const AllBusesResponse& r) {
    // Реализуйте эту функцию
    if (r.buses_to_stops.empty()) {
        os << "No buses"s;
        return os;
    };

    bool first_line = true;
    for (const auto& [bus, stops] : r.buses_to_stops) {
        if (!first_line) {
            os << endl;
        }
        first_line = false;
        os << "Bus "s << bus << ":"s;
        for (const auto& stop : stops) {
            os << " "s << stop;
        }
    }
    return os;
}

class BusManager {
public:
    void AddBus(const string& bus, const vector<string>& stops) {
        // Реализуйте этот метод
        auto& buses = buses_.buses_to_stops[bus];
        for (const string& stop : stops) {
            if (!count(buses.begin(), buses.end(), stop)) {
                buses_.buses_to_stops[bus].push_back(stop);
            }
        }
    }

    BusesForStopResponse GetBusesForStop(const string& stop) const {
        // Реализуйте этот метод
        BusesForStopResponse buses_to_stop;

        buses_to_stop.stop = stop;
        for (const auto& [bus, stops] : buses_.buses_to_stops) {
            if (count(stops.begin(), stops.end(), stop)) {
                buses_to_stop.buses.push_back(bus);
            }
        }

        return buses_to_stop;
    }

    StopsForBusResponse GetStopsForBus(const string& bus) const {
        // Реализуйте этот метод
        StopsForBusResponse stops;

        if (!buses_.buses_to_stops.count(bus)) {
            return stops;
        }

        stops.bus = bus;
        stops.buses_to_stops = buses_.buses_to_stops;
        for (const auto& stop : buses_.buses_to_stops.at(bus)) {
            stops.stops.push_back(stop);
        };
        return stops;
    }

    AllBusesResponse GetAllBuses() const {
        // Реализуйте этот метод
        return buses_;
    }

private:
    AllBusesResponse buses_;
};

// Не меняя тела функции main, реализуйте функции и классы выше
void TestInputNewBus() {
    istringstream input;
    input.str("NEW_BUS 32 3 Tolstopaltsevo Marushkino Vnukovo"s);

    Query q;
    input >> q;
    assert(q.type == QueryType::NewBus);
    assert(q.bus == "32"s);
    vector<string> vector_test = { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s };
    assert(q.stops == vector_test);
}

void TestInputBusesForStop() {
    istringstream input;
    input.str("BUSES_FOR_STOP Marushkino"s);

    Query q;
    input >> q;
    assert(q.type == QueryType::BusesForStop);
    assert(q.stop == "Marushkino"s);
};

void TestInputStopsForBuses() {
    istringstream input;
    input.str("STOPS_FOR_BUS 32K"s);

    Query q;
    input >> q;
    assert(q.type == QueryType::StopsForBus);
    assert(q.bus == "32K"s);
};

void TestInputAllBuses() {
    istringstream input;
    input.str("ALL_BUSES"s);

    Query q;
    input >> q;
    assert(q.type == QueryType::AllBuses);
};

void TestAddBusGetAllBuses() {
    BusManager bm;

    AllBusesResponse buses_test_1;
    assert(bm.GetAllBuses().buses_to_stops == buses_test_1.buses_to_stops);

    bm.AddBus("32"s, { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s });
    buses_test_1.buses_to_stops["32"s] = { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s };
    assert(bm.GetAllBuses().buses_to_stops == buses_test_1.buses_to_stops);

    bm.AddBus("32K"s, { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s, "Peredelkino"s, "Solntsevo"s, "Skolkovo"s });
    buses_test_1.buses_to_stops["32K"s] = { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s, "Peredelkino"s, "Solntsevo"s, "Skolkovo"s };
    assert(bm.GetAllBuses().buses_to_stops == buses_test_1.buses_to_stops);
};

void TestBusesForStop() {
    BusManager bm;

    BusesForStopResponse buses_test_1;
    assert(bm.GetBusesForStop(""s).buses == buses_test_1.buses);

    bm.AddBus("32"s, { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s });
    buses_test_1.buses = { "32"s };
    assert(bm.GetBusesForStop("Marushkino"s).buses == buses_test_1.buses);
};

void TestStopsForBus() {
    BusManager bm;

    StopsForBusResponse stops_test_1;
    assert(bm.GetStopsForBus(""s).stops == stops_test_1.stops);

    bm.AddBus("32"s, { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s });
    stops_test_1.stops = { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s };
    assert(bm.GetStopsForBus("32"s).stops == stops_test_1.stops);
};

void TestOutputAllBusesResponse() {
    BusManager bm;
    ostringstream output;

    bm.AddBus("32"s, { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s });
    output << bm.GetAllBuses();
    assert(output.str() == "Bus 32: Tolstopaltsevo Marushkino Vnukovo"s);

    ostringstream output_1;
    bm.AddBus("272"s, { "Vnukovo"s, "Moskovsky"s, "Rumyantsevo"s, "Troparyovo"s });
    output_1 << bm.GetAllBuses();
    assert(output_1.str() == "Bus 272: Vnukovo Moskovsky Rumyantsevo Troparyovo\nBus 32: Tolstopaltsevo Marushkino Vnukovo"s);
};

void TestOutputBusesForStopResponse() {
    BusManager bm;
    ostringstream output;

    bm.AddBus("32"s, { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s });
    bm.AddBus("272"s, { "Vnukovo"s, "Moskovsky"s, "Rumyantsevo"s, "Troparyovo"s });
    output << bm.GetBusesForStop("Vnukovo"s);
    assert(output.str() == "272 32"s);
};

void TestOutputStopsForBuses() {
    BusManager bm;
    ostringstream output;

    bm.AddBus("32"s, { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s });
    output << bm.GetStopsForBus("32"s);
    assert(output.str() == "Stop Tolstopaltsevo: no interchange\nStop Marushkino: no interchange\nStop Vnukovo: no interchange"s);

    ostringstream output_1;
    bm.AddBus("272"s, { "Vnukovo"s });
    output_1 << bm.GetStopsForBus("32"s);
    assert(output_1.str() == "Stop Tolstopaltsevo: no interchange\nStop Marushkino: no interchange\nStop Vnukovo: 272"s);
};

void Test() {
    TestInputNewBus();
    TestInputBusesForStop();
    TestInputStopsForBuses();
    TestInputAllBuses();

    TestAddBusGetAllBuses();
    TestBusesForStop();
    TestStopsForBus();

    TestOutputAllBusesResponse();
    TestOutputBusesForStopResponse();
    TestOutputStopsForBuses();
}

void TestBusManagerExample() {
    BusManager bm;
    ostringstream output;

    output << bm.GetAllBuses();
    assert(output.str() == "No buses"s);
    cout << bm.GetAllBuses() << endl;

    output.str(""s);
    output << bm.GetBusesForStop("Marushkino"s);
    assert(output.str() == "No stop"s);
    cout << bm.GetBusesForStop("Marushkino"s) << endl;

    output.str(""s);
    output << bm.GetStopsForBus("32K"s);
    assert(output.str() == "No bus"s);
    cout << bm.GetStopsForBus("32K"s) << endl;
    bm.AddBus("32"s, { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s });
    bm.AddBus("32K"s, { "Tolstopaltsevo"s, "Marushkino"s, "Vnukovo"s, "Peredelkino"s, "Solntsevo"s, "Skolkovo"s });
    cout << bm.GetBusesForStop("Vnukovo"s) << endl;
    bm.AddBus("950"s, { "Kokoshkino"s, "Marushkino"s, "Vnukovo"s, "Peredelkino"s, "Solntsevo"s, "Troparyovo"s});
    bm.AddBus("272"s, { "Vnukovo"s, "Moskovsky"s, "Rumyantsevo"s, "Troparyovo"s});
    cout << bm.GetStopsForBus("272"s) << endl;
    cout << bm.GetAllBuses() << endl;
}

int main() {
    Test();
    TestBusManagerExample();
    int query_count;
    Query q;

    cin >> query_count;

    BusManager bm;
    for (int i = 0; i < query_count; ++i) {
        cin >> q;
        switch (q.type) {
        case QueryType::NewBus:
            bm.AddBus(q.bus, q.stops);
            break;
        case QueryType::BusesForStop:
            cout << bm.GetBusesForStop(q.stop) << endl;
            break;
        case QueryType::StopsForBus:
            cout << bm.GetStopsForBus(q.bus) << endl;
            break;
        case QueryType::AllBuses:
            cout << bm.GetAllBuses() << endl;
            break;
        }
    }
}
