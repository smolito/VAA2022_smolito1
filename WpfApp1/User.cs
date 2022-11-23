using System;
using System.Collections.Generic;

namespace WpfApp1;

public partial class User
{
    public User (string username, string email, string password)
    {
        Username = username;
        Email = email; 
        Password = password;
    }
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}

public static class LoggedUser
{
    static LoggedUser ()
    {

    }

    public static int Id { get; set; }

    public static string? Username { get; set; }

    public static string? Email { get; set; }

    public static string? Password { get; set; }

}
