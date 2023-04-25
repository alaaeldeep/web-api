using Day2.BL;
using Day2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.BL;

public interface IDepartmentManager
{
    DepartmentDetailsReadDto? GetDetails(int id);
}
