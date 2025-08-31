using System;
using System.Threading.Tasks;
using Pyrick.SDK.Contracts.DTOs;
using Pyrick.SDK.Contracts.Interfaces;

namespace Pyrick.SDK.Adapters
{
    /// <summary>
    /// Mock adapter implementation for testing and development
    /// </summary>
    public class MockAdapter : BaseCRMAdapter
    {
        private readonly Dictionary<Guid, ContactDto> _contacts = new Dictionary<Guid, ContactDto>();
        private readonly Dictionary<Guid, CompanyDto> _companies = new Dictionary<Guid, CompanyDto>();
        private readonly Dictionary<Guid, EngagementDto> _engagements = new Dictionary<Guid, EngagementDto>();
        private readonly Dictionary<Guid, WorkflowTemplateDto> _workflowTemplates = new Dictionary<Guid, WorkflowTemplateDto>();
        private readonly Dictionary<Guid, WorkflowInstanceDto> _workflowInstances = new Dictionary<Guid, WorkflowInstanceDto>();
        
        public override AdapterInfo GetAdapterInfo()
        {
            return new AdapterInfo
            {
                Name = "Mock CRM Adapter",
                Version = "1.0.0",
                Description = "In-memory mock implementation for testing and development",
                TargetSystem = "Mock System",
                SupportedFeatures = new List<string>
                {
                    "Contacts", "Companies", "Engagements", "Workflows", "Search", "Sync"
                }
            };
        }
        
        protected override Task OnInitializeAsync()
        {
            SeedMockData();
            return Task.CompletedTask;
        }
        
        private void SeedMockData()
        {
            // Seed sample contacts
            var contact1 = new ContactDto
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@example.com",
                Phone = "+1-555-0123",
                CreatedAt = DateTime.UtcNow.AddDays(-30),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };
            _contacts[contact1.Id] = contact1;
            
            var contact2 = new ContactDto
            {
                Id = Guid.NewGuid(),
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@acmecorp.com",
                Phone = "+1-555-0456",
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                UpdatedAt = DateTime.UtcNow.AddDays(-2)
            };
            _contacts[contact2.Id] = contact2;
            
            // Seed sample companies
            var company1 = new CompanyDto
            {
                Id = Guid.NewGuid(),
                Name = "Acme Corporation",
                Website = "https://acmecorp.com",
                Industry = "Technology",
                EmployeeCount = "100-500",
                PrimaryEmail = "info@acmecorp.com",
                PrimaryPhone = "+1-555-0789",
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-10)
            };
            _companies[company1.Id] = company1;
            
            // Seed sample engagements
            var engagement1 = new EngagementDto
            {
                Id = Guid.NewGuid(),
                Name = "Website Redesign Project",
                Description = "Complete redesign of company website",
                PrimaryContactId = contact2.Id,
                PrimaryCompanyId = company1.Id,
                Status = "In Progress",
                Type = "Project",
                Priority = "High",
                EstimatedValue = 50000,
                Currency = "USD",
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                EngagementDate = DateTime.UtcNow.AddDays(-15)
            };
            _engagements[engagement1.Id] = engagement1;
        }
        
        #region Mock CRM Implementation
        public override Task<bool> TestConnectionAsync()
        {
            EnsureInitialized();
            return Task.FromResult(true);
        }
        
        public override Task<ContactDto?> GetContactAsync(Guid id)
        {
            EnsureInitialized();
            _contacts.TryGetValue(id, out var contact);
            return Task.FromResult(contact);
        }
        
        public override Task<ContactDto?> GetContactByEmailAsync(string email)
        {
            EnsureInitialized();
            var contact = _contacts.Values.FirstOrDefault(c => 
                c.Email?.Equals(email, StringComparison.OrdinalIgnoreCase) == true);
            return Task.FromResult(contact);
        }
        
        public override Task<IEnumerable<ContactDto>> GetContactsAsync(int skip = 0, int take = 100)
        {
            EnsureInitialized();
            var contacts = _contacts.Values
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .Skip(skip)
                .Take(take);
            return Task.FromResult(contacts);
        }
        
        public override Task<IEnumerable<ContactDto>> SearchContactsAsync(string searchTerm)
        {
            EnsureInitialized();
            var lowerSearchTerm = searchTerm.ToLowerInvariant();
            var contacts = _contacts.Values.Where(c =>
                c.FirstName.ToLowerInvariant().Contains(lowerSearchTerm) ||
                c.LastName.ToLowerInvariant().Contains(lowerSearchTerm) ||
                (c.Email?.ToLowerInvariant().Contains(lowerSearchTerm) == true));
            return Task.FromResult(contacts);
        }
        
        public override Task<ContactDto> CreateContactAsync(ContactDto contact)
        {
            EnsureInitialized();
            contact.Id = Guid.NewGuid();
            contact.CreatedAt = DateTime.UtcNow;
            contact.UpdatedAt = DateTime.UtcNow;
            _contacts[contact.Id] = contact;
            return Task.FromResult(contact);
        }
        
        public override Task<ContactDto> UpdateContactAsync(ContactDto contact)
        {
            EnsureInitialized();
            if (!_contacts.ContainsKey(contact.Id))
                throw new ArgumentException($"Contact with ID {contact.Id} not found");
            
            contact.UpdatedAt = DateTime.UtcNow;
            _contacts[contact.Id] = contact;
            return Task.FromResult(contact);
        }
        
        public override Task DeleteContactAsync(Guid id)
        {
            EnsureInitialized();
            _contacts.Remove(id);
            return Task.CompletedTask;
        }
        
        public override Task<CompanyDto?> GetCompanyAsync(Guid id)
        {
            EnsureInitialized();
            _companies.TryGetValue(id, out var company);
            return Task.FromResult(company);
        }
        
        public override Task<CompanyDto?> GetCompanyByNameAsync(string name)
        {
            EnsureInitialized();
            var company = _companies.Values.FirstOrDefault(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(company);
        }
        
        public override Task<IEnumerable<CompanyDto>> GetCompaniesAsync(int skip = 0, int take = 100)
        {
            EnsureInitialized();
            var companies = _companies.Values
                .OrderBy(c => c.Name)
                .Skip(skip)
                .Take(take);
            return Task.FromResult(companies);
        }
        
        public override Task<IEnumerable<CompanyDto>> SearchCompaniesAsync(string searchTerm)
        {
            EnsureInitialized();
            var lowerSearchTerm = searchTerm.ToLowerInvariant();
            var companies = _companies.Values.Where(c =>
                c.Name.ToLowerInvariant().Contains(lowerSearchTerm) ||
                (c.Industry?.ToLowerInvariant().Contains(lowerSearchTerm) == true));
            return Task.FromResult(companies);
        }
        
        public override Task<CompanyDto> CreateCompanyAsync(CompanyDto company)
        {
            EnsureInitialized();
            company.Id = Guid.NewGuid();
            company.CreatedAt = DateTime.UtcNow;
            company.UpdatedAt = DateTime.UtcNow;
            _companies[company.Id] = company;
            return Task.FromResult(company);
        }
        
        public override Task<CompanyDto> UpdateCompanyAsync(CompanyDto company)
        {
            EnsureInitialized();
            if (!_companies.ContainsKey(company.Id))
                throw new ArgumentException($"Company with ID {company.Id} not found");
            
            company.UpdatedAt = DateTime.UtcNow;
            _companies[company.Id] = company;
            return Task.FromResult(company);
        }
        
        public override Task DeleteCompanyAsync(Guid id)
        {
            EnsureInitialized();
            _companies.Remove(id);
            return Task.CompletedTask;
        }
        
        public override Task<SyncResult> SyncContactsAsync(DateTime? lastSyncDate = null)
        {
            EnsureInitialized();
            return Task.FromResult(new SyncResult
            {
                Success = true,
                RecordsProcessed = _contacts.Count,
                RecordsCreated = 0,
                RecordsUpdated = 0,
                RecordsDeleted = 0,
                SyncStartTime = DateTime.UtcNow.AddSeconds(-1),
                SyncEndTime = DateTime.UtcNow
            });
        }
        
        public override Task<SyncResult> SyncCompaniesAsync(DateTime? lastSyncDate = null)
        {
            EnsureInitialized();
            return Task.FromResult(new SyncResult
            {
                Success = true,
                RecordsProcessed = _companies.Count,
                RecordsCreated = 0,
                RecordsUpdated = 0,
                RecordsDeleted = 0,
                SyncStartTime = DateTime.UtcNow.AddSeconds(-1),
                SyncEndTime = DateTime.UtcNow
            });
        }
        #endregion
        
        #region Mock Engagement Implementation
        // Implementation for engagement methods would go here
        // For brevity, returning default/empty implementations
        public override Task<EngagementDto?> GetEngagementAsync(Guid id)
        {
            EnsureInitialized();
            _engagements.TryGetValue(id, out var engagement);
            return Task.FromResult(engagement);
        }
        
        public override Task<IEnumerable<EngagementDto>> GetEngagementsAsync(int skip = 0, int take = 100)
        {
            EnsureInitialized();
            var engagements = _engagements.Values.Skip(skip).Take(take);
            return Task.FromResult(engagements);
        }
        
        // Additional engagement methods would be implemented similarly...
        public override Task<IEnumerable<EngagementDto>> GetEngagementsByContactAsync(Guid contactId) => Task.FromResult(Enumerable.Empty<EngagementDto>());
        public override Task<IEnumerable<EngagementDto>> GetEngagementsByCompanyAsync(Guid companyId) => Task.FromResult(Enumerable.Empty<EngagementDto>());
        public override Task<IEnumerable<EngagementDto>> SearchEngagementsAsync(string searchTerm) => Task.FromResult(Enumerable.Empty<EngagementDto>());
        public override Task<EngagementDto> CreateEngagementAsync(EngagementDto engagement) => Task.FromResult(engagement);
        public override Task<EngagementDto> UpdateEngagementAsync(EngagementDto engagement) => Task.FromResult(engagement);
        public override Task DeleteEngagementAsync(Guid id) => Task.CompletedTask;
        public override Task<IEnumerable<EngagementRoleDto>> GetEngagementRolesAsync(Guid engagementId) => Task.FromResult(Enumerable.Empty<EngagementRoleDto>());
        public override Task<EngagementRoleDto> AddEngagementRoleAsync(Guid engagementId, EngagementRoleDto role) => Task.FromResult(role);
        public override Task<EngagementRoleDto> UpdateEngagementRoleAsync(EngagementRoleDto role) => Task.FromResult(role);
        public override Task RemoveEngagementRoleAsync(Guid roleId) => Task.CompletedTask;
        public override Task<IEnumerable<WorkflowStageDto>> GetAvailableStagesAsync(Guid engagementId) => Task.FromResult(Enumerable.Empty<WorkflowStageDto>());
        public override Task<EngagementDto> AdvanceEngagementStageAsync(Guid engagementId, string targetStage, string? notes = null) => throw new NotImplementedException();
        public override Task<IEnumerable<WorkflowHistoryDto>> GetEngagementHistoryAsync(Guid engagementId) => Task.FromResult(Enumerable.Empty<WorkflowHistoryDto>());
        public override Task<SyncResult> SyncEngagementsAsync(DateTime? lastSyncDate = null) => Task.FromResult(new SyncResult { Success = true });
        #endregion
        
        #region Mock Workflow Implementation
        // Placeholder implementations for workflow methods
        public override Task<WorkflowTemplateDto?> GetWorkflowTemplateAsync(Guid id) => Task.FromResult<WorkflowTemplateDto?>(null);
        public override Task<IEnumerable<WorkflowTemplateDto>> GetWorkflowTemplatesAsync() => Task.FromResult(Enumerable.Empty<WorkflowTemplateDto>());
        public override Task<WorkflowTemplateDto> CreateWorkflowTemplateAsync(WorkflowTemplateDto template) => Task.FromResult(template);
        public override Task<WorkflowTemplateDto> UpdateWorkflowTemplateAsync(WorkflowTemplateDto template) => Task.FromResult(template);
        public override Task DeleteWorkflowTemplateAsync(Guid id) => Task.CompletedTask;
        public override Task<WorkflowInstanceDto?> GetWorkflowInstanceAsync(Guid id) => Task.FromResult<WorkflowInstanceDto?>(null);
        public override Task<IEnumerable<WorkflowInstanceDto>> GetWorkflowInstancesAsync(int skip = 0, int take = 100) => Task.FromResult(Enumerable.Empty<WorkflowInstanceDto>());
        public override Task<IEnumerable<WorkflowInstanceDto>> GetWorkflowInstancesByEngagementAsync(Guid engagementId) => Task.FromResult(Enumerable.Empty<WorkflowInstanceDto>());
        public override Task<WorkflowInstanceDto> StartWorkflowAsync(Guid templateId, Guid engagementId) => throw new NotImplementedException();
        public override Task<WorkflowInstanceDto> AdvanceWorkflowAsync(Guid instanceId, Guid stepId, Dictionary<string, object>? stepData = null) => throw new NotImplementedException();
        public override Task<WorkflowInstanceDto> CompleteWorkflowAsync(Guid instanceId) => throw new NotImplementedException();
        public override Task CancelWorkflowAsync(Guid instanceId, string? reason = null) => Task.CompletedTask;
        public override Task<IEnumerable<WorkflowStepDto>> GetCurrentStepsAsync(Guid instanceId) => Task.FromResult(Enumerable.Empty<WorkflowStepDto>());
        public override Task<IEnumerable<WorkflowStepDto>> GetCompletedStepsAsync(Guid instanceId) => Task.FromResult(Enumerable.Empty<WorkflowStepDto>());
        public override Task<WorkflowStepDto> CompleteStepAsync(Guid stepId, Dictionary<string, object>? stepData = null) => throw new NotImplementedException();
        public override Task<IEnumerable<WorkflowInstanceDto>> GetActiveWorkflowsAsync() => Task.FromResult(Enumerable.Empty<WorkflowInstanceDto>());
        public override Task<IEnumerable<WorkflowInstanceDto>> GetOverdueWorkflowsAsync() => Task.FromResult(Enumerable.Empty<WorkflowInstanceDto>());
        public override Task<WorkflowMetricsDto> GetWorkflowMetricsAsync(Guid? templateId = null, DateTime? fromDate = null, DateTime? toDate = null) => Task.FromResult(new WorkflowMetricsDto());
        #endregion
    }
}