
namespace api_framework.Models
{
    public class WeatherDTO
    {
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }

        public Main Main { get; set; }
        public Sys Sys { get; set; }
    }
}
