namespace SMS.DtoLayer.Base;

public record BaseDTO
{
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public bool Status { get; set; }
}