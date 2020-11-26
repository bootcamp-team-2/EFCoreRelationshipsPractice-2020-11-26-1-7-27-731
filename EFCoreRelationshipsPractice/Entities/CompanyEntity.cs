using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Entities
{
    public class CompanyEntity
    {
        public CompanyEntity()
        {
        }

        public CompanyEntity(CompanyDto companyDto)
        {
            this.Name = companyDto.Name;
            this.Profile = new ProfileEntity(companyDto.Profile);
            this.Employees = companyDto.Employees.Select(employeeDto => new EmployeeEntity(employeeDto)).ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
       // public string Location { get; set; }

        public ProfileEntity Profile { get; set; }
        // public int Rank { get; set; }
        public List<EmployeeEntity> Employees { get; set; }
    }
}
