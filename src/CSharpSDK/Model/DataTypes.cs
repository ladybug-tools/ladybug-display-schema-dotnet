/* 
 * LadybugDisplaySchema
 *
 * Contact: info@ladybug.tools
 */

 using System.Runtime.Serialization;
 using LBT.Newtonsoft.Json;
 using LBT.Newtonsoft.Json.Converters;

namespace LadybugDisplaySchema
{
    /// <summary>
    /// An enumeration.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DataTypes
    {

        [EnumMember(Value = "ActivityLevel")]
        ActivityLevel = 1,

        [EnumMember(Value = "AerosolOpticalDepth")]
        AerosolOpticalDepth = 2,

        [EnumMember(Value = "AirSpeed")]
        AirSpeed = 3,

        [EnumMember(Value = "AirTemperature")]
        AirTemperature = 4,

        [EnumMember(Value = "AirTemperatureDelta")]
        AirTemperatureDelta = 5,

        [EnumMember(Value = "Albedo")]
        Albedo = 6,

        [EnumMember(Value = "Angle")]
        Angle = 7,

        [EnumMember(Value = "Area")]
        Area = 8,

        [EnumMember(Value = "AtmosphericStationPressure")]
        AtmosphericStationPressure = 9,

        [EnumMember(Value = "CeilingHeight")]
        CeilingHeight = 10,

        [EnumMember(Value = "ClothingInsulation")]
        ClothingInsulation = 11,

        [EnumMember(Value = "ConvectionCoefficient")]
        ConvectionCoefficient = 12,

        [EnumMember(Value = "CoolingDegreeTime")]
        CoolingDegreeTime = 13,

        [EnumMember(Value = "Current")]
        Current = 14,

        [EnumMember(Value = "DewPointTemperature")]
        DewPointTemperature = 15,

        [EnumMember(Value = "DiffuseHorizontalIlluminance")]
        DiffuseHorizontalIlluminance = 16,

        [EnumMember(Value = "DiffuseHorizontalIrradiance")]
        DiffuseHorizontalIrradiance = 17,

        [EnumMember(Value = "DiffuseHorizontalRadiation")]
        DiffuseHorizontalRadiation = 18,

        [EnumMember(Value = "DirectHorizontalIrradiance")]
        DirectHorizontalIrradiance = 19,

        [EnumMember(Value = "DirectHorizontalRadiation")]
        DirectHorizontalRadiation = 20,

        [EnumMember(Value = "DirectNormalIlluminance")]
        DirectNormalIlluminance = 21,

        [EnumMember(Value = "DirectNormalIrradiance")]
        DirectNormalIrradiance = 22,

        [EnumMember(Value = "DirectNormalRadiation")]
        DirectNormalRadiation = 23,

        [EnumMember(Value = "DiscomfortReason")]
        DiscomfortReason = 24,

        [EnumMember(Value = "Distance")]
        Distance = 25,

        [EnumMember(Value = "DryBulbTemperature")]
        DryBulbTemperature = 26,

        [EnumMember(Value = "EffectiveRadiantField")]
        EffectiveRadiantField = 27,

        [EnumMember(Value = "Energy")]
        Energy = 28,

        [EnumMember(Value = "EnergyFlux")]
        EnergyFlux = 29,

        [EnumMember(Value = "EnergyIntensity")]
        EnergyIntensity = 30,

        [EnumMember(Value = "Enthalpy")]
        Enthalpy = 31,

        [EnumMember(Value = "ExtraterrestrialDirectNormalRadiation")]
        ExtraterrestrialDirectNormalRadiation = 32,

        [EnumMember(Value = "ExtraterrestrialHorizontalRadiation")]
        ExtraterrestrialHorizontalRadiation = 33,

        [EnumMember(Value = "Fraction")]
        Fraction = 34,

        [EnumMember(Value = "GlobalHorizontalIlluminance")]
        GlobalHorizontalIlluminance = 35,

        [EnumMember(Value = "GlobalHorizontalIrradiance")]
        GlobalHorizontalIrradiance = 36,

        [EnumMember(Value = "GlobalHorizontalRadiation")]
        GlobalHorizontalRadiation = 37,

        [EnumMember(Value = "GroundTemperature")]
        GroundTemperature = 38,

        [EnumMember(Value = "HeatingDegreeTime")]
        HeatingDegreeTime = 39,

        [EnumMember(Value = "HorizontalInfraredRadiationIntensity")]
        HorizontalInfraredRadiationIntensity = 40,

        [EnumMember(Value = "HumidityRatio")]
        HumidityRatio = 41,

        [EnumMember(Value = "Illuminance")]
        Illuminance = 42,

        [EnumMember(Value = "Irradiance")]
        Irradiance = 43,

        [EnumMember(Value = "LiquidPrecipitationDepth")]
        LiquidPrecipitationDepth = 44,

        [EnumMember(Value = "LiquidPrecipitationQuantity")]
        LiquidPrecipitationQuantity = 45,

        [EnumMember(Value = "Luminance")]
        Luminance = 46,

        [EnumMember(Value = "Mass")]
        Mass = 47,

        [EnumMember(Value = "MassFlowRate")]
        MassFlowRate = 48,

        [EnumMember(Value = "MeanRadiantTemperature")]
        MeanRadiantTemperature = 49,

        [EnumMember(Value = "MetabolicRate")]
        MetabolicRate = 50,

        [EnumMember(Value = "OpaqueSkyCover")]
        OpaqueSkyCover = 51,

        [EnumMember(Value = "OperativeTemperature")]
        OperativeTemperature = 52,

        [EnumMember(Value = "OperativeTemperatureDelta")]
        OperativeTemperatureDelta = 53,

        [EnumMember(Value = "PercentagePeopleDissatisfied")]
        PercentagePeopleDissatisfied = 54,

        [EnumMember(Value = "Power")]
        Power = 55,

        [EnumMember(Value = "PrecipitableWater")]
        PrecipitableWater = 56,

        [EnumMember(Value = "PredictedMeanVote")]
        PredictedMeanVote = 57,

        [EnumMember(Value = "Pressure")]
        Pressure = 58,

        [EnumMember(Value = "PrevailingOutdoorTemperature")]
        PrevailingOutdoorTemperature = 59,

        [EnumMember(Value = "RValue")]
        RValue = 60,

        [EnumMember(Value = "RadiantCoefficient")]
        RadiantCoefficient = 61,

        [EnumMember(Value = "RadiantTemperature")]
        RadiantTemperature = 62,

        [EnumMember(Value = "RadiantTemperatureDelta")]
        RadiantTemperatureDelta = 63,

        [EnumMember(Value = "Radiation")]
        Radiation = 64,

        [EnumMember(Value = "RelativeHumidity")]
        RelativeHumidity = 65,

        [EnumMember(Value = "SkyTemperature")]
        SkyTemperature = 66,

        [EnumMember(Value = "SnowDepth")]
        SnowDepth = 67,

        [EnumMember(Value = "SpecificEnergy")]
        SpecificEnergy = 68,

        [EnumMember(Value = "Speed")]
        Speed = 69,

        [EnumMember(Value = "StandardEffectiveTemperature")]
        StandardEffectiveTemperature = 70,

        [EnumMember(Value = "Temperature")]
        Temperature = 71,

        [EnumMember(Value = "TemperatureDelta")]
        TemperatureDelta = 72,

        [EnumMember(Value = "TemperatureTime")]
        TemperatureTime = 73,

        [EnumMember(Value = "ThermalComfort")]
        ThermalComfort = 74,

        [EnumMember(Value = "ThermalCondition")]
        ThermalCondition = 75,

        [EnumMember(Value = "ThermalConditionElevenPoint")]
        ThermalConditionElevenPoint = 76,

        [EnumMember(Value = "ThermalConditionFivePoint")]
        ThermalConditionFivePoint = 77,

        [EnumMember(Value = "ThermalConditionNinePoint")]
        ThermalConditionNinePoint = 78,

        [EnumMember(Value = "ThermalConditionSevenPoint")]
        ThermalConditionSevenPoint = 79,

        [EnumMember(Value = "Time")]
        Time = 80,

        [EnumMember(Value = "TotalSkyCover")]
        TotalSkyCover = 81,

        [EnumMember(Value = "UTCICategory")]
        UTCICategory = 82,

        [EnumMember(Value = "UValue")]
        UValue = 83,

        [EnumMember(Value = "UniversalThermalClimateIndex")]
        UniversalThermalClimateIndex = 84,

        [EnumMember(Value = "Visibility")]
        Visibility = 85,

        [EnumMember(Value = "Voltage")]
        Voltage = 86,

        [EnumMember(Value = "Volume")]
        Volume = 87,

        [EnumMember(Value = "VolumeFlowRate")]
        VolumeFlowRate = 88,

        [EnumMember(Value = "VolumeFlowRateIntensity")]
        VolumeFlowRateIntensity = 89,

        [EnumMember(Value = "WetBulbTemperature")]
        WetBulbTemperature = 90,

        [EnumMember(Value = "WindDirection")]
        WindDirection = 91,

        [EnumMember(Value = "WindSpeed")]
        WindSpeed = 92,

        [EnumMember(Value = "ZenithLuminance")]
        ZenithLuminance = 93,

    }
 
}