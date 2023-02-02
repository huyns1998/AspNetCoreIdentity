using WebApplication1.Dao.System;
using WebApplication1.Data;

namespace WebApplication1.Dao.Employee.Impl
{
    public class EmployeeDao : ACrudDao<Data.Employee>, IEmployeeDao
    {
        public EmployeeDao(AppDbContext context) : base(context)
        {
        }
    }
}
