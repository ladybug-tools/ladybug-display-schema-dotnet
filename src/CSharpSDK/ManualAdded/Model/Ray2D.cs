
using System;
using LBT.Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace LadybugDisplaySchema
{
   
    public partial class Ray2D 
    {
       
        /// <summary>
        /// Create an instance of Ray2D.
        /// </summary>
        /// <param name="p">A Point2D representing the base.</param>
        /// <param name="v">A Vector2D representing the direction.</param>
        public Ray2D(Point2D p, Vector2D v)
            : this(p.ToDecimalList(), v.ToDecimalList())
        { }

    
        public bool Uin(double u)
        {
            return u >= 0;
        }


    }
}
