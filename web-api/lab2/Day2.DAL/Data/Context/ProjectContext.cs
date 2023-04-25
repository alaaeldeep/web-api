using Day2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.DAL;

public  class ProjectContext  : DbContext 
{
    public ProjectContext(DbContextOptions<ProjectContext> options):base(options) 
    {

    }
    public DbSet<Ticket> tickets => Set<Ticket>();
    public DbSet<Department> departments => Set<Department>();
    public DbSet<Developer> developers => Set<Developer>();

   



}
