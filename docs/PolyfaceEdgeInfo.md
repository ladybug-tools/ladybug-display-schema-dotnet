
# LadybugDisplaySchema.Model.PolyfaceEdgeInfo

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EdgeIndices** | **List&lt;List&lt;int&gt;&gt;** | An array objects that each contain two integers. These integers correspond to indices within the vertices list and each tuple represents a line segment for an edge of the polyface. | 
**EdgeTypes** | **List&lt;int&gt;** | An array of integers for each edge that parallels the edge_indices list. An integer of 0 denotes a naked edge, an integer of 1 denotes an internal edge. Anything higher is a non-manifold edge. | 
**Type** | **string** |  | [optional] [readonly] [default to "PolyfaceEdgeInfo"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

