namespace SMS.Application.Dto.Topic
{
    public class TopicDto
    {
        public Guid TopicId { get; set; }
        public string? TopicName { get; set; }
        public bool? Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}