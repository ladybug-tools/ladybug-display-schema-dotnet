
# LadybugDisplaySchema.Model.DisplayText3D

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Color** | [**Color**](Color.md) | Color for the geometry. | 
**Text** | **string** | A text string to be displayed in the 3D scene. | 
**Plane** | [**Plane**](Plane.md) | A ladybug-geometry Plane object to locate and orient the text in the 3D scene. | 
**Height** | **double** | A number for the height of the text in the 3D scene. | 
**Type** | **string** |  | [optional] [readonly] [default to "DisplayText3D"]
**Font** | **string** | A text string for the font in which to draw the text. Note that this field may not be interpreted the same on all machines and in all interfaces, particularly when a machine lacks a given font. | [optional] [default to "Arial"]
**HorizontalAlignment** | **HorizontalAlignments** | String to specify the horizontal alignment of the text. | [optional] 
**VerticalAlignment** | **VerticalAlignments** | String to specify the vertical alignment of the text. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

