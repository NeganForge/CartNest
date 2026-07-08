using CartNest.Models.Entities;

public class Admin : BaseEntity
{
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}