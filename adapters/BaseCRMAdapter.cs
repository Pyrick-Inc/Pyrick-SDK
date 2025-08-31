using System;
using System.Threading.Tasks;
using Pyrick.SDK.Contracts.DTOs;
using Pyrick.SDK.Contracts.Interfaces;

namespace Pyrick.SDK.Adapters
{
    /// <summary>
    /// Abstract base class for CRM adapters
    /// Provides common functionality and enforces interface implementation
    /// </summary>
    public abstract class BaseCRMAdapter : ICRMAdapter, IEngagementAdapter, IWorkflowAdapter
    {
        protected Dictionary<string, string> Configuration { get; private set; } = new Dictionary<string, string>();
        protected bool IsInitialized { get; private set; } = false;
        
        public abstract AdapterInfo GetAdapterInfo();
        
        public virtual async Task InitializeAsync(Dictionary<string, string> configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            await OnInitializeAsync();
            IsInitialized = true;
        }
        
        /// <summary>
        /// Override this method to perform adapter-specific initialization
        /// </summary>
        protected virtual Task OnInitializeAsync()
        {
            return Task.CompletedTask;
        }
        
        protected virtual void EnsureInitialized()
        {
            if (!IsInitialized)
                throw new InvalidOperationException("Adapter must be initialized before use. Call InitializeAsync() first.");
        }
        
        protected virtual string GetConfigurationValue(string key, string? defaultValue = null)
        {
            return Configuration.TryGetValue(key, out var value) ? value : defaultValue ?? string.Empty;
        }
        
        protected virtual T GetConfigurationValue<T>(string key, T defaultValue = default!)
        {
            if (!Configuration.TryGetValue(key, out var value))
                return defaultValue;
                
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }
        
        #region ICRMAdapter Implementation
        public abstract Task<bool> TestConnectionAsync();
        public abstract Task<ContactDto?> GetContactAsync(Guid id);
        public abstract Task<ContactDto?> GetContactByEmailAsync(string email);
        public abstract Task<IEnumerable<ContactDto>> GetContactsAsync(int skip = 0, int take = 100);
        public abstract Task<IEnumerable<ContactDto>> SearchContactsAsync(string searchTerm);
        public abstract Task<ContactDto> CreateContactAsync(ContactDto contact);
        public abstract Task<ContactDto> UpdateContactAsync(ContactDto contact);
        public abstract Task DeleteContactAsync(Guid id);
        public abstract Task<CompanyDto?> GetCompanyAsync(Guid id);
        public abstract Task<CompanyDto?> GetCompanyByNameAsync(string name);
        public abstract Task<IEnumerable<CompanyDto>> GetCompaniesAsync(int skip = 0, int take = 100);
        public abstract Task<IEnumerable<CompanyDto>> SearchCompaniesAsync(string searchTerm);
        public abstract Task<CompanyDto> CreateCompanyAsync(CompanyDto company);
        public abstract Task<CompanyDto> UpdateCompanyAsync(CompanyDto company);
        public abstract Task DeleteCompanyAsync(Guid id);
        public abstract Task<SyncResult> SyncContactsAsync(DateTime? lastSyncDate = null);
        public abstract Task<SyncResult> SyncCompaniesAsync(DateTime? lastSyncDate = null);
        #endregion
        
        #region IEngagementAdapter Implementation
        public abstract Task<EngagementDto?> GetEngagementAsync(Guid id);
        public abstract Task<IEnumerable<EngagementDto>> GetEngagementsAsync(int skip = 0, int take = 100);
        public abstract Task<IEnumerable<EngagementDto>> GetEngagementsByContactAsync(Guid contactId);
        public abstract Task<IEnumerable<EngagementDto>> GetEngagementsByCompanyAsync(Guid companyId);
        public abstract Task<IEnumerable<EngagementDto>> SearchEngagementsAsync(string searchTerm);
        public abstract Task<EngagementDto> CreateEngagementAsync(EngagementDto engagement);
        public abstract Task<EngagementDto> UpdateEngagementAsync(EngagementDto engagement);
        public abstract Task DeleteEngagementAsync(Guid id);
        public abstract Task<IEnumerable<EngagementRoleDto>> GetEngagementRolesAsync(Guid engagementId);
        public abstract Task<EngagementRoleDto> AddEngagementRoleAsync(Guid engagementId, EngagementRoleDto role);
        public abstract Task<EngagementRoleDto> UpdateEngagementRoleAsync(EngagementRoleDto role);
        public abstract Task RemoveEngagementRoleAsync(Guid roleId);
        public abstract Task<IEnumerable<WorkflowStageDto>> GetAvailableStagesAsync(Guid engagementId);
        public abstract Task<EngagementDto> AdvanceEngagementStageAsync(Guid engagementId, string targetStage, string? notes = null);
        public abstract Task<IEnumerable<WorkflowHistoryDto>> GetEngagementHistoryAsync(Guid engagementId);
        public abstract Task<SyncResult> SyncEngagementsAsync(DateTime? lastSyncDate = null);
        #endregion
        
        #region IWorkflowAdapter Implementation
        public abstract Task<WorkflowTemplateDto?> GetWorkflowTemplateAsync(Guid id);
        public abstract Task<IEnumerable<WorkflowTemplateDto>> GetWorkflowTemplatesAsync();
        public abstract Task<WorkflowTemplateDto> CreateWorkflowTemplateAsync(WorkflowTemplateDto template);
        public abstract Task<WorkflowTemplateDto> UpdateWorkflowTemplateAsync(WorkflowTemplateDto template);
        public abstract Task DeleteWorkflowTemplateAsync(Guid id);
        public abstract Task<WorkflowInstanceDto?> GetWorkflowInstanceAsync(Guid id);
        public abstract Task<IEnumerable<WorkflowInstanceDto>> GetWorkflowInstancesAsync(int skip = 0, int take = 100);
        public abstract Task<IEnumerable<WorkflowInstanceDto>> GetWorkflowInstancesByEngagementAsync(Guid engagementId);
        public abstract Task<WorkflowInstanceDto> StartWorkflowAsync(Guid templateId, Guid engagementId);
        public abstract Task<WorkflowInstanceDto> AdvanceWorkflowAsync(Guid instanceId, Guid stepId, Dictionary<string, object>? stepData = null);
        public abstract Task<WorkflowInstanceDto> CompleteWorkflowAsync(Guid instanceId);
        public abstract Task CancelWorkflowAsync(Guid instanceId, string? reason = null);
        public abstract Task<IEnumerable<WorkflowStepDto>> GetCurrentStepsAsync(Guid instanceId);
        public abstract Task<IEnumerable<WorkflowStepDto>> GetCompletedStepsAsync(Guid instanceId);
        public abstract Task<WorkflowStepDto> CompleteStepAsync(Guid stepId, Dictionary<string, object>? stepData = null);
        public abstract Task<IEnumerable<WorkflowInstanceDto>> GetActiveWorkflowsAsync();
        public abstract Task<IEnumerable<WorkflowInstanceDto>> GetOverdueWorkflowsAsync();
        public abstract Task<WorkflowMetricsDto> GetWorkflowMetricsAsync(Guid? templateId = null, DateTime? fromDate = null, DateTime? toDate = null);
        #endregion
    }
}