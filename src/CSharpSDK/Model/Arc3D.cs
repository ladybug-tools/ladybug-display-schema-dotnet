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
    /// A single arc or circle in 3D space.
    /// </summary>
    [Summary(@"A single arc or circle in 3D space.")]
    [System.Serializable]
    [DataContract(Name = "Arc3D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Arc3D : OpenAPIGenBaseModel, System.IEquatable<Arc3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Arc3D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Arc3D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Arc3D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Arc3D" /> class.
        /// </summary>
        /// <param name="plane">A Plane in which the arc lies with an origin representing the center of the circle for the arc.</param>
        /// <param name="radius">A number representing the radius of the arc.</param>
        /// <param name="a1">A number between 0 and 2 * pi for the start angle of the arc.</param>
        /// <param name="a2">A number between 0 and 2 * pi for the end angle of the arc.</param>
        public Arc3D
        (
            Plane plane, double radius, double a1 = 0D, double a2 = 6.283185307179586D
        ) : base()
        {
            this.Plane = plane ?? throw new System.ArgumentNullException("plane is a required property for Arc3D and cannot be null");
            this.Radius = radius;
            this.A1 = a1;
            this.A2 = a2;

            // Set readonly properties with defaultValue
            this.Type = "Arc3D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Arc3D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A Plane in which the arc lies with an origin representing the center of the circle for the arc.
        /// </summary>
        [Summary(@"A Plane in which the arc lies with an origin representing the center of the circle for the arc.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "plane", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("plane", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("plane")] // For System.Text.Json
        public Plane Plane { get; set; }

        /// <summary>
        /// A number representing the radius of the arc.
        /// </summary>
        [Summary(@"A number representing the radius of the arc.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "radius", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("radius", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("radius")] // For System.Text.Json
        public double Radius { get; set; }

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
            return "Arc3D";
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
            sb.Append("Arc3D:\n");
            sb.Append("  Plane: ").Append(this.Plane).Append("\n");
            sb.Append("  Radius: ").Append(this.Radius).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  A1: ").Append(this.A1).Append("\n");
            sb.Append("  A2: ").Append(this.A2).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Arc3D object</returns>
        public static Arc3D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Arc3D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Arc3D object</returns>
        public virtual Arc3D DuplicateArc3D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateArc3D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Arc3D);
        }


        /// <summary>
        /// Returns true if Arc3D instances are equal
        /// </summary>
        /// <param name="input">Instance of Arc3D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Arc3D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.Plane, input.Plane) && 
                    Extension.Equals(this.Radius, input.Radius) && 
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
                if (this.Plane != null)
                    hashCode = hashCode * 59 + this.Plane.GetHashCode();
                if (this.Radius != null)
                    hashCode = hashCode * 59 + this.Radius.GetHashCode();
                if (this.A1 != null)
                    hashCode = hashCode * 59 + this.A1.GetHashCode();
                if (this.A2 != null)
                    hashCode = hashCode * 59 + this.A2.GetHashCode();
                return hashCode;
            }
        }


    }
}
