/* 
 * LadybugDisplaySchema
 *
 * Contact: info@ladybug.tools
 */

 using System.Runtime.Serialization;
 // using System.Text.Json;
 // using System.Text.Json.Serialization;
 using LBT.Newtonsoft.Json;
 using LBT.Newtonsoft.Json.Converters;

namespace LadybugDisplaySchema
{
    /// <summary>
    /// An enumeration.
    /// </summary>
    // Shared enum across all serializers
    [DataContract] // For DataContractSerializer
    [JsonConverter(typeof(StringEnumConverter))] // Newtonsoft string form
    // [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))] // STJ string form
    public enum DataTypes
    {

        [EnumMember(Value = "ActivityLevel")]
        [JsonProperty("ActivityLevel")]       // Newtonsoft
        // [JsonPropertyName("ActivityLevel")]                   // STJ
        ActivityLevel = 1,

        [EnumMember(Value = "AerosolOpticalDepth")]
        [JsonProperty("AerosolOpticalDepth")]       // Newtonsoft
        // [JsonPropertyName("AerosolOpticalDepth")]                   // STJ
        AerosolOpticalDepth = 2,

        [EnumMember(Value = "AirSpeed")]
        [JsonProperty("AirSpeed")]       // Newtonsoft
        // [JsonPropertyName("AirSpeed")]                   // STJ
        AirSpeed = 3,

        [EnumMember(Value = "AirTemperature")]
        [JsonProperty("AirTemperature")]       // Newtonsoft
        // [JsonPropertyName("AirTemperature")]                   // STJ
        AirTemperature = 4,

        [EnumMember(Value = "AirTemperatureDelta")]
        [JsonProperty("AirTemperatureDelta")]       // Newtonsoft
        // [JsonPropertyName("AirTemperatureDelta")]                   // STJ
        AirTemperatureDelta = 5,

        [EnumMember(Value = "Albedo")]
        [JsonProperty("Albedo")]       // Newtonsoft
        // [JsonPropertyName("Albedo")]                   // STJ
        Albedo = 6,

        [EnumMember(Value = "Angle")]
        [JsonProperty("Angle")]       // Newtonsoft
        // [JsonPropertyName("Angle")]                   // STJ
        Angle = 7,

        [EnumMember(Value = "Area")]
        [JsonProperty("Area")]       // Newtonsoft
        // [JsonPropertyName("Area")]                   // STJ
        Area = 8,

        [EnumMember(Value = "AtmosphericStationPressure")]
        [JsonProperty("AtmosphericStationPressure")]       // Newtonsoft
        // [JsonPropertyName("AtmosphericStationPressure")]                   // STJ
        AtmosphericStationPressure = 9,

        [EnumMember(Value = "CeilingHeight")]
        [JsonProperty("CeilingHeight")]       // Newtonsoft
        // [JsonPropertyName("CeilingHeight")]                   // STJ
        CeilingHeight = 10,

        [EnumMember(Value = "ClothingInsulation")]
        [JsonProperty("ClothingInsulation")]       // Newtonsoft
        // [JsonPropertyName("ClothingInsulation")]                   // STJ
        ClothingInsulation = 11,

        [EnumMember(Value = "ConvectionCoefficient")]
        [JsonProperty("ConvectionCoefficient")]       // Newtonsoft
        // [JsonPropertyName("ConvectionCoefficient")]                   // STJ
        ConvectionCoefficient = 12,

        [EnumMember(Value = "CoolingDegreeTime")]
        [JsonProperty("CoolingDegreeTime")]       // Newtonsoft
        // [JsonPropertyName("CoolingDegreeTime")]                   // STJ
        CoolingDegreeTime = 13,

        [EnumMember(Value = "Current")]
        [JsonProperty("Current")]       // Newtonsoft
        // [JsonPropertyName("Current")]                   // STJ
        Current = 14,

        [EnumMember(Value = "DewPointTemperature")]
        [JsonProperty("DewPointTemperature")]       // Newtonsoft
        // [JsonPropertyName("DewPointTemperature")]                   // STJ
        DewPointTemperature = 15,

        [EnumMember(Value = "DiffuseHorizontalIlluminance")]
        [JsonProperty("DiffuseHorizontalIlluminance")]       // Newtonsoft
        // [JsonPropertyName("DiffuseHorizontalIlluminance")]                   // STJ
        DiffuseHorizontalIlluminance = 16,

        [EnumMember(Value = "DiffuseHorizontalIrradiance")]
        [JsonProperty("DiffuseHorizontalIrradiance")]       // Newtonsoft
        // [JsonPropertyName("DiffuseHorizontalIrradiance")]                   // STJ
        DiffuseHorizontalIrradiance = 17,

        [EnumMember(Value = "DiffuseHorizontalRadiation")]
        [JsonProperty("DiffuseHorizontalRadiation")]       // Newtonsoft
        // [JsonPropertyName("DiffuseHorizontalRadiation")]                   // STJ
        DiffuseHorizontalRadiation = 18,

        [EnumMember(Value = "DirectHorizontalIrradiance")]
        [JsonProperty("DirectHorizontalIrradiance")]       // Newtonsoft
        // [JsonPropertyName("DirectHorizontalIrradiance")]                   // STJ
        DirectHorizontalIrradiance = 19,

        [EnumMember(Value = "DirectHorizontalRadiation")]
        [JsonProperty("DirectHorizontalRadiation")]       // Newtonsoft
        // [JsonPropertyName("DirectHorizontalRadiation")]                   // STJ
        DirectHorizontalRadiation = 20,

        [EnumMember(Value = "DirectNormalIlluminance")]
        [JsonProperty("DirectNormalIlluminance")]       // Newtonsoft
        // [JsonPropertyName("DirectNormalIlluminance")]                   // STJ
        DirectNormalIlluminance = 21,

        [EnumMember(Value = "DirectNormalIrradiance")]
        [JsonProperty("DirectNormalIrradiance")]       // Newtonsoft
        // [JsonPropertyName("DirectNormalIrradiance")]                   // STJ
        DirectNormalIrradiance = 22,

        [EnumMember(Value = "DirectNormalRadiation")]
        [JsonProperty("DirectNormalRadiation")]       // Newtonsoft
        // [JsonPropertyName("DirectNormalRadiation")]                   // STJ
        DirectNormalRadiation = 23,

        [EnumMember(Value = "DiscomfortReason")]
        [JsonProperty("DiscomfortReason")]       // Newtonsoft
        // [JsonPropertyName("DiscomfortReason")]                   // STJ
        DiscomfortReason = 24,

        [EnumMember(Value = "Distance")]
        [JsonProperty("Distance")]       // Newtonsoft
        // [JsonPropertyName("Distance")]                   // STJ
        Distance = 25,

        [EnumMember(Value = "DryBulbTemperature")]
        [JsonProperty("DryBulbTemperature")]       // Newtonsoft
        // [JsonPropertyName("DryBulbTemperature")]                   // STJ
        DryBulbTemperature = 26,

        [EnumMember(Value = "EffectiveRadiantField")]
        [JsonProperty("EffectiveRadiantField")]       // Newtonsoft
        // [JsonPropertyName("EffectiveRadiantField")]                   // STJ
        EffectiveRadiantField = 27,

        [EnumMember(Value = "Energy")]
        [JsonProperty("Energy")]       // Newtonsoft
        // [JsonPropertyName("Energy")]                   // STJ
        Energy = 28,

        [EnumMember(Value = "EnergyFlux")]
        [JsonProperty("EnergyFlux")]       // Newtonsoft
        // [JsonPropertyName("EnergyFlux")]                   // STJ
        EnergyFlux = 29,

        [EnumMember(Value = "EnergyIntensity")]
        [JsonProperty("EnergyIntensity")]       // Newtonsoft
        // [JsonPropertyName("EnergyIntensity")]                   // STJ
        EnergyIntensity = 30,

        [EnumMember(Value = "Enthalpy")]
        [JsonProperty("Enthalpy")]       // Newtonsoft
        // [JsonPropertyName("Enthalpy")]                   // STJ
        Enthalpy = 31,

        [EnumMember(Value = "ExtraterrestrialDirectNormalRadiation")]
        [JsonProperty("ExtraterrestrialDirectNormalRadiation")]       // Newtonsoft
        // [JsonPropertyName("ExtraterrestrialDirectNormalRadiation")]                   // STJ
        ExtraterrestrialDirectNormalRadiation = 32,

        [EnumMember(Value = "ExtraterrestrialHorizontalRadiation")]
        [JsonProperty("ExtraterrestrialHorizontalRadiation")]       // Newtonsoft
        // [JsonPropertyName("ExtraterrestrialHorizontalRadiation")]                   // STJ
        ExtraterrestrialHorizontalRadiation = 33,

        [EnumMember(Value = "Fraction")]
        [JsonProperty("Fraction")]       // Newtonsoft
        // [JsonPropertyName("Fraction")]                   // STJ
        Fraction = 34,

        [EnumMember(Value = "GlobalHorizontalIlluminance")]
        [JsonProperty("GlobalHorizontalIlluminance")]       // Newtonsoft
        // [JsonPropertyName("GlobalHorizontalIlluminance")]                   // STJ
        GlobalHorizontalIlluminance = 35,

        [EnumMember(Value = "GlobalHorizontalIrradiance")]
        [JsonProperty("GlobalHorizontalIrradiance")]       // Newtonsoft
        // [JsonPropertyName("GlobalHorizontalIrradiance")]                   // STJ
        GlobalHorizontalIrradiance = 36,

        [EnumMember(Value = "GlobalHorizontalRadiation")]
        [JsonProperty("GlobalHorizontalRadiation")]       // Newtonsoft
        // [JsonPropertyName("GlobalHorizontalRadiation")]                   // STJ
        GlobalHorizontalRadiation = 37,

        [EnumMember(Value = "GroundTemperature")]
        [JsonProperty("GroundTemperature")]       // Newtonsoft
        // [JsonPropertyName("GroundTemperature")]                   // STJ
        GroundTemperature = 38,

        [EnumMember(Value = "HeatingDegreeTime")]
        [JsonProperty("HeatingDegreeTime")]       // Newtonsoft
        // [JsonPropertyName("HeatingDegreeTime")]                   // STJ
        HeatingDegreeTime = 39,

        [EnumMember(Value = "HorizontalInfraredRadiationIntensity")]
        [JsonProperty("HorizontalInfraredRadiationIntensity")]       // Newtonsoft
        // [JsonPropertyName("HorizontalInfraredRadiationIntensity")]                   // STJ
        HorizontalInfraredRadiationIntensity = 40,

        [EnumMember(Value = "HumidityRatio")]
        [JsonProperty("HumidityRatio")]       // Newtonsoft
        // [JsonPropertyName("HumidityRatio")]                   // STJ
        HumidityRatio = 41,

        [EnumMember(Value = "Illuminance")]
        [JsonProperty("Illuminance")]       // Newtonsoft
        // [JsonPropertyName("Illuminance")]                   // STJ
        Illuminance = 42,

        [EnumMember(Value = "Irradiance")]
        [JsonProperty("Irradiance")]       // Newtonsoft
        // [JsonPropertyName("Irradiance")]                   // STJ
        Irradiance = 43,

        [EnumMember(Value = "LiquidPrecipitationDepth")]
        [JsonProperty("LiquidPrecipitationDepth")]       // Newtonsoft
        // [JsonPropertyName("LiquidPrecipitationDepth")]                   // STJ
        LiquidPrecipitationDepth = 44,

        [EnumMember(Value = "LiquidPrecipitationQuantity")]
        [JsonProperty("LiquidPrecipitationQuantity")]       // Newtonsoft
        // [JsonPropertyName("LiquidPrecipitationQuantity")]                   // STJ
        LiquidPrecipitationQuantity = 45,

        [EnumMember(Value = "Luminance")]
        [JsonProperty("Luminance")]       // Newtonsoft
        // [JsonPropertyName("Luminance")]                   // STJ
        Luminance = 46,

        [EnumMember(Value = "Mass")]
        [JsonProperty("Mass")]       // Newtonsoft
        // [JsonPropertyName("Mass")]                   // STJ
        Mass = 47,

        [EnumMember(Value = "MassFlowRate")]
        [JsonProperty("MassFlowRate")]       // Newtonsoft
        // [JsonPropertyName("MassFlowRate")]                   // STJ
        MassFlowRate = 48,

        [EnumMember(Value = "MeanRadiantTemperature")]
        [JsonProperty("MeanRadiantTemperature")]       // Newtonsoft
        // [JsonPropertyName("MeanRadiantTemperature")]                   // STJ
        MeanRadiantTemperature = 49,

        [EnumMember(Value = "MetabolicRate")]
        [JsonProperty("MetabolicRate")]       // Newtonsoft
        // [JsonPropertyName("MetabolicRate")]                   // STJ
        MetabolicRate = 50,

        [EnumMember(Value = "OpaqueSkyCover")]
        [JsonProperty("OpaqueSkyCover")]       // Newtonsoft
        // [JsonPropertyName("OpaqueSkyCover")]                   // STJ
        OpaqueSkyCover = 51,

        [EnumMember(Value = "OperativeTemperature")]
        [JsonProperty("OperativeTemperature")]       // Newtonsoft
        // [JsonPropertyName("OperativeTemperature")]                   // STJ
        OperativeTemperature = 52,

        [EnumMember(Value = "OperativeTemperatureDelta")]
        [JsonProperty("OperativeTemperatureDelta")]       // Newtonsoft
        // [JsonPropertyName("OperativeTemperatureDelta")]                   // STJ
        OperativeTemperatureDelta = 53,

        [EnumMember(Value = "PercentagePeopleDissatisfied")]
        [JsonProperty("PercentagePeopleDissatisfied")]       // Newtonsoft
        // [JsonPropertyName("PercentagePeopleDissatisfied")]                   // STJ
        PercentagePeopleDissatisfied = 54,

        [EnumMember(Value = "Power")]
        [JsonProperty("Power")]       // Newtonsoft
        // [JsonPropertyName("Power")]                   // STJ
        Power = 55,

        [EnumMember(Value = "PrecipitableWater")]
        [JsonProperty("PrecipitableWater")]       // Newtonsoft
        // [JsonPropertyName("PrecipitableWater")]                   // STJ
        PrecipitableWater = 56,

        [EnumMember(Value = "PredictedMeanVote")]
        [JsonProperty("PredictedMeanVote")]       // Newtonsoft
        // [JsonPropertyName("PredictedMeanVote")]                   // STJ
        PredictedMeanVote = 57,

        [EnumMember(Value = "Pressure")]
        [JsonProperty("Pressure")]       // Newtonsoft
        // [JsonPropertyName("Pressure")]                   // STJ
        Pressure = 58,

        [EnumMember(Value = "PrevailingOutdoorTemperature")]
        [JsonProperty("PrevailingOutdoorTemperature")]       // Newtonsoft
        // [JsonPropertyName("PrevailingOutdoorTemperature")]                   // STJ
        PrevailingOutdoorTemperature = 59,

        [EnumMember(Value = "RValue")]
        [JsonProperty("RValue")]       // Newtonsoft
        // [JsonPropertyName("RValue")]                   // STJ
        RValue = 60,

        [EnumMember(Value = "RadiantCoefficient")]
        [JsonProperty("RadiantCoefficient")]       // Newtonsoft
        // [JsonPropertyName("RadiantCoefficient")]                   // STJ
        RadiantCoefficient = 61,

        [EnumMember(Value = "RadiantTemperature")]
        [JsonProperty("RadiantTemperature")]       // Newtonsoft
        // [JsonPropertyName("RadiantTemperature")]                   // STJ
        RadiantTemperature = 62,

        [EnumMember(Value = "RadiantTemperatureDelta")]
        [JsonProperty("RadiantTemperatureDelta")]       // Newtonsoft
        // [JsonPropertyName("RadiantTemperatureDelta")]                   // STJ
        RadiantTemperatureDelta = 63,

        [EnumMember(Value = "Radiation")]
        [JsonProperty("Radiation")]       // Newtonsoft
        // [JsonPropertyName("Radiation")]                   // STJ
        Radiation = 64,

        [EnumMember(Value = "RelativeHumidity")]
        [JsonProperty("RelativeHumidity")]       // Newtonsoft
        // [JsonPropertyName("RelativeHumidity")]                   // STJ
        RelativeHumidity = 65,

        [EnumMember(Value = "SkyTemperature")]
        [JsonProperty("SkyTemperature")]       // Newtonsoft
        // [JsonPropertyName("SkyTemperature")]                   // STJ
        SkyTemperature = 66,

        [EnumMember(Value = "SnowDepth")]
        [JsonProperty("SnowDepth")]       // Newtonsoft
        // [JsonPropertyName("SnowDepth")]                   // STJ
        SnowDepth = 67,

        [EnumMember(Value = "SpecificEnergy")]
        [JsonProperty("SpecificEnergy")]       // Newtonsoft
        // [JsonPropertyName("SpecificEnergy")]                   // STJ
        SpecificEnergy = 68,

        [EnumMember(Value = "Speed")]
        [JsonProperty("Speed")]       // Newtonsoft
        // [JsonPropertyName("Speed")]                   // STJ
        Speed = 69,

        [EnumMember(Value = "StandardEffectiveTemperature")]
        [JsonProperty("StandardEffectiveTemperature")]       // Newtonsoft
        // [JsonPropertyName("StandardEffectiveTemperature")]                   // STJ
        StandardEffectiveTemperature = 70,

        [EnumMember(Value = "Temperature")]
        [JsonProperty("Temperature")]       // Newtonsoft
        // [JsonPropertyName("Temperature")]                   // STJ
        Temperature = 71,

        [EnumMember(Value = "TemperatureDelta")]
        [JsonProperty("TemperatureDelta")]       // Newtonsoft
        // [JsonPropertyName("TemperatureDelta")]                   // STJ
        TemperatureDelta = 72,

        [EnumMember(Value = "TemperatureTime")]
        [JsonProperty("TemperatureTime")]       // Newtonsoft
        // [JsonPropertyName("TemperatureTime")]                   // STJ
        TemperatureTime = 73,

        [EnumMember(Value = "ThermalComfort")]
        [JsonProperty("ThermalComfort")]       // Newtonsoft
        // [JsonPropertyName("ThermalComfort")]                   // STJ
        ThermalComfort = 74,

        [EnumMember(Value = "ThermalCondition")]
        [JsonProperty("ThermalCondition")]       // Newtonsoft
        // [JsonPropertyName("ThermalCondition")]                   // STJ
        ThermalCondition = 75,

        [EnumMember(Value = "ThermalConditionElevenPoint")]
        [JsonProperty("ThermalConditionElevenPoint")]       // Newtonsoft
        // [JsonPropertyName("ThermalConditionElevenPoint")]                   // STJ
        ThermalConditionElevenPoint = 76,

        [EnumMember(Value = "ThermalConditionFivePoint")]
        [JsonProperty("ThermalConditionFivePoint")]       // Newtonsoft
        // [JsonPropertyName("ThermalConditionFivePoint")]                   // STJ
        ThermalConditionFivePoint = 77,

        [EnumMember(Value = "ThermalConditionNinePoint")]
        [JsonProperty("ThermalConditionNinePoint")]       // Newtonsoft
        // [JsonPropertyName("ThermalConditionNinePoint")]                   // STJ
        ThermalConditionNinePoint = 78,

        [EnumMember(Value = "ThermalConditionSevenPoint")]
        [JsonProperty("ThermalConditionSevenPoint")]       // Newtonsoft
        // [JsonPropertyName("ThermalConditionSevenPoint")]                   // STJ
        ThermalConditionSevenPoint = 79,

        [EnumMember(Value = "Time")]
        [JsonProperty("Time")]       // Newtonsoft
        // [JsonPropertyName("Time")]                   // STJ
        Time = 80,

        [EnumMember(Value = "TotalSkyCover")]
        [JsonProperty("TotalSkyCover")]       // Newtonsoft
        // [JsonPropertyName("TotalSkyCover")]                   // STJ
        TotalSkyCover = 81,

        [EnumMember(Value = "UTCICategory")]
        [JsonProperty("UTCICategory")]       // Newtonsoft
        // [JsonPropertyName("UTCICategory")]                   // STJ
        UTCICategory = 82,

        [EnumMember(Value = "UValue")]
        [JsonProperty("UValue")]       // Newtonsoft
        // [JsonPropertyName("UValue")]                   // STJ
        UValue = 83,

        [EnumMember(Value = "UniversalThermalClimateIndex")]
        [JsonProperty("UniversalThermalClimateIndex")]       // Newtonsoft
        // [JsonPropertyName("UniversalThermalClimateIndex")]                   // STJ
        UniversalThermalClimateIndex = 84,

        [EnumMember(Value = "Visibility")]
        [JsonProperty("Visibility")]       // Newtonsoft
        // [JsonPropertyName("Visibility")]                   // STJ
        Visibility = 85,

        [EnumMember(Value = "Voltage")]
        [JsonProperty("Voltage")]       // Newtonsoft
        // [JsonPropertyName("Voltage")]                   // STJ
        Voltage = 86,

        [EnumMember(Value = "Volume")]
        [JsonProperty("Volume")]       // Newtonsoft
        // [JsonPropertyName("Volume")]                   // STJ
        Volume = 87,

        [EnumMember(Value = "VolumeFlowRate")]
        [JsonProperty("VolumeFlowRate")]       // Newtonsoft
        // [JsonPropertyName("VolumeFlowRate")]                   // STJ
        VolumeFlowRate = 88,

        [EnumMember(Value = "VolumeFlowRateIntensity")]
        [JsonProperty("VolumeFlowRateIntensity")]       // Newtonsoft
        // [JsonPropertyName("VolumeFlowRateIntensity")]                   // STJ
        VolumeFlowRateIntensity = 89,

        [EnumMember(Value = "WetBulbTemperature")]
        [JsonProperty("WetBulbTemperature")]       // Newtonsoft
        // [JsonPropertyName("WetBulbTemperature")]                   // STJ
        WetBulbTemperature = 90,

        [EnumMember(Value = "WindDirection")]
        [JsonProperty("WindDirection")]       // Newtonsoft
        // [JsonPropertyName("WindDirection")]                   // STJ
        WindDirection = 91,

        [EnumMember(Value = "WindSpeed")]
        [JsonProperty("WindSpeed")]       // Newtonsoft
        // [JsonPropertyName("WindSpeed")]                   // STJ
        WindSpeed = 92,

        [EnumMember(Value = "ZenithLuminance")]
        [JsonProperty("ZenithLuminance")]       // Newtonsoft
        // [JsonPropertyName("ZenithLuminance")]                   // STJ
        ZenithLuminance = 93,

    }
 
}