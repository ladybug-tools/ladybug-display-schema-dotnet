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
    public enum HorizontalAlignments
    {

        [EnumMember(Value = "Left")]
        [JsonProperty("Left")]       // Newtonsoft
        // [JsonPropertyName("Left")]                   // STJ
        Left = 1,

        [EnumMember(Value = "Center")]
        [JsonProperty("Center")]       // Newtonsoft
        // [JsonPropertyName("Center")]                   // STJ
        Center = 2,

        [EnumMember(Value = "Right")]
        [JsonProperty("Right")]       // Newtonsoft
        // [JsonPropertyName("Right")]                   // STJ
        Right = 3,

    }
 
}