namespace BugFree.Robot.MessageAgrs
{
    /// <summary>
    /// 消息实体
    /// 机器人每分钟最多发送30条消息到群里，超过后会限流1分钟
    /// https://open.welink.huaweicloud.com/docs/#/990hh0/whokyc/mmkx2n
    /// </summary>
    public class WeLinkMessageAgrs : IMessageAgrs
    {
        /// <summary>消息类型 text</summary>
        public string messageType => "text";
        /// <summary>文本类型消息</summary>
        public Content? content { get; set; }
        /// <summary>时间戳（10分钟内有效），请使用毫秒</summary>
        public long timeStamp { get; set; }
        /// <summary>UUID字段全局唯一，接口调用前需要重新生成UUID</summary>
        public string? uuid { get; set; }
        /// <summary>是否@某个人</summary>
        public bool isAt { get; set; }
        /// <summary>是否@全员</summary>
        public bool IsAtAll { get; set; }
        /// <summary>被@人员的userid列表（当isAt为true时不能为空，且最多只支持50个账号）。注意：传入错误的userid将无法收到消息</summary>
        public IList<string>? atAccounts { get; set; }

        /// <summary>文本类型消息</summary>
        public class Content
        {
            /// <summary>消息文本内容，内容长度范围（1~500）</summary>
            public string? text { get; set; }
        }
    }
}
