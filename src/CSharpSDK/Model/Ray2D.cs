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
    /// A ray object in 2D space.
    /// </summary>
    [Summary(@"A ray object in 2D space.")]
    [System.Serializable]
    [DataContract(Name = "Ray2D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Ray2D : OpenAPIGenBaseModel, System.IEquatable<Ray2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ray2D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Ray2D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Ray2D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Ray2D" /> class.
        /// </summary>
        /// <param name="p">Ray base point as 2 (x, y) values.</param>
        /// <param name="v">Ray direction vector as 2 (x, y) values.</param>
        public Ray2D
        (
            List<double> p, List<double> v
        ) : base()
        {
            this.P = p ?? throw new System.ArgumentNullException("p is a required property for Ray2D and cannot be null");
            this.V = v ?? throw new System.ArgumentNullException("v is a required property for Ray2D and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "Ray2D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Ray2D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Ray base point as 2 (x, y) values.
        /// </summary>
        [Summary(@"Ray base point as 2 (x, y) values.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "p", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("p", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("p")] // For System.Text.Json
        public List<double> P { get; set; }

        /// <summary>
        /// Ray direction vector as 2 (x, y) values.
        /// </summary>
        [Summary(@"Ray direction vector as 2 (x, y) values.")]
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
            return "Ray2D";
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
            sb.Append("Ray2D:\n");
            sb.Append("  P: ").Append(this.P).Append("\n");
            sb.Append("  V: ").Append(this.V).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Ray2D object</returns>
        public static Ray2D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Ray2D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Ray2D object</returns>
        public virtual Ray2D DuplicateRay2D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateRay2D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Ray2D);
        }


        /// <summary>
        /// Returns true if Ray2D instances are equal
        /// </summary>
        /// <param name="input">Instance of Ray2D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Ray2D input)
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
