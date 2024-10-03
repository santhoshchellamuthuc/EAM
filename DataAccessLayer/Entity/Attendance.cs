using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Attendance
    {
        [Key]
        // Models/Attendance
        public long AttendanceID { get; set; }
        //foreign key for Employee
        public long EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        [ForeignKey("EmployeeID")]
        // Navigation property
        public virtual Employee Employee { get; set; }
    }
}
 