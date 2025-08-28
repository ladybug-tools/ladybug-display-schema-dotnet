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
    public enum LineTypes
    {

        [EnumMember(Value = "Continuous")]
        [JsonProperty("Continuous")]       // Newtonsoft
        // [JsonPropertyName("Continuous")]                   // STJ
        Continuous = 1,

        [EnumMember(Value = "Dashed")]
        [JsonProperty("Dashed")]       // Newtonsoft
        // [JsonPropertyName("Dashed")]                   // STJ
        Dashed = 2,

        [EnumMember(Value = "Dotted")]
        [JsonProperty("Dotted")]       // Newtonsoft
        // [JsonPropertyName("Dotted")]                   // STJ
        Dotted = 3,

        [EnumMember(Value = "DashDot")]
        [JsonProperty("DashDot")]       // Newtonsoft
        // [JsonPropertyName("DashDot")]                   // STJ
        DashDot = 4,

    }
 
}