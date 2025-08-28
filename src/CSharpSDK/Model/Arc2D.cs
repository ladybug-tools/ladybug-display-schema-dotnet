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
    /// A single arc or circle in 2D space.
    /// </summary>
    [Summary(@"A single arc or circle in 2D space.")]
    [System.Serializable]
    [DataContract(Name = "Arc2D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Arc2D : OpenAPIGenBaseModel, System.IEquatable<Arc2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Arc2D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Arc2D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Arc2D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Arc2D" /> class.
        /// </summary>
        /// <param name="c">Center of the arc as 2 (x, y) values.</param>
        /// <param name="r">A number representing the radius of the arc.</param>
        /// <param name="a1">A number between 0 and 2 * pi for the start angle of the arc.</param>
        /// <param name="a2">A number between 0 and 2 * pi for the end angle of the arc.</param>
        public Arc2D
        (
            List<double> c, double r, double a1 = 0D, double a2 = 6.283185307179586D
        ) : base()
        {
            this.C = c ?? throw new System.ArgumentNullException("c is a required property for Arc2D and cannot be null");
            this.R = r;
            this.A1 = a1;
            this.A2 = a2;

            // Set readonly properties with defaultValue
            this.Type = "Arc2D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Arc2D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Center of the arc as 2 (x, y) values.
        /// </summary>
        [Summary(@"Center of the arc as 2 (x, y) values.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "c", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("c", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("c")] // For System.Text.Json
        public List<double> C { get; set; }

        /// <summary>
        /// A number representing the radius of the arc.
        /// </summary>
        [Summary(@"A number representing the radius of the arc.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "r", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("r", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("r")] // For System.Text.Json
        public double R { get; set; }

        /// <summary>
        /// A number between 0 and 2 * pi for the start angle of the arc.
        /// </summary>
        [Summary(@"A number between 0 and 2 * pi for the start angle of the arc.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 6.283185307179586)]
        [DataMember(Name = "a1")] // For internal Serialization XML/JSON
        [JsonProperty("a1", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("a1")] // For System.Text.Json
        public double A1 { get; set; } = 0D;

        /// <summary>
        /// A number between 0 and 2 * pi for the end angle of the arc.
        /// </summary>
        [Summary(@"A number between 0 and 2 * pi for the end angle of the arc.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [Range(0, 6.283185307179586)]
        [DataMember(Name = "a2")] // For internal Serialization XML/JSON
        [JsonProperty("a2", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("a2")] // For System.Text.Json
        public double A2 { get; set; } = 6.283185307179586D;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Arc2D";
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
            sb.Append("Arc2D:\n");
            sb.Append("  C: ").Append(this.C).Append("\n");
            sb.Append("  R: ").Append(this.R).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  A1: ").Append(this.A1).Append("\n");
            sb.Append("  A2: ").Append(this.A2).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Arc2D object</returns>
        public static Arc2D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Arc2D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Arc2D object</returns>
        public virtual Arc2D DuplicateArc2D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateArc2D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Arc2D);
        }


        /// <summary>
        /// Returns true if Arc2D instances are equal
        /// </summary>
        /// <param name="input">Instance of Arc2D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Arc2D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.C, input.C) && 
                    Extension.Equals(this.R, input.R) && 
                    Extension.Equals(this.A1, input.A1) && 
                    Extension.Equals(this.A2, input.A2);
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
                if (this.C != null)
                    hashCode = hashCode * 59 + this.C.GetHashCode();
                if (this.R != null)
                    hashCode = hashCode * 59 + this.R.GetHashCode();
                if (this.A1 != null)
                    hashCode = hashCode * 59 + this.A1.GetHashCode();
                if (this.A2 != null)
                    hashCode = hashCode * 59 + this.A2.GetHashCode();
                return hashCode;
            }
        }


    }
}
