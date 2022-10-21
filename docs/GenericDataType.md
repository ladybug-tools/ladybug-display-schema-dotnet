
# LadybugDisplaySchema.Model.GenericDataType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Text to indicate how the data type displays. This can be more specific than the data_type. | 
**BaseUnit** | **string** | Text string for the base unit of the data type, which should be standard SI units where possible. | 
**DataType** | **string** |  | [optional] [default to "GenericType"]
**Min** | [**AnyOfDefaultnumber**](AnyOfDefaultnumber.md) | Optional lower limit for the data type, values below which should be physically or mathematically impossible. (Default: -inf) | [optional] 
**Max** | [**AnyOfDefaultnumber**](AnyOfDefaultnumber.md) | Optional upper limit for the data type, values above which should be physically or mathematically impossible. (Default: +inf) | [optional] 
**Abbreviation** | **string** | An optional abbreviation for the data type as text. | [optional] [default to ""]
**UnitDescr** | **Object** | An optional dictionary describing categories that the numerical values of the units relate to. For example: {-1: \&quot;Cold\&quot;, 0: \&quot;Neutral\&quot;, +1: \&quot;Hot\&quot;}; {0: \&quot;False\&quot;, 1: \&quot;True\&quot;}. | [optional] 
**PointInTime** | **bool** | Boolean to note whether the data type represents conditions at a single instant in time (True) as opposed to being an average or accumulation over time (False) when it is found in hourly lists of data. | [optional] [default to true]
**Cumulative** | **bool** | Boolean to tell whether the data type can be cumulative when it is represented over time (True) or it can only be averaged over time to be meaningful (False). Note that cumulative cannot be True when point_in_time is also True. | [optional] [default to false]
**Type** | **string** |  | [optional] [readonly] [default to "GenericDataType"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

