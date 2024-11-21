namespace CityServers.Models
{
    public static class CityRepository
    {
        private static List<string> cities = new List<string>()
        {
            "Toronto",
            "Montreal",
            "Hallifax",
            "Ottawa",
            "Calgary"
        };

        public static List<string> GetCities() => cities;
    }
}
