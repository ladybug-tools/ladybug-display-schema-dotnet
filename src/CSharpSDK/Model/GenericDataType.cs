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
    /// Generic data type representation.
    /// </summary>
    [Summary(@"Generic data type representation.")]
    [System.Serializable]
    [DataContract(Name = "GenericDataType")]
    public partial class GenericDataType : OpenAPIGenBaseModel, System.IEquatable<GenericDataType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDataType" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected GenericDataType() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "GenericDataType";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDataType" /> class.
        /// </summary>
        /// <param name="name">Text to indicate how the data type displays. This can be more specific than the data_type.</param>
        /// <param name="baseUnit">Text string for the base unit of the data type, which should be standard SI units where possible.</param>
        /// <param name="dataType">DataType</param>
        /// <param name="min">Optional lower limit for the data type, values below which should be physically or mathematically impossible. (Default: -inf)</param>
        /// <param name="max">Optional upper limit for the data type, values above which should be physically or mathematically impossible. (Default: +inf)</param>
        /// <param name="abbreviation">An optional abbreviation for the data type as text.</param>
        /// <param name="unitDescr">An optional dictionary describing categories that the numerical values of the units relate to. For example: {-1: ""Cold"", 0: ""Neutral"", +1: ""Hot""}; {0: ""False"", 1: ""True""}.</param>
        /// <param name="pointInTime">Boolean to note whether the data type represents conditions at a single instant in time (True) as opposed to being an average or accumulation over time (False) when it is found in hourly lists of data.</param>
        /// <param name="cumulative">Boolean to tell whether the data type can be cumulative when it is represented over time (True) or it can only be averaged over time to be meaningful (False). Note that cumulative cannot be True when point_in_time is also True.</param>
        public GenericDataType
        (
            string name, string baseUnit, string dataType = "GenericType", AnyOf<Default, double> min = default, AnyOf<Default, double> max = default, string abbreviation = "", object unitDescr = default, bool pointInTime = true, bool cumulative = false
        ) : base()
        {
            this.Name = name ?? throw new System.ArgumentNullException("name is a required property for GenericDataType and cannot be null");
            this.BaseUnit = baseUnit ?? throw new System.ArgumentNullException("baseUnit is a required property for GenericDataType and cannot be null");
            this.DataType = dataType ?? "GenericType";
            this.Min = min ?? new Default();
            this.Max = max ?? new Default();
            this.Abbreviation = abbreviation ?? "";
            this.UnitDescr = unitDescr;
            this.PointInTime = pointInTime;
            this.Cumulative = cumulative;

            // Set readonly properties with defaultValue
            this.Type = "GenericDataType";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(GenericDataType))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Text to indicate how the data type displays. This can be more specific than the data_type.
        /// </summary>
        [Summary(@"Text to indicate how the data type displays. This can be more specific than the data_type.")]
        [Required]
        [DataMember(Name = "name", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("name")] // For System.Text.Json
        public string Name { get; set; }

        /// <summary>
        /// Text string for the base unit of the data type, which should be standard SI units where possible.
        /// </summary>
        [Summary(@"Text string for the base unit of the data type, which should be standard SI units where possible.")]
        [Required]
        [DataMember(Name = "base_unit", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("base_unit")] // For System.Text.Json
        public string BaseUnit { get; set; }

        /// <summary>
        /// DataType
        /// </summary>
        [Summary(@"DataType")]
        [RegularExpression(@"^GenericType$")]
        [DataMember(Name = "data_type")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("data_type")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string DataType { get; set; } = "GenericType";

        /// <summary>
        /// Optional lower limit for the data type, values below which should be physically or mathematically impossible. (Default: -inf)
        /// </summary>
        [Summary(@"Optional lower limit for the data type, values below which should be physically or mathematically impossible. (Default: -inf)")]
        [DataMember(Name = "min")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("min")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<Default, double> Min { get; set; } = new Default();

        /// <summary>
        /// Optional upper limit for the data type, values above which should be physically or mathematically impossible. (Default: +inf)
        /// </summary>
        [Summary(@"Optional upper limit for the data type, values above which should be physically or mathematically impossible. (Default: +inf)")]
        [DataMember(Name = "max")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("max")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public AnyOf<Default, double> Max { get; set; } = new Default();

        /// <summary>
        /// An optional abbreviation for the data type as text.
        /// </summary>
        [Summary(@"An optional abbreviation for the data type as text.")]
        [DataMember(Name = "abbreviation")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("abbreviation")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public string Abbreviation { get; set; } = "";

        /// <summary>
        /// An optional dictionary describing categories that the numerical values of the units relate to. For example: {-1: ""Cold"", 0: ""Neutral"", +1: ""Hot""}; {0: ""False"", 1: ""True""}.
        /// </summary>
        [Summary(@"An optional dictionary describing categories that the numerical values of the units relate to. For example: {-1: ""Cold"", 0: ""Neutral"", +1: ""Hot""}; {0: ""False"", 1: ""True""}.")]
        [DataMember(Name = "unit_descr")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("unit_descr")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public object UnitDescr { get; set; }

        /// <summary>
        /// Boolean to note whether the data type represents conditions at a single instant in time (True) as opposed to being an average or accumulation over time (False) when it is found in hourly lists of data.
        /// </summary>
        [Summary(@"Boolean to note whether the data type represents conditions at a single instant in time (True) as opposed to being an average or accumulation over time (False) when it is found in hourly lists of data.")]
        [DataMember(Name = "point_in_time")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("point_in_time")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public bool PointInTime { get; set; } = true;

        /// <summary>
        /// Boolean to tell whether the data type can be cumulative when it is represented over time (True) or it can only be averaged over time to be meaningful (False). Note that cumulative cannot be True when point_in_time is also True.
        /// </summary>
        [Summary(@"Boolean to tell whether the data type can be cumulative when it is represented over time (True) or it can only be averaged over time to be meaningful (False). Note that cumulative cannot be True when point_in_time is also True.")]
        [DataMember(Name = "cumulative")] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("cumulative")] // For System.Text.Json
        [LBT.Newtonsoft.Json.JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json
        public bool Cumulative { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "GenericDataType";
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
            sb.Append("GenericDataType:\n");
            sb.Append("  Name: ").Append(this.Name).Append("\n");
            sb.Append("  BaseUnit: ").Append(this.BaseUnit).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  DataType: ").Append(this.DataType).Append("\n");
            sb.Append("  Min: ").Append(this.Min).Append("\n");
            sb.Append("  Max: ").Append(this.Max).Append("\n");
            sb.Append("  Abbreviation: ").Append(this.Abbreviation).Append("\n");
            sb.Append("  UnitDescr: ").Append(this.UnitDescr).Append("\n");
            sb.Append("  PointInTime: ").Append(this.PointInTime).Append("\n");
            sb.Append("  Cumulative: ").Append(this.Cumulative).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>GenericDataType object</returns>
        public static GenericDataType FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<GenericDataType>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>GenericDataType object</returns>
        public virtual GenericDataType DuplicateGenericDataType()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateGenericDataType();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as GenericDataType);
        }


        /// <summary>
        /// Returns true if GenericDataType instances are equal
        /// </summary>
        /// <param name="input">Instance of GenericDataType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GenericDataType input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Name, input.Name) && 
                    Extension.Equals(this.BaseUnit, input.BaseUnit) && 
                    Extension.Equals(this.DataType, input.DataType) && 
                    Extension.Equals(this.Min, input.Min) && 
                    Extension.Equals(this.Max, input.Max) && 
                    Extension.Equals(this.Abbreviation, input.Abbreviation) && 
                    Extension.Equals(this.UnitDescr, input.UnitDescr) && 
                    Extension.Equals(this.PointInTime, input.PointInTime) && 
                    Extension.Equals(this.Cumulative, input.Cumulative);
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.BaseUnit != null)
                    hashCode = hashCode * 59 + this.BaseUnit.GetHashCode();
                if (this.DataType != null)
                    hashCode = hashCode * 59 + this.DataType.GetHashCode();
                if (this.Min != null)
                    hashCode = hashCode * 59 + this.Min.GetHashCode();
                if (this.Max != null)
                    hashCode = hashCode * 59 + this.Max.GetHashCode();
                if (this.Abbreviation != null)
                    hashCode = hashCode * 59 + this.Abbreviation.GetHashCode();
                if (this.UnitDescr != null)
                    hashCode = hashCode * 59 + this.UnitDescr.GetHashCode();
                if (this.PointInTime != null)
                    hashCode = hashCode * 59 + this.PointInTime.GetHashCode();
                if (this.Cumulative != null)
                    hashCode = hashCode * 59 + this.Cumulative.GetHashCode();
                return hashCode;
            }
        }


    }
}
