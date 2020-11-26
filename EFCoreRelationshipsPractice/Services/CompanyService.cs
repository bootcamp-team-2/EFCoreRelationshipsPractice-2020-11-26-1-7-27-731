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
                .Select(companyEntity => new CompanyDto(companyEntity))
                .ToListAsync();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            var foundCompanyEntity = await this.companyDbContext.Companies
                .FirstOrDefaultAsync(companyEntity => companyEntity.Id == id);

            return new CompanyDto(foundCompanyEntity);
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
                .FirstOrDefaultAsync(company => company.Id == id);
            this.companyDbContext.Companies.Remove(foundCompanyEntity);
            await this.companyDbContext.SaveChangesAsync();
        }
    }
}