using System.ComponentModel.DataAnnotations;

namespace WeatherPI.Shared.Models;

public class ApplicationUserWithRolesDto : ApplicationUserDto
{
    public List<string>? Roles { get; set; }
}
