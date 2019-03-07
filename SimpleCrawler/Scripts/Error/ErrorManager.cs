using System;

namespace SimpleCrawler
{
    public sealed class ErrorManager
    {
        private UiErrorManager _uiErrorManager;
        private static readonly Lazy<ErrorManager> _lazyInstance = new Lazy<ErrorManager>(() => new ErrorManager());

        public static ErrorManager Instance
        {
            get
            {
                return _lazyInstance.Value;
            }
        }
        
        ErrorManager()
        {
            _uiErrorManager = new UiErrorManager();
        }

        public void SetErrorText(string text)
        {
            _uiErrorManager.SetErrorText(text);
        }
    }
}
