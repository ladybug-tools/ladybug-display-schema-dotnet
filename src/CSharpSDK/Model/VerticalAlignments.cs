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
    public enum VerticalAlignments
    {

        [EnumMember(Value = "Top")]
        Top = 1,

        [EnumMember(Value = "Middle")]
        Middle = 2,

        [EnumMember(Value = "Bottom")]
        Bottom = 3,

    }
 
}