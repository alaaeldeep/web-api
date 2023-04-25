using Day2.BL;
using Day2.BL.Dtos.Ticket;
using Day2.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.BL;

public class DepartmentManager : IDepartmentManager
{
    private readonly IDepartmentRepo departmentRepo;

    public DepartmentManager(IDepartmentRepo departmentRepo)
    {
        this.departmentRepo = departmentRepo;
    }
    public DepartmentDetailsReadDto? GetDetails(int id)

    {

        Department? departmentformdb = departmentRepo.GetwithticketsandDevelopersByid(id);

        if (departmentformdb == null)
        {
            return null;

        }
        return new DepartmentDetailsReadDto
        {
            Id = id,
            Name = departmentformdb.Name,


            tickets = departmentformdb.Tickets
            .Select(dbticket => new TicketReadDto {
                Id = dbticket.Id,
                Description = dbticket.Description,
                DevelopersCount = dbticket.Developers.Count,



            }).ToList(),

        };
    } }
