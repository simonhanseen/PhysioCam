﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PhysioCam.Models
{
    public class Exercise
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        
        [JsonProperty(PropertyName = "published_at")]
        public DateTime PublishedAt { get; set; }
        
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        public List<Image> Image { get; set; }
        
        [JsonProperty(PropertyName = "app_users")]
        public List<AppUser> AppUsers { get; set; }
        
        [JsonProperty(PropertyName = "exercise_plans")]
        public List<ExercisePlan> ExercisePlans { get; set; }
    }
}