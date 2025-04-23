namespace SMS.DtoLayer.Base;

public record BaseDto
{

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Status { get; set; }
}