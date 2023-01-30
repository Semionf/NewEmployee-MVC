using System.Data.Entity;

namespace NewEmployees.Models
{
    public class DataLayer:DbContext
    {
        private static DataLayer data;
        private DataLayer() :base("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Employees;Data Source=MSI\\SQLEXPRESS")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayer>());
            if(Employees.Count() == 0) Seed();
        }
        //Function that gives read only access to the internal object
        public static DataLayer Data { get 
            { 
                if (data == null) data = new DataLayer(); 
                return data; 
            }
        }

        //Function to seed the DB at initiallization
        private void Seed()
        {
            Employee employee = new Employee
            {
                IDNumber = "111111118",
                FirstName = "סמיון",
                LastName = "פורלנדר"
            };
            Employees.Add(employee);
            SaveChanges();
        }

        public DbSet<Employee> Employees { get; set;}
        public DbSet<Image> Images { get; set;}
    }
}
