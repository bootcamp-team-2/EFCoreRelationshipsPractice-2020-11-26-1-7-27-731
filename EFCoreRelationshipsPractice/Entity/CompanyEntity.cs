using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice.Entity
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
            this.Employees = companyDto.Employees.Select(employDto => new EmployeeEitity(employDto)).ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ProfileEntity Profile { get; set; }
        public List<EmployeeEitity> Employees { get; set; }
    }

    public class EmployeeEitity
    {
        public EmployeeEitity()
        {
        }

        public EmployeeEitity(EmployeeDto employeeDto)
        {
            this.Name = employeeDto.Name;
            this.Age = employeeDto.Age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class ProfileEntity
    {
        public ProfileEntity()
        {
        }

        public ProfileEntity(ProfileDto profileDto)
        {
            this.CertId = profileDto.CertId;
            this.RegisteredCapital = profileDto.RegisteredCapital;
        }

        public int Id { get; set; }
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}
