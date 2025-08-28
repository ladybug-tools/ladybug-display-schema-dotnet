/* 
 * LadybugDisplaySchema
 *
 * Contact: info@ladybug.tools
 */

 using System.Runtime.Serialization;
 // using System.Text.Json;
 // using System.Text.Json.Serialization;
 using LBT.Newtonsoft.Json;
 using LBT.Newtonsoft.Json.Converters;

namespace LadybugDisplaySchema
{
    /// <summary>
    /// An enumeration.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum DisplayModes
    {

        [EnumMember(Value = "Surface")]
        [JsonProperty("Surface")]       // Newtonsoft
        // [JsonPropertyName("Surface")]                   // STJ
        Surface = 1,

        [EnumMember(Value = "SurfaceWithEdges")]
        [JsonProperty("SurfaceWithEdges")]       // Newtonsoft
        // [JsonPropertyName("SurfaceWithEdges")]                   // STJ
        SurfaceWithEdges = 2,

        [EnumMember(Value = "Wireframe")]
        [JsonProperty("Wireframe")]       // Newtonsoft
        // [JsonPropertyName("Wireframe")]                   // STJ
        Wireframe = 3,

        [EnumMember(Value = "Points")]
        [JsonProperty("Points")]       // Newtonsoft
        // [JsonPropertyName("Points")]                   // STJ
        Points = 4,

    }
 
}