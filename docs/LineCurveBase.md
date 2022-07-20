
# LadybugDisplaySchema.Model.LineCurveBase

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Color** | [**Color**](Color.md) | Color for the geometry. | 
**LineWidth** | [**AnyOfDefaultdouble**](AnyOfDefaultdouble.md) | Number for line width in pixels (for the screen) or millimeters (in print). Set to zero to hide the geometry. | [optional] 
**LineType** | **LineTypes** | Text to indicate the type of line to display (dashed, dotted, etc.). The LineTypes enumeration contains all acceptable types. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "LineCurveBase"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

