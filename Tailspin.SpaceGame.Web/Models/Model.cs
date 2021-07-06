using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TailSpin.SpaceGame.Web.Models
{
    /// <summary>
    /// Base class for data models.
    /// </summary>
    public abstract class Model
    {
        // The value that uniquely identifies this object.
        [JsonPropertyName("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}