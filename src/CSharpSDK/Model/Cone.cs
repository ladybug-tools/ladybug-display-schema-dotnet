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
    /// A cone object.
    /// </summary>
    [Summary(@"A cone object.")]
    [System.Serializable]
    [DataContract(Name = "Cone")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Cone : OpenAPIGenBaseModel, System.IEquatable<Cone>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cone" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Cone() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Cone";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Cone" /> class.
        /// </summary>
        /// <param name="vertex">The point at the tip of the cone as 3 (x, y, z) values.</param>
        /// <param name="axis">The vector representing the direction of the cone as 3 (x, y, z) values. The vector extends from the vertex to the center of the base.</param>
        /// <param name="angle">An angle in radians representing the half angle between the axis and the surface.</param>
        public Cone
        (
            List<double> vertex, List<double> axis, double angle
        ) : base()
        {
            this.Vertex = vertex ?? throw new System.ArgumentNullException("vertex is a required property for Cone and cannot be null");
            this.Axis = axis ?? throw new System.ArgumentNullException("axis is a required property for Cone and cannot be null");
            this.Angle = angle;

            // Set readonly properties with defaultValue
            this.Type = "Cone";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Cone))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The point at the tip of the cone as 3 (x, y, z) values.
        /// </summary>
        [Summary(@"The point at the tip of the cone as 3 (x, y, z) values.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "vertex", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("vertex", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("vertex")] // For System.Text.Json
        public List<double> Vertex { get; set; }

        /// <summary>
        /// The vector representing the direction of the cone as 3 (x, y, z) values. The vector extends from the vertex to the center of the base.
        /// </summary>
        [Summary(@"The vector representing the direction of the cone as 3 (x, y, z) values. The vector extends from the vertex to the center of the base.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "axis", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("axis", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("axis")] // For System.Text.Json
        public List<double> Axis { get; set; }

        /// <summary>
        /// An angle in radians representing the half angle between the axis and the surface.
        /// </summary>
        [Summary(@"An angle in radians representing the half angle between the axis and the surface.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "angle", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("angle", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("angle")] // For System.Text.Json
        public double Angle { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Cone";
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
            sb.Append("Cone:\n");
            sb.Append("  Vertex: ").Append(this.Vertex).Append("\n");
            sb.Append("  Axis: ").Append(this.Axis).Append("\n");
            sb.Append("  Angle: ").Append(this.Angle).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Cone object</returns>
        public static Cone FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Cone>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Cone object</returns>
        public virtual Cone DuplicateCone()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateCone();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Cone);
        }


        /// <summary>
        /// Returns true if Cone instances are equal
        /// </summary>
        /// <param name="input">Instance of Cone to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Cone input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Vertex, input.Vertex) && 
                    Extension.AllEquals(this.Axis, input.Axis) && 
                    Extension.Equals(this.Angle, input.Angle);
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
                if (this.Vertex != null)
                    hashCode = hashCode * 59 + this.Vertex.GetHashCode();
                if (this.Axis != null)
                    hashCode = hashCode * 59 + this.Axis.GetHashCode();
                if (this.Angle != null)
                    hashCode = hashCode * 59 + this.Angle.GetHashCode();
                return hashCode;
            }
        }


    }
}
