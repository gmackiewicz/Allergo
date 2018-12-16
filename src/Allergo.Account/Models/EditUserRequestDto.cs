namespace Allergo.Account.Models
{
    public class EditUserRequestDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
    }
}
