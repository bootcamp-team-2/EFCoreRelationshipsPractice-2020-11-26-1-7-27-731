using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Entities;
using EFCoreRelationshipsPractice.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext companyDbContext;

        public CompanyService(CompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            var companies = await this.companyDbContext.Companies
                .Include(company => company.Profile)
                .Include(company => company.Employees).ToListAsync();
            return companies.Select(companyEntity => new CompanyDto(companyEntity)).ToList();
            //throw new NotImplementedException();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            var foundcompany = await this.companyDbContext.Companies.FirstOrDefaultAsync(companyEntity => companyEntity.Id == id);
            return new CompanyDto(foundcompany);
            // throw new NotImplementedException();
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            CompanyEntity companyEntity = new CompanyEntity()
            {
                Name = companyDto.Name,
               // Location = companyDto.Location,
                Profile = new Entities.ProfileEntity(companyDto.Profile),
                Employees = companyDto.Employees.Select(employDTO => new EmployeeEntity(employDTO)).ToList()
            };

            await this.companyDbContext.Companies.AddAsync(companyEntity);
            await this.companyDbContext.SaveChangesAsync();
            return companyEntity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            throw new NotImplementedException();
            //var foundCompany : Task<CompanyEntity> = Companies.FirstOrDefault
        }
    }
}