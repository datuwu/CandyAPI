using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int? Roleid { get; set; }
        public bool? Status { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
