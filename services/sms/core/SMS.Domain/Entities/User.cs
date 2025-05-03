using SMS.Domain.Entities.Common;

namespace SMS.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; } // Kullanıcı adı
    public string Email { get; set; } // Kullanıcı email adresi

    public virtual ICollection<Message> Messages { get; set; } // Kullanıcının gönderdiği mesajlar
}