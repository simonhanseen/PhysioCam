using System.Collections.Generic;
using Newtonsoft.Json;

namespace PhysioCam.Models
{
    public class ExercisePlanDto
    {
        public ExercisePlanDto()
        {
            Exercises = new List<object>();
        }

        public string Title { get; set; }
        
        public string Description { get; set; }

        [JsonProperty(PropertyName = "exercises")]
        public ICollection<object> Exercises { get; set; }
    }
}