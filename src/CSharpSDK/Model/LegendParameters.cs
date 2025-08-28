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
    /// Legend parameters used to customize legends.
    /// </summary>
    [Summary(@"Legend parameters used to customize legends.")]
    [System.Serializable]
    [DataContract(Name = "LegendParameters")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class LegendParameters : OpenAPIGenBaseModel, System.IEquatable<LegendParameters>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegendParameters" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected LegendParameters() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "LegendParameters";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LegendParameters" /> class.
        /// </summary>
        /// <param name="min">A number to set the lower boundary of the legend. If Default, the minimum of the values associated with the legend will be used.</param>
        /// <param name="max">A number to set the upper boundary of the legend. If Default, the maximum of the values associated with the legend will be used.</param>
        /// <param name="segmentCount">An integer representing the number of steps between the high and low boundary of the legend. The default is set to 11 or it will be equal to the number of items in the ordinal_dictionary. Any custom values input in here should always be greater than or equal to 1.</param>
        /// <param name="colors">An list of color objects. Default is the Ladybug original colorset.</param>
        /// <param name="title">Text string for Legend title. Typically, the units of the data are used here but the type of data might also be used.</param>
        /// <param name="continuousLegend">Boolean noting whether legend is drawn as a gradient or discrete segments.</param>
        /// <param name="ordinalDictionary">Optional dictionary that maps values to text categories. If None, numerical values will be used for the legend segments. If not, text categories will be used and the legend will be ordinal. Note that, if the number of items in the dictionary are less than the segment_count, some segments will not receive any label. Examples for possible dictionaries include: {-1: ""Cold"", 0: ""Neutral"", 1: ""Hot""}, {0: ""False"", 1: ""True""}</param>
        /// <param name="decimalCount">An an integer for the number of decimal places in the legend text. Note that this input has no bearing on the resulting legend text when an ordinal_dictionary is present.</param>
        /// <param name="includeLargerSmaller">Boolean noting whether > and < should be included in legend segment text.</param>
        /// <param name="vertical">Boolean noting whether legend is vertical (True) or horizontal (False).</param>
        /// <param name="font">Text string to set the font for the legend text. Examples include ""Arial"", ""Times New Roman"", ""Courier"". Note that this parameter may not have an effect on certain interfaces that have limited access to fonts.</param>
        /// <param name="properties3d">A Legend3DParameters object to specify the dimensional properties of the legend when it is rendered in the 3D environment of the geometry scene.</param>
        /// <param name="properties2d">A Legend2DParameters object to specify the dimensional properties of the legend when it is rendered in the 2D plane of a screen.</param>
        /// <param name="userData">Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list).</param>
        public LegendParameters
        (
            AnyOf<Default, double> min = default, AnyOf<Default, double> max = default, AnyOf<Default, int> segmentCount = default, List<Color> colors = default, string title = "", bool continuousLegend = false, object ordinalDictionary = default, int decimalCount = 2, bool includeLargerSmaller = false, bool vertical = true, string font = "Arial", Legend3DParameters properties3d = default, Legend2DParameters properties2d = default, object userData = default
        ) : base()
        {
            this.Min = min ?? new Default();
            this.Max = max ?? new Default();
            this.SegmentCount = segmentCount ?? new Default();
            this.Colors = colors;
            this.Title = title ?? "";
            this.ContinuousLegend = continuousLegend;
            this.OrdinalDictionary = ordinalDictionary;
            this.DecimalCount = decimalCount;
            this.IncludeLargerSmaller = includeLargerSmaller;
            this.Vertical = vertical;
            this.Font = font ?? "Arial";
            this.Properties3d = properties3d;
            this.Properties2d = properties2d;
            this.UserData = userData;

            // Set readonly properties with defaultValue
            this.Type = "LegendParameters";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(LegendParameters))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A number to set the lower boundary of the legend. If Default, the minimum of the values associated with the legend will be used.
        /// </summary>
        [Summary(@"A number to set the lower boundary of the legend. If Default, the minimum of the values associated with the legend will be used.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "min")] // For internal Serialization XML/JSON
        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("min")] // For System.Text.Json
        public AnyOf<Default, double> Min { get; set; } = new Default();

        /// <summary>
        /// A number to set the upper boundary of the legend. If Default, the maximum of the values associated with the legend will be used.
        /// </summary>
        [Summary(@"A number to set the upper boundary of the legend. If Default, the maximum of the values associated with the legend will be used.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "max")] // For internal Serialization XML/JSON
        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("max")] // For System.Text.Json
        public AnyOf<Default, double> Max { get; set; } = new Default();

        /// <summary>
        /// An integer representing the number of steps between the high and low boundary of the legend. The default is set to 11 or it will be equal to the number of items in the ordinal_dictionary. Any custom values input in here should always be greater than or equal to 1.
        /// </summary>
        [Summary(@"An integer representing the number of steps between the high and low boundary of the legend. The default is set to 11 or it will be equal to the number of items in the ordinal_dictionary. Any custom values input in here should always be greater than or equal to 1.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "segment_count")] // For internal Serialization XML/JSON
        [JsonProperty("segment_count", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("segment_count")] // For System.Text.Json
        public AnyOf<Default, int> SegmentCount { get; set; } = new Default();

        /// <summary>
        /// An list of color objects. Default is the Ladybug original colorset.
        /// </summary>
        [Summary(@"An list of color objects. Default is the Ladybug original colorset.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "colors")] // For internal Serialization XML/JSON
        [JsonProperty("colors", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("colors")] // For System.Text.Json
        public List<Color> Colors { get; set; }

        /// <summary>
        /// Text string for Legend title. Typically, the units of the data are used here but the type of data might also be used.
        /// </summary>
        [Summary(@"Text string for Legend title. Typically, the units of the data are used here but the type of data might also be used.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "title")] // For internal Serialization XML/JSON
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("title")] // For System.Text.Json
        public string Title { get; set; } = "";

        /// <summary>
        /// Boolean noting whether legend is drawn as a gradient or discrete segments.
        /// </summary>
        [Summary(@"Boolean noting whether legend is drawn as a gradient or discrete segments.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "continuous_legend")] // For internal Serialization XML/JSON
        [JsonProperty("continuous_legend", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("continuous_legend")] // For System.Text.Json
        public bool ContinuousLegend { get; set; } = false;

        /// <summary>
        /// Optional dictionary that maps values to text categories. If None, numerical values will be used for the legend segments. If not, text categories will be used and the legend will be ordinal. Note that, if the number of items in the dictionary are less than the segment_count, some segments will not receive any label. Examples for possible dictionaries include: {-1: ""Cold"", 0: ""Neutral"", 1: ""Hot""}, {0: ""False"", 1: ""True""}
        /// </summary>
        [Summary(@"Optional dictionary that maps values to text categories. If None, numerical values will be used for the legend segments. If not, text categories will be used and the legend will be ordinal. Note that, if the number of items in the dictionary are less than the segment_count, some segments will not receive any label. Examples for possible dictionaries include: {-1: ""Cold"", 0: ""Neutral"", 1: ""Hot""}, {0: ""False"", 1: ""True""}")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "ordinal_dictionary")] // For internal Serialization XML/JSON
        [JsonProperty("ordinal_dictionary", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("ordinal_dictionary")] // For System.Text.Json
        public object OrdinalDictionary { get; set; }

        /// <summary>
        /// An an integer for the number of decimal places in the legend text. Note that this input has no bearing on the resulting legend text when an ordinal_dictionary is present.
        /// </summary>
        [Summary(@"An an integer for the number of decimal places in the legend text. Note that this input has no bearing on the resulting legend text when an ordinal_dictionary is present.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, int.MaxValue)]
        [DataMember(Name = "decimal_count")] // For internal Serialization XML/JSON
        [JsonProperty("decimal_count", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("decimal_count")] // For System.Text.Json
        public int DecimalCount { get; set; } = 2;

        /// <summary>
        /// Boolean noting whether > and < should be included in legend segment text.
        /// </summary>
        [Summary(@"Boolean noting whether > and < should be included in legend segment text.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "include_larger_smaller")] // For internal Serialization XML/JSON
        [JsonProperty("include_larger_smaller", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("include_larger_smaller")] // For System.Text.Json
        public bool IncludeLargerSmaller { get; set; } = false;

        /// <summary>
        /// Boolean noting whether legend is vertical (True) or horizontal (False).
        /// </summary>
        [Summary(@"Boolean noting whether legend is vertical (True) or horizontal (False).")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "vertical")] // For internal Serialization XML/JSON
        [JsonProperty("vertical", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("vertical")] // For System.Text.Json
        public bool Vertical { get; set; } = true;

        /// <summary>
        /// Text string to set the font for the legend text. Examples include ""Arial"", ""Times New Roman"", ""Courier"". Note that this parameter may not have an effect on certain interfaces that have limited access to fonts.
        /// </summary>
        [Summary(@"Text string to set the font for the legend text. Examples include ""Arial"", ""Times New Roman"", ""Courier"". Note that this parameter may not have an effect on certain interfaces that have limited access to fonts.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "font")] // For internal Serialization XML/JSON
        [JsonProperty("font", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("font")] // For System.Text.Json
        public string Font { get; set; } = "Arial";

        /// <summary>
        /// A Legend3DParameters object to specify the dimensional properties of the legend when it is rendered in the 3D environment of the geometry scene.
        /// </summary>
        [Summary(@"A Legend3DParameters object to specify the dimensional properties of the legend when it is rendered in the 3D environment of the geometry scene.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "properties_3d")] // For internal Serialization XML/JSON
        [JsonProperty("properties_3d", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("properties_3d")] // For System.Text.Json
        public Legend3DParameters Properties3d { get; set; }

        /// <summary>
        /// A Legend2DParameters object to specify the dimensional properties of the legend when it is rendered in the 2D plane of a screen.
        /// </summary>
        [Summary(@"A Legend2DParameters object to specify the dimensional properties of the legend when it is rendered in the 2D plane of a screen.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "properties_2d")] // For internal Serialization XML/JSON
        [JsonProperty("properties_2d", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("properties_2d")] // For System.Text.Json
        public Legend2DParameters Properties2d { get; set; }

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
            return "LegendParameters";
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
            sb.Append("LegendParameters:\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Min: ").Append(this.Min).Append("\n");
            sb.Append("  Max: ").Append(this.Max).Append("\n");
            sb.Append("  SegmentCount: ").Append(this.SegmentCount).Append("\n");
            sb.Append("  Colors: ").Append(this.Colors).Append("\n");
            sb.Append("  Title: ").Append(this.Title).Append("\n");
            sb.Append("  ContinuousLegend: ").Append(this.ContinuousLegend).Append("\n");
            sb.Append("  OrdinalDictionary: ").Append(this.OrdinalDictionary).Append("\n");
            sb.Append("  DecimalCount: ").Append(this.DecimalCount).Append("\n");
            sb.Append("  IncludeLargerSmaller: ").Append(this.IncludeLargerSmaller).Append("\n");
            sb.Append("  Vertical: ").Append(this.Vertical).Append("\n");
            sb.Append("  Font: ").Append(this.Font).Append("\n");
            sb.Append("  Properties3d: ").Append(this.Properties3d).Append("\n");
            sb.Append("  Properties2d: ").Append(this.Properties2d).Append("\n");
            sb.Append("  UserData: ").Append(this.UserData).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>LegendParameters object</returns>
        public static LegendParameters FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<LegendParameters>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>LegendParameters object</returns>
        public virtual LegendParameters DuplicateLegendParameters()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateLegendParameters();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as LegendParameters);
        }


        /// <summary>
        /// Returns true if LegendParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of LegendParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LegendParameters input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Min, input.Min) && 
                    Extension.Equals(this.Max, input.Max) && 
                    Extension.Equals(this.SegmentCount, input.SegmentCount) && 
                    Extension.AllEquals(this.Colors, input.Colors) && 
                    Extension.Equals(this.Title, input.Title) && 
                    Extension.Equals(this.ContinuousLegend, input.ContinuousLegend) && 
                    Extension.Equals(this.OrdinalDictionary, input.OrdinalDictionary) && 
                    Extension.Equals(this.DecimalCount, input.DecimalCount) && 
                    Extension.Equals(this.IncludeLargerSmaller, input.IncludeLargerSmaller) && 
                    Extension.Equals(this.Vertical, input.Vertical) && 
                    Extension.Equals(this.Font, input.Font) && 
                    Extension.Equals(this.Properties3d, input.Properties3d) && 
                    Extension.Equals(this.Properties2d, input.Properties2d) && 
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
                if (this.Min != null)
                    hashCode = hashCode * 59 + this.Min.GetHashCode();
                if (this.Max != null)
                    hashCode = hashCode * 59 + this.Max.GetHashCode();
                if (this.SegmentCount != null)
                    hashCode = hashCode * 59 + this.SegmentCount.GetHashCode();
                if (this.Colors != null)
                    hashCode = hashCode * 59 + this.Colors.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.ContinuousLegend != null)
                    hashCode = hashCode * 59 + this.ContinuousLegend.GetHashCode();
                if (this.OrdinalDictionary != null)
                    hashCode = hashCode * 59 + this.OrdinalDictionary.GetHashCode();
                if (this.DecimalCount != null)
                    hashCode = hashCode * 59 + this.DecimalCount.GetHashCode();
                if (this.IncludeLargerSmaller != null)
                    hashCode = hashCode * 59 + this.IncludeLargerSmaller.GetHashCode();
                if (this.Vertical != null)
                    hashCode = hashCode * 59 + this.Vertical.GetHashCode();
                if (this.Font != null)
                    hashCode = hashCode * 59 + this.Font.GetHashCode();
                if (this.Properties3d != null)
                    hashCode = hashCode * 59 + this.Properties3d.GetHashCode();
                if (this.Properties2d != null)
                    hashCode = hashCode * 59 + this.Properties2d.GetHashCode();
                if (this.UserData != null)
                    hashCode = hashCode * 59 + this.UserData.GetHashCode();
                return hashCode;
            }
        }


    }
}
