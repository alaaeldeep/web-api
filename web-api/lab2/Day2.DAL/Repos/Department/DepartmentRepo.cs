using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.DAL
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ProjectContext context;

        public DepartmentRepo(ProjectContext Context)
        {
            context = Context;
        }
        public Department? GetwithticketsandDevelopersByid(int id)
        {
            return context.departments.Include(d => d.Tickets)
                                            .ThenInclude(t => t.Developers)
                                            .FirstOrDefault(p => p.Id == id);
        }
    }
}
