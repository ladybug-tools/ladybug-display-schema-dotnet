extern alias LBTNewtonsoft; using System;
using LBTNewtonsoft::Newtonsoft.Json;
using LBTNewtonsoft::Newtonsoft.Json.Linq;


namespace LadybugDisplaySchema
{
    public interface IDisplay { }
    public partial interface IDisplay2D : IDisplay { }
    public partial interface IDisplay3D : IDisplay { }

 
}

