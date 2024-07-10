namespace Milmom_Service.Model.Request.AccountApplication;

public class UpdateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}