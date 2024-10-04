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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        
        // Navigation property
        public virtual Attendance Attendance { get; set; }
    }

    
    

}
