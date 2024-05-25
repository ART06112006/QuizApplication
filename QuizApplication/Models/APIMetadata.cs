using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class ByCategory
    {
        [JsonProperty("history")]
        public int History { get; set; }

        [JsonProperty("geography")]
        public int Geography { get; set; }

        [JsonProperty("science")]
        public int Science { get; set; }

        [JsonProperty("food_and_drink")]
        public int FoodAndDrink { get; set; }
    }

    public class ByDifficulty
    {
        [JsonProperty("easy")]
        public int Easy { get; set; }

        [JsonProperty("medium")]
        public int Medium { get; set; }

        [JsonProperty("hard")]
        public int Hard { get; set; }
    }

    public class ByState
    {
        [JsonProperty("approved")]
        public int Approved { get; set; }

        [JsonProperty("rejected")]
        public int Rejected { get; set; }

        [JsonProperty("pending")]
        public int Pending { get; set; }
    }

    public class ByType
    {
        [JsonProperty("text_choice")]
        public int TextChoice { get; set; }

        [JsonProperty("image_choice")]
        public int ImageChoice { get; set; }
    }

    public class APIMetadata
    {
        [JsonProperty("byCategory")]
        public ByCategory ByCategory { get; set; }

        [JsonProperty("byDifficulty")]
        public ByDifficulty ByDifficulty { get; set; }

        [JsonProperty("byState")]
        public ByState ByState { get; set; }

        [JsonProperty("byType")]
        public ByType ByType { get; set; }

        [JsonProperty("lastCreated")]
        public DateTime LastCreated { get; set; }

        [JsonProperty("lastReviewed")]
        public DateTime LastReviewed { get; set; }
    }
}
