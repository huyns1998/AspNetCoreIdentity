namespace WebApplication1.BL.Employee
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Data.Employee>> GetAll();
        public Task<Data.Employee> Create(Data.Employee em);
    }
}
