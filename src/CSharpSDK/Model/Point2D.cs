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
    /// A point object in 2D space.
    /// </summary>
    [Summary(@"A point object in 2D space.")]
    [System.Serializable]
    [DataContract(Name = "Point2D")]
    public partial class Point2D : OpenAPIGenBaseModel, System.IEquatable<Point2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Point2D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Point2D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D" /> class.
        /// </summary>
        /// <param name="x">Number for X coordinate.</param>
        /// <param name="y">Number for Y coordinate.</param>
        public Point2D
        (
            double x, double y
        ) : base()
        {
            this.X = x;
            this.Y = y;

            // Set readonly properties with defaultValue
            this.Type = "Point2D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Point2D))
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Point2D";
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
            sb.Append("Point2D:\n");
            sb.Append("  X: ").Append(this.X).Append("\n");
            sb.Append("  Y: ").Append(this.Y).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Point2D object</returns>
        public static Point2D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Point2D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Point2D object</returns>
        public virtual Point2D DuplicatePoint2D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicatePoint2D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Point2D);
        }


        /// <summary>
        /// Returns true if Point2D instances are equal
        /// </summary>
        /// <param name="input">Instance of Point2D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Point2D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.Equals(this.X, input.X) && 
                    Extension.Equals(this.Y, input.Y);
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
                return hashCode;
            }
        }


    }
}
