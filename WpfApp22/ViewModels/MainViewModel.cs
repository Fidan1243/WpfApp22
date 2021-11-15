using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfApp22.Commands;
using WpfApp22.Models;

namespace WpfApp22.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string cFullname;

        public string CFullname
        {
            get { return cFullname; }
            set { cFullname = value; OnPropertyChanged(); }
        }

        private decimal minusMoney;

        public decimal MinusMoney
        {
            get { return minusMoney; }
            set { minusMoney = value; OnPropertyChanged(); }
        }

        private decimal Moneyminus;

        public decimal MoneyMinus
        {
            get { return Moneyminus; }
            set { Moneyminus = value; OnPropertyChanged(); }
        }

        private decimal money;

        public decimal Money
        {
            get { return money; }
            set { money = value; OnPropertyChanged(); }
        }

        private long cardNumber;

        public long CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; OnPropertyChanged(); }
        }

        private bool insertE;

        public bool InsertE
        {
            get { return insertE; }
            set { insertE = value; OnPropertyChanged(); }
        }

        private bool transferE;

        public bool TransferE
        {
            get { return transferE; }
            set { transferE = value; OnPropertyChanged(); }
        }

        private Card customer;

        public Card Customer
        {
            get { return customer; }
            set { customer = value; OnPropertyChanged(); }
        }


        public RelayCommand LoadCommand { get; set; }
        public RelayCommand TransferCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public List<Card> Cards { get; set; }
        public static object obj = new object();
        public Thread ThreadMoney { get; set; }
        public bool TheButton { get; set; } = false;
        public MainViewModel(List<Card> cards)
        {
            Cards = cards;
            CardNumber = 0;

            LoadCommand = new RelayCommand((e) =>
            {
                var card = Cards.FirstOrDefault(b => b.CardNumber == CardNumber);
                if (card != null)
                {
                    CFullname = card.Name + " " + card.Surname;
                    Customer = card;
                    Money = Customer.Money;
                    TransferE = true;
                }
            }, (f) =>
            {
                if (CardNumber != 0)
                {
                    return true;
                }
                return false;
            });
            InsertCommand = new RelayCommand((e) =>
            {
                InsertE = true;
            });
            TransferCommand = new RelayCommand((e) =>
            {
                if (Customer.Money < MoneyMinus || MoneyMinus < 0)
                {
                    MessageBox.Show("Enter invalid value!");
                }
                else
                {
                    ThreadMoney = new Thread((ThreadStart)AllThreads);
                    ThreadMoney.Start();

                }
            });

        }
        public void AllThreads()
        {
            if (!TheButton)
            {
                lock (obj)
                {
                    TheButton = true;
                    for (int i = 0; i < MoneyMinus; i += 10)
                    {
                        MinusMoney = i + 10;
                        Customer.Money -= 10;
                        Money = Customer.Money;
                        Thread.Sleep(1000);
                    }
                    MessageBox.Show("Transfer is successfull!");
                    TheButton = false;
                }
            }
        }

    }
}
