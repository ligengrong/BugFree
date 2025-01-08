using BugFree.Robot.MessageAgrs;

using NewLife.Log;
using NewLife.Remoting;

namespace BugFree.Robot
{
    /// <summary>Robot服务类</summary>
    public class RobotService
    {
        /// <summary>性能追踪</summary>
        protected ITracer? Tracer { get; set; } = DefaultTracer.Instance;
        HttpClient? _Client;
        Task<Object?> PostAsync(string webhook, Object agrs)
        {
            _Client ??= Tracer.CreateHttpClient();
            return _Client.PostAsync<Object>(webhook, agrs);
        }

        /// <summary>发送消息</summary>
        public virtual Task Send(string webhook, IMessageAgrs? agrs)
        {
            if (agrs is not null && !string.IsNullOrWhiteSpace(webhook))
            {
                if ((webhook.Contains("qyapi.weixin") && (agrs is WeiXinMessageAgrs)) ||
                   (webhook.Contains("oapi.dingtalk") && (agrs is DingTalkMessageAgrs)) ||
                   (webhook.Contains("open.welink") && (agrs is WeLinkMessageAgrs))) { PostAsync(webhook, agrs).ConfigureAwait(false); }
                else { throw new Exception("消息类型与webhook不匹配"); }
            }
            return Task.CompletedTask;
        }
        /// <summary>发送消息</summary>
        public virtual Task Send(MessageSendType sendType, string token, IMessageAgrs? agrs)
        {
            if (agrs is null && !string.IsNullOrWhiteSpace(token))
            {
                Send(sendType switch
                {
                    MessageSendType.WeLink => $"https://open.welink.huaweicloud.com/api/werobot/v1/webhook/send?token={token}&channel=standard",
                    MessageSendType.DingTalk => $"https://oapi.dingtalk.com/robot/send?access_token={token}",
                    MessageSendType.QyWeiXin => $"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={token}",
                    MessageSendType.FeiShu => $"https://open.feishu.cn/open-apis/bot/v2/hook/{token}",
                    _ => throw new Exception("未知的消息类型")
                }, agrs);
            }
            return Task.CompletedTask;
        }
    }

    /// <summary>消息类型</summary>
    public enum MessageSendType
    {
        /// <summary>企业微信</summary>
        QyWeiXin,
        /// <summary>钉钉</summary>
        DingTalk,
        /// <summary>WeLink</summary>
        WeLink,
        /// <summary>飞书</summary>
        FeiShu
    }
}
