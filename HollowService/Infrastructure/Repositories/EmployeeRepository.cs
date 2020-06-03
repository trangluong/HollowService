using HollowService.Interfaces;
using HollowService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollowService.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDBContext _db;
        public EmployeeRepository(MyDBContext dBContext)
        {
            _db = dBContext;
        }

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<int> DeleteEmployeeByIdAsync(int id)
        {
            var employee = new Employee { Id = id };
            _db.Employees.Attach(employee);
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return id;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await (from p in _db.Employees
                          where p.Id == id
                          select p).FirstOrDefaultAsync();

        }


        public async Task<List<Employee>> GetEmployementsAsync()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<int> UpdateEmployeeByIdAsync(int id, Employee employee)
        {
            var emp = new Employee { Id = id };
            _db.Employees.Attach(employee);
            _db.Entry(employee).State = EntityState.Modified;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Title = employee.Title;
            await _db.SaveChangesAsync();
            return id;
        }
    }
}
