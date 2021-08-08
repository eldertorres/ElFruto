using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}