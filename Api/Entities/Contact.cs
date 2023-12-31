﻿namespace API.Entities
{
    public abstract class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Comments { get; set; }
    }
}
