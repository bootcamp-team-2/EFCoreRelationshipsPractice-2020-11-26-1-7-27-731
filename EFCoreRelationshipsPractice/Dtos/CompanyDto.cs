using System.Collections.Generic;
using EFCoreRelationshipsPractice.Entites;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto()
        {
        }

        public CompanyDto(CompanyEntity companyEntity)
        {
            Name = companyEntity.Name;
            Profile = new ProfileDto(companyEntity.Profile);
        }

        public string Name { get; set; }

        public ProfileDto Profile { get; set; }

        public List<EmployeeDto> Employees { get; set; }
    }
}