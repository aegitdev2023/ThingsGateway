# ThingsGateway

## 介绍

基于net9的跨平台高性能边缘采集网关

## 文档

[文档](https://thingsgateway.cn/)

[NuGet](https://www.nuget.org/packages?q=Tags%3A%22ThingsGateway%22)


## 演示

[ThingsGateway演示地址](https://demo.thingsgateway.cn/)

账户	:  **SuperAdmin**

密码 : **111111**

**右上角个人弹出框中，切换到物联网关模块**

## Docker

```shell

docker pull registry.cn-shenzhen.aliyuncs.com/thingsgateway/thingsgateway

docker pull registry.cn-shenzhen.aliyuncs.com/thingsgateway/thingsgateway_arm64
```


### 插件列表

#### 采集插件


| 插件名称    | 备注                                  |
| ----------- | ------------------------------------- |
| Modbus      | Rtu/Tcp报文格式，支持串口/Tcp/Udp链路 |
| SiemensS7   | 西门子PLC S7系列                      |
| Dlt6452007  | 支持串口/Tcp/Udp链路                  |
| OpcDaMaster | 64位编译                              |
| OpcUaMaster | 支持证书登录，扩展对象，Json读写      |

#### 业务插件


| 插件名称         | 备注                                                       |
| ---------------- | ---------------------------------------------------------- |
| ModbusSlave      | Rtu/Tcp报文格式，支持串口/Tcp/Udp链路，支持Rpc反写         |
| OpcUaServer      | OpcUa服务端，支持Rpc反写                                   |
| MqttClient       | Mqtt客户端，支持Rpc反写，脚本自定义上传内容                |
| MqttServer       | Mqtt服务端，支持WebSocket，支持Rpc反写，脚本自定义上传内容 |
| KafkaProducer    | 脚本自定义上传内容                                         |
| RabbitMQProducer | 脚本自定义上传内容                                         |
| SqlDB            | 关系数据库存储，支持历史存储和实时数据更新                 |
| SqlHistoryAlarm      | 报警历史数据关系数据库存储                                 |
| TDengineDB       | 时序数据库存储                                             |
| QuestDB          | 时序数据库存储                                             |
| Webhook          | Webhook                                             |

## 协议

[版权声明](https://thingsgateway.cn/docs/1)


## 赞助

[赞助途径](https://thingsgateway.cn/docs/1000)

## 社区

QQ群：605534569 [跳转](http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=NnBjPO-8kcNFzo_RzSbdICflb97u2O1i&authKey=V1MI3iJtpDMHc08myszP262kDykbx2Yev6ebE4Me0elTe0P0IFAmtU5l7Sy5w0jx&noverify=0&group_code=605534569)

## Pro插件

[插件列表](https://thingsgateway.cn/docs/1001)


## 特别声明

ThingsGateway 项目已加入 [dotNET China](https://gitee.com/dotnetchina)  组织。<br/>

![dotnetchina](https://gitee.com/dotnetchina/home/raw/master/assets/dotnetchina-raw.png "dotNET China LOGO")