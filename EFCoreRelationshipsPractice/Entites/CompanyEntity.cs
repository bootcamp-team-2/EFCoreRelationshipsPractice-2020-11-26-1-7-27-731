using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Entites
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
            this.Employees = companyDto.Employees?
                .Select(employeeDto => new EmployeeEntity(employeeDto))
                .ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ProfileEntity? Profile { get; set; }
        [ForeignKey("CompanyId")]
        public List<EmployeeEntity>? Employees { get; set; }
    }
}
