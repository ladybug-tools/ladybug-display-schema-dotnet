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
    /// A visualization set containing analysis and context geometry to be visualized.
    /// </summary>
    [Summary(@"A visualization set containing analysis and context geometry to be visualized.")]
    [System.Serializable]
    [DataContract(Name = "VisualizationSet")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class VisualizationSet : VisualizationBase, System.IEquatable<VisualizationSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VisualizationSet" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected VisualizationSet() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "VisualizationSet";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="VisualizationSet" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. Must be less than 100 characters and not contain spaces or special characters.</param>
        /// <param name="displayName">Display name of the object with no character restrictions. This is typically used to set the layer of the object in the interface that renders the VisualizationSet. A :: in the display_name can be used to denote sub-layers following a convention of ParentLayer::SubLayer. If not set, the display_name will be equal to the object identifier.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="geometry">A list of AnalysisGeometry and ContextGeometry objects to display in the visualization. Each geometry object will typically be translated to its own layer within the interface that renders the VisualizationSet.</param>
        /// <param name="units">Text indicating the units in which the model geometry exists. If None, the geometry will always be assumed to be in the current units system of the display interface.</param>
        public VisualizationSet
        (
            string identifier, string displayName = default, object userData = default, List<AnyOf<AnalysisGeometry, ContextGeometry>> geometry = default, Units units = default
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Geometry = geometry;
            this.Units = units;

            // Set readonly properties with defaultValue
            this.Type = "VisualizationSet";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(VisualizationSet))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of AnalysisGeometry and ContextGeometry objects to display in the visualization. Each geometry object will typically be translated to its own layer within the interface that renders the VisualizationSet.
        /// </summary>
        [Summary(@"A list of AnalysisGeometry and ContextGeometry objects to display in the visualization. Each geometry object will typically be translated to its own layer within the interface that renders the VisualizationSet.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "geometry")] // For internal Serialization XML/JSON
        [JsonProperty("geometry", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public List<AnyOf<AnalysisGeometry, ContextGeometry>> Geometry { get; set; }

        /// <summary>
        /// Text indicating the units in which the model geometry exists. If None, the geometry will always be assumed to be in the current units system of the display interface.
        /// </summary>
        [Summary(@"Text indicating the units in which the model geometry exists. If None, the geometry will always be assumed to be in the current units system of the display interface.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "units")] // For internal Serialization XML/JSON
        [JsonProperty("units", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("units")] // For System.Text.Json
        public Units Units { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "VisualizationSet";
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
            sb.Append("VisualizationSet:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  Units: ").Append(this.Units).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>VisualizationSet object</returns>
        public static VisualizationSet FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<VisualizationSet>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VisualizationSet object</returns>
        public virtual VisualizationSet DuplicateVisualizationSet()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VisualizationBase</returns>
        public override VisualizationBase DuplicateVisualizationBase()
        {
            return DuplicateVisualizationSet();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as VisualizationSet);
        }


        /// <summary>
        /// Returns true if VisualizationSet instances are equal
        /// </summary>
        /// <param name="input">Instance of VisualizationSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VisualizationSet input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Geometry, input.Geometry) && 
                    Extension.Equals(this.Units, input.Units);
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
                if (this.Units != null)
                    hashCode = hashCode * 59 + this.Units.GetHashCode();
                return hashCode;
            }
        }


    }
}
