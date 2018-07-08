using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using Remotion.Linq.Clauses;

namespace P02_DatabaseFirst
{
    public class StartUp
    {
        private const string ResultsFolder = "Results\\";

        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            //EmployeesFullInformation(db);
            //EmployeesWithSalaryOver50000(db);
            //EmployeesFromResearchAndDevelopment(db);
            //AddingNewAddressUpdatingEmployee(db);
            //EmployeesAndProjects(db);
            //AddressesByTown(db);
            //Employee147(db);
            //DepartmentsWithMoreThanFiveEmployees(db);
            //FindLatestTenProjects(db);
            //IncreaseSalaries(db);
            //FindEmployeesByFirstNameStartingWithSA(db);
            //DeleteProjectById(db);
            RemoveTowns(db);
        }

        private static void EmployeesFullInformation(SoftUniContext db)
        {
            var employees = db.Employees
                .Select(x => new Employee()
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    JobTitle = x.JobTitle,
                    Salary = x.Salary
                })
                .OrderBy(x => x.EmployeeId)
                .ToArray();

            using (StreamWriter swr = new StreamWriter(ResultsFolder + "EmployeesFullInfo.txt"))
            {
                foreach (var employee in employees)
                {
                    swr.WriteLine("{0} {1} {2} {3} {4:F2}", employee.FirstName, employee.LastName, employee.MiddleName, employee.JobTitle, employee.Salary);
                }
            }
        }

        private static void EmployeesWithSalaryOver50000(SoftUniContext db)
        {
            var employees = db.Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .Select(x => x.FirstName);

            using (StreamWriter swr = new StreamWriter(ResultsFolder + "EmployeesWithSalaryOver50000.txt"))
            {
                foreach (var name in employees)
                {
                    swr.WriteLine(name);
                }
            }
        }

        private static void EmployeesFromResearchAndDevelopment(SoftUniContext db)
        {
            var employees = db.Employees
                .Where(d => d.Department.Name == "Research and Development")
                .OrderBy(s => s.Salary)
                .ThenByDescending(f => f.FirstName)
                .Select(x => new 
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DepartmentName = x.Department.Name,
                    Salary = x.Salary
                });

            using (StreamWriter swr = new StreamWriter(ResultsFolder + "EmployeesResearchDevelopment.txt"))
            {
                foreach (var employee in employees)
                {
                    swr.WriteLine("{0} {1} from {2} - ${3:F2}", employee.FirstName, employee.LastName, employee.DepartmentName, employee.Salary);
                }
            }
        }

        private static void AddingNewAddressUpdatingEmployee(SoftUniContext db)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = db.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;

            db.SaveChanges();

            var employees = db.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText);

            using (StreamWriter swr = new StreamWriter(ResultsFolder + "AddingNewAddressUpdatingEmployee.txt"))
            {
                foreach (var addressText in employees)
                {
                    swr.WriteLine(addressText);
                }
            }
        }

        private static void EmployeesAndProjects(SoftUniContext db)
        {
            var employees = db.Employees
                .Where(ep =>
                    ep.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                })
                .Take(30)
                .ToArray();

            using (StreamWriter swr = new StreamWriter(ResultsFolder + "EmployeesAndProjects.txt"))
            {
                foreach (var employee in employees)
                {
                    swr.WriteLine("{0} - Manager: {1}", employee.EmployeeName, employee.ManagerName);

                    foreach (var p in employee.Projects)
                    {
                        swr.WriteLine("--{0} - {1} - {2}", p.ProjectName, 
                                                          p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                                          p.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) ?? "not finished");
                    }
                }
            }
        }

        private static void AddressesByTown(SoftUniContext db)
        {
            var addresses = db.Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(t => t.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(x => new
                {
                    AddressText = x.AddressText,
                    TownName = x.Town.Name,
                    EmployeeCount = x.Employees.Count
                });

            StreamWriter swr = new StreamWriter(ResultsFolder + "AddressesByTown.txt");

            using (swr)
            {
                foreach (var address in addresses)
                {
                    swr.WriteLine("{0}, {1} - {2} employees", address.AddressText, address.TownName, address.EmployeeCount);
                }
            }
        }

        private static void Employee147(SoftUniContext db)
        {
            int employeeId = 147;

            var employee = db.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .FirstOrDefault(e => e.EmployeeId == employeeId);

            var projects = employee.EmployeesProjects
                .OrderBy(x => x.Project.Name)
                .Select(x => x.Project.Name)
                .ToArray();

            StreamWriter swr = new StreamWriter(ResultsFolder + "Employee147.txt");

            using (swr)
            {
                swr.WriteLine("{0} {1} - {2}", employee.FirstName, employee.LastName, employee.JobTitle);

                foreach (var project in projects)
                {
                    swr.WriteLine(project);
                }
            }
        }

        private static void DepartmentsWithMoreThanFiveEmployees(SoftUniContext db)
        {
            var departments = db.Departments
                .Include(m => m.Manager)
                .Include(e => e.Employees)
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name);
            
            StreamWriter swr = new StreamWriter(ResultsFolder + "DepartmentsWithMoreThanFiveEmployees.txt");

            using (swr)
            {
                foreach (var department in departments)
                {
                    swr.WriteLine("{0} - {1}", department.Name, department.Manager.FirstName + " " + department.Manager.LastName);

                    foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                    {
                        swr.WriteLine("{0} - {1}", employee.FirstName + " " + employee.LastName, employee.JobTitle);
                    }

                    swr.WriteLine("----------");
                }
            }
        }

        private static void FindLatestTenProjects(SoftUniContext db)
        {
            var projects = db.Projects
                .OrderByDescending(s => s.StartDate)
                .Take(10);

            StreamWriter swr = new StreamWriter(ResultsFolder + "FindLatestTenProjects.txt");

            using (swr)
            {
                foreach (var project in projects.OrderBy(x => x.Name))
                {
                    swr.WriteLine(project.Name);
                    swr.WriteLine(project.Description);
                    swr.WriteLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                }
            }
        }

        private static void IncreaseSalaries(SoftUniContext db)
        {
            string[] departments = { "Engineering", "Tool Design", "Marketing ", "Information Services" };

            var employees = db.Employees
                .Include(d => d.Departments)
                .Where(x => departments.Contains(x.Department.Name));

            foreach (var employee in employees)
            {
                employee.Salary += (employee.Salary * 0.12m);
            }
            db.SaveChanges();

            StreamWriter swr = new StreamWriter(ResultsFolder + "IncreaseSalaries.txt");

            using (swr)
            {
                foreach (var employee in employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    swr.WriteLine("{0} {1} (${2:F2})", employee.FirstName, employee.LastName, employee.Salary);
                }
            }
        }

        private static void FindEmployeesByFirstNameStartingWithSA(SoftUniContext db)
        {
            var employees = db.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            StreamWriter swr = new StreamWriter(ResultsFolder + "FindEmployeesByFirstNameStartingWithSA.txt");

            using (swr)
            {
                foreach (var employee in employees)
                {
                    swr.WriteLine("{0} - {1} - (${2:F2})", employee.FirstName + " " + employee.LastName, employee.JobTitle, employee.Salary);
                }
            }
        }

        private static void DeleteProjectById(SoftUniContext db)
        {
            int projectId = 2;

            var projectToDelete = db.Projects.Find(projectId);
            var projectReferences = db.EmployeesProjects
                .Where(x => x.Project.ProjectId == projectId);

            foreach (var reference in projectReferences)
            {
                db.EmployeesProjects.Remove(reference);
            }
            db.Projects.Remove(projectToDelete);

            db.SaveChanges();

            var projectsToPrint = db.Projects
                .Take(10);

            StreamWriter swr = new StreamWriter(ResultsFolder + "DeleteProjectById.txt");

            using (swr)
            {
                foreach (var project in projectsToPrint)
                {
                    swr.WriteLine($"{project.Name}");
                }
            }
        }

        private static void RemoveTowns(SoftUniContext db)
        {
            string townToDelete = Console.ReadLine();

            var addresses = db.Addresses
                .Include(x => x.Employees)
                .Where(x => x.Town.Name == townToDelete)
                .ToArray();

            for (int i = 0; i < addresses.Length; i++)
            {
                addresses[i] = null;
            }

            var addressesToDelete = db.Addresses
                .Where(x => x.Town.Name == townToDelete)
                .ToArray();

            db.Addresses.RemoveRange(addressesToDelete);
            var town = db.Towns.FirstOrDefault(x => x.Name == townToDelete);
            db.Towns.Remove(town);

            Console.WriteLine("{0} {1} in {2} {3} deleted", addresses.Length, 
                (addresses.Length > 1 ? "addresses" : "address"),
                townToDelete,
                addresses.Length > 1 ? "were" : "was");
        }
    }
}
