namespace Chat.Domain.Entities;

public class ChatRoom
{
    public Guid Id { get; set; } // Sohbet odası ID'si
    public string Name { get; set; } // Sohbet odası adı
    public DateTime CreatedAt { get; set; } // Odanın oluşturulma zamanı

    public virtual ICollection<Message> Messages { get; set; } // Odanın mesajları
    public virtual ICollection<User> Users { get; set; } // Odaya katılan kullanıcılar
}