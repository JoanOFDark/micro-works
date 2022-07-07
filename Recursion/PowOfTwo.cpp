#include <iostream>

using namespace std;

bool IsPowOfTwo(int n) {
	if (n == 1) {
		return true;
	}
	if (n % 2 != 0 || n == 0) {
		return false;
	}
	return IsPowOfTwo(n / 2);
}

int main() {
	int result = IsPowOfTwo(1024);
	cout << result << endl;

	cout << IsPowOfTwo(0) << endl;
	cout << IsPowOfTwo(1) << endl;
	cout << IsPowOfTwo(2) << endl;
	cout << IsPowOfTwo(3) << endl;
	cout << IsPowOfTwo(4) << endl;
}