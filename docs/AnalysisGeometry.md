
# LadybugDisplaySchema.Model.AnalysisGeometry

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Geometry** | [**AnyOfMesh2DMesh3DPolyface3Darray**](AnyOfMesh2DMesh3DPolyface3Darray.md) | A ladybug-geometry object or list of ladybug-geometry objects that is aligned with the values in the input data_sets. If a Mesh or Polyface is specified here, it is expected that the number of values match the number of faces or the number of vertices. If a list of geometry objects is specified (ie. a list of Point3Ds), it is expected that the length of this list align with the number of values. | 
**DataSets** | [**List&lt;VisualizationData&gt;**](VisualizationData.md) | An list of VisualizationData objects representing the data sets that are associated with the input geometry. | 
**Type** | **string** |  | [optional] [readonly] [default to "AnalysisGeometry"]
**ActiveData** | **int** | An integer to denote which of the input data_sets should be displayed by default. | [optional] [default to 0]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

