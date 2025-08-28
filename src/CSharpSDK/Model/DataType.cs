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
    /// Data type representation.
    /// </summary>
    [Summary(@"Data type representation.")]
    [System.Serializable]
    [DataContract(Name = "DataType")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class DataType : OpenAPIGenBaseModel, System.IEquatable<DataType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="_DataType" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected DataType()
        {
            // Set readonly properties with defaultValue
            this.Type = "DataType";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="_DataType" /> class.
        /// </summary>
        /// <param name="dataType">Text to indicate the type of data. This governs the behavior of the data type and the acceptable units. The DataTypes enumeration contains all acceptable types.</param>
        /// <param name="name">Text to indicate how the data type displays. This can be more specific than the data_type.</param>
        public DataType
        (
            DataTypes dataType, string name
        ) : base()
        {
            this._DataType = dataType;
            this.Name = name ?? throw new System.ArgumentNullException("name is a required property for DataType and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "DataType";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(DataType))
                this.IsValid(throwException: true);
        }



        /// <summary>
        /// Text to indicate the type of data. This governs the behavior of the data type and the acceptable units. The DataTypes enumeration contains all acceptable types.
        /// </summary>
        [Summary(@"Text to indicate the type of data. This governs the behavior of the data type and the acceptable units. The DataTypes enumeration contains all acceptable types.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "data_type", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("data_type", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("data_type")] // For System.Text.Json
        public DataTypes _DataType { get; set; }

        /// <summary>
        /// Text to indicate how the data type displays. This can be more specific than the data_type.
        /// </summary>
        [Summary(@"Text to indicate how the data type displays. This can be more specific than the data_type.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "name", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("name", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("name")] // For System.Text.Json
        public string Name { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "DataType";
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
            sb.Append("DataType:\n");
            sb.Append("  DataType: ").Append(this._DataType).Append("\n");
            sb.Append("  Name: ").Append(this.Name).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>DataType object</returns>
        public static DataType FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<DataType>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>DataType object</returns>
        public virtual DataType DuplicateDataType()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateDataType();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as DataType);
        }


        /// <summary>
        /// Returns true if DataType instances are equal
        /// </summary>
        /// <param name="input">Instance of DataType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DataType input)
        {
            if (input == null)
                return false;
            return base.Equals(input) &&
                    Extension.Equals(this._DataType, input._DataType) &&
                    Extension.Equals(this.Name, input.Name);
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
                if (this._DataType != null)
                    hashCode = hashCode * 59 + this._DataType.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                return hashCode;
            }
        }


    }
}
