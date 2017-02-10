using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhantomComic
{
    public static class ComicUtils
    {
        /// <summary>
        /// Delete all chapters, pages and metadata for a specific series.
        /// </summary>
        /// <param name="rccode">Series RC Code</param>
        public static void DeleteComic(string rccode)
        {
            Directory.Delete("data\\" + rccode, true);
        }

        /// <summary>
        /// Convert series name to a usable RC code.
        /// </summary>
        /// <param name="seriesname">Series Name</param>
        /// <returns>RC Code corresponding to the series title</returns>
        public static string GetRCCode(string seriesname)
        {
            return seriesname.Replace("{", "").Replace("}", "").Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Replace(":", "").Replace("&", "").Replace("/", "-").Replace("\\", "").Replace("@", "").Replace("'", "").Replace("*", "").Replace("!", "").Replace("+", "").Replace("?", "").Replace(",", "").Replace(" - ", "-").Replace("  ", "-").Replace(" ", "-").ToLower().TrimEnd(new char[] { '-' });
        }

        /// <summary>
        /// Parse the comic page and read back the URL for the comic banner.
        /// </summary>
        /// <param name="rccode">Series RC Code</param>
        /// <param name="shtml">Saved HTML</param>
        /// <returns>Comic banner URL</returns>
        public static string RetrieveBanner(string rccode, string shtml = "")
        {
            // Grab page source
            string html = shtml == "" ? new WebClient().DownloadString("http://www.readcomics.tv/comic/" + rccode) : shtml;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Parse page source
            HtmlNode node = doc.GetElementbyId("series_image");
            string loc = node.OuterHtml.Split(new string[] { "src=\"" }, StringSplitOptions.None)[1].Split(new char[] { '\"' })[0];

            // Return
            return loc;
        }
        /// <summary>
        /// Find and parse a random chapter and read back a list of all hosted chapters.
        /// </summary>
        /// <param name="rccode">Series RC Code</param>
        /// <returns>The complete chapter list in the specified comic series</returns>
        public static string[] RetrieveChapterList(string rccode)
        {
            // Grab page source
            string html = new WebClient().DownloadString("http://www.readcomics.tv/comic/" + rccode);

            //blablabla

            return null;
        }
        /// <summary>
        /// Parse the comic page and read back the description for the comic.
        /// </summary>
        /// <param name="rccode">Series RC Code</param>
        /// <param name="shtml">Saved HTML</param>
        /// <returns>Comic description</returns>
        public static string RetrieveDescription(string rccode, string shtml = "")
        {
            // Grab page source
            string html = shtml == "" ? new WebClient().DownloadString("http://www.readcomics.tv/comic/" + rccode) : shtml;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Parse page source
            string desc = "";
            foreach (HtmlNode node in doc.DocumentNode.Descendants())
                if (node.Name == "div")
                    if (node.GetAttributeValue("class", "") == "manga-desc")
                        desc = node.InnerText.Split(new string[] { "\r\n      " }, StringSplitOptions.None)[1];

            // Return
            return desc;
        }
        /// <summary>
        /// Parse the chapter page and read back the page count.
        /// </summary>
        /// <param name="rccode">Series RC Code</param>
        /// <param name="chapter">Chapter (ex: 1, 3, 5.1, 15-3, etc..)</param>
        /// <returns>The amount of pages in the specified chapter</returns>
        public static int RetrievePageCount(string rccode, string chapter)
        {
            try
            {
                // Grab page source
                string html = new WebClient().DownloadString("http://www.readcomics.tv/" + rccode + "/chapter-" + chapter);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                // Parse page source
                HtmlNode node = doc.GetElementbyId("asset_2");
                string[] buffer = node.InnerText.Replace("\r\n    ", "").Replace("   ", "").Split(new char[] { ' ' });
                int res = 0;
                bool parsed = int.TryParse(buffer[buffer.Length - 1], out res);

                // Return
                if (parsed)
                    return res;
                return (int)ChapterFailReason.UnableToReadPageCount;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("(404)"))
                    return (int)ChapterFailReason.DoesntExist;
                return (int)ChapterFailReason.Unknown;
            }
        }
    }
}