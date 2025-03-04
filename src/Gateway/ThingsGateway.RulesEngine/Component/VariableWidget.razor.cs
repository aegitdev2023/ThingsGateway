// ------------------------------------------------------------------------------
// �˴����Ȩ����Ϊȫ�ļ����ǣ�����ԭ�����ر������������·��ֶ�����
// �˴����Ȩ�����ر�������Ĵ��룩�����߱���Diego����
// Դ����ʹ��Э����ѭ���ֿ�Ŀ�ԴЭ�鼰����Э��
// GiteeԴ����ֿ⣺https://gitee.com/diego2098/ThingsGateway
// GithubԴ����ֿ⣺https://github.com/kimdiego2098/ThingsGateway
// ʹ���ĵ���https://thingsgateway.cn/
// QQȺ��605534569
// ------------------------------------------------------------------------------

using ThingsGateway.Extension.Generic;
using ThingsGateway.Gateway.Application;
using ThingsGateway.NewLife.Extension;

namespace ThingsGateway.RulesEngine
{
    public partial class VariableWidget
    {
        [Inject]
        IStringLocalizer<ThingsGateway.RulesEngine._Imports> Localizer { get; set; }

        [Parameter]
        public VariableNode Node { get; set; }

        private static async Task<QueryData<SelectedItem>> OnRedundantDevicesQuery(VirtualizeQueryOption option)
        {
            var ret = new QueryData<SelectedItem>()
            {
                IsSorted = false,
                IsFiltered = false,
                IsAdvanceSearch = false,
                IsSearch = !option.SearchText.IsNullOrWhiteSpace()
            };

            var devices = await GlobalData.GetCurrentUserDevices().ConfigureAwait(false);
            var items = devices.WhereIf(!option.SearchText.IsNullOrWhiteSpace(), a => a.Value.Name.Contains(option.SearchText)).Select(a => a.Value).Take(20)
               .Select(a => new SelectedItem(a.Name, a.Name));

            ret.TotalCount = items.Count();
            ret.Items = items;
            return ret;
        }
        private async Task<QueryData<SelectedItem>> OnRedundantVariablesQuery(VirtualizeQueryOption option)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            var ret = new QueryData<SelectedItem>()
            {
                IsSorted = false,
                IsFiltered = false,
                IsAdvanceSearch = false,
                IsSearch = !option.SearchText.IsNullOrWhiteSpace()
            };

            if (GlobalData.ReadOnlyDevices.TryGetValue(Node.DeviceText, out var device))
            {
                var items = device.ReadOnlyIdVariableRuntimes.WhereIf(!option.SearchText.IsNullOrWhiteSpace(), a => a.Value.Name.Contains(option.SearchText)).Select(a => a.Value).Take(20)
                   .Select(a => new SelectedItem(a.Name, a.Name));

                ret.TotalCount = items.Count();
                ret.Items = items;
                return ret;
            }
            else
            {
                ret.TotalCount = 0;
                ret.Items = new List<SelectedItem>();
                return ret;
            }
        }


    }
}