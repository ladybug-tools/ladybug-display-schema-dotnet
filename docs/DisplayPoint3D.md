
# LadybugDisplaySchema.Model.DisplayPoint3D

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Color** | [**Color**](Color.md) | Color for the geometry. | 
**Geometry** | [**Point3D**](Point3D.md) | Point3D for the geometry. | 
**Type** | **string** |  | [optional] [readonly] [default to "DisplayPoint3D"]
**Radius** | [**AnyOfDefaultnumber**](AnyOfDefaultnumber.md) | Number for the radius with which the point should be displayed in pixels (for the screen) or millimeters (in print). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

