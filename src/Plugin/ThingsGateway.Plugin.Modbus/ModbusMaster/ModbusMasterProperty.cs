﻿//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://thingsgateway.cn/
//  QQ群：605534569
//------------------------------------------------------------------------------

using ThingsGateway.Foundation.Modbus;
using ThingsGateway.Gateway.Application;


namespace ThingsGateway.Plugin.Modbus;

/// <summary>
/// <inheritdoc/>
/// </summary>
public class ModbusMasterProperty : CollectPropertyBase
{
    [DynamicProperty]
    public ModbusTypeEnum ModbusType { get; set; }

    /// <summary>
    /// 默认站号
    /// </summary>
    [DynamicProperty]
    public byte Station { get; set; } = 1;

    /// <summary>
    /// 默认DtuId
    /// </summary>
    [DynamicProperty]
    public string? DtuId { get; set; } = "DtuId";

    /// <summary>
    /// 默认解析顺序
    /// </summary>
    [DynamicProperty]
    public DataFormatEnum DataFormat { get; set; }

    /// <summary>
    /// 读写超时时间
    /// </summary>
    [DynamicProperty]
    public ushort Timeout { get; set; } = 3000;

    /// <summary>
    /// 发送延时ms
    /// </summary>
    [DynamicProperty]
    public int SendDelayTime { get; set; } = 0;


    /// <summary>
    /// 最大打包长度
    /// </summary>
    [DynamicProperty]
    public ushort MaxPack { get; set; } = 100;

    [DynamicProperty]
    public bool IsStringReverseByteWord { get; set; }

}
