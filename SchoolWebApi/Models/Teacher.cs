using System;
using System.Collections.Generic;

namespace SchoolWebApi.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
