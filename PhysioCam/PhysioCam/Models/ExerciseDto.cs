using System.Collections.Generic;
using Newtonsoft.Json;

namespace PhysioCam.Models
{
    public class ExerciseDto
    {
        public ExerciseDto()
        {
            AppUsers = new List<object>();
        }
        
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }

        public List<Image> Image { get; set; }
        
        [JsonProperty(PropertyName = "app_users")]
        public ICollection<object> AppUsers { get; set; }
        
        [JsonProperty(PropertyName = "exercise_plans"), JsonIgnore]
        public ICollection<object> ExercisePlans { get; set; }
    }
}