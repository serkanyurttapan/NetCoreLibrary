using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.Models
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual string Content { get; set; }
        public virtual string Province { get; set; }
        public virtual string PostCode { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
