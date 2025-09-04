using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pyrick.SDK.Contracts.Interfaces
{
    /// <summary>
    /// Adapter interface for Real-Time Service (RTS) integration
    /// Provides Socket.IO and real-time communication capabilities
    /// </summary>
    public interface IRealTimeAdapter
    {
        /// <summary>
        /// Check if RTS service is available
        /// </summary>
        Task<bool> IsServiceAvailableAsync();

        /// <summary>
        /// Get online users for a core configuration
        /// </summary>
        Task<IEnumerable<UserOnlineStatusDto>> GetConnectedUsersAsync(Guid coreConfigurationRef);

        /// <summary>
        /// Get active chat rooms for a core configuration
        /// </summary>
        Task<IEnumerable<ChatRoomDto>> GetActiveRoomsAsync(Guid coreConfigurationRef);

        /// <summary>
        /// Notify users about engagement updates
        /// </summary>
        Task NotifyEngagementUpdateAsync(Guid coreConfigurationRef, string engagementRef, string updateType, object data);

        /// <summary>
        /// Notify users about workflow state changes
        /// </summary>
        Task NotifyWorkflowUpdateAsync(Guid coreConfigurationRef, string workflowRef, string stepRef, string newState);

        /// <summary>
        /// Send system notification to all users in core configuration
        /// </summary>
        Task BroadcastSystemNotificationAsync(Guid coreConfigurationRef, string message, string notificationType = "info");

        /// <summary>
        /// Send notification to specific user
        /// </summary>
        Task SendUserNotificationAsync(Guid coreConfigurationRef, Guid userRef, string message, string notificationType = "info");
    }

    /// <summary>
    /// User online status DTO for RTS integration
    /// </summary>
    public class UserOnlineStatusDto
    {
        public Guid UserRef { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool IsOnline { get; set; }
        public string Status { get; set; } = "offline";
        public string? CustomStatusMessage { get; set; }
        public DateTime LastSeenAt { get; set; }
        public string? ConnectionId { get; set; }
    }

    /// <summary>
    /// Chat room DTO for RTS integration
    /// </summary>
    public class ChatRoomDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string ChatType { get; set; } = "group";
        public Guid CoreConfigurationRef { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public int UnreadCount { get; set; }
        public int ParticipantCount { get; set; }
    }
}