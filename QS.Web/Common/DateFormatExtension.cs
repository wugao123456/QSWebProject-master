using System;

using System.Web.Mvc;
using QS.Common;
using QS.DTO.Module;

namespace QS.Web.Common
{
    public static class DateFormatExtension
    {
        public static string DateFormat(this HtmlHelper helper, DateTime datetime)
        {
            var span = DateTime.Now - datetime;
            if (span.TotalDays > 7)
            {
                return datetime.ToShortDateString();
            }
            if (span.TotalDays > 1)
            {
                return string.Format("{0}天前", (int) Math.Floor(span.TotalDays));
            }
            if (span.TotalHours > 1)
            {
                return string.Format("{0}小时前", (int) Math.Floor(span.TotalHours));
            }
            if (span.TotalMinutes > 1)
            {
                return string.Format("{0}分钟前", (int) Math.Floor(span.TotalMinutes));
            }
            return span.TotalSeconds >= 30 ? string.Format("{0}秒前", (int) Math.Floor(span.TotalSeconds)) : "刚刚";
        }

        public static string GetHeadSentence(this HtmlHelper helper, string str, int len)
        {
            return String.IsNullOrEmpty(str) ? @"暂无描述" : Utilities.CutString(str, len);
        }

        public static string ViewTimesFormat(this HtmlHelper helper, int num)
        {
            return num == 0 ? @"无人问津" : num + @"次浏览";
        }

        public static string CommentsFormat(this HtmlHelper helper, int num)
        {
            return num == 0 ? @"暂无评论" : num + @"次评论";
        }

        public static string ArticleCategoryFormat(this HtmlHelper helper, string category)
        {
            if (category.Equals("Back"))
            {
                return @"后端学习";
            }
            if (category.Equals("Front"))
            {
                return @"前端学习";
            }
            if (category.Equals("Algorithm"))
            {
                return @"算法学习";
            }
            if (category.Equals("Others"))
            {
                return @"杂七杂八";
            }
            return @"其他";
        }

        public static string TagBelongFormat(this HtmlHelper helper, TagBelongType type)
        {
            switch (type)
            {
                case TagBelongType.All:
                    return @"所有媒介";
                case TagBelongType.News:
                    return @"新闻速递";
                case TagBelongType.Article:
                    return @"技术文章";
                case TagBelongType.Gallery:
                    return @"精美图片";
                case TagBelongType.Video:
                    return @"影视心灵";
                case TagBelongType.Book:
                    return @"书籍推荐";
                default:
                    return @"不知所属";
            }
        }

        public static string BookGradeFormat(this HtmlHelper helper, decimal grade, int times)
        {
            if (times == 0)
                return @"暂无评分";
            return grade + "分 / 共" + times + "次评分";
        }
    }
}