﻿namespace Esportify.Api.Entity;

public class UserEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string Pseudo { get; set; }
    public int RoleId { get; set; }
}