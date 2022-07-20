
# LadybugDisplaySchema.Model.DisplayPolyface3D

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Geometry** | [**Polyface3D**](Polyface3D.md) | Polyface3D for the geometry. | 
**Colors** | [**List&lt;Color&gt;**](Color.md) | A list of colors that correspond to either the faces of the polyface or the vertices of the polyface. It can also be a single color for the entire polyface. | 
**Type** | **string** |  | [optional] [readonly] [default to "DisplayPolyface3D"]
**DisplayMode** | **DisplayModes** | Text to indicate the display mode (shaded, wireframe, etc.). The DisplayModes enumeration contains all acceptable types. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

