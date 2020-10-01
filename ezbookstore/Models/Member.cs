using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ezbookstore.Models
{
    public class Member
    {
        public virtual long Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual int Phone { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime DateJoined { get; set; }
    }
}