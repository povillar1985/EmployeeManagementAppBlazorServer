using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAppBlazorServer.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
