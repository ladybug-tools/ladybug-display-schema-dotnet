
# LadybugDisplaySchema.Model.ContextGeometry

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Geometry** | [**List&lt;AnyOfDisplayVector2DDisplayPoint2DDisplayRay2DDisplayLineSegment2DDisplayPolyline2DDisplayArc2DDisplayPolygon2DDisplayMesh2DDisplayVector3DDisplayPoint3DDisplayRay3DDisplayPlaneDisplayLineSegment3DDisplayPolyline3DDisplayArc3DDisplayFace3DDisplayMesh3DDisplayPolyface3DDisplaySphereDisplayConeDisplayCylinderDisplayText3D&gt;**](AnyOfDisplayVector2DDisplayPoint2DDisplayRay2DDisplayLineSegment2DDisplayPolyline2DDisplayArc2DDisplayPolygon2DDisplayMesh2DDisplayVector3DDisplayPoint3DDisplayRay3DDisplayPlaneDisplayLineSegment3DDisplayPolyline3DDisplayArc3DDisplayFace3DDisplayMesh3DDisplayPolyface3DDisplaySphereDisplayConeDisplayCylinderDisplayText3D.md) | A list of ladybug-geometry or ladybug-display objects that gives context to analysis geometry or other aspects of the visualization. Typically, these will display in wireframe around the geometry, though the properties of display geometry can be used to customize the visualization. | 
**Type** | **string** |  | [optional] [readonly] [default to "ContextGeometry"]
**Hidden** | **bool** | A boolean to note whether the geometry is hidden by default and must be un-hidden to be visible in the 3D scene. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

