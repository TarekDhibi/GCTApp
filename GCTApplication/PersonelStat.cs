using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTApplication
{
    public class PersonelStat
    {
        public string login { get; set; }
        public int action { get; set; }
        public PersonelStat(String login, int action)
        {
            this.login = login;
            this.action = action;
        }
    }
}
