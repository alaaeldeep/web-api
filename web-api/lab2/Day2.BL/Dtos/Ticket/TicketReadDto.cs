using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.BL.Dtos.Ticket
{
    public record  TicketReadDto
    {
        public required int Id { get; init; }
        public required string? Description { get; init; }

        public required int DevelopersCount { get; init; }
    }
}
