
# LadybugDisplaySchema.Model.Legend2DParameters

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "Legend2DParameters"]
**OriginX** | [**AnyOfDefaultstring**](AnyOfDefaultstring.md) | A text string to note the X coordinate of the base point from where the legend will be generated (assuming an origin in the upper-left corner of the viewport with higher positive values of X moving to the right). Text must be formatted as an integer followed by either \&quot;px\&quot; (to denote the number of viewport pixels) or \&quot;%\&quot; (to denote the percentage of the viewport width). Examples include 10px, 5%. The default is set to make the legend clearly visible on the viewport (usually 10px). | [optional] 
**OriginY** | [**AnyOfDefaultstring**](AnyOfDefaultstring.md) | A text string to note the Y coordinate of the base point from where the legend will be generated (assuming an origin in the upper-left corner of the viewport with higher positive values of Y moving downward). Text must be formatted as an integer followed by either \&quot;px\&quot; (to denote the number of viewport pixels) or \&quot;%\&quot; (to denote the percentage of the viewport height). Examples include 10px, 5%. The default is set to make the legend clearly visible on the viewport (usually 50px). | [optional] 
**SegmentHeight** | [**AnyOfDefaultstring**](AnyOfDefaultstring.md) | A text string to note the height for each of the legend segments. Text must be formatted as an integer followed by either \&quot;px\&quot; (to denote the number of viewport pixels) or \&quot;%\&quot; (to denote the percentage of the viewport height). Examples include 10px, 5%. The default is set to make most legends readable (25px for horizontal legends and 36px for vertical legends). | [optional] 
**SegmentWidth** | [**AnyOfDefaultstring**](AnyOfDefaultstring.md) | A text string to set the width for each of the legend segments. Text must be formatted as an integer followed by either \&quot;px\&quot; (to denote the number of viewport pixels) or \&quot;%\&quot; (to denote the percentage of the viewport width). Examples include 10px, 5%. The default is set to make most legends readable (36px for horizontal legends and 25px for vertical legends). | [optional] 
**TextHeight** | [**AnyOfDefaultstring**](AnyOfDefaultstring.md) | A text string to set the height for the legend text. Text must be formatted as an integer followed by either \&quot;px\&quot; (to denote the number of viewport pixels) or \&quot;%\&quot; (to denote the percentage of the viewport height). Examples include 10px, 5%. Default is 1/3 of the segment_height. Default is 12px. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

