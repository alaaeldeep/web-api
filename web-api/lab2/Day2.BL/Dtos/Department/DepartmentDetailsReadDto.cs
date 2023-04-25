using Day2.BL.Dtos.Ticket;
using Day2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.BL;

public record DepartmentDetailsReadDto
{
    public required int Id { get; init; }
    public required string? Name { get; init; }

    public List <TicketReadDto> tickets { get; init; } = new();
}
