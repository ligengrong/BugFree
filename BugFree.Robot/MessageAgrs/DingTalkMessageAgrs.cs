namespace BugFree.Robot.MessageAgrs
{
    /// <summary>
    /// 消息实体
    /// https://open.dingtalk.com/document/orgapp/custom-robots-send-group-messages?spm=ding_open_doc.document.0.0.24e34a97QDJa8P
    /// </summary>
    public class DingTalkMessageAgrs : IMessageAgrs
    {
        /// <summary>
        /// 消息类型 text、link、markdown、actionCard、feedCard
        /// </summary>
        public string? msgtype { get; set; } = "text";
        /// <summary>文本类型消息</summary>
        public Text? text { get; set; }
        /// <summary>被@的群成员信息</summary>
        public At? at { get; set; }
        /// <summary>链接类型消息</summary>
        public Link? link { get; set; }
        /// <summary>markdown类型消息</summary>
        public Markdown? markdown { get; set; }
        /// <summary>actionCard类型消息</summary>
        public ActionCard? actionCard { get; set; }
        /// <summary>feedCard类型消息</summary>
        public FeedCard? feedCard { get; set; }
        public class Text
        {
            /// <summary>文本消息的内容</summary>
            public string? content { get; set; }
        }

        public class At
        {
            /// <summary>是否@所有人</summary>
            public bool isAtAll { get; set; }
            /// <summary>被@的群成员手机号</summary>
            public IList<string>? atMobiles { get; set; }
            /// <summary>被@的群成员userId</summary>
            public IList<string>? atUserIds { get; set; }
        }

        public class FeedCardLink
        {
            /// <summary>点击消息跳转的URL</summary>
            public string? messageUrl { get; set; }
            /// <summary>链接消息标题</summary>
            public string? title { get; set; }
            /// <summary>链接消息内的图片地址，建议使用上传媒体文件接口获取</summary>
            public string? picUrl { get; set; }
        }
        public class Link : FeedCardLink
        {
            /// <summary>链接消息的内容</summary>
            public string? text { get; set; }
        }

        public class Markdown
        {
            /// <summary>消息会话列表中展示的标题，非消息体的标题</summary>
            public string? title { get; set; }
            /// <summary>markdown类型消息的文本内容</summary>
            public string? text { get; set; }
        }

        public class ActionCard
        {
            /// <summary>
            /// 是否显示消息发送者头像。
            /// 0：正常发消息者头像
            /// 1：隐藏发消息者头像
            /// </summary>
            public string? hideAvatar { get; set; }
            /// <summary>
            /// 消息内按钮排列方式。
            /// 0：按钮竖直排列
            /// 1：按钮横向排列
            /// </summary>
            public string? btnOrientation { get; set; }
            /// <summary>单个按钮的方案。(设置此项和singleURL后btns无效。)</summary>
            public string? singleTitle { get; set; }
            /// <summary>点击singleTitle按钮触发的URL</summary>
            public string? singleURL { get; set; }
            /// <summary>消息会话列表中展示的标题，非消息体的标题</summary>
            public string? title { get; set; }
            /// <summary>actionCard类型消息的正文内容，支持markdown语法</summary>
            public string? text { get; set; }
            /// <summary>按钮的信息列表</summary>
            public IList<Btn>? btns { get; set; }

            public class Btn
            {
                /// <summary>按钮上显示的文本</summary>
                public string? title { get; set; }
                /// <summary>按钮跳转的URL</summary>
                public string? actionURL { get; set; }
            }
        }
        /// <summary>feedCard类型消息</summary>
        public class FeedCard
        {
            /// <summary>feedCard消息的内容列表</summary>
            public IList<FeedCardLink>? links { get; set; }
        }
    }
}
