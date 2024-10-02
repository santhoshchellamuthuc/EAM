using System;

namespace DataAccessLayer
{
    // Models/Employee.cs
    public class Employee
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

        // Navigation property
        public virtual Attendance Attendance { get; set; }
    }

    // Models/Attendance.cs
    public class Attendance
    {
        public long AttendanceID { get; set; }
        public long EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }

        // Navigation property
        public virtual Employee Employee { get; set; }
    }

}
