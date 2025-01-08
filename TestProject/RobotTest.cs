using BugFree.Robot;
using BugFree.Robot.MessageAgrs;

using System.Security.Cryptography;
using System.Text;

namespace TestProject
{
    public class RobotTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WeLinkTest()
        {
            var robot = new RobotService();
            robot.Send("https://open.welink.huaweicloud.com/api/werobot/v1/webhook/send?token=***&channel=standard", new WeLinkMessageAgrs
            {
                content = new WeLinkMessageAgrs.Content
                {
                    text = "测试消息"
                },
                timeStamp = DateTime.Now.ToLong(),
                uuid = Guid.NewGuid().ToString("N"),
                isAt = false,
                IsAtAll = true,
            });
        }
        [Test]
        public void WeiXinTest()
        {
            var robot = new RobotService();
            var webhook = "https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key=***";
            //文本消息
            {
                robot.Send(webhook, new WeiXinMessageAgrs
                {
                    msgtype = "text",
                    text = new WeiXinMessageAgrs.Text
                    {
                        content = "测试消息",
                        mentioned_list = new List<string> { "@all" },
                    }
                });
            }
            //markdown类型
            {
                var content = new StringBuilder();
                content.AppendLine("实时新增用户反馈<font color=\"warning\">132例</font>，请相关同事注意");
                content.AppendLine(">类型:<font color=\"comment\">用户反馈</font>");
                content.AppendLine(">普通用户反馈:<font color=\"comment\">117例</font>");
                content.AppendLine(">VIP用户反馈:<font color=\"comment\">15例</font>");
                robot.Send(webhook, new WeiXinMessageAgrs
                {
                    msgtype = "markdown",
                    markdown = new WeiXinMessageAgrs.Markdown
                    {
                        content = content.ToString(),
                    }
                });
            }
            //图片类型
            {
                var filePath = "img/202201062104.366e5ee28e.png".GetFullPath();
                var bytes = File.ReadAllBytes(filePath);
                using var md5 = MD5.Create();
                using var stream = System.IO.File.OpenRead(filePath);
                byte[] buffer = new byte[8192]; // Buffer size for reading chunks
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    md5.TransformBlock(buffer, 0, bytesRead, buffer, 0);
                }
                md5.TransformFinalBlock(buffer, 0, 0); // Finalize the hash calculation
                var hash = md5.Hash.ToHex();

                robot.Send(webhook, new WeiXinMessageAgrs
                {
                    msgtype = "image",
                    image = new WeiXinMessageAgrs.Image
                    {
                        base64 = Convert.ToBase64String(bytes),
                        md5 = hash,
                    }
                });
            }
            //图文类型
            {
                robot.Send(webhook, new WeiXinMessageAgrs
                {
                    msgtype = "news",
                    news = new WeiXinMessageAgrs.News
                    {
                        articles = new List<WeiXinMessageAgrs.News.Article>
                        {
                            new WeiXinMessageAgrs.News.Article
                            {
                                title = "测试消息",
                                description = "测试消息",
                                url = "https://www.baidu.com",
                                picurl = "https://www.baidu.com/img/PCfb_5bf082d29588c07f842ccde3f97243ea.png",
                            },
                            new WeiXinMessageAgrs.News.Article
                            {
                                title = "测试消息1",
                                description = "测试消息1",
                                url = "https://www.baidu.com",
                                picurl = "https://www.baidu.com/img/PCfb_5bf082d29588c07f842ccde3f97243ea.png",
                            }
                        }
                    }
                });
            }
            //模版卡片类型
            {
                robot.Send(webhook, new WeiXinMessageAgrs
                {
                    msgtype = "template_card",
                    template_card = new WeiXinMessageAgrs.TemplateCard
                    {
                        card_type = "text_notice",
                        source = new WeiXinMessageAgrs.TemplateCard.Source
                        {
                            icon_url = "https://wework.qpic.cn/wwpic/252813_jOfDHtcISzuodLa_1629280209/0",
                            desc = "企业微信",
                            desc_color = 0
                        },
                        main_title = new WeiXinMessageAgrs.TemplateCard.MainTitle
                        {
                            title = "欢迎使用企业微信",
                            desc = "您的好友正在邀请您加入企业微信"
                        },
                        emphasis_content = new WeiXinMessageAgrs.TemplateCard.EmphasisContent
                        {
                            title = "100",
                            desc = "数据含义"
                        },
                        quote_area = new WeiXinMessageAgrs.TemplateCard.QuoteArea
                        {
                            type = 1,
                            title = "引用文本标题",
                            url = "https://work.weixin.qq.com/?from=openApi",
                            quote_text = "Jack：企业微信真的很好用~\nBalian：超级好的一款软件！"
                        },
                        sub_title_text = "下载企业微信还能抢红包！",
                        horizontal_content_list = new List<WeiXinMessageAgrs.TemplateCard.HorizontalContentList>
                        {
                            new WeiXinMessageAgrs.TemplateCard.HorizontalContentList
                            {
                                keyname = "邀请人",
                                value = "黎更荣"
                            },
                            new WeiXinMessageAgrs.TemplateCard.HorizontalContentList
                            {
                                keyname = "企微官网",
                                value = "点击访问",
                                type = 1,
                                url = "https://work.weixin.qq.com/?from=openApi"
                            },
                            new WeiXinMessageAgrs.TemplateCard.HorizontalContentList
                            {
                                keyname = "企微下载",
                                value = "企业微信.apk",
                                type = 1,
                                url = "https://work.weixin.qq.com/?from=openApi"
                            }
                        },
                        jump_list = new List<WeiXinMessageAgrs.TemplateCard.JumpList> {
                            new WeiXinMessageAgrs.TemplateCard.JumpList
                            {
                                type = 1,
                                title = "企业微信官网",
                                url = "https://work.weixin.qq.com/?from=openApi"
                            },
                            new WeiXinMessageAgrs.TemplateCard.JumpList
                            {
                                type = 1,
                                title = "跳转小程序",
                                url = "https://work.weixin.qq.com/?from=openApi"
                            }
                        },
                        card_action = new WeiXinMessageAgrs.TemplateCard.CardAction
                        {
                            type = 1,
                            url = "https://work.weixin.qq.com/?from=openApi",
                        }
                    }
                });
            }
        }
        [Test]
        public void DingTalkTest()
        {
            var robot = new RobotService();
            var webhook = "https://oapi.dingtalk.com/robot/send?access_token=**";
            //文本消息
            {
                robot.Send(webhook, new DingTalkMessageAgrs
                {
                    msgtype = "text",
                    text = new DingTalkMessageAgrs.Text
                    {
                        content = "测试消息"
                    },
                    at = new DingTalkMessageAgrs.At { isAtAll = true }
                });
            }
            //链接类型
            {
                robot.Send(webhook, new DingTalkMessageAgrs
                {
                    msgtype = "link",
                    link = new DingTalkMessageAgrs.Link
                    {
                        text = "测试消息",
                        title = "测试消息",
                        picUrl = "https://www.baidu.com/img/PCfb_5bf082d29588c07f842ccde3f97243ea.png",
                        messageUrl = "https://www.dingtalk.com/s?__biz=MzA4NjMwMTA2Ng==&mid=2650316842&idx=1&sn=60da3ea2b29f1dcc43a7c8e4a7c97a16&scene=2&srcid=09189AnRJEdIiWVaKltFzNTw&from=timeline&isappinstalled=0&key=&ascene=2&uin=&devicetype=android-23&version=26031933&nettype=WIFI"
                    },
                    at = new DingTalkMessageAgrs.At { isAtAll = true }

                });
            }
            //markdown类型
            {
                robot.Send(webhook, new DingTalkMessageAgrs
                {
                    msgtype = "markdown",
                    markdown = new DingTalkMessageAgrs.Markdown
                    {
                        title = "广州天气测试",
                        text = "#### 广州天气 @150XXXXXXXX \n > 9度，西北风1级，空气良89，相对温度73%\n > ![screenshot](https://img.alicdn.com/tfs/TB1NwmBEL9TBuNjy1zbXXXpepXa-2400-1218.png)\n > ###### 10点20分发布 [天气](https://www.dingtalk.com) \n"
                    },
                    at = new DingTalkMessageAgrs.At { isAtAll = true }
                });
            }
            //actionCard类型
            {
                robot.Send(webhook, new DingTalkMessageAgrs
                {
                    msgtype = "actionCard",
                    actionCard = new DingTalkMessageAgrs.ActionCard
                    {
                        title = "测试乔布斯 20 年前想打造一间苹果咖啡厅，而它正是 Apple Store 的前身",
                        text = "![screenshot](https://gw.alicdn.com/tfs/TB1ut3xxbsrBKNjSZFpXXcXhFXa-846-786.png) \r\n ### 乔布斯 20 年前想打造的苹果咖啡厅 \r\n Apple Store 的设计正从原来满满的科技感走向生活化，而其生活化的走向其实可以追溯到 20 年前苹果一个建立咖啡馆的计划",
                        btnOrientation = "0",
                        singleTitle = "阅读全文",
                        singleURL = "https://www.baidu.com"
                    },
                    at = new DingTalkMessageAgrs.At { isAtAll = true }
                });

                robot.Send(webhook, new DingTalkMessageAgrs
                {
                    msgtype = "actionCard",
                    actionCard = new DingTalkMessageAgrs.ActionCard
                    {
                        title = "测试乔布斯 20 年前想打造一间苹果咖啡厅，而它正是 Apple Store 的前身",
                        text = "![screenshot](https://gw.alicdn.com/tfs/TB1ut3xxbsrBKNjSZFpXXcXhFXa-846-786.png) \r\n ### 乔布斯 20 年前想打造的苹果咖啡厅 \r\n Apple Store 的设计正从原来满满的科技感走向生活化，而其生活化的走向其实可以追溯到 20 年前苹果一个建立咖啡馆的计划",
                        btnOrientation = "0",
                        btns = new List<DingTalkMessageAgrs.ActionCard.Btn>
                        {
                            new DingTalkMessageAgrs.ActionCard.Btn
                            {
                                title = "内容不错",
                                actionURL = "https://www.baidu.com"
                            },
                            new DingTalkMessageAgrs.ActionCard.Btn
                            {
                                title = "不感兴趣",
                                actionURL = "https://www.baidu.com"
                            }
                        }
                    },
                    at = new DingTalkMessageAgrs.At { isAtAll = true }
                });
            }
            //feedCard类型
            {
                robot.Send(webhook, new DingTalkMessageAgrs
                {
                    msgtype = "feedCard",
                    feedCard = new DingTalkMessageAgrs.FeedCard
                    {
                        links = new List<DingTalkMessageAgrs.FeedCardLink> {
                            new DingTalkMessageAgrs.FeedCardLink{
                                title = "测试时代的火车向前开1",
                                messageUrl = "https://www.dingtalk.com/",
                                picUrl = "https://img.alicdn.com/tfs/TB1NwmBEL9TBuNjy1zbXXXpepXa-2400-1218.png"
                            },
                            new DingTalkMessageAgrs.FeedCardLink{
                                title = "测试时代的火车向前开2",
                                messageUrl = "https://www.dingtalk.com/",
                                picUrl = "https://img.alicdn.com/tfs/TB1NwmBEL9TBuNjy1zbXXXpepXa-2400-1218.png"
                            }
                        }
                    },
                    at = new DingTalkMessageAgrs.At { isAtAll = true }
                });
            }
        }
    }
}
