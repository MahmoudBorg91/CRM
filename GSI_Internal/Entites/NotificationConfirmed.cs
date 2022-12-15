using System.ComponentModel.DataAnnotations.Schema;

namespace GSI_Internal.Entites;

public class NotificationConfirmed
{
    public int Id { get; set; }

    [ForeignKey("Notification")]
    public int NotificationId { get; set; }

    public virtual Notification Notification { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }

    public virtual ApplicationUser User { get; set; }
}