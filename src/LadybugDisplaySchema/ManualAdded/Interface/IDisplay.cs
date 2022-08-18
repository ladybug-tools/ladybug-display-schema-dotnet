
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace LadybugDisplaySchema
{
    public interface IDisplay { }
    public partial interface IDisplay2D : IDisplay { }
    public partial interface IDisplay3D : IDisplay { }



    public class TestObj
    {
        [JsonConverter(typeof(ConcreteConverter))]
        public IDisplay Display { get; set; }
    }

    public class ProxyDisplay
    {
        //[JsonConverter(typeof(ConcreteConverter))]
        public AnyOf<IDisplay> Display { get; set; }

        public static ProxyDisplay FromJson(string json)
        {
            var oo = JsonConvert.DeserializeObject<IDisplay>(json, JsonSetting.AnyOfConvertSetting);
            return null;
        }
    }

    public class ConcreteConverter : JsonConverter<IDisplay>
    {
        public override IDisplay ReadJson(JsonReader reader, Type objectType, IDisplay existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var typeName = jObject["type"].Value<string>();
            var ss = jObject.ToString();
            if (objectType.IsInterface)
            {
                var realObjectType = objectType.Assembly.GetType($"LadybugDisplaySchema.{typeName}", false, true);
                if (realObjectType != null)
                {
                    if (objectType.IsAssignableFrom(realObjectType))
                    {
                        var oo = jObject.ToObject(realObjectType, serializer);
                        var soo = jObject.ToObject(realObjectType);
                        return oo as IDisplay;
                    }
                }
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, IDisplay value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}

