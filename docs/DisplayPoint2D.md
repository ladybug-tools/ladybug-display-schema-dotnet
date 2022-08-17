
# LadybugDisplaySchema.Model.DisplayPoint2D

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Layer** | **string** | Optional text for the layer on which the geometry exists. Sub-layers should be separated from parent layers by means of a :: and platforms that support sub-layers will interpret the layer as such. | [optional] 
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Color** | [**Color**](Color.md) | Color for the geometry. | 
**Geometry** | [**Point2D**](Point2D.md) | Point2D for the geometry. | 
**Type** | **string** |  | [optional] [readonly] [default to "DisplayPoint2D"]
**Radius** | [**AnyOfDefaultnumber**](AnyOfDefaultnumber.md) | Number for the radius with which the point should be displayed in pixels (for the screen) or millimeters (in print). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

