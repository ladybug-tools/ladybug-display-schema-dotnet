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
    /// A sphere object.
    /// </summary>
    [Summary(@"A sphere object.")]
    [System.Serializable]
    [DataContract(Name = "Sphere")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Sphere : OpenAPIGenBaseModel, System.IEquatable<Sphere>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sphere" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Sphere() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Sphere";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Sphere" /> class.
        /// </summary>
        /// <param name="center">The center of the sphere as 3 (x, y, z) values.</param>
        /// <param name="radius">A number representing the radius of the sphere.</param>
        public Sphere
        (
            List<double> center, double radius
        ) : base()
        {
            this.Center = center ?? throw new System.ArgumentNullException("center is a required property for Sphere and cannot be null");
            this.Radius = radius;

            // Set readonly properties with defaultValue
            this.Type = "Sphere";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Sphere))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The center of the sphere as 3 (x, y, z) values.
        /// </summary>
        [Summary(@"The center of the sphere as 3 (x, y, z) values.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "center", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("center", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("center")] // For System.Text.Json
        public List<double> Center { get; set; }

        /// <summary>
        /// A number representing the radius of the sphere.
        /// </summary>
        [Summary(@"A number representing the radius of the sphere.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "radius", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("radius", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("radius")] // For System.Text.Json
        public double Radius { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Sphere";
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
            sb.Append("Sphere:\n");
            sb.Append("  Center: ").Append(this.Center).Append("\n");
            sb.Append("  Radius: ").Append(this.Radius).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Sphere object</returns>
        public static Sphere FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Sphere>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Sphere object</returns>
        public virtual Sphere DuplicateSphere()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateSphere();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Sphere);
        }


        /// <summary>
        /// Returns true if Sphere instances are equal
        /// </summary>
        /// <param name="input">Instance of Sphere to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Sphere input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Center, input.Center) && 
                    Extension.Equals(this.Radius, input.Radius);
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
                if (this.Center != null)
                    hashCode = hashCode * 59 + this.Center.GetHashCode();
                if (this.Radius != null)
                    hashCode = hashCode * 59 + this.Radius.GetHashCode();
                return hashCode;
            }
        }


    }
}
