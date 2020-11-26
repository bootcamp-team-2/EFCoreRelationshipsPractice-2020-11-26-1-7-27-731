using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Entites;
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
            return await this.companyDbContext.Companies
                .Include(company => company.Employees)
                .Include(company => company.Profile)
                .Select(companyEntity => new CompanyDto(companyEntity))
                .ToListAsync();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            var foundCompanyEntity = await this.companyDbContext.Companies
                .Include(company => company.Employees)
                .Include(company => company.Profile)
                .FirstOrDefaultAsync(companyEntity => companyEntity.Id == id);
            if (foundCompanyEntity != null)
            {
                return new CompanyDto(foundCompanyEntity);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            var companyEntity = new CompanyEntity(companyDto);

            await this.companyDbContext.Companies.AddAsync(companyEntity);
            await this.companyDbContext.SaveChangesAsync();
            return companyEntity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            var foundCompanyEntity = await this.companyDbContext.Companies
                .Include(company => company.Employees)
                .Include(company => company.Profile)
                .FirstOrDefaultAsync(company => company.Id == id);
            this.companyDbContext.Companies.Remove(foundCompanyEntity);
            this.companyDbContext.Profiles.RemoveRange(foundCompanyEntity.Profile);
            this.companyDbContext.Employees.RemoveRange(foundCompanyEntity.Employees);
            await this.companyDbContext.SaveChangesAsync();
        }
    }
}