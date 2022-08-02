
namespace LadybugDisplaySchema
{
    public interface ILadybugObject
    {
        string ToString(bool detailed);
        string ToJson(bool indented = false);
        OpenAPIGenBaseModel Duplicate();
    } 

    
}

