﻿namespace HR_Management.Application.Models.Identity;

public class AuthResponse
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Email{ get; set; }
    public required string Token{ get; set; }
}
