
# LadybugDisplaySchema.Model.DisplayMesh3D

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Geometry** | [**Mesh3D**](Mesh3D.md) | Mesh3D for the geometry. | 
**Colors** | [**List&lt;Color&gt;**](Color.md) | A list of colors that correspond to either the faces of the mesh or the vertices of the mesh. It can also be a single color for the entire mesh. | 
**Type** | **string** |  | [optional] [readonly] [default to "DisplayMesh3D"]
**DisplayMode** | **DisplayModes** | Text to indicate the display mode (surface, wireframe, etc.). The DisplayModes enumeration contains all acceptable types. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

