using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Entites
{
    public class EmployeeEntity
    {
        public EmployeeEntity()
        {
        }

        public EmployeeEntity(EmployeeDto employeeDto)
        {
            Name = employeeDto.Name;
            Age = employeeDto.Age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
