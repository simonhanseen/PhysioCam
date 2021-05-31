using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PhysioCam.Models
{
    public class ExercisePlan
    {
        public ExercisePlan()
        {
            Exercises = new List<Exercise>();
        }
        
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        [JsonProperty(PropertyName = "published_at")]
        public DateTime PublishedAt { get; set; }
        
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "exercises")]
        public List<Exercise> Exercises { get; set; }
    }
}