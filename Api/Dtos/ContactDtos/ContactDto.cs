﻿namespace Api.Dtos.ContactDtos
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Comments { get; set; }
    }
}
