using DataModels.Entity;

namespace DataModels.ExtendedModels
{
    public class EmployeeExtended
    {
        public int id { get; set; }
        public string fpNumber { get; set; }
        public string rank { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string department { get; set; }
        public DateTimeOffset date { get; set; }
        public IEnumerable<MaterialItem> MaterialItems { get; set; }
        public EmployeeExtended()
        {

        }
        public EmployeeExtended(Employee employee)
        {
            id = employee.id;
            fpNumber = employee.fpNumber;
            rank = employee.rank;
            firstName = employee.firstName;
            middleName = employee.middleName;
            lastName = employee.lastName;
            gender = employee.gender;
            department = employee.department;
            date = employee.date;

        }
    }
}
