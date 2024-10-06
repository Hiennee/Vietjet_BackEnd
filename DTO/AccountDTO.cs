namespace Vietjet_BackEnd.DTO
{
    public class AccountDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public DateTime? Terminated_until { get; set; }
    }
}
