using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForm
{
    internal class Orders
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int total { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }

        
        public DateTime created_at { get; set; }
    }
}
