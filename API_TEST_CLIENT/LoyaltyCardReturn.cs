using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_TEST_CLIENT
{
    public class LoyaltyCardReturn
    {
        public int id { get; set; }
        public string LoyaltyСard { get; set; }
        public string CardHolder { get; set; }
        public int Balance { get; set; }

        public LoyaltyCardReturn(int id, string loyaltyСard, string cardHolder, int balance)
        {
            this.id = id;
            LoyaltyСard = loyaltyСard;
            CardHolder = cardHolder;
            Balance = balance;
        }
    }
}
