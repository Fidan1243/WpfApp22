using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp22.Commands;
using WpfApp22.Models;

namespace WpfApp22.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private string cFullname;

        public string CFullname
        {
            get { return cFullname; }
            set { cFullname = value;OnPropertyChanged(); }
        }

        private decimal minusMoney;

        public decimal MinusMoney
        {
            get { return minusMoney; }
            set { minusMoney = value;OnPropertyChanged(); }
        }

        private long cardNumber;

        public long CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value;OnPropertyChanged(); }
        }

        private bool insertE;

        public bool InsertE
        {
            get { return insertE; }
            set { insertE = value;OnPropertyChanged(); }
        }

        private bool transferE;

        public bool TransferE
        {
            get { return transferE; }
            set { transferE = value; OnPropertyChanged(); }
        }

        public RelayCommand LoadCommand { get; set; }
        public RelayCommand TransferCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public List<Card> Cards { get; set; }
        public Card Customer { get; set; }
        public MainViewModel(List<Card> cards)
        {
            Cards = cards;
            CardNumber = 0;
            LoadCommand = new RelayCommand((e) =>
            {
                var card = Cards.FirstOrDefault(b => b.CardNumber == CardNumber);
                if (card != null)
                {
                    CFullname = card.Name + card.Surname;
                    Customer = card;
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

        }

    }
}
