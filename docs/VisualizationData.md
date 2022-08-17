
# LadybugDisplaySchema.Model.VisualizationData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Values** | **List&lt;double&gt;** | A list of numerical values that will be used to generate the visualization colors. | 
**Type** | **string** |  | [optional] [readonly] [default to "VisualizationData"]
**LegendParameters** | [**LegendParameters**](LegendParameters.md) | An Optional LegendParameters object to override default parameters of the legend. None indicates that default legend parameters will be used. | [optional] 
**DataType** | [**DataType**](DataType.md) | Optional DataType from the ladybug datatype subpackage (ie. Temperature()) , which will be used to assign default legend properties. If None, the legend associated with this object will contain no units unless a unit below is specified. | [optional] 
**Unit** | **string** | Optional text string for the units of the values. (ie. \&quot;C\&quot;). If None, the default units of the data_type will be used. | [optional] [default to ""]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

