﻿using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto.Ticket
{
    public class UpdateTicketTypeRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        [Required]
        public Guid VenueId { get; set; }

    }
}
