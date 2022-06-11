using System;

//Get the money amount user wants to insert into machine.
Console.WriteLine("Please enter the money amount you want to put: ");
int enterAmount = Int32.Parse(Console.ReadLine());

//Get the price of item user wants to buy.
Console.WriteLine("Please enter the price of item you want to buy: ");
int itemPrice = Int32.Parse(Console.ReadLine());

//Initialize the coins value and quantity.
Dictionary<string, int> initCoins = new Dictionary<string, int>() {
    { "$20",15},
    { "$10",15},
    { "$5",15},
    { "$2",15},
    { "$1",15},
};

/*This function receive a dictionary for coins state in vending machine, a int for total value of coins user insert and a int for price of item in the machine.
This would return different string depending the arguements, console.writeLine() statement just for showing the information easily.*/

string handlePurchase(Dictionary<string, int> initCoins, int enterAmount, int itemPrice)

{
    //Create a dictionary to store the information of all coins return to the user.
    Dictionary<string, int> returnCoins = new Dictionary<string, int>();
    int returnAmount = enterAmount - itemPrice;
    int totalMoneyInMachine = 0;

    //Calculate the total value of coins in the machine.
    foreach (KeyValuePair<string, int> coin in initCoins)
    {
        totalMoneyInMachine += int.Parse(coin.Key.Substring(1)) * coin.Value;
    }

    //Returns different information depending on different situation.
    if (returnAmount > totalMoneyInMachine)
    {
        Console.WriteLine("Sorry! There is not enough money for charge");
        return "Sorry! There is not enough money for charge";
    }
    else if (returnAmount < 0)
    {
        Console.WriteLine("Sorry! Please put ${0} more.", itemPrice - enterAmount);
        return "Please insert more coins";
    }
    else if (returnAmount == 0)
    {
        Console.WriteLine("Thanks! You inserted the right number of coins");
        return "Thanks! You inserted the right number of coins";
    }
    else
    {
        foreach (KeyValuePair<string, int> coin in initCoins)
        {
            int coinValue = int.Parse(coin.Key.Substring(1));
            if (returnAmount >= coinValue)
            {
                int amount = returnAmount / coinValue;
                returnAmount -= amount * coinValue;
                returnCoins.Add(coin.Key, amount);
            }
        }
        string finalInfo = "Here is the changes: \n";
        foreach (KeyValuePair<string, int> coin in returnCoins)
        {
            finalInfo += coin.Key + " : " + coin.Value.ToString() + " piece \n";
        }
        Console.WriteLine(finalInfo);
        return finalInfo;
    }
}

handlePurchase(initCoins, enterAmount, itemPrice);