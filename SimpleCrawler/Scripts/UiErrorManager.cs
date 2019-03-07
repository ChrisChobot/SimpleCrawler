using System.Windows;
using System.Windows.Controls;

namespace SimpleCrawler
{
    class UiErrorManager
    {
        private TextBlock _errorBox;

        public void SetErrorText(string text)
        {
            if (_errorBox != null)
            {
                _errorBox.Text = text;
            }            
        }

        public UiErrorManager()
        {
            MainWindow mainWindow = null;

            if (Application.Current.MainWindow is MainWindow)
            {
                mainWindow = Application.Current.MainWindow as MainWindow;
            }

            _errorBox = mainWindow?.ErrorBox;
        }        
    }
}
