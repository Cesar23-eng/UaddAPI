﻿using System.ComponentModel.DataAnnotations;

namespace UaddAPI.Dto.User;

public class UserLoginDto
{
    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}