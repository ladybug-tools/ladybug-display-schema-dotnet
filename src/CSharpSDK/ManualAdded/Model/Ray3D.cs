namespace LadybugDisplaySchema
{
    public partial class Ray3D 
    {

        public Ray3D(Point3D p, Vector3D v)
            : this(p.ToDecimalList(), v.ToDecimalList())
        { }

        public bool Uin(double u)
        {
            return u >= 0;
        }

    }
}
