﻿using EFCoreRelationshipsPractice.Entites;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }

        public EmployeeDto(EmployeeEntity employeeEntity)
        {
            Name = employeeEntity.Name;
            Age = employeeEntity.Age;
        }

        public string Name { get; set; }
        public int? Age { get; set; }
    }
}