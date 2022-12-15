
# LadybugDisplaySchema.Model.VisualizationSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "VisualizationSet"]
**Geometry** | [**List&lt;AnyOfAnalysisGeometryContextGeometry&gt;**](AnyOfAnalysisGeometryContextGeometry.md) | A list of AnalysisGeometry and ContextGeometry objects to display in the visualization. Each geometry object will typically be translated to its own layer within the interface that renders the VisualizationSet. | [optional] 
**Units** | **Units** | Text indicating the units in which the model geometry exists. If None, the geometry will always be assumed to be in the current units system of the display interface. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

