namespace WebApplication1.BL.Employee
{
    public interface IEmployeeService
    {
         Task<IEnumerable<Data.Employee>> GetAll();
         Task<Data.Employee> Create(Data.Employee em);
         Task<Data.Employee> GetById(int Id);
         Task<Data.Employee> Update(Data.Employee em);
         Task<Data.Employee> Delete(int Id);
    }
}
