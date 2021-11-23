namespace AudiMarket.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int Content { get; set; }
        public int CreateDate { get; set; }
        public int IdvProducer { get; set; }
        public int DmProducer { get; set; }
    }
}