#include <iostream>
#include <string>
using std::string;
using namespace std;

class Person
{
public:
	Person()
	{
		cout << "Person()" << endl;
		firstName = "Bobby";
		lastName = "Joe";
	}

	string getFirstName()
	{
		return firstName;
	}

	string getLastName()
	{
		return lastName;
	}

	void setFirstName(string s)
	{
		firstName = s;
	}

	void setLastName(string s)
	{
		lastName = s;
	}

private:
	string firstName;
	string lastName;
};

int main()
{
	cout << "Hello World!";
	Person person;
	person.setFirstName("Billy");
	person.setLastName("Bob");
	cout << person.getFirstName() << " " << person.getLastName() << " is someone you should avoid in the future.";
	cin.get();
	return 0;
}