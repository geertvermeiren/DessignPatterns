using System;
using System.Collections.Generic;
using System.Linq;

/*Sometimes, you don’t want to do execute your functions immediately.
You can use the Command pattern to add work to a queue, to be done later.
You can use it to retry, if a command cannot execute properly.
You might be able to use this to add “undo” capabilities to a program. */

namespace BankAccountCommand
{
    //command = class that execute the action

    public interface ITransaction
    {
         bool IsCompleted { get; set; }
         void Execute();
    }

    //concrete command 

    public class Deposit:ITransaction
    {
        private readonly Account _account;
        private readonly decimal _amount;

        public bool IsCompleted { get; set; }

        public Deposit(Account account,decimal amount)
        {
            this._account = account;
            this._amount = amount;
            IsCompleted = false;

        }
        public void Execute()
        {
            _account.Balance += _amount;
            IsCompleted = true; 
        }
    }

    public class Withdraw:ITransaction
    {
        private readonly Account _account;
        private readonly decimal _amount;

        public bool IsCompleted { get; set; }

        public Withdraw(Account account,decimal amount)
        {
            this._account = account;
            this._amount = amount;
            IsCompleted = false;

        }

         public void Execute()
        {
            if(_account.Balance >= _amount)
            {
                _account.Balance -= _amount;
    
                IsCompleted = true;
            }
        }

    }

    //receiver =business object that receives the action from the command

    public class Account
    {
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }
        public Account(string ownerName,decimal balance)
        {
            this.OwnerName = ownerName;
            this.Balance = balance;
            
        }

    }

    //invoker = this class tels the command to execute actions. the invoker can
    //somethimes be queque

    public class TransactionManager
    {
        public readonly List<ITransaction> _transactions = new List<ITransaction>();
        public bool HasPendingTransaction
        {
            get{return _transactions.Any(x=> !x.IsCompleted);}
        }
        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void ProcessPendingTransaction()
        {
            foreach(ITransaction transaction in _transactions.Where(x=> !x.IsCompleted))
            {
                transaction.Execute();

            }
        }

    }
    //client = consumes the command pattern

    public class Client
    {
        public Client()
       {
           TransactionManager _transactionManager = new TransactionManager();
           Account geert = new Account("Geert",100000);
           System.Console.WriteLine($"initial balance: {geert.Balance}" );
           Deposit deposit = new Deposit(geert,50000);
           _transactionManager.AddTransaction(deposit);
           _transactionManager.ProcessPendingTransaction();
           Withdraw _withdraw = new Withdraw(geert,875);
           
           _transactionManager.AddTransaction(_withdraw);
           _transactionManager.ProcessPendingTransaction();
           System.Console.WriteLine(geert.Balance); 
       } 
    }
}