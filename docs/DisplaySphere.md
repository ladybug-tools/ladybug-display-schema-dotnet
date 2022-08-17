
# LadybugDisplaySchema.Model.DisplaySphere

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Layer** | **string** | Optional text for the layer on which the geometry exists. Sub-layers should be separated from parent layers by means of a :: and platforms that support sub-layers will interpret the layer as such. | [optional] 
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Color** | [**Color**](Color.md) | Color for the geometry. | 
**Geometry** | [**Sphere**](Sphere.md) | Sphere for the geometry. | 
**Type** | **string** |  | [optional] [readonly] [default to "DisplaySphere"]
**DisplayMode** | **DisplayModes** | Text to indicate the display mode (shaded, wireframe, etc.). The DisplayModes enumeration contains all acceptable types. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

