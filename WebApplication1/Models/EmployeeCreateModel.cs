using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class EmployeeCreateModel
    {
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
    }
}
