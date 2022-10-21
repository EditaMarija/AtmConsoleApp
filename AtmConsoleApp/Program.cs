using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    } 
    public string getNum()
    {
        return cardNum;
    }

    public int getPin() 
    { 
        return pin; 
    }

    public string getFirstName()
    {
        return firstName;   
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string NewCardNum) 
    { 
        cardNum = NewCardNum; 
    }

    public void setPin(int NewPin)
    {
        pin = NewPin;
    }

    public void setFirstName(string newFirstName) 
    { 
        firstName = newFirstName; 
    }
    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options... \n");
            Console.WriteLine(" \t  1: Deposit");
            Console.WriteLine(" \t  2: Withdraw");
            Console.WriteLine(" \t  3: Show balance");
            Console.WriteLine(" \t  4: Exit");
            //Console.Write("".PadRight(10));
            Console.Write(new string(' ', 10));
        }

        void deposit(cardHolder currentUser)
        {
            Console.Clear();
            Console.WriteLine("How much $$ would you like to deposit: \n");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.Clear();
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance() + "\n");
        }

        void withdraw(cardHolder currentUser)
        {
            Console.Clear();
            Console.WriteLine("How much $$ would you like to withdraw: \n");
            double withdrawal = double.Parse(Console.ReadLine());
            //Check if user has enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.Clear();
                Console.WriteLine("Insufficient balance :( \n");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.Clear();
                Console.WriteLine("You're good to go! Thank you :) \n");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.Clear();
            Console.WriteLine("Current balance: " + currentUser.getBalance() + "\n");
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4321", 1234, "Marija", "TheCoder", 150.31));
        cardHolders.Add(new cardHolder("6032772818527382", 5678, "Bart", "Simpson", 321.13));
        cardHolders.Add(new cardHolder("5132772818527372", 9101, "Lisa", "Simpson", 105.59));

        //Prompt user
        Console.WriteLine("Welcome to MySuperSimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // Check against our db
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }
        Console.Clear();
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :) \n");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            { }
                if (option == 1) { deposit(currentUser); }
                else if(option == 2) { withdraw(currentUser); }  
                else if(option == 3) { balance(currentUser); }
                else if(option == 4) { break; }
                else { option = 0; }
            
        } 
        while (option != 4);
        Console.Clear();
        Console.WriteLine("Thank you! Have a nice day :)");
    }


}