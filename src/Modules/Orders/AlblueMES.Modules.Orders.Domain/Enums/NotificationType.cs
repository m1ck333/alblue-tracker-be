namespace AlblueMES.Modules.Orders.Domain.Enums;

public enum NotificationType
{
    DeadlineWarning,
    DeadlineCritical,
    BlockRequest,
    BlockRequestApproved,
    BlockRequestRejected,
    ProcessCompleted,
    ProcessBlocked,
    OrderActivated
}
