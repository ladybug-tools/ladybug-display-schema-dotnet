
# LadybugDisplaySchema.Model.AnalysisGeometry

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Geometry** | [**List&lt;AnyOfVector2DPoint2DRay2DLineSegment2DPolyline2DArc2DPolygon2DMesh2DVector3DPoint3DRay3DPlaneLineSegment3DPolyline3DArc3DFace3DMesh3DPolyface3DSphereConeCylinder&gt;**](AnyOfVector2DPoint2DRay2DLineSegment2DPolyline2DArc2DPolygon2DMesh2DVector3DPoint3DRay3DPlaneLineSegment3DPolyline3DArc3DFace3DMesh3DPolyface3DSphereConeCylinder.md) | A list of ladybug-geometry objects that is aligned with the values in the input data_sets. The length of this list should usually be equal to the total number of values in each data_set, indicating that each geometry gets a single color. Alternatively, if all of the geometry objects are meshes, the number of values in the data can be equal to the total number of faces across the meshes or the total number of vertices across the meshes. | 
**DataSets** | [**List&lt;VisualizationData&gt;**](VisualizationData.md) | An list of VisualizationData objects representing the data sets that are associated with the input geometry. | 
**Type** | **string** |  | [optional] [readonly] [default to "AnalysisGeometry"]
**ActiveData** | **int** | An integer to denote which of the input data_sets should be displayed by default. | [optional] [default to 0]
**DisplayMode** | **DisplayModes** | Text to indicate the display mode (surface, wireframe, etc.). The DisplayModes enumeration contains all acceptable types. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

