using System;

namespace PhantomComic
{
    public enum ChapterFailReason
    {
        DoesntExist = -2,
        UnableToReadPageCount = -3,
        Unknown = -1
    }
}