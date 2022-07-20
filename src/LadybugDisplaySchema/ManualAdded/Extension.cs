
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{

    public static class Extension 
	{
        public static bool AllEquals(IList x, IList y)
        {
            if (x != null && y != null)
            {
                if (x.Count <=0 || y.Count <= 0)
                    return x.Count == y.Count;

                //Test if it is points List<List<double>> with the length of 3
                if (x.Count == 3 && y.Count == 3 && x[0] is double && y[0] is double)
                {
                    var px = x.Cast<double>().ToList();
                    var py = y.Cast<double>().ToList();
                    var dis = CalDistanceSquare(px, py); 
                    var tol = 0.000001;
                    return dis <= tol;
                }
                else if (x[0] is IList listX && y[0] is IList listY)
                {
                    return AllEquals(listX, listY);
                }
                else
                {
                    var xo = x.Cast<object>();
                    var yo = y.Cast<object>();
                    return xo.SequenceEqual(yo);
                }
            }
            else if (x == null)
            {
                return y == null || y.Count == 0;
            }
            else if (y == null)
            {
                return x == null || x.Count == 0;
            }
            else
            {
                return x == y;
            }
        }

        public static bool Equals(object x, object y)
        {

            if (x == y)
                return true;

            if (x == null)
                return y == null;

            if (x is JObject j)
                return JToken.DeepEquals(j, y as JObject);
            else
                return x.Equals(y);

        }
        public static double CalDistanceSquare(List<double> p1, List<double> p2)
        {
            var px1 = p1[0];
            var py1 = p1[1];
            var pz1 = p1[2];

            var px2 = p2[0];
            var py2 = p2[1];
            var pz2 = p2[2];

            var disSquare = Math.Pow(px1 - px2, 2) + Math.Pow(py1 - py2, 2) + Math.Pow(pz1 - pz2, 2);
            return disSquare;

        }
	

        public static Dictionary<string, object> GetUserData(this DisplayBaseModel obj)
        {
            var ud = ToDictionary(obj.UserData);
            obj.UserData = ud;
            return ud;
        }

        public static void AddUserData(this DisplayBaseModel obj, string key, object vaule)
        {
            if (obj == null || vaule == null || key == null)
                return;

            var ud = obj.GetUserData();
            ud.TryAddUpdate(key, vaule);
        }


        public static Dictionary<string, object> ToDictionary(object userData)
        {
            if (userData is Dictionary<string, object> dd)
                return dd;

            var uds = new Dictionary<string, object>();
            Newtonsoft.Json.Linq.JObject jObj = null;
            if (userData is string)
                jObj = Newtonsoft.Json.Linq.JObject.Parse(userData?.ToString());
            else if (userData is Newtonsoft.Json.Linq.JObject j)
                jObj = j;

            if (jObj != null)
            {
                uds = jObj.Children()
                   .OfType<Newtonsoft.Json.Linq.JProperty>()
                   .ToDictionary(_ => _.Name, _ => _.Value as object);
            }
            return uds;

        }

        public static void TryAddUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.TryGetValue(key, out var oldValue))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }

    }

}

