
# LadybugDisplaySchema.Model.GraphicContainer

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Values** | **List&lt;double&gt;** | An list of numerical values that will be used to generate the legend and colors. | 
**Type** | **string** |  | [optional] [readonly] [default to "GraphicContainer"]
**Geometry** | [**AnyOfMesh2DMesh3DPolyface3Darray**](AnyOfMesh2DMesh3DPolyface3Darray.md) | An optional ladybug-geometry object (or list of ladybug-geometry objects) that is aligned with the input values. If a Mesh or Polyface is specified here, it is expected that the number of values match the number of faces or the number of vertices. If a list of geometry objects is specified (ie. a list of Point3Ds), it is expected that the length of this list align with the number of values. | [optional] 
**MinPoint** | [**Point3D**](Point3D.md) | A Point3D object for the minimum of the bounding box around the graphic geometry. If None, then there must be an input for geometry and the bounding box around this geometry will be used to set up the graphic container. | [optional] 
**MaxPoint** | [**Point3D**](Point3D.md) | A Point3D object for the maximum of the  bounding box around the graphic geometry. If None, then there must be an input for geometry and the bounding box around this geometry will be used to set up the graphic container. | [optional] 
**LegendParameters** | [**LegendParameters**](LegendParameters.md) | An Optional LegendParameters object to override default parameters of the legend. None indicates that default legend parameters will be used. | [optional] 
**DataType** | [**DataType**](DataType.md) | Optional DataType from the ladybug datatype subpackage (ie. Temperature()) , which will be used to assign default legend properties. If None, the legend associated with this object will contain no units unless a unit below is specified. | [optional] 
**Unit** | **string** | Optional text string for the units of the values. (ie. \&quot;C\&quot;). If None, the default units of the data_type will be used. | [optional] [default to ""]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

