
# LadybugDisplaySchema.Model.VisualizationSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "VisualizationSet"]
**AnalysisGeometry** | [**AnalysisGeometry**](AnalysisGeometry.md) | An AnalysisGeometry object for spatial data that should be displayed in the visualization. | [optional] 
**ContextGeometry** | [**List&lt;AnyOfDisplayVector2DDisplayPoint2DDisplayRay2DDisplayLineSegment2DDisplayPolyline2DDisplayArc2DDisplayPolygon2DDisplayMesh2DDisplayVector3DDisplayPoint3DDisplayRay3DDisplayPlaneDisplayLineSegment3DDisplayPolyline3DDisplayArc3DDisplayFace3DDisplayMesh3DDisplayPolyface3DDisplaySphereDisplayConeDisplayCylinder&gt;**](AnyOfDisplayVector2DDisplayPoint2DDisplayRay2DDisplayLineSegment2DDisplayPolyline2DDisplayArc2DDisplayPolygon2DDisplayMesh2DDisplayVector3DDisplayPoint3DDisplayRay3DDisplayPlaneDisplayLineSegment3DDisplayPolyline3DDisplayArc3DDisplayFace3DDisplayMesh3DDisplayPolyface3DDisplaySphereDisplayConeDisplayCylinder.md) | An optional list of ladybug-geometry or ladybug-display objects that gives context to the analysis geometry or other aspects of the visualization. Typically, these will display in wireframe around the geometry, though the properties of display geometry can be used to customize the visualization. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

