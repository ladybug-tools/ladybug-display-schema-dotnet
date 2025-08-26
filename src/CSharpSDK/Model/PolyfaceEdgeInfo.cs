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
    /// Optional edge information for Polyface.
    /// </summary>
    [Summary(@"Optional edge information for Polyface.")]
    [System.Serializable]
    [DataContract(Name = "PolyfaceEdgeInfo")]
    public partial class PolyfaceEdgeInfo : OpenAPIGenBaseModel, System.IEquatable<PolyfaceEdgeInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolyfaceEdgeInfo" /> class.
        /// </summary>
        [LBT.Newtonsoft.Json.JsonConstructorAttribute]
        // [System.Text.Json.Serialization.JsonConstructor] // for future switching to System.Text.Json
        protected PolyfaceEdgeInfo() 
        { 
            // Set readonly properties with defaultValue
            this.Type = "PolyfaceEdgeInfo";
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PolyfaceEdgeInfo" /> class.
        /// </summary>
        /// <param name="edgeIndices">An array objects that each contain two integers. These integers correspond to indices within the vertices list and each tuple represents a line segment for an edge of the polyface.</param>
        /// <param name="edgeTypes">An array of integers for each edge that parallels the edge_indices list. An integer of 0 denotes a naked edge, an integer of 1 denotes an internal edge. Anything higher is a non-manifold edge.</param>
        public PolyfaceEdgeInfo
        (
            List<List<int>> edgeIndices, List<int> edgeTypes
        ) : base()
        {
            this.EdgeIndices = edgeIndices ?? throw new System.ArgumentNullException("edgeIndices is a required property for PolyfaceEdgeInfo and cannot be null");
            this.EdgeTypes = edgeTypes ?? throw new System.ArgumentNullException("edgeTypes is a required property for PolyfaceEdgeInfo and cannot be null");

            // Set readonly properties with defaultValue
            this.Type = "PolyfaceEdgeInfo";

            // check if object is valid, only check for inherited class
            if (this.GetType() == typeof(PolyfaceEdgeInfo))
                this.IsValid(throwException: true);
        }

	
	
        /// <summary>
        /// An array objects that each contain two integers. These integers correspond to indices within the vertices list and each tuple represents a line segment for an edge of the polyface.
        /// </summary>
        [Summary(@"An array objects that each contain two integers. These integers correspond to indices within the vertices list and each tuple represents a line segment for an edge of the polyface.")]
        [Required]
        [DataMember(Name = "edge_indices", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("edge_indices")] // For System.Text.Json
        public List<List<int>> EdgeIndices { get; set; }

        /// <summary>
        /// An array of integers for each edge that parallels the edge_indices list. An integer of 0 denotes a naked edge, an integer of 1 denotes an internal edge. Anything higher is a non-manifold edge.
        /// </summary>
        [Summary(@"An array of integers for each edge that parallels the edge_indices list. An integer of 0 denotes a naked edge, an integer of 1 denotes an internal edge. Anything higher is a non-manifold edge.")]
        [Required]
        [DataMember(Name = "edge_types", IsRequired = true)] // For Newtonsoft.Json
        // [System.Text.Json.Serialization.JsonPropertyName("edge_types")] // For System.Text.Json
        public List<int> EdgeTypes { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return "PolyfaceEdgeInfo";
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
            sb.Append("PolyfaceEdgeInfo:\n");
            sb.Append("  EdgeIndices: ").Append(this.EdgeIndices).Append("\n");
            sb.Append("  EdgeTypes: ").Append(this.EdgeTypes).Append("\n");
            sb.Append("  Type: ").Append(this.Type).Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// Returns the object from JSON string
        /// </summary>
        /// <returns>PolyfaceEdgeInfo object</returns>
        public static PolyfaceEdgeInfo FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<PolyfaceEdgeInfo>(json, JsonSetting.AnyOfConvertSetting);
            if (obj == null)
                return null;
            return obj.Type.ToLower() == obj.GetType().Name.ToLower() && obj.IsValid(throwException: true) ? obj : null;
        }




        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>PolyfaceEdgeInfo object</returns>
        public virtual PolyfaceEdgeInfo DuplicatePolyfaceEdgeInfo()
        {
            return FromJson(this.ToJson());
        }


        /// <summary>
        /// Creates a new instance with the same properties.
        /// </summary>
        /// <returns>OpenAPIGenBaseModel</returns>
        public override OpenAPIGenBaseModel DuplicateOpenAPIGenBaseModel()
        {
            return DuplicatePolyfaceEdgeInfo();
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            input = input is AnyOf anyOf ? anyOf.Obj : input;
            return this.Equals(input as PolyfaceEdgeInfo);
        }


        /// <summary>
        /// Returns true if PolyfaceEdgeInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of PolyfaceEdgeInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PolyfaceEdgeInfo input)
        {
            if (input == null)
                return false;
            return base.Equals(input) && 
                    Extension.AllEquals(this.EdgeIndices, input.EdgeIndices) && 
                    Extension.AllEquals(this.EdgeTypes, input.EdgeTypes);
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
                if (this.EdgeIndices != null)
                    hashCode = hashCode * 59 + this.EdgeIndices.GetHashCode();
                if (this.EdgeTypes != null)
                    hashCode = hashCode * 59 + this.EdgeTypes.GetHashCode();
                return hashCode;
            }
        }


    }
}
