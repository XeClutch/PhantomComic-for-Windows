using System;
using System.Text;

namespace PhantomComic
{
    public struct ComicDownloadEntry
    {
        public int chapter_num;
        public int chapter_ad;
        public bool chapter_hasdec;
        public bool chapter_hashyp;
        public string comic_name;
        public string comic_rccode;
        public int page_start;
        public int page_end;
        public bool resize;
    }
}