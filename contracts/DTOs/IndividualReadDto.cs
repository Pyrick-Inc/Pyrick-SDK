using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Pyrick.Api.Data.DTOs.Individual
{
    public class IndividualReadDto
    {
        public Guid Id { get; set; }
        public string? Prefix { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? Suffix { get; set; }
        public string? Pronouns { get; set; }
        public string? Linkedin { get; set; }
        public string? Website { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public JsonDocument? CustomFields { get; set; }
    }
}
