using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Pyrick.Api.Data.DTOs.Individual
{
    public class IndividualUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Website { get; set; }
        public string? SocialSecurityNumber { get; set; }
        
        private DateTime? _dateOfBirth;
        public DateTime? DateOfBirth 
        { 
            get => _dateOfBirth;
            set => _dateOfBirth = value?.Kind == DateTimeKind.Unspecified 
                ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) 
                : value?.ToUniversalTime();
        }
        public JsonDocument? CustomFields { get; set; }
    }
}
