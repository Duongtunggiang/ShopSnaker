using NewShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Shop.Services
{
    public class RoleService
    {
        private readonly Model1 _context;

        public RoleService(Model1 context)
        {
            _context = context;
        }

        public void EnsureRolesExist()
        {
            try
            {
                if (!_context.Role.Any(r => r.RoleName == "Admin"))
                {
                    var adminRole = new Role { RoleName = "Admin" };
                    _context.Role.Add(adminRole);
                    Console.WriteLine("Admin role added.");
                }

                if (!_context.Role.Any(r => r.RoleName == "Customer"))
                {
                    var customerRole = new Role { RoleName = "Customer" };
                    _context.Role.Add(customerRole);
                    Console.WriteLine("Customer role added.");
                }

                if (!_context.Role.Any(r => r.RoleName == "Saler"))
                {
                    var salerRole = new Role { RoleName = "Saler" };
                    _context.Role.Add(salerRole);
                    Console.WriteLine("Saler role added.");
                }

                _context.SaveChanges();
                Console.WriteLine("Roles saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding roles: " + ex.Message);
            }
        }

    }
}