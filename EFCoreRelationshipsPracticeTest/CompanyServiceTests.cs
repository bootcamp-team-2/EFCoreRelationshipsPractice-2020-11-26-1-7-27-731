using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EFCoreRelationshipsPracticeTest
{
    public class CompanyServiceTests : TestBase
    {
        public CompanyServiceTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_create_company_success_via_company_service()
        {
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19
                },
            };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };

            var scope = Factory.Services.CreateScope();

            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<CompanyDbContext>();

            var companyService = new CompanyService(context);
            companyService.AddCompany(companyDto);
            Assert.Equal(1, context.Companies.Count());
        }

        [Fact]
        public async Task Should_get_company_by_id_success_via_company_service()
        {
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19
                },
            };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };

            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<CompanyDbContext>();
            var companyService = new CompanyService(context);
            var id = await companyService.AddCompany(companyDto);

            var company = await companyService.GetById(id);
            Assert.Equal("IBM", company.Name);
            Assert.Equal("Tom", company.Employees[0].Name);
            Assert.Equal(19, company.Employees[0].Age);
            Assert.Equal(100010, company.Profile.RegisteredCapital);
            Assert.Equal("100", company.Profile.CertId);
        }

        [Fact]
        public async Task Should_get_all_companies_success_via_company_service()
        {
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19
                },
            };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };

            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<CompanyDbContext>();
            var companyService = new CompanyService(context);
            await companyService.AddCompany(companyDto);
            await companyService.AddCompany(companyDto);

            var companies = await companyService.GetAll();
            Assert.Equal(2, companies.Count);
            Assert.Equal("IBM", companies[0].Name);
            Assert.Equal("Tom", companies[0].Employees[0].Name);
            Assert.Equal(19, companies[0].Employees[0].Age);
            Assert.Equal(100010, companies[0].Profile.RegisteredCapital);
            Assert.Equal("100", companies[0].Profile.CertId);
        }

        [Fact]
        public async Task Should_delete_company_and_related_employees_by_id_success_via_company_service()
        {
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19
                },
            };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };

            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<CompanyDbContext>();
            var companyService = new CompanyService(context);
            var id = await companyService.AddCompany(companyDto);
            await companyService.AddCompany(companyDto);

            await companyService.DeleteCompany(id);

            var companies = await companyService.GetAll();
            Assert.Equal(1, companies.Count);
            var company = await companyService.GetById(id);
            Assert.Null(company);
        }
    }
}
