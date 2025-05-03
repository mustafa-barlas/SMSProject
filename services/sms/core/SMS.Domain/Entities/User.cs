namespace Chat.Domain.Entities;

public class User
{
    public Guid Id { get; set; } // Kullanıcı ID'si
    public string UserName { get; set; } // Kullanıcı adı
    public string Email { get; set; } // Kullanıcı email adresi
    public DateTime CreatedAt { get; set; } // Hesabın oluşturulma zamanı

    public virtual ICollection<Message> Messages { get; set; } // Kullanıcının gönderdiği mesajlar
}