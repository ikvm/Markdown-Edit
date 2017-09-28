﻿using Infrastructure;

namespace ServicesModule.Services
{
    public class CommonMarkEngine : IMarkdownEngine
    {
        public string Name { get; } = "CommonMark";

        public string ToHtml(string text)
        {
            return CommonMark.CommonMarkConverter.Convert(text);
        }
    }
}