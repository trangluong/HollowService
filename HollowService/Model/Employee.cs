using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HollowService.Model
{
    public class Employee
    {
        private int _id;
        [Key]
        public int Id { get { return _id; } set { _id = value; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

    }
}
