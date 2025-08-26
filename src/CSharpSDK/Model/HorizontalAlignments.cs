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
    public enum HorizontalAlignments
    {

        [EnumMember(Value = "Left")]
        Left = 1,

        [EnumMember(Value = "Center")]
        Center = 2,

        [EnumMember(Value = "Right")]
        Right = 3,

    }
 
}