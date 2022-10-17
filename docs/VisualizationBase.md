
# LadybugDisplaySchema.Model.VisualizationBase

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. Must be less than 100 characters and not contain spaces or special characters. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. This is typically used to set the layer of the object in the interface that renders the VisualizationSet. A :: in the display_name can be used to denote sub-layers following a convention of ParentLayer::SubLayer. If not set, the display_name will be equal to the object identifier. | [optional] 
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "_VisualizationBase"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

