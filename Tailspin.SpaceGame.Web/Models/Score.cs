using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TailSpin.SpaceGame.Web.Models
{
    public class Score : Model
    {
        // The ID of the player profile associated with this score.
        [JsonPropertyName("profileId")]
        public int ProfileId { get; set; }

        // The score value.
        [JsonPropertyName("score")]
        public int HighScore { get; set; }

        // The game mode the score is associated with.
        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        // The game region (map) the score is associated with.
        [JsonPropertyName("gameRegion")]
        public string GameRegion { get; set; }

        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }
    }
}