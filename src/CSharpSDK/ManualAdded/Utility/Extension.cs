
using System;
using LBT.Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{
    /// <summary>
    /// Extensions of System.Collection.Generic
    /// </summary>
    public static partial class Extension
    {
        public static List<double> ToDecimalList(this Vector3D v)
        {
            return new List<double> { v.X, v.Y, v.Z };
        }
        public static List<double> ToDecimalList(this Vector2D v)
        {
            return new List<double> { v.X, v.Y };
        }

        public static List<double> ToDecimalList(this Point3D p)
        {
            return new List<double> { p.X, p.Y, p.Z };
        }
        public static List<double> ToDecimalList(this Point2D p)
        {
            return new List<double> { p.X, p.Y };
        }

        /// <summary>
        /// Get an item by index. Also negative index
        /// </summary>
        /// <typeparam name="T">Type that implement IComparable.</typeparam>
        /// <param name="items">Array to use.</param>
        /// <param name="index">Index to use.</param>
        /// <returns>Element at index.</returns>
        public static T GetElementByIndex<T>(this IEnumerable<T> items, int index)
        {
            if (index < 0)
            {
                index = items.Count() + index;
            }

            return items.ElementAt(index);
        }

        /// <summary>
        /// Set an item by index. Also negative.
        /// </summary>
        /// <typeparam name="T">Type that implement IComparable.</typeparam>
        /// <param name="items">Array to use.</param>
        /// <param name="index">Index of item to set.</param>
        /// <param name="value">Value to set.</param>
        /// <returns>True if success.</returns>
        public static bool SetElementByIndex<T>(this List<T> items, 
            int index, 
            T value)
            where T : IComparable
        {
            if (index < 0)
            {
                index = items.Count + index;
            }

            items[index] = value;
            return true;
        }

        public static bool AllEquals(IList x, IList y, double tol = 0.001)
        {
            var tolSqr = tol * tol;

            if (x != null && y != null)
            {
                if (x.Count <= 0 || y.Count <= 0)
                    return x.Count == y.Count;

                //Test if it is points List<List<double>> with the length of 3
                if (x.Count == 3 && y.Count == 3 && x[0] is double && y[0] is double)
                {
                    var px = x.Cast<double>().ToList();
                    var py = y.Cast<double>().ToList();
                    var dis = CalDistanceSquare(px, py);
                    return dis <= tolSqr;
                }
                else if (x[0] is IList listX && y[0] is IList listY)
                {
                    return AllEquals(listX, listY, tol);
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

        public new static bool Equals(object x, object y)
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

        /// <summary>
        /// Convert a jagged array to multidimensional array.
        /// </summary>
        /// <typeparam name="T">Type that implement IComparable.</typeparam>
        /// <param name="arr">Array to convert.</param>
        /// <returns>Multidimensional array with same items.</returns>
        public static T[,] ConvertToMultidimensional<T>(this T[][] arr)
            where T : IComparable
        {
            try
            {
                var dimX = arr.Length;
                var dimY = arr.GroupBy(row => row.Length)
                    .Single().Key;

                var result = new T[dimX, dimY];
                for (int i = 0; i < dimX; ++i)
                    for (int j = 0; j < dimY; ++j)
                        result[i, j] = arr[i][j];

                return result;
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException("The given jagged " +
                    $"array is not rectangular. {e.Message}");
            }
        }

        /// <summary>
        /// Compare two arrays.
        /// </summary>
        /// <typeparam name="T">Type that implement IComparable.</typeparam>
        /// <param name="arr">First array.</param>
        /// <param name="other">Second array.</param>
        /// <returns>True if content is equals else false.</returns>
        /// <returns></returns>
        public static bool ContentEquals<T>(this T[] arr, T[] other)
            where T : IComparable
        {
            if (arr.Length != other.Length)
                return false;

            for (int i = 0; i < arr.Length; i++)
                if (arr[i].CompareTo(other[i]) != 0)
                    return false;

            return true;
        }

        /// <summary>
        /// Rotate left by one place.
        /// </summary>
        /// <typeparam name="T">Type that implement IList.</typeparam>
        /// <param name="list">List to rotate.</param>
        /// <returns>True when done.</returns>
        public static bool Rotate<T>(this List<T> list) 
            where T : IList<T>
        {
            var first = list[0];
            list.RemoveAt(0);
            list.Add(first);
            return true;
        }

        /// <summary>
        /// Rotate left by one place.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="array">Array to rotate.</param>
        /// <returns>True when done.</returns>
        public static bool Rotate<T>(this T[] array)
        {
            var first = array[0];
            Array.Copy(array, 1, array, 0, array.Length - 1);
            array[array.Length - 1] = first;
            return true;
        }

        /// <summary>
        /// Rotate right by one place.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="array">Array to rotate.</param>
        /// <returns>True when done.</returns>
        public static bool RotateRight<T>(this T[] array)
        {
            var last = array[array.Length - 1];
            for (int i = (array.Length - 1); i > 0; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = last;

            return true;
        }

        /// <summary>
        /// Rotate by index. Left or right rotation.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="arr">Array to rotate.</param>
        /// <param name="index">A positive or negative index to use for 
        /// rotation. Rotate right if negative.</param>
        /// <returns>True when done.</returns>
        public static bool RotateByIndex<T>(this T[] arr, int index)
        {
            if (index >= 0)
            {
                for (int i = 0; i < index; i++)
                {
                    arr.Rotate();
                }
            }
            else
            {
                for (int i = 0; i < Math.Abs(index); i++)
                {
                    arr.RotateRight();
                }
            }
            return true;
        }

        /// <summary>
        /// Insert an array at specific index.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="arr">Array to modify.</param>
        /// <param name="other">Array to add.</param>
        /// <param name="index">Index where to insert other array.</param>
        /// <returns>A new array with the addiction.</returns>
        public static T[] InsertAt<T>(this T[] arr, T[] other, int index=0)
        {
            if (index < 0)
            {
                index = arr.Length + index;
            }

            var firstArr = arr.Take(index)
                .ToList();
            var secondArr = arr.Skip(index)
                .ToList();

            firstArr.AddRange(other.ToList());
            firstArr.AddRange(secondArr);

            var outArr = firstArr.ToArray();

            return outArr;
        }

        /// <summary>
        /// Deep copy of array.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="array">Array to duplicate.</param>
        /// <returns>A copy of the array.</returns>
        public static T[] Duplicate<T>(this T[] array)
        {
            T[] target = new T[array.Length];
            array.CopyTo(target, 0);
            return target;
        }

        public static Dictionary<string, object> GetUserData(this LegendParameters obj)
        {
            var ud = ToDictionary(obj.UserData);
            obj.UserData = ud;
            return ud;
        }

        public static LegendParameters AddUserData(this LegendParameters obj, string key, object vaule)
        {
            if (obj == null || vaule == null || key == null)
                return obj;

            var dup = obj.DuplicateLegendParameters();
            var ud = dup.GetUserData();
            ud.TryAddUpdate(key, vaule);
            return dup;
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
            LBT.Newtonsoft.Json.Linq.JObject jObj = null;
            if (userData is string)
                jObj = LBT.Newtonsoft.Json.Linq.JObject.Parse(userData?.ToString());
            else if (userData is LBT.Newtonsoft.Json.Linq.JObject j)
                jObj = j;

            if (jObj != null)
            {
                uds = jObj.Children()
                   .OfType<LBT.Newtonsoft.Json.Linq.JProperty>()
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


        public static Point3D Average(this IEnumerable<Point3D> pts)
        {
            var x = pts.Select(_ => _.X).Average();
            var y = pts.Select(_ => _.Y).Average();
            var z = pts.Select(_ => _.Z).Average();

            return new Point3D(x, y, z);
        }

        public static List<AlignGrid> CullDuplicates(this IEnumerable<AlignGrid> grid, double tolerance)
        {
            if (grid == null)
            {
                return null;
            }

            var sqlTol = tolerance * tolerance;
            var point3dList = grid.Where(_ => _.WeightPoints.Count > 0).ToList();
            int count = point3dList.Count;
            if (count == 0)
            {
                return null;
            }

            bool[] array = new bool[count];
            var point3dList2 = new List<AlignGrid>(count);
            for (int i = 0; i < count; i++)
            {
                if (array[i])
                {
                    continue;
                }

                point3dList2.Add(point3dList[i]);
                for (int j = i + 1; j < count; j++)
                {
                    var dis = point3dList[i].Plane.Origin.DistanceToSquared(point3dList[j].Plane.Origin);
                    if (dis <= sqlTol)
                    {
                        point3dList2.Last().WeightPoints.AddRange(point3dList[j].WeightPoints);
                        array[j] = true;
                    }
                }
            }

            var averaged = point3dList2.Select(_ => _.Weight()).Where(_ => _.WeightPoints.Count > 0).ToList();

            return averaged;
        }



    }
}
