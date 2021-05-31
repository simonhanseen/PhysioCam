using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PhysioCam.Models
{
    public class Exercise
    {
        public Exercise()
        {
            AppUsers = new List<AppUser>();
        }
        
        public string Title { get; set; }
        
        public string Description { get; set; }

        public List<Image> Image { get; set; }
        
        [JsonProperty(PropertyName = "app_users"), JsonIgnore]
        public ICollection<AppUser> AppUsers { get; set; }
        
        [JsonProperty(PropertyName = "exercise_plans"), JsonIgnore]
        public List<ExercisePlan> ExercisePlans { get; set; }
    }
}