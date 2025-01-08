namespace BugFree.Robot.MessageAgrs
{
    /// <summary>
    /// 消息实体
    /// https://developer.work.weixin.qq.com/document/path/99110
    /// </summary>
    public class WeiXinMessageAgrs : IMessageAgrs
    {
        /// <summary>消息类型，text、markdown、image、news、file、voice、template_card</summary>
        public string msgtype { get; set; } = "text";
        /// <summary>文本信息实体</summary>
        public Text? text { get; set; }
        /// <summary>markdown信息实体</summary>
        public Markdown? markdown { get; set; }
        /// <summary>image信息实体</summary>
        public Image? image { get; set; }
        /// <summary>图文信息实体</summary>
        public News? news { get; set; }
        /// <summary>file信息实体</summary>
        public MsgFile? file { get; set; }
        /// <summary>语音类型</summary>
        public MsgFile? voice { get; set; }
        /// <summary>文本通知模版卡片</summary>
        public TemplateCard? template_card { get; set; }
        public class Text
        {
            /// <summary>文本内容，最长不超过2048个字节，必须是utf8编码</summary>
            public string? content { get; set; }
            /// <summary>userid的列表，提醒群中的指定成员(@某个成员)，@all表示提醒所有人，如果开发者获取不到userid，可以使用mentioned_mobile_list</summary>
            public IList<string>? mentioned_list { get; set; }
            /// <summary>userid的列表，提醒群中的指定成员(@某个成员)，@all表示提醒所有人，如果开发者获取不到userid，可以使用mentioned_mobile_list</summary>
            public IList<string>? mentioned_mobile_list { get; set; }
        }

        public class Markdown
        {
            /// <summary>markdown内容，最长不超过4096个字节，必须是utf8编码</summary>
            public string? content { get; set; }
        }

        public class Image
        {
            /// <summary>图片内容的base64编码 注：图片（base64编码前）最大不能超过2M，支持JPG,PNG格式</summary>
            public string? base64 { get; set; }
            /// <summary>图片内容（base64编码前）的md5值</summary>
            public string md5 { get; set; }
        }

        public class News
        {
            public IList<Article>? articles { get; set; }

            public class Article
            {
                /// <summary>标题，不超过128个字节，超过会自动截断</summary>
                public string? title { get; set; }
                /// <summary>描述，不超过512个字节，超过会自动截断</summary>
                public string? description { get; set; }
                /// <summary>点击后跳转的链接</summary>
                public string? url { get; set; }
                /// <summary>图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图 1068*455，小图150*150</summary>
                public string? picurl { get; set; }
            }
        }

        public class MsgFile
        {
            /// <summary>文件id，通过文件上传接口获取</summary>
            public string? media_id { get; set; }
        }

        public class TemplateCard
        {
            /// <summary>模版卡片的模版类型</summary>
            public string? card_type { get; set; }
            /// <summary>卡片来源样式信息，不需要来源样式可不填写</summary>
            public Source? source { get; set; }
            /// <summary>模版卡片的主要内容，包括一级标题和标题辅助信息</summary>
            public MainTitle? main_title { get; set; }
            /// <summary>图片样式</summary>
            public CardImage? card_image { get; set; }
            /// <summary>左图右文样式</summary>
            public ImageTextArea? image_text_area { get; set; }
            /// <summary>关键数据样式</summary>
            public EmphasisContent? emphasis_content { get; set; }
            /// <summary>引用文献样式，建议不与关键数据共用</summary>
            public QuoteArea? quote_area { get; set; }
            /// <summary>二级普通文本，建议不超过112个字。模版卡片主要内容的一级标题main_title.title和二级普通文本sub_title_text必须有一项填写</summary>
            public string? sub_title_text { get; set; }
            /// <summary>二级标题+文本列表，该字段可为空数组，但有数据的话需确认对应字段是否必填，列表长度不超过6</summary>
            public IList<HorizontalContentList>? horizontal_content_list { get; set; }
            /// <summary>跳转指引样式的列表，该字段可为空数组，但有数据的话需确认对应字段是否必填，列表长度不超过3</summary>
            public IList<JumpList>? jump_list { get; set; }
            /// <summary>整体卡片的点击跳转事件，text_notice模版卡片中该字段为必填项</summary>
            public CardAction? card_action { get; set; }
            public class Source
            {
                /// <summary>来源图片的url</summary>
                public string? icon_url { get; set; }
                /// <summary>来源图片的描述，建议不超过13个字</summary>
                public string? desc { get; set; }
                /// <summary>来源文字的颜色，目前支持：0(默认) 灰色，1 黑色，2 红色，3 绿色</summary>
                public int desc_color { get; set; } = 0;
            }

            public class MainTitle
            {
                /// <summary>一级标题，建议不超过26个字。模版卡片主要内容的一级标题main_title.title和二级普通文本sub_title_text必须有一项填写</summary>
                public string? title { get; set; }
                /// <summary>标题辅助信息，建议不超过30个字</summary>
                public string? desc { get; set; }
            }

            public class EmphasisContent
            {
                /// <summary>关键数据样式的数据内容，建议不超过10个字</summary>
                public string? title { get; set; }
                /// <summary>关键数据样式的数据描述内容，建议不超过15个字</summary>
                public string? desc { get; set; }
            }

            public class QuoteArea
            {
                /// <summary>引用文献样式区域点击事件，0或不填代表没有点击事件，1 代表跳转url，2 代表跳转小程序</summary>
                public int type { get; set; }
                /// <summary>点击跳转的小程序的appid，quote_area.type是2时必填</summary>
                public string? appid { get; set; }
                /// <summary>点击跳转的url，quote_area.type是1时必填</summary>
                public string? url { get; set; }
                /// <summary>点击跳转的小程序的pagepath，quote_area.type是2时选填</summary>
                public string? pagepath { get; set; }
                /// <summary>引用文献样式的标题</summary>
                public string? title { get; set; }
                /// <summary>引用文献样式的引用文案</summary>
                public string? quote_text { get; set; }
            }

            public class HorizontalContentList
            {
                /// <summary>模版卡片的二级标题信息内容支持的类型，1是url，2是文件附件，3 代表点击跳转成员详情</summary>
                public int type { get; set; }
                /// <summary>二级标题，建议不超过5个字</summary>
                public string? keyname { get; set; }
                /// <summary>二级文本，如果horizontal_content_list.type是2，该字段代表文件名称（要包含文件类型），建议不超过26个字</summary>
                public string? value { get; set; }
                /// <summary>附件的media_id，horizontal_content_list.type是2时必填</summary>
                public string? media_id { get; set; }
                /// <summary>链接跳转的url，horizontal_content_list.type是1时必填</summary>
                public string? url { get; set; }
                /// <summary>成员详情的userid，horizontal_content_list.type是3时必填</summary>
                public string? userid { get; set; }
            }

            public class JumpList
            {
                /// <summary>跳转链接类型，0或不填代表不是链接，1 代表跳转url，2 代表跳转小程序</summary>
                public int type { get; set; }
                /// <summary>跳转链接的url，jump_list.type是1时必填</summary>
                public string? url { get; set; }
                /// <summary>跳转链接的小程序的appid，jump_list.type是2时必填</summary>
                public string? appid { get; set; }
                /// <summary>跳转链接的小程序的pagepath，jump_list.type是2时选填</summary>
                public string? pagepath { get; set; }
                /// <summary>跳转链接样式的文案内容，建议不超过13个字</summary>
                public string? title { get; set; }
            }

            public class CardAction
            {
                /// <summary>卡片跳转类型，1 代表跳转url，2 代表打开小程序。text_notice模版卡片中该字段取值范围为[1,2]</summary>
                public int type { get; set; }
                /// <summary>跳转事件的url，card_action.type是1时必填</summary>
                public string? url { get; set; }
                /// <summary>跳转事件的小程序的appid，card_action.type是2时必填</summary>
                public string? appid { get; set; }
                /// <summary>跳转事件的小程序的pagepath，card_action.type是2时选填</summary>
                public string? pagepath { get; set; }
            }

            public class CardImage
            {
                /// <summary>图片的url</summary>
                public string? url { get; set; }
                /// <summary>图片的宽高比，宽高比要小于2.25，大于1.3，不填该参数默认1.3</summary>
                public float aspect_ratio { get; set; } = 1.3f;
            }

            public class ImageTextArea
            {
                /// <summary>左图右文样式区域点击事件，0或不填代表没有点击事件，1 代表跳转url，2 代表跳转小程序</summary>
                public int type { get; set; }
                /// <summary>点击跳转的url，image_text_area.type是1时必填</summary>
                public string? url { get; set; }
                /// <summary>点击跳转的小程序的appid，必须是与当前应用关联的小程序，image_text_area.type是2时必填</summary>
                public string? appid { get; set; }
                /// <summary>点击跳转的小程序的pagepath，image_text_area.type是2时选填</summary>
                public string? pagepath { get; set; }
                /// <summary>左图右文样式的标题</summary>
                public string? title { get; set; }
                /// <summary>左图右文样式的描述</summary>
                public string? desc { get; set; }
                /// <summary>左图右文样式的图片url</summary>
                public string? image_url { get; set; }
            }
        }
    }
}
