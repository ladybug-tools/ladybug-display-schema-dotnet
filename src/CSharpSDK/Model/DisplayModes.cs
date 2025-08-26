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
    public enum DisplayModes
    {

        [EnumMember(Value = "Surface")]
        Surface = 1,

        [EnumMember(Value = "SurfaceWithEdges")]
        SurfaceWithEdges = 2,

        [EnumMember(Value = "Wireframe")]
        Wireframe = 3,

        [EnumMember(Value = "Points")]
        Points = 4,

    }
 
}