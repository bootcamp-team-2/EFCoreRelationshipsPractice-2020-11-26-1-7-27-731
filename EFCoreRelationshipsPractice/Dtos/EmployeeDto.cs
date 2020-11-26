using EFCoreRelationshipsPractice.Entity;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }

        public EmployeeDto(EmployeeEitity employeeEitity)
        {
            this.Name = employeeEitity.Name;
            this.Age = employeeEitity.Age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}