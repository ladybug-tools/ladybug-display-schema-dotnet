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
    /// Base class for visualization objects.
    /// </summary>
    [Summary(@"Base class for visualization objects.")]
    [System.Serializable]
    [DataContract(Name = "VisualizationBase")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class VisualizationBase : OpenAPIGenBaseModel, System.IEquatable<VisualizationBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VisualizationBase" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected VisualizationBase() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "_VisualizationBase";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="VisualizationBase" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. Must be less than 100 characters and not contain spaces or special characters.</param>
        /// <param name="displayName">Display name of the object with no character restrictions. This is typically used to set the layer of the object in the interface that renders the VisualizationSet. A :: in the display_name can be used to denote sub-layers following a convention of ParentLayer::SubLayer. If not set, the display_name will be equal to the object identifier.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        public VisualizationBase
        (
            string identifier, string displayName = default, object userData = default
        ) : base()
        {
            this.Identifier = identifier ?? throw new System.ArgumentNullException("identifier is a required property for VisualizationBase and cannot be null");
            this.DisplayName = displayName;
            this.UserData = userData;

            // Set readonly properties with defaultValue
            this.Type = "_VisualizationBase";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(VisualizationBase))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text string for a unique object ID. Must be less than 100 characters and not contain spaces or special characters.
        /// </summary>
        [Summary(@"Text string for a unique object ID. Must be less than 100 characters and not contain spaces or special characters.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [RegularExpression(@"^[.A-Za-z0-9_-]+$")]
        [MinLength(1)]
        [MaxLength(100)]
        [DataMember(Name = "identifier", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("identifier", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("identifier")] // For System.Text.Json
        public string Identifier { get; set; }

        /// <summary>
        /// Display name of the object with no character restrictions. This is typically used to set the layer of the object in the interface that renders the VisualizationSet. A :: in the display_name can be used to denote sub-layers following a convention of ParentLayer::SubLayer. If not set, the display_name will be equal to the object identifier.
        /// </summary>
        [Summary(@"Display name of the object with no character restrictions. This is typically used to set the layer of the object in the interface that renders the VisualizationSet. A :: in the display_name can be used to denote sub-layers following a convention of ParentLayer::SubLayer. If not set, the display_name will be equal to the object identifier.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "display_name")] // For internal Serialization XML/JSON
        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("display_name")] // For System.Text.Json
        public string DisplayName { get; set; }

        /// <summary>
        /// Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).
        /// </summary>
        [Summary(@"Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "user_data")] // For internal Serialization XML/JSON
        [JsonProperty("user_data", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("user_data")] // For System.Text.Json
        public object UserData { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "VisualizationBase";
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
            sb.Append("VisualizationBase:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>VisualizationBase object</returns>
        public static VisualizationBase FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<VisualizationBase>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VisualizationBase object</returns>
        public virtual VisualizationBase DuplicateVisualizationBase()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateVisualizationBase();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as VisualizationBase);
        }


        /// <summary>
        /// Returns true if VisualizationBase instances are equal
        /// </summary>
        /// <param name="input">Instance of VisualizationBase to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VisualizationBase input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Identifier, input.Identifier) && 
                    Extension.Equals(this.DisplayName, input.DisplayName) && 
                    Extension.Equals(this.UserData, input.UserData);
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
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.UserData != null)
                    hashCode = hashCode * 59 + this.UserData.GetHashCode();
                return hashCode;
            }
        }


    }
}
