
# LadybugDisplaySchema.Model.Polyline3D

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Vertices** | **List&lt;List&lt;double&gt;&gt;** | A list of points representing the the vertices of the polyline. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. | 
**Type** | **string** |  | [optional] [readonly] [default to "Polyline3D"]
**Interpolated** | **bool** | A boolean to note whether the polyline should be interpolated between the input vertices when it is translated to other interfaces. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

