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

using System.Text;

using ThingsGateway.Foundation;
using ThingsGateway.NewLife.Extension;

namespace ThingsGateway.Plugin.Webhook;

/// <summary>
/// WebhookClient
/// </summary>
public partial class Webhook : BusinessBaseWithCacheIntervalScript<VariableBasicData, DeviceBasicData, AlarmVariable>
{

    protected override void AlarmChange(AlarmVariable alarmVariable)
    {
        if (!_businessPropertyWithCacheIntervalScript.AlarmTopic.IsNullOrWhiteSpace())
            AddQueueAlarmModel(new(alarmVariable));
        base.AlarmChange(alarmVariable);
    }



    protected override void DeviceTimeInterval(DeviceRuntime deviceRunTime, DeviceBasicData deviceData)
    {

        if (!_businessPropertyWithCacheIntervalScript.DeviceTopic.IsNullOrWhiteSpace())
            AddQueueDevModel(new(deviceData));

        base.DeviceChange(deviceRunTime, deviceData);
    }
    protected override void DeviceChange(DeviceRuntime deviceRunTime, DeviceBasicData deviceData)
    {


        if (!_businessPropertyWithCacheIntervalScript.DeviceTopic.IsNullOrWhiteSpace())
            AddQueueDevModel(new(deviceData));

        base.DeviceChange(deviceRunTime, deviceData);
    }

    protected override ValueTask<OperResult> UpdateAlarmModel(IEnumerable<CacheDBItem<AlarmVariable>> item, CancellationToken cancellationToken)
    {
        return UpdateAlarmModel(item.Select(a => a.Value).OrderBy(a => a.Id), cancellationToken);
    }

    protected override ValueTask<OperResult> UpdateDevModel(IEnumerable<CacheDBItem<DeviceBasicData>> item, CancellationToken cancellationToken)
    {


        return UpdateDevModel(item.Select(a => a.Value).OrderBy(a => a.Id), cancellationToken);
    }

    protected override ValueTask<OperResult> UpdateVarModel(IEnumerable<CacheDBItem<VariableBasicData>> item, CancellationToken cancellationToken)
    {
        return UpdateVarModel(item.Select(a => a.Value).OrderBy(a => a.Id), cancellationToken);
    }

    protected override void VariableTimeInterval(VariableRuntime variableRuntime, VariableBasicData variable)
    {
        if (!_businessPropertyWithCacheIntervalScript.VariableTopic.IsNullOrWhiteSpace())
            AddQueueVarModel(new(variable));
        base.VariableChange(variableRuntime, variable);
    }
    protected override void VariableChange(VariableRuntime variableRuntime, VariableBasicData variable)
    {
        if (!_businessPropertyWithCacheIntervalScript.VariableTopic.IsNullOrWhiteSpace())
            AddQueueVarModel(new(variable));
        base.VariableChange(variableRuntime, variable);
    }

    private readonly HttpClient client = new HttpClient();

    private async Task<OperResult> WebhookUpAsync(string topic, string json, int count, CancellationToken cancellationToken)
    {

        // 设置请求内容
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            // 发送POST请求
            HttpResponseMessage response = await client.PostAsync(topic, content, cancellationToken).ConfigureAwait(false);

            // 检查响应状态
            if (response.IsSuccessStatusCode)
            {
                if (_driverPropertys.DetailLog)
                {
                    if (LogMessage.LogLevel <= TouchSocket.Core.LogLevel.Trace)
                        LogMessage.LogTrace($"Topic：{topic}{Environment.NewLine}PayLoad：{json} {Environment.NewLine} VarModelQueue:{_memoryVarModelQueue.Count}");
                }
                else
                {
                    LogMessage.LogTrace($"Topic：{topic}{Environment.NewLine}Count：{count} {Environment.NewLine} VarModelQueue:{_memoryVarModelQueue.Count}");

                }
                return new();
            }
            else
            {
                return new($"Failed to trigger webhook. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            return new(ex);
        }

    }

    #region private

    private async ValueTask<OperResult> Update(List<TopicJson> topicJsonList, int count, CancellationToken cancellationToken)
    {
        foreach (var topicJson in topicJsonList)
        {
            var result = await WebhookUpAsync(topicJson.Topic, topicJson.Json, count, cancellationToken).ConfigureAwait(false);
            if (cancellationToken.IsCancellationRequested)
                return result;
            if (success != result.IsSuccess)
            {
                if (!result.IsSuccess)
                {
                    LogMessage.LogWarning(result.ToString());
                }
                success = result.IsSuccess;
            }
            if (!result.IsSuccess)
            {
                return result;
            }
        }
        return OperResult.Success;
    }



    private ValueTask<OperResult> UpdateAlarmModel(IEnumerable<AlarmVariable> item, CancellationToken cancellationToken)
    {
        List<TopicJson> topicJsonList = GetAlarms(item);
        return Update(topicJsonList, item.Count(), cancellationToken);
    }

    private ValueTask<OperResult> UpdateDevModel(IEnumerable<DeviceBasicData> item, CancellationToken cancellationToken)
    {

        List<TopicJson> topicJsonList = GetDeviceData(item);
        return Update(topicJsonList, item.Count(), cancellationToken);
    }

    private ValueTask<OperResult> UpdateVarModel(IEnumerable<VariableBasicData> item, CancellationToken cancellationToken)
    {
        List<TopicJson> topicJsonList = GetVariableBasicData(item);
        return Update(topicJsonList, item.Count(), cancellationToken);
    }

    #endregion private



}
