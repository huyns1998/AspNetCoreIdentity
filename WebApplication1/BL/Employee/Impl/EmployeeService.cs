using WebApplication1.Dao.Employee;

namespace WebApplication1.BL.Employee.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDao employeeDao;

        public EmployeeService(IEmployeeDao employeeDao)
        {
            this.employeeDao = employeeDao; 
        }
        public async Task<IEnumerable<Data.Employee>> GetAll()
        {
            return await employeeDao.GetAll();   
        }
        public async Task<Data.Employee> Create(Data.Employee em)
        {
            return await employeeDao.Add(em);
        }
    }
}
