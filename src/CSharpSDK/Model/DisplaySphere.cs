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
    /// A sphere object with display properties.
    /// </summary>
    [Summary(@"A sphere object with display properties.")]
    [System.Serializable]
    [DataContract(Name = "DisplaySphere")]
    public partial class DisplaySphere : DisplayBaseModel, System.IEquatable<DisplaySphere>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplaySphere" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected DisplaySphere() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DisplaySphere";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplaySphere" /> class.
        /// </summary>
        /// <param name="color">Color for the geometry.</param>
        /// <param name="geometry">Sphere for the geometry.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="displayMode">Text to indicate the display mode (surface, wireframe, etc.). The DisplayModes enumeration contains all acceptable types.</param>
        public DisplaySphere
        (
            Color color, Sphere geometry, object userData = default, DisplayModes displayMode = DisplayModes.Surface
        ) : base(userData: userData)
        {
            this.Color = color ?? throw new System.ArgumentNullException("color is a required property for DisplaySphere and cannot be null");
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for DisplaySphere and cannot be null");
            this.DisplayMode = displayMode;

            // Set readonly properties with defaultValue
            this.Type = "DisplaySphere";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DisplaySphere))
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
        /// Sphere for the geometry.
        /// </summary>
        [Summary(@"Sphere for the geometry.")]
        [Required]
        [DataMember(Name = "geometry", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public Sphere Geometry { get; set; }

        /// <summary>
        /// Text to indicate the display mode (surface, wireframe, etc.). The DisplayModes enumeration contains all acceptable types.
        /// </summary>
        [Summary(@"Text to indicate the display mode (surface, wireframe, etc.). The DisplayModes enumeration contains all acceptable types.")]
        [DataMember(Name = "display_mode")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("display_mode")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public DisplayModes DisplayMode { get; set; } = DisplayModes.Surface;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DisplaySphere";
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
            sb.Append("DisplaySphere:\n");
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
        /// <returns>DisplaySphere object</returns>
        public static DisplaySphere FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DisplaySphere>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplaySphere object</returns>
        public virtual DisplaySphere DuplicateDisplaySphere()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayBaseModel</returns>
        public override DisplayBaseModel DuplicateDisplayBaseModel()
        {
            return DuplicateDisplaySphere();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DisplaySphere);
        }


        /// <summary>
        /// Returns true if DisplaySphere instances are equal
        /// </summary>
        /// <param name="input">Instance of DisplaySphere to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DisplaySphere input)
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
