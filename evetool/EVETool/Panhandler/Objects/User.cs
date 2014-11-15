using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panhandler.Objects
{
    public class User
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public decimal multiplier { get; set; }

        public User(string userLine)
        {
            var items = userLine.Split(new []{'|'}).ToList();

            if (items.Count != 3) return;

            userName = items[0].Trim();
            multiplier = Decimal.Parse(items[1].Trim());
            userId = items[2].Trim();
        }

        public override string ToString()
        {
            return String.Format("{0,-35}|{1,-5}|{2}", new []{
                     this.userName, this.multiplier.ToString(), this.userId
                 });
        }
    }
}
