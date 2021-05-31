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

        public string Title { get; set; }
        
        public string Description { get; set; }

        [JsonProperty(PropertyName = "exercises"), JsonIgnore]
        public ICollection<Exercise> Exercises { get; set; }
    }
}