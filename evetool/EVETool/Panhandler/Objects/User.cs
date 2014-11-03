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

        public User(string pUserLine)
        {
            var tItems = pUserLine.Split(new char[]{'|'}).ToList();

            if (tItems.Count == 3) 
            {
                this.userName = tItems[0].Trim();
                this.multiplier = Decimal.Parse(tItems[1].Trim());
                this.userId = tItems[2].Trim();
            }
        }

        public override string ToString()
        {
            return String.Format("{0}|{1}|{2}", new string[]{
                     this.userName, this.multiplier.ToString(), this.userId
                 });
        }
    }
}
