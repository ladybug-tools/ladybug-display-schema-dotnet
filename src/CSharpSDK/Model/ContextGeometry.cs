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
    /// An object representing context geometry to display.
    /// </summary>
    [Summary(@"An object representing context geometry to display.")]
    [System.Serializable]
    [DataContract(Name = "ContextGeometry")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class ContextGeometry : VisualizationBase, System.IEquatable<ContextGeometry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextGeometry" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected ContextGeometry()
        {
            // Set readonly properties with defaultValue
            this.Type = "ContextGeometry";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextGeometry" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. Must be less than 100 characters and not contain spaces or special characters.</param>
        /// <param name="geometry">A list of ladybug-geometry or ladybug-display objects that gives context to analysis geometry or other aspects of the visualization. Typically, these will display in wireframe around the geometry, though the properties of display geometry can be used to customize the visualization.</param>
        /// <param name="displayName">Display name of the object with no character restrictions. This is typically used to set the layer of the object in the interface that renders the VisualizationSet. A :: in the display_name can be used to denote sub-layers following a convention of ParentLayer::SubLayer. If not set, the display_name will be equal to the object identifier.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="hidden">A boolean to note whether the geometry is hidden by default and must be un-hidden to be visible in the 3D scene.</param>
        public ContextGeometry
        (
            string identifier, List<AnyOf<IDisplay>> geometry, string displayName = default, object userData = default, bool hidden = false
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for ContextGeometry and cannot be null");
            this.Hidden = hidden;

            // Set readonly properties with defaultValue
            this.Type = "ContextGeometry";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(ContextGeometry))
                this.IsValid(throwException: true);
        }



        /// <summary>
        /// A list of ladybug-geometry or ladybug-display objects that gives context to analysis geometry or other aspects of the visualization. Typically, these will display in wireframe around the geometry, though the properties of display geometry can be used to customize the visualization.
        /// </summary>
        [Summary(@"A list of ladybug-geometry or ladybug-display objects that gives context to analysis geometry or other aspects of the visualization. Typically, these will display in wireframe around the geometry, though the properties of display geometry can be used to customize the visualization.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "geometry", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("geometry", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public List<AnyOf<IDisplay>> Geometry { get; set; }

        /// <summary>
        /// A boolean to note whether the geometry is hidden by default and must be un-hidden to be visible in the 3D scene.
        /// </summary>
        [Summary(@"A boolean to note whether the geometry is hidden by default and must be un-hidden to be visible in the 3D scene.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "hidden")] // For internal Serialization XML/JSON
        [JsonProperty("hidden", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("hidden")] // For System.Text.Json
        public bool Hidden { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "ContextGeometry";
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
            sb.Append("ContextGeometry:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Hidden: ").Append(this.Hidden).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>ContextGeometry object</returns>
        public static ContextGeometry FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<ContextGeometry>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>ContextGeometry object</returns>
        public virtual ContextGeometry DuplicateContextGeometry()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VisualizationBase</returns>
        public override VisualizationBase DuplicateVisualizationBase()
        {
            return DuplicateContextGeometry();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as ContextGeometry);
        }


        /// <summary>
        /// Returns true if ContextGeometry instances are equal
        /// </summary>
        /// <param name="input">Instance of ContextGeometry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContextGeometry input)
        {
            if (input == null)
                return false;
            return base.Equals(input) &&
                    Extension.AllEquals(this.Geometry, input.Geometry) &&
                    Extension.Equals(this.Hidden, input.Hidden);
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
                if (this.Geometry != null)
                    hashCode = hashCode * 59 + this.Geometry.GetHashCode();
                if (this.Hidden != null)
                    hashCode = hashCode * 59 + this.Hidden.GetHashCode();
                return hashCode;
            }
        }


    }
}
