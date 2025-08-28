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
    /// A single line segment face in 3D space.
    /// </summary>
    [Summary(@"A single line segment face in 3D space.")]
    [System.Serializable]
    [DataContract(Name = "LineSegment3D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class LineSegment3D : OpenAPIGenBaseModel, System.IEquatable<LineSegment3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegment3D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected LineSegment3D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "LineSegment3D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegment3D" /> class.
        /// </summary>
        /// <param name="p">Line segment base point as 3 (x, y, z) values.</param>
        /// <param name="v">Line segment direction vector as 3 (x, y, z) values.</param>
        public LineSegment3D
        (
            List<double> p, List<double> v
        ) : base()
        {
            this.P = p ?? throw new System.ArgumentNullException("p is a required property for LineSegment3D and cannot be null");
            this.V = v ?? throw new System.ArgumentNullException("v is a required property for LineSegment3D and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "LineSegment3D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(LineSegment3D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Line segment base point as 3 (x, y, z) values.
        /// </summary>
        [Summary(@"Line segment base point as 3 (x, y, z) values.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "p", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("p", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("p")] // For System.Text.Json
        public List<double> P { get; set; }

        /// <summary>
        /// Line segment direction vector as 3 (x, y, z) values.
        /// </summary>
        [Summary(@"Line segment direction vector as 3 (x, y, z) values.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "v", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("v", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("v")] // For System.Text.Json
        public List<double> V { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "LineSegment3D";
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
            sb.Append("LineSegment3D:\n");
            sb.Append("  P: ").Append(this.P).Append("\n");
            sb.Append("  V: ").Append(this.V).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>LineSegment3D object</returns>
        public static LineSegment3D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<LineSegment3D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>LineSegment3D object</returns>
        public virtual LineSegment3D DuplicateLineSegment3D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateLineSegment3D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as LineSegment3D);
        }


        /// <summary>
        /// Returns true if LineSegment3D instances are equal
        /// </summary>
        /// <param name="input">Instance of LineSegment3D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LineSegment3D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.P, input.P) && 
                    Extension.AllEquals(this.V, input.V);
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
                if (this.P != null)
                    hashCode = hashCode * 59 + this.P.GetHashCode();
                if (this.V != null)
                    hashCode = hashCode * 59 + this.V.GetHashCode();
                return hashCode;
            }
        }


    }
}
