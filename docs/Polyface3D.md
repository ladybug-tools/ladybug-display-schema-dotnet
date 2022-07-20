
# LadybugDisplaySchema.Model.Polyface3D

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Vertices** | **List&lt;List&lt;double&gt;&gt;** | A list of points representing the vertices of the polyface. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. | 
**FaceIndices** | **List&lt;List&lt;List&lt;int&gt;&gt;&gt;** | A list of lists with one list for each face of the polyface. Each face list must contain at least one sub-list of integers corresponding to indices within the vertices list. Additional sub-lists of integers may follow this one such that the first sub-list denotes the boundary of the face while each subsequent sub-list denotes a hole in the face. | 
**Type** | **string** |  | [optional] [readonly] [default to "Polyface3D"]
**EdgeInformation** | [**PolyfaceEdgeInfo**](PolyfaceEdgeInfo.md) | Optional edge information, which will speed up the creation of the Polyface object if it is available but should be left as None if it is unknown. If None, edge_information will be computed from the vertices and face_indices inputs. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

