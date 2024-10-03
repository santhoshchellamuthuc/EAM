using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    // Models/Employee
    public class Employee
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        
        // Navigation property
        public virtual Attendance Attendance { get; set; }
    }

    
    

}
