﻿// ------------------------------------------------------------------------
// 版权信息
// 版权归百小僧及百签科技（广东）有限公司所有。
// 所有权利保留。
// 官方网站：https://baiqian.com
//
// 许可证信息
// 项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。
// 许可证的完整文本可以在源代码树根目录中的 LICENSE-APACHE 和 LICENSE-MIT 文件中找到。
// ------------------------------------------------------------------------

namespace ThingsGateway.Shapeless;

/// <summary>
///     流变对象事件委托
/// </summary>
public delegate void ClayEventHandler(dynamic sender, ClayEventArgs args);

/// <summary>
///     流变对象
/// </summary>
public partial class Clay
{
    /// <summary>
    ///     数据变更之前事件
    /// </summary>
    public event ClayEventHandler? Changing;

    /// <summary>
    ///     数据变更之后事件
    /// </summary>
    public event ClayEventHandler? Changed;

    /// <summary>
    ///     移除数据之前事件
    /// </summary>
    public event ClayEventHandler? Removing;

    /// <summary>
    ///     移除数据之后事件
    /// </summary>
    public event ClayEventHandler? Removed;

    /// <summary>
    ///     添加事件
    /// </summary>
    /// <param name="eventName">事件名。可选值：Changing、Changed、Removing 和 Removed。</param>
    /// <param name="handler">
    ///     <see cref="ClayEventHandler" />
    /// </param>
    /// <returns>
    ///     <see cref="Clay" />
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    public Clay AddEvent(string eventName, ClayEventHandler handler)
    {
        // 空检查
        ArgumentException.ThrowIfNullOrWhiteSpace(eventName);
        ArgumentNullException.ThrowIfNull(handler);

        switch (eventName)
        {
            case nameof(Changing):
                Changing += handler;
                break;
            case nameof(Changed):
                Changed += handler;
                break;
            case nameof(Removing):
                Removing += handler;
                break;
            case nameof(Removed):
                Removed += handler;
                break;
            default:
                throw new ArgumentException($"Unknown event name: `{eventName}`.", eventName);
        }

        return this;
    }

    /// <summary>
    ///     添加事件
    /// </summary>
    /// <param name="eventName">事件名。可选值：Changing、Changed、Removing 和 Removed。</param>
    /// <param name="handler">
    ///     <see cref="ClayEventHandler" />
    /// </param>
    /// <returns>
    ///     <see cref="Clay" />
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    public Clay AddEvent(string eventName, Action<dynamic, ClayEventArgs> handler) =>
        AddEvent(eventName, new ClayEventHandler(handler));

    /// <summary>
    ///     触发数据变更之前事件
    /// </summary>
    /// <param name="identifier">标识符，可以是键（字符串）或索引（整数）或索引运算符（Index）或范围运算符（Range）</param>
    internal void OnChanging(object identifier) => TryInvoke(Changing, identifier);

    /// <summary>
    ///     触发数据变更之后事件
    /// </summary>
    /// <param name="identifier">标识符，可以是键（字符串）或索引（整数）或索引运算符（Index）或范围运算符（Range）</param>
    internal void OnChanged(object identifier) => TryInvoke(Changed, identifier);

    /// <summary>
    ///     触发移除数据之前事件
    /// </summary>
    /// <param name="identifier">标识符，可以是键（字符串）或索引（整数）或索引运算符（Index）或范围运算符（Range）</param>
    internal void OnRemoving(object identifier) => TryInvoke(Removing, identifier);

    /// <summary>
    ///     触发移除数据之后事件
    /// </summary>
    /// <param name="identifier">标识符，可以是键（字符串）或索引（整数）或索引运算符（Index）或范围运算符（Range）</param>
    internal void OnRemoved(object identifier) => TryInvoke(Removed, identifier);

    /// <summary>
    ///     尝试执行事件处理程序
    /// </summary>
    /// <param name="handler">
    ///     <see cref="ClayEventHandler" />
    /// </param>
    /// <param name="identifier">标识符，可以是键（字符串）或索引（整数）或索引运算符（Index）或范围运算符（Range）</param>
    internal void TryInvoke(ClayEventHandler? handler, object identifier)
    {
        // 空检查
        if (handler is null)
        {
            return;
        }

        try
        {
            handler(this, new ClayEventArgs(identifier, Contains(identifier)));
        }
        catch (Exception)
        {
            // ignored
        }
    }
}