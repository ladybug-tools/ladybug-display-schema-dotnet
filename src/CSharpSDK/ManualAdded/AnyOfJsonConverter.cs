﻿
using LBT.Newtonsoft.Json;
using LBT.Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace LadybugDisplaySchema
{
    // This is a special version of the AnyOfJsonConverter, and different from the one from HoneybeeSchema
    public class AnyOfJsonConverter : JsonConverter<AnyOf>
    {
        private readonly Type _types;

        public AnyOfJsonConverter()
        {
            _types = typeof(AnyOf);
        }

        public override AnyOf ReadJson(JsonReader reader, Type objectType, AnyOf existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var objType = objectType;
            var validTypes = objType.GenericTypeArguments;

            // null value assigned to AnyOf type, ignore 
            if (reader.TokenType == JsonToken.Null)
                return null;

            var data = reader.Value;

            // try to load AnyOf value
            if (data == null)
            {
                var jObject = JObject.Load(reader);

                if (jObject["type"] == null)
                    throw new ArgumentException($"Unable to load {reader.Path}");

                var typeName = jObject["type"].Value<string>();
                var interfaceTypes = validTypes.Where(_ => _.IsInterface);
                if (interfaceTypes.Any())
                {
                    var assembly = objectType.Assembly;
                    var assemblyName = assembly.GetName().Name;
                    foreach (var interfaceType in interfaceTypes)
                    {
                        var realObjectType = assembly.GetType($"{assemblyName}.{typeName}", false, true);
                        if (realObjectType != null && interfaceType.IsAssignableFrom(realObjectType))
                        {
                            data = jObject.ToObject(realObjectType, serializer);
                            break;
                        }
                    }
                }
                else
                {
                    var type = validTypes.FirstOrDefault(_ => _.Name.Equals(typeName, StringComparison.CurrentCultureIgnoreCase));
                    if (type != null)
                    {
                        data = jObject.ToObject(type, serializer);
                    }
                    else
                    {
                        throw new ArgumentException($"{typeName} is not a valid type for {reader.Path}, this might because of mismatch version of schema!");
                    }
                }


                if (data == null)
                {
                    throw new ArgumentException($"{typeName} is not a valid type of {string.Join(",", validTypes.Select(_ => _.Name))}, this might because of mismatch version of schema!");
                }
            }


            var inputType = data.GetType();

            //convert int to double if the number was saved as int to json string 
            var allValidTypes = validTypes.ToList();
            if ((inputType == typeof(int) || inputType == typeof(Int64)) && allValidTypes.Contains(typeof(double)))
            {
                inputType = typeof(double);
                data = double.Parse(data.ToString());
            }
            else if ((data is long || data is double) && allValidTypes.Contains(typeof(int)))
            {
                data = int.Parse(data?.ToString());
                inputType = typeof(int);
            }

            var obj = Activator.CreateInstance(objectType, new object[] { data });
            return obj as AnyOf;

        }

        public override void WriteJson(JsonWriter writer, AnyOf value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value.Obj, serializer);
            t.WriteTo(writer);
        }



    }
}