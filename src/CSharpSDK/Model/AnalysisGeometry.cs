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
    /// An object where multiple data streams correspond to the same geometry.
    /// </summary>
    [Summary(@"An object where multiple data streams correspond to the same geometry.")]
    [System.Serializable]
    [DataContract(Name = "AnalysisGeometry")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class AnalysisGeometry : VisualizationBase, System.IEquatable<AnalysisGeometry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalysisGeometry" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected AnalysisGeometry()
        {
            // Set readonly properties with defaultValue
            this.Type = "AnalysisGeometry";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalysisGeometry" /> class.
        /// </summary>
        /// <param name="identifier">Text string for a unique object ID. Must be less than 100 characters and not contain spaces or special characters.</param>
        /// <param name="geometry">A list of ladybug-geometry objects that is aligned with the values in the input data_sets. The length of this list should usually be equal to the total number of values in each data_set, indicating that each geometry gets a single color. Alternatively, if all of the geometry objects are meshes, the number of values in the data can be equal to the total number of faces across the meshes or the total number of vertices across the meshes.</param>
        /// <param name="dataSets">An list of VisualizationData objects representing the data sets that are associated with the input geometry.</param>
        /// <param name="displayName">Display name of the object with no character restrictions. This is typically used to set the layer of the object in the interface that renders the VisualizationSet. A :: in the display_name can be used to denote sub-layers following a convention of ParentLayer::SubLayer. If not set, the display_name will be equal to the object identifier.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        /// <param name="activeData">An integer to denote which of the input data_sets should be displayed by default.</param>
        /// <param name="displayMode">Text to indicate the display mode (surface, wireframe, etc.). The DisplayModes enumeration contains all acceptable types.</param>
        /// <param name="hidden">A boolean to note whether the geometry is hidden by default and must be un-hidden to be visible in the 3D scene.</param>
        public AnalysisGeometry
        (
            string identifier, List<AnyOf<IGeometry>> geometry, List<VisualizationData> dataSets, string displayName = default, object userData = default, int activeData = 0, DisplayModes displayMode = DisplayModes.Surface, bool hidden = false
        ) : base(identifier: identifier, displayName: displayName, userData: userData)
        {
            this.Geometry = geometry ?? throw new System.ArgumentNullException("geometry is a required property for AnalysisGeometry and cannot be null");
            this.DataSets = dataSets ?? throw new System.ArgumentNullException("dataSets is a required property for AnalysisGeometry and cannot be null");
            this.ActiveData = activeData;
            this.DisplayMode = displayMode;
            this.Hidden = hidden;

            // Set readonly properties with defaultValue
            this.Type = "AnalysisGeometry";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(AnalysisGeometry))
                this.IsValid(throwException: true);
        }



        /// <summary>
        /// A list of ladybug-geometry objects that is aligned with the values in the input data_sets. The length of this list should usually be equal to the total number of values in each data_set, indicating that each geometry gets a single color. Alternatively, if all of the geometry objects are meshes, the number of values in the data can be equal to the total number of faces across the meshes or the total number of vertices across the meshes.
        /// </summary>
        [Summary(@"A list of ladybug-geometry objects that is aligned with the values in the input data_sets. The length of this list should usually be equal to the total number of values in each data_set, indicating that each geometry gets a single color. Alternatively, if all of the geometry objects are meshes, the number of values in the data can be equal to the total number of faces across the meshes or the total number of vertices across the meshes.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "geometry", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("geometry", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("geometry")] // For System.Text.Json
        public List<AnyOf<IGeometry>> Geometry { get; set; }

        /// <summary>
        /// An list of VisualizationData objects representing the data sets that are associated with the input geometry.
        /// </summary>
        [Summary(@"An list of VisualizationData objects representing the data sets that are associated with the input geometry.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "data_sets", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("data_sets", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("data_sets")] // For System.Text.Json
        public List<VisualizationData> DataSets { get; set; }

        /// <summary>
        /// An integer to denote which of the input data_sets should be displayed by default.
        /// </summary>
        [Summary(@"An integer to denote which of the input data_sets should be displayed by default.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "active_data")] // For internal Serialization XML/JSON
        [JsonProperty("active_data", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("active_data")] // For System.Text.Json
        public int ActiveData { get; set; } = 0;

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
            return "AnalysisGeometry";
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
            sb.Append("AnalysisGeometry:\n");
            sb.Append("  Identifier: ").Append(this.Identifier).Append("\n");
            sb.Append("  Geometry: ").Append(this.Geometry).Append("\n");
            sb.Append("  DataSets: ").Append(this.DataSets).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DisplayName: ").Append(this.DisplayName).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            sb.Append("  ActiveData: ").Append(this.ActiveData).Append("\n");
            sb.Append("  DisplayMode: ").Append(this.DisplayMode).Append("\n");
            sb.Append("  Hidden: ").Append(this.Hidden).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>AnalysisGeometry object</returns>
        public static AnalysisGeometry FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<AnalysisGeometry>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>AnalysisGeometry object</returns>
        public virtual AnalysisGeometry DuplicateAnalysisGeometry()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VisualizationBase</returns>
        public override VisualizationBase DuplicateVisualizationBase()
        {
            return DuplicateAnalysisGeometry();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as AnalysisGeometry);
        }


        /// <summary>
        /// Returns true if AnalysisGeometry instances are equal
        /// </summary>
        /// <param name="input">Instance of AnalysisGeometry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AnalysisGeometry input)
        {
            if (input == null)
                return false;
            return base.Equals(input) &&
                    Extension.AllEquals(this.Geometry, input.Geometry) &&
                    Extension.AllEquals(this.DataSets, input.DataSets) &&
                    Extension.Equals(this.ActiveData, input.ActiveData) &&
                    Extension.Equals(this.DisplayMode, input.DisplayMode) &&
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
                if (this.DataSets != null)
                    hashCode = hashCode * 59 + this.DataSets.GetHashCode();
                if (this.ActiveData != null)
                    hashCode = hashCode * 59 + this.ActiveData.GetHashCode();
                if (this.DisplayMode != null)
                    hashCode = hashCode * 59 + this.DisplayMode.GetHashCode();
                if (this.Hidden != null)
                    hashCode = hashCode * 59 + this.Hidden.GetHashCode();
                return hashCode;
            }
        }


    }
}
