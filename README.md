## 概述
扩展 [Consul](https://github.com/G-Research/consuldotnet)，程序启动前，注入 Consul 客户端到 Asp.Net Core 容器。

## 安装
```xml
<PackageReference Include="NXHub.Consul.AspNetCore" Version="0.0.1" />
```

## 使用
```cs
public void ConfigureServices(IServiceCollection services)
{
    // ...

    // 1. 默认，连接本地 8500 端口
    services.AddConsulClient();

    // 2. 自定义配置
    services.AddConsulClient(options =>
    {
        options.Address = new Uri("http://other:8500");
    });
}
```
