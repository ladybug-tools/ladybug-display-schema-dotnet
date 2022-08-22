using Newtonsoft.Json;
using System.Runtime.Serialization;


namespace LadybugDisplaySchema
{
    public abstract class LadybugObject: ILadybugObject
    {

        /// <summary>
        /// Number of decimals to use for calculation.
        /// </summary>
        protected const int APPROX = 6;
        /// <summary>
        /// Default tolerance to for calculation.
        /// </summary>
        protected const double TOL = 0.000001;

        /// <summary>
        /// Gets or Sets Type
        /// The default value is set to "InvalidSchemaObject", which should be overridden in subclass' constructor.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public virtual string Type { get; protected set; } = "InvalidSchemaObject";

        /// <summary>
        /// This is the base class for all honeybee schema objects.
        /// </summary>
        protected internal LadybugObject()
        {
           
        }


        public abstract string ToString(bool detailed);

        public abstract OpenAPIGenBaseModel Duplicate();
        public string ToJson(bool indented = false)
        {
            var format = indented ? Formatting.Indented : Formatting.None;
            return JsonConvert.SerializeObject(this, format, JsonSetting.AnyOfConvertSetting);
        }

        public static bool operator == (LadybugObject left, LadybugObject right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return left.Equals(right);
        }

        public static bool operator !=(LadybugObject left, LadybugObject right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is LadybugObject input)
                return Extension.Equals(this.Type, input.Type);
            return false;
        }
    }
}
