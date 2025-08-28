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
    /// A polyline in 2D space.
    /// </summary>
    [Summary(@"A polyline in 2D space.")]
    [System.Serializable]
    [DataContract(Name = "Polyline2D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Polyline2D : OpenAPIGenBaseModel, System.IEquatable<Polyline2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polyline2D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Polyline2D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Polyline2D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Polyline2D" /> class.
        /// </summary>
        /// <param name="vertices">A list of points representing the the vertices of the polyline. The list should include at least 3 points and each point should be a list of 2 (x, y) values.</param>
        /// <param name="interpolated">A boolean to note whether the polyline should be interpolated between the input vertices when it is translated to other interfaces.</param>
        public Polyline2D
        (
            List<List<double>> vertices, bool interpolated = false
        ) : base()
        {
            this.Vertices = vertices ?? throw new System.ArgumentNullException("vertices is a required property for Polyline2D and cannot be null");
            this.Interpolated = interpolated;

            // Set readonly properties with defaultValue
            this.Type = "Polyline2D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Polyline2D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of points representing the the vertices of the polyline. The list should include at least 3 points and each point should be a list of 2 (x, y) values.
        /// </summary>
        [Summary(@"A list of points representing the the vertices of the polyline. The list should include at least 3 points and each point should be a list of 2 (x, y) values.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "vertices", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("vertices", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("vertices")] // For System.Text.Json
        public List<List<double>> Vertices { get; set; }

        /// <summary>
        /// A boolean to note whether the polyline should be interpolated between the input vertices when it is translated to other interfaces.
        /// </summary>
        [Summary(@"A boolean to note whether the polyline should be interpolated between the input vertices when it is translated to other interfaces.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "interpolated")] // For internal Serialization XML/JSON
        [JsonProperty("interpolated", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("interpolated")] // For System.Text.Json
        public bool Interpolated { get; set; } = false;


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Polyline2D";
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
            sb.Append("Polyline2D:\n");
            sb.Append("  Vertices: ").Append(this.Vertices).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  Interpolated: ").Append(this.Interpolated).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Polyline2D object</returns>
        public static Polyline2D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Polyline2D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Polyline2D object</returns>
        public virtual Polyline2D DuplicatePolyline2D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicatePolyline2D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Polyline2D);
        }


        /// <summary>
        /// Returns true if Polyline2D instances are equal
        /// </summary>
        /// <param name="input">Instance of Polyline2D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Polyline2D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Vertices, input.Vertices) && 
                    Extension.Equals(this.Interpolated, input.Interpolated);
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
                if (this.Vertices != null)
                    hashCode = hashCode * 59 + this.Vertices.GetHashCode();
                if (this.Interpolated != null)
                    hashCode = hashCode * 59 + this.Interpolated.GetHashCode();
                return hashCode;
            }
        }


    }
}
