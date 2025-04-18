using TheEarth.Models;

public class Program
{
    static void Main(string[] args)
    {
        List<Planet> planets = new();
        Planet? selectedPlanet = null;
        bool exit = false;
        do
        {
            Console.WriteLine("-----------------------------------------");
            switch (RequireIntInput("1. Sisteme giris\n" +
                                    "0. Cixis\n" +
                                    "\n" +
                                    "Sizin secim", 0, 1))
            {
                case 0: exit = true; break;
                case 1:
                    {
                        switch (RequireIntInput("1. Planet yarat\n" +
                                    "2. Butun planetleri gor\n" +
                                    "3. Planet sec (planetin adini daxil ederek secilecek)\n" +
                                    "0. Exit\n" +
                                    "\n" +
                                    "Sizin secim", 0, 3))
                        {
                            case 0: break;
                            case 1:
                                {
                                    var name = RequireStringInput("Ad");
                                    var area = RequireStringInput("Erazi");
                                    planets.Add(new Planet()
                                    {
                                        Name = name,
                                        Area = area
                                    });
                                    Console.WriteLine("Yaradildi");
                                }
                                break;
                            case 2:
                                {
                                    for (var i = 0; i < planets.Count; i++)
                                    {
                                        Console.WriteLine($"{i}: {planets[i].Name}");
                                    }
                                }
                                break;
                            case 3:
                                {
                                    var planetName = RequireStringInput("Planet adini yazin");
                                    Planet? foundPlanet = null;
                                    foreach (var planet in planets)
                                    {
                                        if (planet.Name == planetName)
                                        {
                                            foundPlanet = planet;
                                            break;
                                        }
                                    }
                                    if (foundPlanet == null)
                                    {
                                        Console.WriteLine("Planet tapilmadi");
                                    }
                                    else
                                    {
                                        selectedPlanet = foundPlanet;
                                        Console.WriteLine("Planet secildi");
                                        switch (RequireIntInput("1. Olke yarat\n" +
                                            "2. Olkeleri gor\n" +
                                            "3. Evvelki menyuya qayit\n" +
                                            "\n" +
                                            "Sizin secim", 1, 3))
                                        {
                                            case 1:
                                                {
                                                    var name = RequireStringInput("Ad");
                                                    var area = RequireStringInput("Erazi");
                                                    var anthem = RequireStringInput("Himn");
                                                    selectedPlanet.CreateCountry(name, area, anthem, TheEarth.Enums.Region.AFRICA);
                                                    Console.WriteLine("Yaradildi");
                                                }
                                                break;
                                            case 2:
                                                {
                                                    foreach (var country in selectedPlanet.GetAllCountries())
                                                    {
                                                        Console.WriteLine($"{country.Name}, {country.Area}");
                                                    }
                                                }
                                                break;
                                            case 3: break;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    break;
            }
        } while (!exit);
    }

    static int RequireIntInput(string? infoStr = null, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        while (true)
        {
            if (infoStr != null && infoStr.Length != 0)
            {
                Console.Write(infoStr + ": ");
            }
            var input = Console.ReadLine();
            if (input != null)
            {
                try
                {
                    var res = int.Parse(input);
                    if (res >= minValue && res <= maxValue)
                    {
                        return res;
                    }
                    else
                    {
                        Console.WriteLine($"Minimum: {minValue}, maximum: {maxValue}");
                    }
                }
                catch
                {
                }
            }
        }
        return 0;
    }

    static string RequireStringInput(string? infoStr = null, uint minLength = uint.MinValue, uint maxLength = uint.MaxValue)
    {
        while (true)
        {
            if (infoStr != null && infoStr.Length != 0)
            {
                Console.Write(infoStr + ": ");
            }
            var input = Console.ReadLine();
            if (input != null)
            {
                if (input.Length >= minLength && input.Length <= maxLength)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine($"Minimum length: {minLength}, maximum length: {maxLength}");
                }
            }
        }
        return "";
    }
}
