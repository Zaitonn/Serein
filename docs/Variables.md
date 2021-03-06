## 变量列表
### 食用方法
在执行命令的文本中插入`%变量名%` 即可 （**不区分大小写**）
>例子：  
`现在是%DateTime%`→`现在是2022/1/1 20:00:00`

### Serein变量

| 变量名 | 描述 | 例子 |  
| --- | --- | --- |
| SereinVersion | 当前版本 | `v1.2.3` | 

### 日期变量

| 变量名 | 描述 | 例子 |  
| --- | --- | --- |
| DateTime | 当前日期与时间 | `2022/1/1 20:00:00` | 
| Date | 当前日期 | `2022/1/1` | 
| Time | 当前时间 | `20:00:00` | 
| DayOfWeek | 星期 | `Tuesday` | 
| Year | 年（1-9999） | `2022` | 
| Month | 月（1-12） | `1` | 
| Day | 日（1-31） | `1` | 
| Hour | 时（0-24） | `20` | 
| Minute | 分钟（0-59） | `0` | 
| Second | 秒（0-59） | `0` | 

### 系统变量

| 变量名 | 描述 | 例子 |  
| --- | --- | --- |
| NET |  当前NET版本 | `4.0.30319.42000` |  
| OS | 操作系统名称 | `Microsoft Windows 10 家庭版` |  
| CPUName | CPU名称 | `Intel(R) Core(TM) i5-1035G4 CPU @ 1.10GHz` |  
| TotalRAM | 总内存（MB） | `7778` |  
| UsedRAM | 已用内存（MB) | `6072` |  
| RAMPercentage | 内存占用率 | `78.1` |  
| CPUPercentage | CPU占用率 | `11.4` | 


### 服务器变量

>#### ⚠ 提示
> 以下几种情况除`Status`可能会返回`-`  
> - 服务器不在运行
> - `settings/Matches.json`设置有误，无法捕捉消息

| 变量名 | 描述 | 例子 |  
| --- | --- | --- |
| Status | 运行状态 | `已启动` `未启动` |
| LevelName | 存档名称 | `Bedrock level` |
| Version | 服务端版本 | `1.18.33.02` |
| Difficulty | 难度 | `Normal` |
| RunTime | 运行时间 | `1.4m` `2.0h` `3.23d` |
| Percentage | **服务器进程**CPU占用率 | `23.4` |  


### 服务器Motd变量

>#### ⭐ Tips 
>使用以下变量前请确保设置中的服务器类型和本地端口与实际一致

>#### ⚠ 提示
> - 以下几种情况可能会返回`-`
>   - 除了[事件](Event.md)中的变量：
>       - 服务器类型设置不正确
>       - 本地端口设置错误
>   - 服务器不在运行
> - 其中
>   - `GameMode`仅适用于基岩版服务器（Java服务器无法获取游戏模式）
>   - `Favicon`仅适用于Java服务器（基岩版服务器不支持设置图标）
>   - Java服务器的`Original`可能很长很长，直接输出到控制台或机器人可能会导致`Serein`卡死
>   - 对于本地的服务器`Delay`可以获取但是没有实际意义 ~~你搁这原地tp呢~~
>   - `Delay`保留两位小数

| 变量名 | 描述 | 例子 |  
| --- | --- | --- |
| MaxPlayer | 最大玩家数 | `10` |  
| OnlinePlayer | 当前玩家数 | `0` |  
| Description | 服务器介绍 | `Dedicated Server` |  
| Version | 版本 | `1.19.1` |
| Protocol | 协议版本 | `527` |  
| GameMode | 游戏模式 | `Survival` |  
| Delay | 延迟(ms)| `20.22` |
| Favicon | 图标 | ![favicon.png](imgs/favicon.png) ![favicon_hypixel.png](imgs/favicon_hypixel.png) ![favicon_mcol.png](imgs/favicon_mcol.png)*👈仅供参考*|
| Original | Motd原文 | `MCPE;Dedicated Server;527;1.19.1;0;10;10904212759644275432;Bedrock level;Survival;1;19132;19133;` |  

### 成员管理变量

>#### ⚠ 提示
> `<GameID>`、`<ID>`对象未找到时返回`null`或`unknown`

| 变量名 | 描述 | 例子 |  
| --- | --- | --- |
| ID:`<GameID>` | 获取绑定的游戏ID对应的ID | `114514` |
| GameID | 获取当前账号对应的游戏ID | `Default` |
| GameID:`<ID>` | 获取绑定的用户ID对应的游戏ID | `Zaitonn` |

### 消息变量（私聊）

>#### ⚠ 提示
> 若非消息触发的命令使用以下变量可能**返回空值或保留原文**   

| 变量名 | 描述 | 例子 |  
| --- | --- | --- |
| Age | 年龄（来自资料页） | `20`   |
| ID | 发送者 QQ 号 | `114514`   |
| Nickname | 昵称（来自资料页） | `我是昵称`   |
| Sex | 性别（来自资料页） | `未知` `男` `女`   |

### 消息变量（群聊）

>#### ⚠ 提示
>若非群聊消息触发的命令使用以下变量可能**返回空值或保留原文**    

| 变量名 | 描述 | 例子 |  
| --- | --- | --- |
| Age | 年龄（来自资料页） | `20`   |
| ID | 发送者 QQ 号 | `114514`   |
| Nickname | 成员昵称（来自资料页） | `我是昵称`   |
| Sex | 性别（来自资料页） | `未知` `男` `女`   |
| Area | 地区 | `中国`   |
| Card | 群名片 | `我是群名片`   |
| Level | 成员等级 | _未知_   |
| Title | 专属头衔（群主授予） | `我是专属头衔`   |
| Role | 角色 | `群主` `管理员` `成员`   |
| ShownName | 显示名称（群名片若空则为昵称） | `我是群名片` `我是昵称`   |


  
>参考：[Post_Message_MessageSender](https://docs.go-cqhttp.org/reference/data_struct.html#post-message-messagesender)    


>#### ⚠ 提示
>需要注意的是， 各字段是尽最大努力提供的， 也就是说， **不保证每个字段都一定存在**， **也不保证存在的字段都是完全正确的** ( 缓存可能过期 ) 。尤其对于匿名消息， 此字段**不具有参考价值**。