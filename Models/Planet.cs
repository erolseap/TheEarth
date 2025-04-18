using TheEarth.Enums;

namespace TheEarth.Models;

public class Planet
{
    public string Name { get; set; }
    public string Area { get; set; }
    public List<Country> Countries { get; set; } = new();

    #region Create
    public Country CreateCountry(string name, string area, string anthem, Region region)
    {
        if (FindCountryByName(name) != null)
        {
            throw new Exception("Country already exists");
        }

        var created = new Country()
        {
            Name = name,
            Area = area,
            Anthem = anthem,
            Region = region
        };

        Countries.Add(created);

        return created;
    }
    #endregion
    #region Read
    public int FindCountryIdByName(string name)
    {
        for (int i = 0; i < Countries.Count; i++)
        {
            if (Countries[i].Name == name)
            {
                return i;
            }
        }
        return -1;
    }

    public Country? FindCountryByName(string name)
    {
        var idx = FindCountryIdByName(name);
        return idx >= 0 ? Countries[idx] : null;
    }

    public List<Country> GetAllCountries()
    {
        return Countries;
    }

    public List<Country> GetCountriesByRegion(Region region)
    {
        List<Country> res = new();
        foreach (var country in Countries)
        {
            if (country.Region == region)
            {
                res.Add(country);
            }
        }
        return res;
    }
    #endregion
    #region Update
    //idkwhattowritehere
    #endregion
    #region Delete
    public bool DeleteCountry(int idx)
    {
        if (!(Countries.Count >= 0 && idx < Countries.Count))
        {
            return false;
        }
        Countries.RemoveAt(idx);
        return true;
    }

    public bool DeleteCountryByName(string name)
    {
        return Countries.Remove(FindCountryByName(name));
    }
    #endregion
}
