namespace Kasa.Infrastructure.DTO
{
    public class BankAccountDto
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
