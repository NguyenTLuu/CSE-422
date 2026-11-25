using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }

        public string FullName { get; set; } = "";
    }
}
