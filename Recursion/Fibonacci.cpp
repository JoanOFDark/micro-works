#include <iostream>
#include <cassert>

using namespace std;

int FibonacciCycle(int n) {
	int a = 0;
	int b = 1;
	for (int i = n / 2; i > 0; --i) {
		a += b;
		b += a;
	}
	if (n % 2 == 0) {
		return a;
	}
	else {
		return b;
	}
}

void TestFibCycle() {
	assert(FibonacciCycle(0) == 0);
	assert(FibonacciCycle(1) == 1);
	assert(FibonacciCycle(2) == 1);
	assert(FibonacciCycle(3) == 2);
	assert(FibonacciCycle(4) == 3);
	assert(FibonacciCycle(5) == 5);
	assert(FibonacciCycle(6) == 8);
	assert(FibonacciCycle(7) == 13);
	cout << "TestFibCycle is done with success!"s << endl;
}

int FibonacciRecursion(int n) {
	if (n == 0) {
		return 0;
	}
	if (n == 1) {
		return 1;
	}
	return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
}

void TestFibRecursion() {
	assert(FibonacciRecursion(0) == 0);
	assert(FibonacciRecursion(1) == 1);
	assert(FibonacciRecursion(2) == 1);
	assert(FibonacciRecursion(3) == 2);
	assert(FibonacciRecursion(4) == 3);
	assert(FibonacciRecursion(5) == 5);
	assert(FibonacciRecursion(6) == 8);
	assert(FibonacciRecursion(7) == 13);
	cout << "TestFibRecursion is done with success!"s << endl;
}

int main() {
	cout << FibonacciCycle(0) << endl;
	cout << FibonacciCycle(1) << endl;
	cout << FibonacciCycle(2) << endl;
	cout << FibonacciCycle(3) << endl;
	cout << FibonacciCycle(4) << endl;
	cout << FibonacciCycle(5) << endl;
	cout << FibonacciCycle(6) << endl;
	cout << FibonacciCycle(7) << endl;
	TestFibCycle();
	cout << FibonacciRecursion(0) << endl;
	cout << FibonacciRecursion(1) << endl;
	cout << FibonacciRecursion(2) << endl;
	cout << FibonacciRecursion(3) << endl;
	cout << FibonacciRecursion(4) << endl;
	cout << FibonacciRecursion(5) << endl;
	cout << FibonacciRecursion(6) << endl;
	cout << FibonacciRecursion(7) << endl;
	TestFibRecursion();
}