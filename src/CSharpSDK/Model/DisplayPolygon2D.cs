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
    /// A single polygon in 2D space with display properties.
    /// </summary>
    [Summary(@"A single polygon in 2D space with display properties.")]
    [System.Serializable]
    [DataContract(Name = "DisplayPolygon2D")]
    public partial class DisplayPolygon2D : DisplayBaseModel, System.IEquatable<DisplayPolygon2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayPolygon2D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected DisplayPolygon2D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DisplayPolygon2D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayPolygon2D" /> class.
        /// </summary>
        /// <param name="color">Color for the geometry.</param>
        /// <param name="geometry">Polygon2D for the geometry.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="lineWidth">Number for line width in pixels (for the screen) or millimeters (in print). Set to zero to hide the geometry.</param>
        /// <param name="lineType">Text to indicate the type of line to display (dashed, dotted, etc.). The LineTypes enumeration contains all acceptable types.</param>
        public DisplayPolygon2D
        (
            Color color, Polygon2D geometry, object userData = default, AnyOf<Default, double> lineWidth = default, LineTypes lineType = LineTypes.Continuous
        ) : base(userData: userData)
        {
            this.Color = color ?? throw new System.ArgumentNullException("color is a required property for DisplayPolygon2D and cannot be null");
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for DisplayPolygon2D and cannot be null");
            this.LineWidth = lineWidth ?? new Default();
            this.LineType = lineType;

            // Set readonly properties with defaultValue
            this.Type = "DisplayPolygon2D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DisplayPolygon2D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Color for the geometry.
        /// </summary>
        [Summary(@"Color for the geometry.")]
        [Required]
        [DataMember(Name = "color", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("color")] // For System.Text.Json
        public Color Color { get; set; }

        /// <summary>
        /// Polygon2D for the geometry.
        /// </summary>
        [Summary(@"Polygon2D for the geometry.")]
        [Required]
        [DataMember(Name = "geometry", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public Polygon2D Geometry { get; set; }

        /// <summary>
        /// Number for line width in pixels (for the screen) or millimeters (in print). Set to zero to hide the geometry.
        /// </summary>
        [Summary(@"Number for line width in pixels (for the screen) or millimeters (in print). Set to zero to hide the geometry.")]
        [DataMember(Name = "line_width")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("line_width")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<Default, double> LineWidth { get; set; } = new Default();

        /// <summary>
        /// Text to indicate the type of line to display (dashed, dotted, etc.). The LineTypes enumeration contains all acceptable types.
        /// </summary>
        [Summary(@"Text to indicate the type of line to display (dashed, dotted, etc.). The LineTypes enumeration contains all acceptable types.")]
        [DataMember(Name = "line_type")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("line_type")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public LineTypes LineType { get; set; } = LineTypes.Continuous;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DisplayPolygon2D";
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
            sb.Append("DisplayPolygon2D:\n");
            sb.Append("  Color: ").Append(this.Color).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  LineWidth: ").Append(this.LineWidth).Append("\n");
            sb.Append("  LineType: ").Append(this.LineType).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DisplayPolygon2D object</returns>
        public static DisplayPolygon2D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DisplayPolygon2D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayPolygon2D object</returns>
        public virtual DisplayPolygon2D DuplicateDisplayPolygon2D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayBaseModel</returns>
        public override DisplayBaseModel DuplicateDisplayBaseModel()
        {
            return DuplicateDisplayPolygon2D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DisplayPolygon2D);
        }


        /// <summary>
        /// Returns true if DisplayPolygon2D instances are equal
        /// </summary>
        /// <param name="input">Instance of DisplayPolygon2D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DisplayPolygon2D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Color, input.Color) && 
                    Extension.Equals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.LineWidth, input.LineWidth) && 
                    Extension.Equals(this.LineType, input.LineType);
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
                if (this.Color != null)
                    hashCode = hashCode * 59 + this.Color.GetHashCode();
                if (this.Geometry != null)
                    hashCode = hashCode * 59 + this.Geometry.GetHashCode();
                if (this.LineWidth != null)
                    hashCode = hashCode * 59 + this.LineWidth.GetHashCode();
                if (this.LineType != null)
                    hashCode = hashCode * 59 + this.LineType.GetHashCode();
                return hashCode;
            }
        }


    }
}
