using System;
public class Account_NonCommand
{
    public string OwnerName { get; set; }
    public decimal Balance { get; set; }
 
    public Account_NonCommand(string ownerName, decimal balance)
    {
        OwnerName = ownerName;
        Balance = balance;
    }
 
    public void Deposit(decimal amount)
    {
        Balance += amount;
    }
 
    public void Withdraw(decimal amount)
    {
        if(amount > Balance)
        {
            throw new ArgumentOutOfRangeException("Overdraft error");
        }
 
        Balance -= amount;
    }
}