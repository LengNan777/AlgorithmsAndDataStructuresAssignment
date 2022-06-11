using System;

Console.WriteLine("Please enter the money amount you want to put: ");
int enterAmount = Int32.Parse(Console.ReadLine());
Console.WriteLine("Please enter the price of item you want to buy: ");
int itemPrice = Int32.Parse(Console.ReadLine());

Dictionary<string, int> initCoins = new Dictionary<string, int>() {
    { "$20",15},
    { "$10",15},
    { "$5",15},
    { "$2",15},
    { "$1",15},
};

string handlePurchase(Dictionary<string, int> initCoins, int enterAmount, int itemPrice)

{
    Dictionary<string, int> returnCoins = new Dictionary<string, int>();
    int returnAmount = enterAmount - itemPrice;

    int totalMoneyInMachine = 0;
    foreach (KeyValuePair<string, int> coin in initCoins)
    {
        totalMoneyInMachine += int.Parse(coin.Key.Substring(1)) * coin.Value;
    }

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