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
    /// A vector object in 3D space.
    /// </summary>
    [Summary(@"A vector object in 3D space.")]
    [System.Serializable]
    [DataContract(Name = "Vector3D")]
    public partial class Vector3D : OpenAPIGenBaseModel, System.IEquatable<Vector3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Vector3D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Vector3D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3D" /> class.
        /// </summary>
        /// <param name="x">Number for X coordinate.</param>
        /// <param name="y">Number for Y coordinate.</param>
        /// <param name="z">Number for Z coordinate.</param>
        public Vector3D
        (
            double x, double y, double z
        ) : base()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

            // Set readonly properties with defaultValue
            this.Type = "Vector3D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Vector3D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// Number for X coordinate.
        /// </summary>
        [Summary(@"Number for X coordinate.")]
        [Required]
        [DataMember(Name = "x", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("x")] // For System.Text.Json
        public double X { get; set; }

        /// <summary>
        /// Number for Y coordinate.
        /// </summary>
        [Summary(@"Number for Y coordinate.")]
        [Required]
        [DataMember(Name = "y", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("y")] // For System.Text.Json
        public double Y { get; set; }

        /// <summary>
        /// Number for Z coordinate.
        /// </summary>
        [Summary(@"Number for Z coordinate.")]
        [Required]
        [DataMember(Name = "z", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("z")] // For System.Text.Json
        public double Z { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Vector3D";
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
            sb.Append("Vector3D:\n");
            sb.Append("  X: ").Append(this.X).Append("\n");
            sb.Append("  Y: ").Append(this.Y).Append("\n");
            sb.Append("  Z: ").Append(this.Z).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Vector3D object</returns>
        public static Vector3D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Vector3D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Vector3D object</returns>
        public virtual Vector3D DuplicateVector3D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateVector3D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Vector3D);
        }


        /// <summary>
        /// Returns true if Vector3D instances are equal
        /// </summary>
        /// <param name="input">Instance of Vector3D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Vector3D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.X, input.X) && 
                    Extension.Equals(this.Y, input.Y) && 
                    Extension.Equals(this.Z, input.Z);
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
                if (this.X != null)
                    hashCode = hashCode * 59 + this.X.GetHashCode();
                if (this.Y != null)
                    hashCode = hashCode * 59 + this.Y.GetHashCode();
                if (this.Z != null)
                    hashCode = hashCode * 59 + this.Z.GetHashCode();
                return hashCode;
            }
        }


    }
}
