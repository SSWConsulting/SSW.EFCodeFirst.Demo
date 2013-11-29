using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo.Domain
{
    public class Customer
    {
        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string EmailAddress { get; set; }

        public virtual string Address1 { get; set; }

        public virtual string Address2 { get; set; }

        public virtual string Suburb { get; set; }

        public virtual State State { get; set; }

        public virtual String Postcode { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Mobile { get; set; }


    }


    public enum State
    {
        ACT,
        QLD,
        NSW,
        NT,
        SA,
        TAS,
        VIC,
        WA
    }

}
