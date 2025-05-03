
using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class ChatRoom : BaseEntity
{
    public string Name { get; set; } // Sohbet odası adı

    public virtual ICollection<Message> Messages { get; set; } // Odanın mesajları
    public virtual ICollection<User> Users { get; set; } // Odaya katılan kullanıcılar
}