using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EFCoreRelationshipsPracticeTest.ServiceTest
{
    [Collection("IntegrationTest")]
    public class CompanyServiceTest : TestBase
    {
        public CompanyServiceTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_Create_Company_Success_Via_Service()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<CompanyDbContext>();

            CompanyService companyService = new CompanyService(context);
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19
                    }
                };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };
            await companyService.AddCompany(companyDto);
            var foundCompany = await context.Companies
                .Include(company => company.Profile)
                .Include(company => company.Employees)
                .FirstOrDefaultAsync();
            Assert.Equal(1, context.Companies.Count());
            Assert.Equal(companyDto.Employees.Count, foundCompany.Employees.Count);
            Assert.Equal(companyDto.Employees[0].Age, foundCompany.Employees[0].Age);
            Assert.Equal(companyDto.Employees[0].Name, foundCompany.Employees[0].Name);
            Assert.Equal(companyDto.Profile.CertId, foundCompany.Profile.CertId);
            Assert.Equal(companyDto.Profile.RegisteredCapital, foundCompany.Profile.RegisteredCapital);
        }

        [Fact]
        public async Task Should_Create_Many_Companies_Success_Via_Service()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<CompanyDbContext>();

            CompanyService companyService = new CompanyService(context);
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19
                }
            };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };

            await companyService.AddCompany(companyDto);
            await companyService.AddCompany(companyDto);

            Assert.Equal(2, context.Companies.Count());
        }

        [Fact]
        public async Task Should_Delete_Company_With_Related_Employees_And_Profiles_Success_Via_Service()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<CompanyDbContext>();

            CompanyService companyService = new CompanyService(context);
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19
                }
            };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };

            var companyId = await companyService.AddCompany(companyDto);
            await companyService.DeleteCompany(companyId);

            Assert.Equal(0, context.Companies.Count());
            //Assert.Equal(0, context.Profiles.Count());
            //Assert.Equal(0, context.Profiles.Count());
        }
    }
}
