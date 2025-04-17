namespace SMS.Domain.Entities.Common;

public class BaseEntity
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public bool Status { get; set; }


    //public DateTime DeletedDate { get; set; }
}