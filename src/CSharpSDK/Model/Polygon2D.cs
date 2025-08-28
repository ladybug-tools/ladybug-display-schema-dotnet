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
    /// A polygon in 2D space (without holes).
    /// </summary>
    [Summary(@"A polygon in 2D space (without holes).")]
    [System.Serializable]
    [DataContract(Name = "Polygon2D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Polygon2D : OpenAPIGenBaseModel, System.IEquatable<Polygon2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon2D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Polygon2D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Polygon2D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon2D" /> class.
        /// </summary>
        /// <param name="vertices">A list of points representing the vertices of the polygon. The list should include at least 3 points and each point should be a list of 2 (x, y) values.</param>
        public Polygon2D
        (
            List<List<double>> vertices
        ) : base()
        {
            this.Vertices = vertices ?? throw new System.ArgumentNullException("vertices is a required property for Polygon2D and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "Polygon2D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Polygon2D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of points representing the vertices of the polygon. The list should include at least 3 points and each point should be a list of 2 (x, y) values.
        /// </summary>
        [Summary(@"A list of points representing the vertices of the polygon. The list should include at least 3 points and each point should be a list of 2 (x, y) values.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "vertices", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("vertices", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("vertices")] // For System.Text.Json
        public List<List<double>> Vertices { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Polygon2D";
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
            sb.Append("Polygon2D:\n");
            sb.Append("  Vertices: ").Append(this.Vertices).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Polygon2D object</returns>
        public static Polygon2D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Polygon2D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Polygon2D object</returns>
        public virtual Polygon2D DuplicatePolygon2D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicatePolygon2D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Polygon2D);
        }


        /// <summary>
        /// Returns true if Polygon2D instances are equal
        /// </summary>
        /// <param name="input">Instance of Polygon2D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Polygon2D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Vertices, input.Vertices);
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
                return hashCode;
            }
        }


    }
}
