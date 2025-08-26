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
    /// A cylinder object.
    /// </summary>
    [Summary(@"A cylinder object.")]
    [System.Serializable]
    [DataContract(Name = "Cylinder")]
    public partial class Cylinder : OpenAPIGenBaseModel, System.IEquatable<Cylinder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cylinder" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Cylinder() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Cylinder";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Cylinder" /> class.
        /// </summary>
        /// <param name="center">The center of the bottom base of the cylinder as 3 (x, y, z) values.</param>
        /// <param name="axis">The vector representing the direction of the cylinder as 3 (x, y, z) values. The vector extends from the bottom base center to the top base center.</param>
        /// <param name="radius">A number representing the radius of the cylinder.</param>
        public Cylinder
        (
            List<double> center, List<double> axis, double radius
        ) : base()
        {
            this.Center = center ?? throw new System.ArgumentNullException("center is a required property for Cylinder and cannot be null");
            this.Axis = axis ?? throw new System.ArgumentNullException("axis is a required property for Cylinder and cannot be null");
            this.Radius = radius;

            // Set readonly properties with defaultValue
            this.Type = "Cylinder";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Cylinder))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// The center of the bottom base of the cylinder as 3 (x, y, z) values.
        /// </summary>
        [Summary(@"The center of the bottom base of the cylinder as 3 (x, y, z) values.")]
        [Required]
        [DataMember(Name = "center", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("center")] // For System.Text.Json
        public List<double> Center { get; set; }

        /// <summary>
        /// The vector representing the direction of the cylinder as 3 (x, y, z) values. The vector extends from the bottom base center to the top base center.
        /// </summary>
        [Summary(@"The vector representing the direction of the cylinder as 3 (x, y, z) values. The vector extends from the bottom base center to the top base center.")]
        [Required]
        [DataMember(Name = "axis", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("axis")] // For System.Text.Json
        public List<double> Axis { get; set; }

        /// <summary>
        /// A number representing the radius of the cylinder.
        /// </summary>
        [Summary(@"A number representing the radius of the cylinder.")]
        [Required]
        [DataMember(Name = "radius", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("radius")] // For System.Text.Json
        public double Radius { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Cylinder";
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
            sb.Append("Cylinder:\n");
            sb.Append("  Center: ").Append(this.Center).Append("\n");
            sb.Append("  Axis: ").Append(this.Axis).Append("\n");
            sb.Append("  Radius: ").Append(this.Radius).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Cylinder object</returns>
        public static Cylinder FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Cylinder>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Cylinder object</returns>
        public virtual Cylinder DuplicateCylinder()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicateCylinder();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Cylinder);
        }


        /// <summary>
        /// Returns true if Cylinder instances are equal
        /// </summary>
        /// <param name="input">Instance of Cylinder to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Cylinder input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Center, input.Center) && 
                    Extension.AllEquals(this.Axis, input.Axis) && 
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
                if (this.Axis != null)
                    hashCode = hashCode * 59 + this.Axis.GetHashCode();
                if (this.Radius != null)
                    hashCode = hashCode * 59 + this.Radius.GetHashCode();
                return hashCode;
            }
        }


    }
}
