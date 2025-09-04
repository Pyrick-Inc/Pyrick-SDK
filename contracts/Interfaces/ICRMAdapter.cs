using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pyrick.SDK.Contracts.DTOs;

namespace Pyrick.SDK.Contracts.Interfaces
{
    /// <summary>
    /// Interface for CRM system adapters to enable microservices to interact with different CRM systems
    /// </summary>
    public interface ICRMAdapter
    {
        /// <summary>
        /// Create a new engagement in the CRM system
        /// </summary>
        Task<EngagementDto> CreateEngagementAsync(CreateEngagementRequest request);
        
        /// <summary>
        /// Get an engagement by ID
        /// </summary>
        Task<EngagementDto?> GetEngagementAsync(Guid engagementId);
        
        /// <summary>
        /// Update an existing engagement
        /// </summary>
        Task<EngagementDto> UpdateEngagementAsync(Guid engagementId, UpdateEngagementRequest request);
        
        /// <summary>
        /// Get engagements for a party
        /// </summary>
        Task<IEnumerable<EngagementDto>> GetEngagementsByPartyAsync(Guid partyId);
        
        /// <summary>
        /// Create a new party (Individual or Organization)
        /// </summary>
        Task<PartyDto> CreatePartyAsync(CreatePartyRequest request);
        
        /// <summary>
        /// Get a party by ID
        /// </summary>
        Task<PartyDto?> GetPartyAsync(Guid partyId);
        
        /// <summary>
        /// Search for parties by criteria
        /// </summary>
        Task<IEnumerable<PartyDto>> SearchPartiesAsync(PartySearchRequest request);
        
        /// <summary>
        /// Validate that an engagement exists and belongs to the specified party
        /// </summary>
        Task<bool> ValidateEngagementAsync(Guid engagementId, Guid partyId);
        
        /// <summary>
        /// Get available engagement types
        /// </summary>
        Task<IEnumerable<EngagementTypeDto>> GetEngagementTypesAsync();
        
        /// <summary>
        /// Health check for the CRM system
        /// </summary>
        Task<bool> IsHealthyAsync();
    }
    
    // Request/Response DTOs
    public class CreateEngagementRequest
    {
        public Guid PartyId { get; set; }
        public Guid EngagementTypeId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid RegisteredOrganizationId { get; set; }
        public Guid TenantId { get; set; }
    }
    
    public class UpdateEngagementRequest
    {
        public string? Status { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid UpdatedBy { get; set; }
    }
    
    public class CreatePartyRequest
    {
        public string PartyType { get; set; } = string.Empty; // "INDIVIDUAL" or "ORGANIZATION"
        public string DisplayName { get; set; } = string.Empty;
        public string? PrimaryEmail { get; set; }
        public string? PrimaryPhone { get; set; }
        public Guid CreatedBy { get; set; }
        
        // Individual-specific fields
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        // Organization-specific fields
        public string? LegalName { get; set; }
        public string? TaxId { get; set; }
        public string? OrganizationType { get; set; }
    }
    
    public class PartySearchRequest
    {
        public string? SearchTerm { get; set; }
        public string? PartyType { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int Limit { get; set; } = 50;
        public int Offset { get; set; } = 0;
    }
}