﻿using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;

namespace Notepad.ViewModel
{
    class NotepadCommands : INotifyPropertyChanged
    {
        private ICommand m_newFile;
        private ICommand m_openFile;
        private ICommand m_saveFile;
        private ICommand m_saveFileAs;
        private ICommand m_exitWindow;

        private ICommand m_find;
        private ICommand m_replace;
        private ICommand m_replaceAll;

        private ICommand m_about;

        public void NewFile(object parameter)
        {
            TabCommands.AddNewTab();
        }

        public void OpenFile(object parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Title = "Select a file",
                Filter = "Text document (*.txt)|*.txt|All files (*.*)|*.*"
            };
            openFile.ShowDialog();

            if (openFile.FileName.CompareTo("") == 0)
                return;

            StreamReader streamReader = new StreamReader(File.OpenRead(openFile.FileName));
            TabCommands.AddNewTab(openFile.SafeFileName, streamReader.ReadToEnd());
            streamReader.Dispose();
        }

        public void SaveFile(object parameter)
        {
        }

        public void SaveFileAs(object parameter)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = "file.txt",
                Filter = "Text document (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (saveFile.ShowDialog() == true)
            {
                File.WriteAllText(saveFile.FileName, TabCommands.Tabs[1].Content);
            }
        }

        public void ExitWindow(object parameter)
        {
            System.Environment.Exit(0);
        }

        public void PerformFind(object parameter)
        {
        }

        public void PerformReplace(object parameter)
        {
        }

        public void PerformReplaceAll(object parameter)
        {
        }

        public void AboutDisplay(object parameter)
        {
        }

        public ICommand New
        {
            get
            {
                if (m_newFile == null)
                {
                    m_newFile = new RelayCommand(NewFile);
                }

                return m_newFile;
            }
        }

        public ICommand Open
        {
            get
            {
                if (m_openFile == null)
                {
                    m_openFile = new RelayCommand(OpenFile);
                }

                return m_openFile;
            }
        }

        public ICommand Save
        {
            get
            {
                if (m_saveFile == null)
                {
                    m_saveFile = new RelayCommand(SaveFile);
                }

                return m_saveFile;
            }
        }

        public ICommand SaveAs
        {
            get
            {
                if (m_saveFileAs == null)
                {
                    m_saveFileAs = new RelayCommand(SaveFileAs);
                }

                return m_saveFileAs;
            }
        }

        public ICommand Exit
        {
            get
            {
                if (m_exitWindow == null)
                {
                    m_exitWindow = new RelayCommand(ExitWindow);
                }

                return m_exitWindow;
            }
        }

        public ICommand Find
        {
            get
            {
                if (m_find == null)
                {
                    m_find = new RelayCommand(PerformFind);
                }

                return m_find;
            }
        }

        public ICommand Replace
        {
            get
            {
                if (m_replace == null)
                {
                    m_replace = new RelayCommand(PerformReplace);
                }

                return m_replace;
            }
        }

        public ICommand ReplaceAll
        {
            get
            {
                if (m_replaceAll == null)
                {
                    m_replaceAll = new RelayCommand(PerformReplaceAll);
                }

                return m_replaceAll;
            }
        }

        public ICommand About
        {
            get
            {
                if (m_about == null)
                {
                    m_about = new RelayCommand(AboutDisplay);
                }

                return m_about;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}