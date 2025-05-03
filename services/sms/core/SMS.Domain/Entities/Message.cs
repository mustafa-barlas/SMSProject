using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class Message : BaseEntity
{
    public string Content { get; set; } // Mesaj içeriği
    public Guid SenderId { get; set; } // Gönderen kullanıcı ID'si
    public Guid ChatRoomId { get; set; } // Mesajın ait olduğu sohbet odası ID'si
    public DateTime SentAt { get; set; } // Mesajın gönderildiği zaman

    public virtual User Sender { get; set; } // Gönderen kullanıcı
    public virtual ChatRoom ChatRoom { get; set; } // Sohbet odası
}