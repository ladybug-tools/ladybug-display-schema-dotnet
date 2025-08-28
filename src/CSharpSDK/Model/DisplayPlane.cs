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
    /// A plane object with display properties.
    /// </summary>
    [Summary(@"A plane object with display properties.")]
    [System.Serializable]
    [DataContract(Name = "DisplayPlane")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class DisplayPlane : DisplayBaseModel, System.IEquatable<DisplayPlane>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayPlane" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected DisplayPlane() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DisplayPlane";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayPlane" /> class.
        /// </summary>
        /// <param name="color">Color for the geometry.</param>
        /// <param name="geometry">Plane for the geometry.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="showAxes">A boolean to note whether the plane should be displayed with XY axes instead of just an origin point and a normal vector.</param>
        /// <param name="showGrid">A boolean to note whether the plane should be displayed with a grid.</param>
        public DisplayPlane
        (
            Color color, Plane geometry, object userData = default, bool showAxes = false, bool showGrid = false
        ) : base(userData: userData)
        {
            this.Color = color ?? throw new System.ArgumentNullException("color is a required property for DisplayPlane and cannot be null");
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for DisplayPlane and cannot be null");
            this.ShowAxes = showAxes;
            this.ShowGrid = showGrid;

            // Set readonly properties with defaultValue
            this.Type = "DisplayPlane";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DisplayPlane))
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
        /// Plane for the geometry.
        /// </summary>
        [Summary(@"Plane for the geometry.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "geometry", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("geometry", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public Plane Geometry { get; set; }

        /// <summary>
        /// A boolean to note whether the plane should be displayed with XY axes instead of just an origin point and a normal vector.
        /// </summary>
        [Summary(@"A boolean to note whether the plane should be displayed with XY axes instead of just an origin point and a normal vector.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "show_axes")] // For internal Serialization XML/JSON
        [JsonProperty("show_axes", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("show_axes")] // For System.Text.Json
        public bool ShowAxes { get; set; } = false;

        /// <summary>
        /// A boolean to note whether the plane should be displayed with a grid.
        /// </summary>
        [Summary(@"A boolean to note whether the plane should be displayed with a grid.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "show_grid")] // For internal Serialization XML/JSON
        [JsonProperty("show_grid", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("show_grid")] // For System.Text.Json
        public bool ShowGrid { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DisplayPlane";
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
            sb.Append("DisplayPlane:\n");
            sb.Append("  Color: ").Append(this.Color).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  ShowAxes: ").Append(this.ShowAxes).Append("\n");
            sb.Append("  ShowGrid: ").Append(this.ShowGrid).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DisplayPlane object</returns>
        public static DisplayPlane FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DisplayPlane>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayPlane object</returns>
        public virtual DisplayPlane DuplicateDisplayPlane()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayBaseModel</returns>
        public override DisplayBaseModel DuplicateDisplayBaseModel()
        {
            return DuplicateDisplayPlane();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DisplayPlane);
        }


        /// <summary>
        /// Returns true if DisplayPlane instances are equal
        /// </summary>
        /// <param name="input">Instance of DisplayPlane to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DisplayPlane input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Color, input.Color) && 
                    Extension.Equals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.ShowAxes, input.ShowAxes) && 
                    Extension.Equals(this.ShowGrid, input.ShowGrid);
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
                if (this.ShowAxes != null)
                    hashCode = hashCode * 59 + this.ShowAxes.GetHashCode();
                if (this.ShowGrid != null)
                    hashCode = hashCode * 59 + this.ShowGrid.GetHashCode();
                return hashCode;
            }
        }


    }
}
