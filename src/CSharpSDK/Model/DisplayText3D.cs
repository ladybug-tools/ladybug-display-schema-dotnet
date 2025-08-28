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
    /// A text object in 3D space with display properties.
    /// </summary>
    [Summary(@"A text object in 3D space with display properties.")]
    [System.Serializable]
    [DataContract(Name = "DisplayText3D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class DisplayText3D : DisplayBaseModel, System.IEquatable<DisplayText3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayText3D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected DisplayText3D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "DisplayText3D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayText3D" /> class.
        /// </summary>
        /// <param name="color">Color for the geometry.</param>
        /// <param name="text">A text string to be displayed in the 3D scene.</param>
        /// <param name="plane">A ladybug-geometry Plane object to locate and orient the text in the 3D scene.</param>
        /// <param name="height">A number for the height of the text in the 3D scene.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="font">A text string for the font in which to draw the text. Note that this field may not be interpreted the same on all machines and in all interfaces, particularly when a machine lacks a given font.</param>
        /// <param name="horizontalAlignment">String to specify the horizontal alignment of the text.</param>
        /// <param name="verticalAlignment">String to specify the vertical alignment of the text.</param>
        public DisplayText3D
        (
            Color color, string text, Plane plane, double height, object userData = default, string font = "Arial", HorizontalAlignments horizontalAlignment = HorizontalAlignments.Left, VerticalAlignments verticalAlignment = VerticalAlignments.Bottom
        ) : base(userData: userData)
        {
            this.Color = color ?? throw new System.ArgumentNullException("color is a required property for DisplayText3D and cannot be null");
            this.Text = text ?? throw new System.ArgumentNullException("text is a required property for DisplayText3D and cannot be null");
            this.Plane = plane ?? throw new System.ArgumentNullException("plane is a required property for DisplayText3D and cannot be null");
            this.Height = height;
            this.Font = font ?? "Arial";
            this.HorizontalAlignment = horizontalAlignment;
            this.VerticalAlignment = verticalAlignment;

            // Set readonly properties with defaultValue
            this.Type = "DisplayText3D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DisplayText3D))
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
        /// A text string to be displayed in the 3D scene.
        /// </summary>
        [Summary(@"A text string to be displayed in the 3D scene.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "text", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("text", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("text")] // For System.Text.Json
        public string Text { get; set; }

        /// <summary>
        /// A ladybug-geometry Plane object to locate and orient the text in the 3D scene.
        /// </summary>
        [Summary(@"A ladybug-geometry Plane object to locate and orient the text in the 3D scene.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "plane", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("plane", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("plane")] // For System.Text.Json
        public Plane Plane { get; set; }

        /// <summary>
        /// A number for the height of the text in the 3D scene.
        /// </summary>
        [Summary(@"A number for the height of the text in the 3D scene.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "height", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("height", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("height")] // For System.Text.Json
        public double Height { get; set; }

        /// <summary>
        /// A text string for the font in which to draw the text. Note that this field may not be interpreted the same on all machines and in all interfaces, particularly when a machine lacks a given font.
        /// </summary>
        [Summary(@"A text string for the font in which to draw the text. Note that this field may not be interpreted the same on all machines and in all interfaces, particularly when a machine lacks a given font.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "font")] // For internal Serialization XML/JSON
        [JsonProperty("font", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("font")] // For System.Text.Json
        public string Font { get; set; } = "Arial";

        /// <summary>
        /// String to specify the horizontal alignment of the text.
        /// </summary>
        [Summary(@"String to specify the horizontal alignment of the text.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "horizontal_alignment")] // For internal Serialization XML/JSON
        [JsonProperty("horizontal_alignment", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("horizontal_alignment")] // For System.Text.Json
        public HorizontalAlignments HorizontalAlignment { get; set; } = HorizontalAlignments.Left;

        /// <summary>
        /// String to specify the vertical alignment of the text.
        /// </summary>
        [Summary(@"String to specify the vertical alignment of the text.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "vertical_alignment")] // For internal Serialization XML/JSON
        [JsonProperty("vertical_alignment", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("vertical_alignment")] // For System.Text.Json
        public VerticalAlignments VerticalAlignment { get; set; } = VerticalAlignments.Bottom;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DisplayText3D";
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
            sb.Append("DisplayText3D:\n");
            sb.Append("  Color: ").Append(this.Color).Append("\n");
            sb.Append("  Text: ").Append(this.Text).Append("\n");
            sb.Append("  Plane: ").Append(this.Plane).Append("\n");
            sb.Append("  Height: ").Append(this.Height).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Font: ").Append(this.Font).Append("\n");
            sb.Append("  HorizontalAlignment: ").Append(this.HorizontalAlignment).Append("\n");
            sb.Append("  VerticalAlignment: ").Append(this.VerticalAlignment).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DisplayText3D object</returns>
        public static DisplayText3D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DisplayText3D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayText3D object</returns>
        public virtual DisplayText3D DuplicateDisplayText3D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayBaseModel</returns>
        public override DisplayBaseModel DuplicateDisplayBaseModel()
        {
            return DuplicateDisplayText3D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DisplayText3D);
        }


        /// <summary>
        /// Returns true if DisplayText3D instances are equal
        /// </summary>
        /// <param name="input">Instance of DisplayText3D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DisplayText3D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Color, input.Color) && 
                    Extension.Equals(this.Text, input.Text) && 
                    Extension.Equals(this.Plane, input.Plane) && 
                    Extension.Equals(this.Height, input.Height) && 
                    Extension.Equals(this.Font, input.Font) && 
                    Extension.Equals(this.HorizontalAlignment, input.HorizontalAlignment) && 
                    Extension.Equals(this.VerticalAlignment, input.VerticalAlignment);
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
                if (this.Text != null)
                    hashCode = hashCode * 59 + this.Text.GetHashCode();
                if (this.Plane != null)
                    hashCode = hashCode * 59 + this.Plane.GetHashCode();
                if (this.Height != null)
                    hashCode = hashCode * 59 + this.Height.GetHashCode();
                if (this.Font != null)
                    hashCode = hashCode * 59 + this.Font.GetHashCode();
                if (this.HorizontalAlignment != null)
                    hashCode = hashCode * 59 + this.HorizontalAlignment.GetHashCode();
                if (this.VerticalAlignment != null)
                    hashCode = hashCode * 59 + this.VerticalAlignment.GetHashCode();
                return hashCode;
            }
        }


    }
}
