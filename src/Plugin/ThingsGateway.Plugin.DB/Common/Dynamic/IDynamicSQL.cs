﻿//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://thingsgateway.cn/
//  QQ群：605534569
//------------------------------------------------------------------------------

using SqlSugar;

namespace ThingsGateway.Plugin.DB;

public abstract class DynamicSQLBase
{
    public TouchSocket.Core.ILog Logger { get; set; }

    /// <summary>
    /// 建库建表
    /// </summary>
    /// <returns></returns>
    public virtual Task DBInit(ISqlSugarClient db, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// 完全自定义上传
    /// </summary>
    /// <returns></returns>
    public virtual Task DBInsertable(ISqlSugarClient db, IEnumerable<object> datas, CancellationToken cancellationToken)
    {
        throw new NotSupportedException();
    }
}
