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
    /// A Polyface in 3D space.
    /// </summary>
    [Summary(@"A Polyface in 3D space.")]
    [System.Serializable]
    [DataContract(Name = "Polyface3D")] // Enables DataMember rules. For internal Serialization XML/JSON
    public partial class Polyface3D : OpenAPIGenBaseModel, System.IEquatable<Polyface3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polyface3D" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected Polyface3D() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "Polyface3D";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Polyface3D" /> class.
        /// </summary>
        /// <param name="vertices">A list of points representing the vertices of the polyface. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.</param>
        /// <param name="faceIndices">A list of lists with one list for each face of the polyface. Each face list must contain at least one sub-list of integers corresponding to indices within the vertices list. Additional sub-lists of integers may follow this one such that the first sub-list denotes the boundary of the face while each subsequent sub-list denotes a hole in the face.</param>
        /// <param name="edgeInformation">Optional edge information, which will speed up the creation of the Polyface object if it is available but should be left as None if it is unknown. If None, edge_information will be computed from the vertices and face_indices inputs.</param>
        public Polyface3D
        (
            List<List<double>> vertices, List<List<List<int>>> faceIndices, PolyfaceEdgeInfo edgeInformation = default
        ) : base()
        {
            this.Vertices = vertices ?? throw new System.ArgumentNullException("vertices is a required property for Polyface3D and cannot be null");
            this.FaceIndices = faceIndices ?? throw new System.ArgumentNullException("faceIndices is a required property for Polyface3D and cannot be null");
            this.EdgeInformation = edgeInformation;

            // Set readonly properties with defaultValue
            this.Type = "Polyface3D";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(Polyface3D))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// A list of points representing the vertices of the polyface. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.
        /// </summary>
        [Summary(@"A list of points representing the vertices of the polyface. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "vertices", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("vertices", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("vertices")] // For System.Text.Json
        public List<List<double>> Vertices { get; set; }

        /// <summary>
        /// A list of lists with one list for each face of the polyface. Each face list must contain at least one sub-list of integers corresponding to indices within the vertices list. Additional sub-lists of integers may follow this one such that the first sub-list denotes the boundary of the face while each subsequent sub-list denotes a hole in the face.
        /// </summary>
        [Summary(@"A list of lists with one list for each face of the polyface. Each face list must contain at least one sub-list of integers corresponding to indices within the vertices list. Additional sub-lists of integers may follow this one such that the first sub-list denotes the boundary of the face while each subsequent sub-list denotes a hole in the face.")]
        [Required] // For validation after deserialization
        // [System.Text.Json.Serialization.JsonRequired] // For System.Text.Json 
        [DataMember(Name = "face_indices", IsRequired = true)] // For internal Serialization XML/JSON
        [JsonProperty("face_indices", Required = Required.Always)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("face_indices")] // For System.Text.Json
        public List<List<List<int>>> FaceIndices { get; set; }

        /// <summary>
        /// Optional edge information, which will speed up the creation of the Polyface object if it is available but should be left as None if it is unknown. If None, edge_information will be computed from the vertices and face_indices inputs.
        /// </summary>
        [Summary(@"Optional edge information, which will speed up the creation of the Polyface object if it is available but should be left as None if it is unknown. If None, edge_information will be computed from the vertices and face_indices inputs.")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  // For System.Text.Json  
        [DataMember(Name = "edge_information")] // For internal Serialization XML/JSON
        [JsonProperty("edge_information", NullValueHandling = NullValueHandling.Ignore)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("edge_information")] // For System.Text.Json
        public PolyfaceEdgeInfo EdgeInformation { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "Polyface3D";
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
            sb.Append("Polyface3D:\n");
            sb.Append("  Vertices: ").Append(this.Vertices).Append("\n");
            sb.Append("  FaceIndices: ").Append(this.FaceIndices).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            sb.Append("  EdgeInformation: ").Append(this.EdgeInformation).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>Polyface3D object</returns>
        public static Polyface3D FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<Polyface3D>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>Polyface3D object</returns>
        public virtual Polyface3D DuplicatePolyface3D()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicatePolyface3D();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as Polyface3D);
        }


        /// <summary>
        /// Returns true if Polyface3D instances are equal
        /// </summary>
        /// <param name="input">Instance of Polyface3D to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Polyface3D input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.Vertices, input.Vertices) && 
                    Extension.AllEquals(this.FaceIndices, input.FaceIndices) && 
                    Extension.Equals(this.EdgeInformation, input.EdgeInformation);
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
                if (this.FaceIndices != null)
                    hashCode = hashCode * 59 + this.FaceIndices.GetHashCode();
                if (this.EdgeInformation != null)
                    hashCode = hashCode * 59 + this.EdgeInformation.GetHashCode();
                return hashCode;
            }
        }


    }
}
