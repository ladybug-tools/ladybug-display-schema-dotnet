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
    /// A mesh in 3D space with display properties.
    /// </summary>
    [Summary(@"A mesh in 3D space with display properties.")]
    [System.Serializable]
    [DataContract(Name = "DisplayMesh3D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class DisplayMesh3D : DisplayBaseModel, System.IEquatable<DisplayMesh3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayMesh3D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected DisplayMesh3D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DisplayMesh3D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayMesh3D" /> class.
        /// </summary>
        /// <param name="color">Color for the geometry.</param>
        /// <param name="geometry">Mesh3D for the geometry.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="displayMode">Text to indicate the display mode (surface, wireframe, etc.). The DisplayModes enumeration contains all acceptable types.</param>
        public DisplayMesh3D
        (
            Color color, Mesh3D geometry, object userData = default, DisplayModes displayMode = DisplayModes.Surface
        ) : base(userData: userData)
        {
            this.Color = color ?? throw new System.ArgumentNullException("color is a required property for DisplayMesh3D and cannot be null");
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for DisplayMesh3D and cannot be null");
            this.DisplayMode = displayMode;

            // Set readonly properties with defaultValue
            this.Type = "DisplayMesh3D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DisplayMesh3D))
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
        /// Mesh3D for the geometry.
        /// </summary>
        [Summary(@"Mesh3D for the geometry.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "geometry", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("geometry", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public Mesh3D Geometry { get; set; }

        /// <summary>
        /// Text to indicate the display mode (surface, wireframe, etc.). The DisplayModes enumeration contains all acceptable types.
        /// </summary>
        [Summary(@"Text to indicate the display mode (surface, wireframe, etc.). The DisplayModes enumeration contains all acceptable types.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "display_mode")] // For internal Serialization XML/JSON
        [JsonProperty("display_mode", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("display_mode")] // For System.Text.Json
        public DisplayModes DisplayMode { get; set; } = DisplayModes.Surface;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DisplayMesh3D";
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
            sb.Append("DisplayMesh3D:\n");
            sb.Append("  Color: ").Append(this.Color).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  DisplayMode: ").Append(this.DisplayMode).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DisplayMesh3D object</returns>
        public static DisplayMesh3D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DisplayMesh3D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayMesh3D object</returns>
        public virtual DisplayMesh3D DuplicateDisplayMesh3D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayBaseModel</returns>
        public override DisplayBaseModel DuplicateDisplayBaseModel()
        {
            return DuplicateDisplayMesh3D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DisplayMesh3D);
        }


        /// <summary>
        /// Returns true if DisplayMesh3D instances are equal
        /// </summary>
        /// <param name="input">Instance of DisplayMesh3D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DisplayMesh3D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Color, input.Color) && 
                    Extension.Equals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.DisplayMode, input.DisplayMode);
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
                if (this.DisplayMode != null)
                    hashCode = hashCode * 59 + this.DisplayMode.GetHashCode();
                return hashCode;
            }
        }


    }
}
