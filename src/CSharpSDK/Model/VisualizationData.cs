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
    /// Represents a data set for visualization with legend parameters and data type.
    /// </summary>
    [Summary(@"Represents a data set for visualization with legend parameters and data type.")]
    [System.Serializable]
    [DataContract(Name = "VisualizationData")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class VisualizationData : OpenAPIGenBaseModel, System.IEquatable<VisualizationData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VisualizationData" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected VisualizationData() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "VisualizationData";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="VisualizationData" /> class.
        /// </summary>
        /// <param name="values">A list of numerical values that will be used to generate the visualization colors.</param>
        /// <param name="legendParameters">An Optional LegendParameters object to override default parameters of the legend. None indicates that default legend parameters will be used.</param>
        /// <param name="dataType">Optional DataType from the ladybug datatype subpackage (ie. Temperature()) , which will be used to assign default legend properties. If None, the legend associated with this object will contain no units unless a unit below is specified.</param>
        /// <param name="unit">Optional text string for the units of the values. (ie. ""C""). If None, the default units of the data_type will be used.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        public VisualizationData
        (
            List<double> values, LegendParameters legendParameters = default, AnyOf<DataType, GenericDataType> dataType = default, string unit = "", object userData = default
        ) : base()
        {
            this.Values = values ?? throw new System.ArgumentNullException("values is a required property for VisualizationData and cannot be null");
            this.LegendParameters = legendParameters;
            this.DataType = dataType;
            this.Unit = unit ?? "";
            this.UserData = userData;

            // Set readonly properties with defaultValue
            this.Type = "VisualizationData";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(VisualizationData))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of numerical values that will be used to generate the visualization colors.
        /// </summary>
        [Summary(@"A list of numerical values that will be used to generate the visualization colors.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "values", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("values", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("values")] // For System.Text.Json
        public List<double> Values { get; set; }

        /// <summary>
        /// An Optional LegendParameters object to override default parameters of the legend. None indicates that default legend parameters will be used.
        /// </summary>
        [Summary(@"An Optional LegendParameters object to override default parameters of the legend. None indicates that default legend parameters will be used.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "legend_parameters")] // For internal Serialization XML/JSON
        [JsonProperty("legend_parameters", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("legend_parameters")] // For System.Text.Json
        public LegendParameters LegendParameters { get; set; }

        /// <summary>
        /// Optional DataType from the ladybug datatype subpackage (ie. Temperature()) , which will be used to assign default legend properties. If None, the legend associated with this object will contain no units unless a unit below is specified.
        /// </summary>
        [Summary(@"Optional DataType from the ladybug datatype subpackage (ie. Temperature()) , which will be used to assign default legend properties. If None, the legend associated with this object will contain no units unless a unit below is specified.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "data_type")] // For internal Serialization XML/JSON
        [JsonProperty("data_type", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("data_type")] // For System.Text.Json
        public AnyOf<DataType, GenericDataType> DataType { get; set; }

        /// <summary>
        /// Optional text string for the units of the values. (ie. ""C""). If None, the default units of the data_type will be used.
        /// </summary>
        [Summary(@"Optional text string for the units of the values. (ie. ""C""). If None, the default units of the data_type will be used.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "unit")] // For internal Serialization XML/JSON
        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("unit")] // For System.Text.Json
        public string Unit { get; set; } = "";

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
            return "VisualizationData";
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
            sb.Append("VisualizationData:\n");
            sb.Append("  Values: ").Append(this.Values).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  LegendParameters: ").Append(this.LegendParameters).Append("\n");
            sb.Append("  DataType: ").Append(this.DataType).Append("\n");
            sb.Append("  Unit: ").Append(this.Unit).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>VisualizationData object</returns>
        public static VisualizationData FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<VisualizationData>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>VisualizationData object</returns>
        public virtual VisualizationData DuplicateVisualizationData()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateVisualizationData();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as VisualizationData);
        }


        /// <summary>
        /// Returns true if VisualizationData instances are equal
        /// </summary>
        /// <param name="input">Instance of VisualizationData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VisualizationData input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Values, input.Values) && 
                    Extension.Equals(this.LegendParameters, input.LegendParameters) && 
                    Extension.Equals(this.DataType, input.DataType) && 
                    Extension.Equals(this.Unit, input.Unit) && 
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
                if (this.Values != null)
                    hashCode = hashCode * 59 + this.Values.GetHashCode();
                if (this.LegendParameters != null)
                    hashCode = hashCode * 59 + this.LegendParameters.GetHashCode();
                if (this.DataType != null)
                    hashCode = hashCode * 59 + this.DataType.GetHashCode();
                if (this.Unit != null)
                    hashCode = hashCode * 59 + this.Unit.GetHashCode();
                if (this.UserData != null)
                    hashCode = hashCode * 59 + this.UserData.GetHashCode();
                return hashCode;
            }
        }


    }
}
