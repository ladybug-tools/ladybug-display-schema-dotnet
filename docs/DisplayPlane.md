
# LadybugDisplaySchema.Model.DisplayPlane

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Color** | [**Color**](Color.md) | Color for the geometry. | 
**Geometry** | [**Plane**](Plane.md) | Plane for the geometry. | 
**Type** | **string** |  | [optional] [readonly] [default to "DisplayPlane"]
**ShowAxes** | **bool** | A boolean to note whether the plane should be displayed with XY axes instead of just an origin point and a normal vector. | [optional] [default to false]
**ShowGrid** | **bool** | A boolean to note whether the plane should be displayed with a grid. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

