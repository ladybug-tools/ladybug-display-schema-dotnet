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
    public enum VerticalAlignments
    {

        [EnumMember(Value = "Top")]
        [JsonProperty("Top")]       // Newtonsoft
        // [JsonPropertyName("Top")]                   // STJ
        Top = 1,

        [EnumMember(Value = "Middle")]
        [JsonProperty("Middle")]       // Newtonsoft
        // [JsonPropertyName("Middle")]                   // STJ
        Middle = 2,

        [EnumMember(Value = "Bottom")]
        [JsonProperty("Bottom")]       // Newtonsoft
        // [JsonPropertyName("Bottom")]                   // STJ
        Bottom = 3,

    }
 
}