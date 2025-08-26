/* 
 * LadybugDisplaySchema
 *
 * Contact: info@ladybug.tools
 */

//using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using LBT.Newtonsoft.Json;
using LBT.Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace LadybugDisplaySchema
{
    /// <summary>
    /// Base class for all objects that are not extensible with additional keys.
    /// </summary>
    [Summary(@"Base class for all objects that are not extensible with additional keys.")]
    [System.Serializable]
    [DataContract(Name = "Legend3DParameters")]
    public partial class Legend3DParameters : OpenAPIGenBaseModel, System.IEquatable<Legend3DParameters>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Legend3DParameters" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Legend3DParameters() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Legend3DParameters";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Legend3DParameters" /> class.
        /// </summary>
        /// <param name="basePlane">A Ladybug Plane object to note the starting position from where the legend will be generated. The default is the world XY plane at origin (0, 0, 0) unless the legend is assigned to a specific geometry, in which case the origin is in the lower right corner of the geometry bounding box for vertical legends and the upper right corner for horizontal legends.</param>
        /// <param name="segmentHeight">A number to set the height for each of the legend segments. The default is 1 unless the legend is assigned to a specific geometry, in which case it is automatically set to a value on an appropriate scale (some fraction of the bounding box around the geometry).</param>
        /// <param name="segmentWidth">A number to set the width for each of the legend segments. The default is 1 unless the legend is assigned to a specific geometry, in which case it is automatically set to a value on an appropriate scale (some fraction of the bounding box around the geometry).</param>
        /// <param name="textHeight">A number to set the height for the legend text. Default is 1/3 of the segment_height.</param>
        public Legend3DParameters
        (
            Plane basePlane = default, AnyOf<Default, double> segmentHeight = default, AnyOf<Default, double> segmentWidth = default, AnyOf<Default, double> textHeight = default
        ) : base()
        {
            this.BasePlane = basePlane;
            this.SegmentHeight = segmentHeight ?? new Default();
            this.SegmentWidth = segmentWidth ?? new Default();
            this.TextHeight = textHeight ?? new Default();

            // Set readonly properties with defaultValue
            this.Type = "Legend3DParameters";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Legend3DParameters))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A Ladybug Plane object to note the starting position from where the legend will be generated. The default is the world XY plane at origin (0, 0, 0) unless the legend is assigned to a specific geometry, in which case the origin is in the lower right corner of the geometry bounding box for vertical legends and the upper right corner for horizontal legends.
        /// </summary>
        [Summary(@"A Ladybug Plane object to note the starting position from where the legend will be generated. The default is the world XY plane at origin (0, 0, 0) unless the legend is assigned to a specific geometry, in which case the origin is in the lower right corner of the geometry bounding box for vertical legends and the upper right corner for horizontal legends.")]
        [DataMember(Name = "base_plane")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("base_plane")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public Plane BasePlane { get; set; }

        /// <summary>
        /// A number to set the height for each of the legend segments. The default is 1 unless the legend is assigned to a specific geometry, in which case it is automatically set to a value on an appropriate scale (some fraction of the bounding box around the geometry).
        /// </summary>
        [Summary(@"A number to set the height for each of the legend segments. The default is 1 unless the legend is assigned to a specific geometry, in which case it is automatically set to a value on an appropriate scale (some fraction of the bounding box around the geometry).")]
        [DataMember(Name = "segment_height")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("segment_height")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<Default, double> SegmentHeight { get; set; } = new Default();

        /// <summary>
        /// A number to set the width for each of the legend segments. The default is 1 unless the legend is assigned to a specific geometry, in which case it is automatically set to a value on an appropriate scale (some fraction of the bounding box around the geometry).
        /// </summary>
        [Summary(@"A number to set the width for each of the legend segments. The default is 1 unless the legend is assigned to a specific geometry, in which case it is automatically set to a value on an appropriate scale (some fraction of the bounding box around the geometry).")]
        [DataMember(Name = "segment_width")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("segment_width")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<Default, double> SegmentWidth { get; set; } = new Default();

        /// <summary>
        /// A number to set the height for the legend text. Default is 1/3 of the segment_height.
        /// </summary>
        [Summary(@"A number to set the height for the legend text. Default is 1/3 of the segment_height.")]
        [DataMember(Name = "text_height")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("text_height")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<Default, double> TextHeight { get; set; } = new Default();


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Legend3DParameters";
        }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString(bool detailed)
        {
            if (!detailed)
                return this.ToString();
            
            var sb = new StringBuilder();
            sb.Append("Legend3DParameters:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  BasePlane: ").Append(this.BasePlane).Append("\n");
            sb.Append("  SegmentHeight: ").Append(this.SegmentHeight).Append("\n");
            sb.Append("  SegmentWidth: ").Append(this.SegmentWidth).Append("\n");
            sb.Append("  TextHeight: ").Append(this.TextHeight).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Legend3DParameters object</returns>
        public static Legend3DParameters FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Legend3DParameters>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Legend3DParameters object</returns>
        public virtual Legend3DParameters DuplicateLegend3DParameters()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateLegend3DParameters();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Legend3DParameters);
        }


        /// <summary>
        /// Returns true if Legend3DParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of Legend3DParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Legend3DParameters input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.BasePlane, input.BasePlane) && 
                    Extension.Equals(this.SegmentHeight, input.SegmentHeight) && 
                    Extension.Equals(this.SegmentWidth, input.SegmentWidth) && 
                    Extension.Equals(this.TextHeight, input.TextHeight);
        }


        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
                if (this.BasePlane != null)
                    hashCode = hashCode * 59 + this.BasePlane.GetHashCode();
                if (this.SegmentHeight != null)
                    hashCode = hashCode * 59 + this.SegmentHeight.GetHashCode();
                if (this.SegmentWidth != null)
                    hashCode = hashCode * 59 + this.SegmentWidth.GetHashCode();
                if (this.TextHeight != null)
                    hashCode = hashCode * 59 + this.TextHeight.GetHashCode();
                return hashCode;
            }
        }


    }
}
