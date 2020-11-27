using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Entity;
using EFCoreRelationshipsPractice.Repository;
using Microsoft.AspNetCore.Mvc;
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
                .Include(company => company.Employees)
                .ToListAsync();
            return this.companyDbContext.Companies.ToList().Select(companyEntity => new CompanyDto(companyEntity)).ToList();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            var foundCompanyEntity = await this.companyDbContext.Companies.FirstOrDefaultAsync(companyEntity => companyEntity.Id == id);
            return new CompanyDto(foundCompanyEntity);
        }

        public async Task<int> AddCompanyAsync(CompanyDto companyDto)
        {
            CompanyEntity companyEntity = new CompanyEntity(companyDto);
            await this.companyDbContext.Companies.AddAsync(companyEntity);
            await this.companyDbContext.SaveChangesAsync();
            return companyEntity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            var foundCompany = await this.companyDbContext.Companies.FirstOrDefaultAsync(company => company.Id == id);
            companyDbContext.Companies.Remove(foundCompany);
            await companyDbContext.SaveChangesAsync();
        }
    }
}