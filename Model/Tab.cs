namespace Notepad.Model
{
    class Tab : ViewModel.BaseViewModel
    {
        private string header;
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
                OnNotifyPropertyChanged("Header");
            }
        }

        private string content;
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                OnNotifyPropertyChanged("Content");
            }
        }

        private string filePath;
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
                OnNotifyPropertyChanged("FilePath");
            }
        }

        private string oldContent;
        public string OldContent
        {
            get
            {
                return oldContent;
            }
            set
            {
                oldContent = value;
                OnNotifyPropertyChanged("OldContent");
            }
        }

        private string blankspace = "   ";
        public string BlankSpace
        {
            get
            {
                return blankspace;
            }
            set
            {
                blankspace = value;
                OnNotifyPropertyChanged("BlankSpace");
            }
        }

        private string wordToFind;
        public string WordToFind
        {
            get
            {
                return wordToFind;
            }
            set
            {
                wordToFind = value;
                OnNotifyPropertyChanged("WordToFind");
            }
        }
    }
}
