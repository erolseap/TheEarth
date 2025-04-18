using TheEarth.Enums;

namespace TheEarth.Models;

public class Country
{
    public string Name { get; set; }
    public string Area { get; set; }
    public string Anthem { get; set; }
    public Region Region { get; set; }
}
