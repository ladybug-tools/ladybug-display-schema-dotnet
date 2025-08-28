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
    /// Base class for all Geometric Display objects with a single color.
    /// </summary>
    [Summary(@"Base class for all Geometric Display objects with a single color.")]
    [System.Serializable]
    [DataContract(Name = "SingleColorBase")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class SingleColorBase : DisplayBaseModel, System.IEquatable<SingleColorBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleColorBase" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected SingleColorBase() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "SingleColorBase";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleColorBase" /> class.
        /// </summary>
        /// <param name="color">Color for the geometry.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        public SingleColorBase
        (
            Color color, object userData = default
        ) : base(userData: userData)
        {
            this.Color = color ?? throw new System.ArgumentNullException("color is a required property for SingleColorBase and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "SingleColorBase";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(SingleColorBase))
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "SingleColorBase";
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
            sb.Append("SingleColorBase:\n");
            sb.Append("  Color: ").Append(this.Color).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>SingleColorBase object</returns>
        public static SingleColorBase FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<SingleColorBase>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>SingleColorBase object</returns>
        public virtual SingleColorBase DuplicateSingleColorBase()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DisplayBaseModel</returns>
        public override DisplayBaseModel DuplicateDisplayBaseModel()
        {
            return DuplicateSingleColorBase();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as SingleColorBase);
        }


        /// <summary>
        /// Returns true if SingleColorBase instances are equal
        /// </summary>
        /// <param name="input">Instance of SingleColorBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SingleColorBase input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Color, input.Color);
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
                return hashCode;
            }
        }


    }
}
