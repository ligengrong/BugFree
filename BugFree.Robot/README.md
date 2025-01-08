# BugFree.Robot

#### 介绍
企业微信、钉钉、WeLink机器人对接SDK<br>
注：WeLink只支持文本消息

#### 使用说明
```cs
var robot = new RobotService();
//WeLink
robot.Send("https://open.welink.huaweicloud.com/api/werobot/v1/webhook/send?token=*******&channel=standard", new WeLinkMessageAgrs {
    content = new WeLinkMessageAgrs.Content { text = "测试消息" },
    timeStamp = DateTime.Now.ToLong(),
    uuid = Guid.NewGuid().ToString("N"),
    isAt = false,
    IsAtAll = true,
});
//企业微信
robot.Send("https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key=*******", new WeiXinMessageAgrs
{
    msgtype = "text",
    text = new WeiXinMessageAgrs.Text
    {
        content = "测试消息",
        mentioned_list = new List<string> { "@all" },
    }
});
//钉钉
robot.Send("https://oapi.dingtalk.com/robot/send?access_token=*******", new DingTalkMessageAgrs
{
    msgtype = "text",
    text = new DingTalkMessageAgrs.Text
    {
        content = "测试消息",
    },
    at = new DingTalkMessageAgrs.At { isAtAll = true }
});
```
##### 贡献
欢迎贡献代码、报告问题和提供建议！请在 Gitee/GitHub 项目中提交 Issue 或 Pull Request。

##### 许可
本项目基于 MIT 许可进行分发和使用。详细信息请查阅 LICENSE 文件。

##### 作者
作者：荣少<br>
邮箱：ligengrong@hotmail.com<br>
QQ群：7405133

##### 🏅开源地址
[![Github](https://shields.io/badge/Github-https://github.com/ligengrong/BugFree-green?logo=github&style=flat&logoColor=red)](https://github.com/ligengrong/BugFree)<br/>
