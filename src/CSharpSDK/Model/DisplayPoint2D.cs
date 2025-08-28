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
    /// A point object in 2D space with display properties.
    /// </summary>
    [Summary(@"A point object in 2D space with display properties.")]
    [System.Serializable]
    [DataContract(Name = "DisplayPoint2D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class DisplayPoint2D : DisplayBaseModel, System.IEquatable<DisplayPoint2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayPoint2D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected DisplayPoint2D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DisplayPoint2D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayPoint2D" /> class.
        /// </summary>
        /// <param name="color">Color for the geometry.</param>
        /// <param name="geometry">Point2D for the geometry.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="radius">Number for the radius with which the point should be displayed in pixels (for the screen) or millimeters (in print).</param>
        public DisplayPoint2D
        (
            Color color, Point2D geometry, object userData = default, AnyOf<Default, double> radius = default
        ) : base(userData: userData)
        {
            this.Color = color ?? throw new System.ArgumentNullException("color is a required property for DisplayPoint2D and cannot be null");
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for DisplayPoint2D and cannot be null");
            this.Radius = radius ?? new Default();

            // Set readonly properties with defaultValue
            this.Type = "DisplayPoint2D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DisplayPoint2D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Color for the geometry.
        /// </summary>
        [Summary(@"Color for the geometry.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "color", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("color", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("color")] // For System.Text.Json
        public Color Color { get; set; }

        /// <summary>
        /// Point2D for the geometry.
        /// </summary>
        [Summary(@"Point2D for the geometry.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "geometry", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("geometry", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public Point2D Geometry { get; set; }

        /// <summary>
        /// Number for the radius with which the point should be displayed in pixels (for the screen) or millimeters (in print).
        /// </summary>
        [Summary(@"Number for the radius with which the point should be displayed in pixels (for the screen) or millimeters (in print).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "radius")] // For internal Serialization XML/JSON
        [JsonProperty("radius", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("radius")] // For System.Text.Json
        public AnyOf<Default, double> Radius { get; set; } = new Default();


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DisplayPoint2D";
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
            sb.Append("DisplayPoint2D:\n");
            sb.Append("  Color: ").Append(this.Color).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Radius: ").Append(this.Radius).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DisplayPoint2D object</returns>
        public static DisplayPoint2D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DisplayPoint2D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayPoint2D object</returns>
        public virtual DisplayPoint2D DuplicateDisplayPoint2D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayBaseModel</returns>
        public override DisplayBaseModel DuplicateDisplayBaseModel()
        {
            return DuplicateDisplayPoint2D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DisplayPoint2D);
        }


        /// <summary>
        /// Returns true if DisplayPoint2D instances are equal
        /// </summary>
        /// <param name="input">Instance of DisplayPoint2D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DisplayPoint2D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Color, input.Color) && 
                    Extension.Equals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.Radius, input.Radius);
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
                if (this.Radius != null)
                    hashCode = hashCode * 59 + this.Radius.GetHashCode();
                return hashCode;
            }
        }


    }
}
