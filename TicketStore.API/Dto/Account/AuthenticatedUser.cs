﻿namespace TicketStore.API.Dto.Account
{
    public class AuthenticatedUser
    {
        public string? Username { get; set; }
        
        public string? Email { get; set; }
        
        public string? Fullname { get; set; }

        public string? Token { get; set; }
    }
}
