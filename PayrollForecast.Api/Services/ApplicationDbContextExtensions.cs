using PayrollForecast.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Services
{
    public static class ApplicationDbContextExtensions
    {
        public static void EnsureSeedDataForContext(this ApplicationDbContext context)
        {
            if (!context.Employees.Any())
            {                
                var employees = new List<Employee>()
                {
                    new Employee()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Dependents = new List<Dependent>()
                        {
                            new Dependent()
                            {
                                FirstName = "Jane",
                                LastName = "Doe"
                            },
                            new Dependent()
                            {
                                FirstName = "Alex",
                                LastName = "Doe"
                            }
                        }
                    },
                    new Employee()
                    {
                        FirstName = "Alison",
                        LastName = "Jacobs"
                    },
                    new Employee()
                    {
                        FirstName = "Kelly",
                        LastName = "Charleston",
                        Dependents = new List<Dependent>()
                        {
                            new Dependent()
                            {
                                FirstName = "Matthew",
                                LastName = "Charleston"
                            }
                        }
                    },
                    new Employee()
                    {
                        FirstName = "Kyle",
                        LastName = "Richardson",
                        Dependents = new List<Dependent>()
                        {
                            new Dependent()
                            {
                                FirstName = "Elena",
                                LastName = "Richardson"
                            },
                            new Dependent()
                            {
                                FirstName = "Rebecca",
                                LastName = "Richardson"
                            },
                            new Dependent()
                            {
                                FirstName = "Tyler",
                                LastName = "Richardson"
                            }
                        }
                    }
                };

                context.Employees.AddRange(employees);

                context.SaveChanges();
            }
        }
    }
}
