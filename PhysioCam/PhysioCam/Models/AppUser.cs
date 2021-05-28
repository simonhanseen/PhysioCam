using System;
using Newtonsoft.Json;

namespace PhysioCam.Models
{
    public class AppUser
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        
        public string DateOfBirth { get; set; }
        
        [JsonProperty(PropertyName = "published_at")]
        public DateTime PublishedAt { get; set; }
        
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        
    }
}