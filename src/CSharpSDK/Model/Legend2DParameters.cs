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
    [DataContract(Name = "Legend2DParameters")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Legend2DParameters : OpenAPIGenBaseModel, System.IEquatable<Legend2DParameters>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Legend2DParameters" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Legend2DParameters() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Legend2DParameters";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Legend2DParameters" /> class.
        /// </summary>
        /// <param name="originX">A text string to note the X coordinate of the base point from where the legend will be generated (assuming an origin in the upper-left corner of the viewport with higher positive values of X moving to the right). Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport width). Examples include 10px, 5%. The default is set to make the legend clearly visible on the viewport (usually 10px).</param>
        /// <param name="originY">A text string to note the Y coordinate of the base point from where the legend will be generated (assuming an origin in the upper-left corner of the viewport with higher positive values of Y moving downward). Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport height). Examples include 10px, 5%. The default is set to make the legend clearly visible on the viewport (usually 50px).</param>
        /// <param name="segmentHeight">A text string to note the height for each of the legend segments. Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport height). Examples include 10px, 5%. The default is set to make most legends readable (25px for horizontal legends and 36px for vertical legends).</param>
        /// <param name="segmentWidth">A text string to set the width for each of the legend segments. Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport width). Examples include 10px, 5%. The default is set to make most legends readable (36px for horizontal legends and 25px for vertical legends).</param>
        /// <param name="textHeight">A text string to set the height for the legend text. Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport height). Examples include 10px, 5%. Default is 1/3 of the segment_height. Default is 12px.</param>
        public Legend2DParameters
        (
            AnyOf<Default, string> originX = default, AnyOf<Default, string> originY = default, AnyOf<Default, string> segmentHeight = default, AnyOf<Default, string> segmentWidth = default, AnyOf<Default, string> textHeight = default
        ) : base()
        {
            this.OriginX = originX ?? new Default();
            this.OriginY = originY ?? new Default();
            this.SegmentHeight = segmentHeight ?? new Default();
            this.SegmentWidth = segmentWidth ?? new Default();
            this.TextHeight = textHeight ?? new Default();

            // Set readonly properties with defaultValue
            this.Type = "Legend2DParameters";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Legend2DParameters))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A text string to note the X coordinate of the base point from where the legend will be generated (assuming an origin in the upper-left corner of the viewport with higher positive values of X moving to the right). Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport width). Examples include 10px, 5%. The default is set to make the legend clearly visible on the viewport (usually 10px).
        /// </summary>
        [Summary(@"A text string to note the X coordinate of the base point from where the legend will be generated (assuming an origin in the upper-left corner of the viewport with higher positive values of X moving to the right). Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport width). Examples include 10px, 5%. The default is set to make the legend clearly visible on the viewport (usually 10px).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "origin_x")] // For internal Serialization XML/JSON
        [JsonProperty("origin_x", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("origin_x")] // For System.Text.Json
        public AnyOf<Default, string> OriginX { get; set; } = new Default();

        /// <summary>
        /// A text string to note the Y coordinate of the base point from where the legend will be generated (assuming an origin in the upper-left corner of the viewport with higher positive values of Y moving downward). Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport height). Examples include 10px, 5%. The default is set to make the legend clearly visible on the viewport (usually 50px).
        /// </summary>
        [Summary(@"A text string to note the Y coordinate of the base point from where the legend will be generated (assuming an origin in the upper-left corner of the viewport with higher positive values of Y moving downward). Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport height). Examples include 10px, 5%. The default is set to make the legend clearly visible on the viewport (usually 50px).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "origin_y")] // For internal Serialization XML/JSON
        [JsonProperty("origin_y", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("origin_y")] // For System.Text.Json
        public AnyOf<Default, string> OriginY { get; set; } = new Default();

        /// <summary>
        /// A text string to note the height for each of the legend segments. Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport height). Examples include 10px, 5%. The default is set to make most legends readable (25px for horizontal legends and 36px for vertical legends).
        /// </summary>
        [Summary(@"A text string to note the height for each of the legend segments. Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport height). Examples include 10px, 5%. The default is set to make most legends readable (25px for horizontal legends and 36px for vertical legends).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "segment_height")] // For internal Serialization XML/JSON
        [JsonProperty("segment_height", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("segment_height")] // For System.Text.Json
        public AnyOf<Default, string> SegmentHeight { get; set; } = new Default();

        /// <summary>
        /// A text string to set the width for each of the legend segments. Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport width). Examples include 10px, 5%. The default is set to make most legends readable (36px for horizontal legends and 25px for vertical legends).
        /// </summary>
        [Summary(@"A text string to set the width for each of the legend segments. Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport width). Examples include 10px, 5%. The default is set to make most legends readable (36px for horizontal legends and 25px for vertical legends).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "segment_width")] // For internal Serialization XML/JSON
        [JsonProperty("segment_width", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("segment_width")] // For System.Text.Json
        public AnyOf<Default, string> SegmentWidth { get; set; } = new Default();

        /// <summary>
        /// A text string to set the height for the legend text. Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport height). Examples include 10px, 5%. Default is 1/3 of the segment_height. Default is 12px.
        /// </summary>
        [Summary(@"A text string to set the height for the legend text. Text must be formatted as an integer followed by either ""px"" (to denote the number of viewport pixels) or ""%"" (to denote the percentage of the viewport height). Examples include 10px, 5%. Default is 1/3 of the segment_height. Default is 12px.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "text_height")] // For internal Serialization XML/JSON
        [JsonProperty("text_height", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("text_height")] // For System.Text.Json
        public AnyOf<Default, string> TextHeight { get; set; } = new Default();


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Legend2DParameters";
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
            sb.Append("Legend2DParameters:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  OriginX: ").Append(this.OriginX).Append("\n");
            sb.Append("  OriginY: ").Append(this.OriginY).Append("\n");
            sb.Append("  SegmentHeight: ").Append(this.SegmentHeight).Append("\n");
            sb.Append("  SegmentWidth: ").Append(this.SegmentWidth).Append("\n");
            sb.Append("  TextHeight: ").Append(this.TextHeight).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Legend2DParameters object</returns>
        public static Legend2DParameters FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Legend2DParameters>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Legend2DParameters object</returns>
        public virtual Legend2DParameters DuplicateLegend2DParameters()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateLegend2DParameters();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Legend2DParameters);
        }


        /// <summary>
        /// Returns true if Legend2DParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of Legend2DParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Legend2DParameters input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.OriginX, input.OriginX) && 
                    Extension.Equals(this.OriginY, input.OriginY) && 
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
                if (this.OriginX != null)
                    hashCode = hashCode * 59 + this.OriginX.GetHashCode();
                if (this.OriginY != null)
                    hashCode = hashCode * 59 + this.OriginY.GetHashCode();
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
