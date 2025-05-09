﻿using Dem.Exceptions.InvalidExceptions;
using Dem.Exceptions.NotFoundExceptions;
using Dem.Models.Entities;
using System.Net.Mail;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Dem.Services.DbServices
{
    public class EmployeeService : GenericRepository<Employee>, IEmployeeService
    {
        public EmployeeService(ApplicationDbContext db) : base(db) { }

        public override void Add(Employee employee)
        {
            ValidateEmployee(employee);
            base.Add(employee);
        }

        public override void Update(Employee employee)
        {
            ValidateEmployee(employee);
            base.Update(employee);
        }

        public List<Employee> GetAllWithDetailsAsync()
        {
            return _db.Employees.Include(p => p.HealhStatus).ToList();
        }

        public Employee Get(Guid id)
        {
            Employee? employee = GetById(id);

            return employee == null ? throw new EmployeeNotFoundException(id) : employee;
        }
        public Employee GetWithDetailsAsync(Guid id)
        {
            Employee? employee = _db.Employees.Include(p => p.HealhStatus).FirstOrDefault();

            return employee == null ? throw new EmployeeNotFoundException(id) : employee;
        }

        private void ValidateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new InvalidEmployeeException();
                          
            }
            if (employee.Password.Length < 8)
            {
                throw new InvalidEmployeeException("пароль должен состоять минимум из 8 символов");
            }
            if (DateOnly.FromDateTime(DateTime.Now).Year - employee.DateOfBirth.Year <= 18)
            {
                throw new InvalidEmployeeException("неверно задана дата рождения"); 
            }        
            if (
                String.IsNullOrEmpty(employee.FullName)
                || String.IsNullOrEmpty(employee.JobTitle)
                || String.IsNullOrEmpty(employee.Password)
                || String.IsNullOrEmpty(employee.Email)
                || !MailAddress.TryCreate(employee.Email, out MailAddress? address))
            {
                throw new InvalidEmployeeException();
            }
        }

        public Employee? GetByEmail(string email)
        {
            if (email == null)
            {
                return null;
            }

            return _db.Employees.FirstOrDefault(e => e.Email == email);
        }
    }
}
