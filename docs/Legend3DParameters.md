
# LadybugDisplaySchema.Model.Legend3DParameters

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "Legend3DParameters"]
**BasePlane** | [**Plane**](Plane.md) | A Ladybug Plane object to note the starting position from where the legend will be generated. The default is the world XY plane at origin (0, 0, 0) unless the legend is assigned to a specific geometry, in which case the origin is in the lower right corner of the geometry bounding box for vertical legends and the upper right corner for horizontal legends. | [optional] 
**SegmentHeight** | [**AnyOfDefaultnumber**](AnyOfDefaultnumber.md) | A number to set the height for each of the legend segments. The default is 1 unless the legend is assigned to a specific geometry, in which case it is automatically set to a value on an appropriate scale (some fraction of the bounding box around the geometry). | [optional] 
**SegmentWidth** | [**AnyOfDefaultnumber**](AnyOfDefaultnumber.md) | A number to set the width for each of the legend segments. The default is 1 unless the legend is assigned to a specific geometry, in which case it is automatically set to a value on an appropriate scale (some fraction of the bounding box around the geometry). | [optional] 
**TextHeight** | [**AnyOfDefaultnumber**](AnyOfDefaultnumber.md) | A number to set the height for the legend text. Default is 1/3 of the segment_height. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

