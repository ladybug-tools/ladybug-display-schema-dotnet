
# LadybugDisplaySchema.Model.VisualizationMetaData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "VisualizationMetaData"]
**LegendParameters** | [**LegendParameters**](LegendParameters.md) | An Optional LegendParameters object to override default parameters of the legend. None indicates that default legend parameters will be used. | [optional] 
**DataType** | [**AnyOfDataTypeGenericDataType**](AnyOfDataTypeGenericDataType.md) | Optional DataType from the ladybug datatype subpackage (ie. Temperature()) , which will be used to assign default legend properties. If None, the legend associated with this object will contain no units unless a unit below is specified. | [optional] 
**Unit** | **string** | Optional text string for the units of the values. (ie. \&quot;C\&quot;). If None, the default units of the data_type will be used. | [optional] [default to ""]
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

