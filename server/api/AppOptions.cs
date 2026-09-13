using System.ComponentModel.DataAnnotations;

namespace api;

public class AppOptions
{
    [MinLength(1)]// validation that it can't be empty
public string DbConnectionString { get; set; }

}