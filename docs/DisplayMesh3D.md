
# LadybugDisplaySchema.Model.DisplayMesh3D

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Layer** | **string** | Optional text for the layer on which the geometry exists. Sub-layers should be separated from parent layers by means of a :: and platforms that support sub-layers will interpret the layer as such. | [optional] 
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Geometry** | [**Mesh3D**](Mesh3D.md) | Mesh3D for the geometry. | 
**Colors** | [**List&lt;Color&gt;**](Color.md) | A list of colors that correspond to either the faces of the mesh or the vertices of the mesh. It can also be a single color for the entire mesh. | 
**Type** | **string** |  | [optional] [readonly] [default to "DisplayMesh3D"]
**DisplayMode** | **DisplayModes** | Text to indicate the display mode (shaded, wireframe, etc.). The DisplayModes enumeration contains all acceptable types. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

