using System;
using System.Collections.Generic;
using System.Text;

namespace EmpPayRollADODay26
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime start { get; set; }
        public char gender { get; set; }
        public long phone { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public int basic_pay { get; set; }
        public int deduction { get; set; }
        public int taxable_Pay { get; set; }
        public int income_tax { get; set; }
        public int net_pay{ get; set; }
        public string company { get; set; }


    }
}
