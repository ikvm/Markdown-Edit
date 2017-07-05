﻿using System;
using Infrastructure;
using Prism.Events;
using Prism.Mvvm;

namespace PreviewModule.ViewModels
{
    internal class PreviewControlViewModel : BindableBase
    {
        public IEventAggregator EventAggregator { get; }
        public IMarkdownEngine MarkdownEngine { get; }
        public Action<string> UpdateBrowserDelegate { get; set; }

        public PreviewControlViewModel(IEventAggregator eventAggregator, IMarkdownEngine markdownEngine)
        {
            EventAggregator = eventAggregator;
            MarkdownEngine = markdownEngine;

            eventAggregator.GetEvent<TextUpdatedEvent>().Subscribe(OnTextUpdated);
        }

        private void OnTextUpdated(string text)
        {
            var html = MarkdownEngine.ToHtml(text);
            UpdateBrowserDelegate(html);
        }
    }
}
