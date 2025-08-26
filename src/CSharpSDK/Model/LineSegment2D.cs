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
    /// A single line segment face in 2D space.
    /// </summary>
    [Summary(@"A single line segment face in 2D space.")]
    [System.Serializable]
    [DataContract(Name = "LineSegment2D")]
    public partial class LineSegment2D : OpenAPIGenBaseModel, System.IEquatable<LineSegment2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegment2D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected LineSegment2D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "LineSegment2D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegment2D" /> class.
        /// </summary>
        /// <param name="p">Line segment base point as 2 (x, y) values.</param>
        /// <param name="v">Line segment direction vector as 2 (x, y) values.</param>
        public LineSegment2D
        (
            List<double> p, List<double> v
        ) : base()
        {
            this.P = p ?? throw new System.ArgumentNullException("p is a required property for LineSegment2D and cannot be null");
            this.V = v ?? throw new System.ArgumentNullException("v is a required property for LineSegment2D and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "LineSegment2D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(LineSegment2D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Line segment base point as 2 (x, y) values.
        /// </summary>
        [Summary(@"Line segment base point as 2 (x, y) values.")]
        [Required]
        [DataMember(Name = "p", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("p")] // For System.Text.Json
        public List<double> P { get; set; }

        /// <summary>
        /// Line segment direction vector as 2 (x, y) values.
        /// </summary>
        [Summary(@"Line segment direction vector as 2 (x, y) values.")]
        [Required]
        [DataMember(Name = "v", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("v")] // For System.Text.Json
        public List<double> V { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "LineSegment2D";
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
            sb.Append("LineSegment2D:\n");
            sb.Append("  P: ").Append(this.P).Append("\n");
            sb.Append("  V: ").Append(this.V).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>LineSegment2D object</returns>
        public static LineSegment2D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<LineSegment2D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>LineSegment2D object</returns>
        public virtual LineSegment2D DuplicateLineSegment2D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateLineSegment2D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as LineSegment2D);
        }


        /// <summary>
        /// Returns true if LineSegment2D instances are equal
        /// </summary>
        /// <param name="input">Instance of LineSegment2D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LineSegment2D input)
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
