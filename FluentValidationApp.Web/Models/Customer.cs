using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.Models
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual int Age { get; set; }
        public virtual DateTime? BirthDay { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public Gender Gender { get; set; }
    }
}