﻿//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://thingsgateway.cn/
//  QQ群：605534569
//------------------------------------------------------------------------------

using BootstrapBlazor.Components;

using Newtonsoft.Json;

namespace ThingsGateway.Gateway.Application;

/// <summary>
/// 设备业务变化数据
/// </summary>
public class DeviceBasicData : IPrimaryIdEntity
{
    /// <inheritdoc cref="PrimaryIdEntity.Id"/>
    public long Id { get; set; }

    /// <inheritdoc cref="Device.Name"/>
    public string Name { get; set; }

    /// <inheritdoc cref="DeviceRuntime.ActiveTime"/>
    public DateTime ActiveTime { get; set; }

    /// <inheritdoc cref="DeviceRuntime.DeviceStatus"/>
    public DeviceStatusEnum DeviceStatus { get; set; }

    /// <inheritdoc cref="DeviceRuntime.LastErrorMessage"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string LastErrorMessage { get; set; }

    /// <inheritdoc cref="DeviceRuntime.PluginName"/>
    public string PluginName { get; set; }

    /// <inheritdoc cref="Device.Description"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <inheritdoc cref="Device.Remark1"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Remark1 { get; set; }

    /// <inheritdoc cref="Device.Remark2"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Remark2 { get; set; }

    /// <inheritdoc cref="Device.Remark3"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Remark3 { get; set; }

    /// <inheritdoc cref="Device.Remark4"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Remark4 { get; set; }

    /// <inheritdoc cref="Device.Remark5"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Remark5 { get; set; }


}

/// <summary>
/// 变量业务变化数据
/// </summary>
public class VariableBasicData : IPrimaryIdEntity
{
    /// <inheritdoc cref="PrimaryIdEntity.Id"/>
    public long Id { get; set; }

    /// <inheritdoc cref="Variable.Name"/>
    public string Name { get; set; }
    /// <inheritdoc cref="Variable.Group"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Group { get; set; }
    /// <inheritdoc cref="VariableRuntime.DeviceName"/>
    public string DeviceName { get; set; }
    /// <inheritdoc cref="VariableRuntime.RuntimeType"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string RuntimeType { get; set; }
    /// <inheritdoc cref="VariableRuntime.Value"/>
    public object Value { get; set; }
    /// <inheritdoc cref="VariableRuntime.RawValue"/>
    public object RawValue { get; set; }
    /// <inheritdoc cref="VariableRuntime.LastSetValue"/>
    public object LastSetValue { get; set; }

    /// <inheritdoc cref="VariableRuntime.ChangeTime"/>
    public DateTime ChangeTime { get; set; }

    /// <inheritdoc cref="VariableRuntime.CollectTime"/>
    public DateTime CollectTime { get; set; }

    /// <inheritdoc cref="VariableRuntime.IsOnline"/>
    public bool IsOnline { get; set; }

    /// <inheritdoc cref="VariableRuntime.DeviceRuntime"/>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [AutoGenerateColumn(Ignore = true)]
    public DeviceBasicData DeviceRuntime { get; set; }

    /// <inheritdoc cref="VariableRuntime.LastErrorMessage"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string? LastErrorMessage { get; set; }
    /// <inheritdoc cref="Variable.RegisterAddress"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string? RegisterAddress { get; set; }

    /// <inheritdoc cref="Variable.Unit"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string? Unit { get; set; }

    /// <inheritdoc cref="Variable.Description"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <inheritdoc cref="Variable.ProtectType"/>
    public ProtectTypeEnum ProtectType { get; set; }

    /// <inheritdoc cref="Variable.DataType"/>
    public DataTypeEnum DataType { get; set; }

    /// <inheritdoc cref="Device.Remark1"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Remark1 { get; set; }

    /// <inheritdoc cref="Device.Remark2"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Remark2 { get; set; }

    /// <inheritdoc cref="Device.Remark3"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Remark3 { get; set; }

    /// <inheritdoc cref="Device.Remark4"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Remark4 { get; set; }

    /// <inheritdoc cref="Device.Remark5"/>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
    public string Remark5 { get; set; }
}


