/* 
 * LadybugDisplaySchema
 *
 * Contact: info@ladybug.tools
 */

 using System.Runtime.Serialization;
 using LBT.Newtonsoft.Json;
 using LBT.Newtonsoft.Json.Converters;

namespace LadybugDisplaySchema
{
    /// <summary>
    /// An enumeration.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LineTypes
    {

        [EnumMember(Value = "Continuous")]
        Continuous = 1,

        [EnumMember(Value = "Dashed")]
        Dashed = 2,

        [EnumMember(Value = "Dotted")]
        Dotted = 3,

        [EnumMember(Value = "DashDot")]
        DashDot = 4,

    }
 
}