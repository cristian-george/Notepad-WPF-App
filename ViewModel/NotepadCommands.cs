﻿using Microsoft.Win32;
using System.IO;
using System.Windows.Input;
using static Notepad.Model.DataProvider;
using Notepad.View;
using System.Windows;

namespace Notepad.ViewModel
{
    class NotepadCommands : BaseViewModel
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

            if (openFile.ShowDialog() == true)
            {
                string filePath = openFile.FileName;
                string fileName = openFile.SafeFileName;

                StreamReader streamReader = new StreamReader(File.OpenRead(filePath));
                TabCommands.AddNewTab(fileName, streamReader.ReadToEnd(), filePath);
                streamReader.Dispose();
            }
        }

        public void SaveFile(object parameter)
        {
            if (TabCommands.SelectedTab == null)
            {
                MessageBox.Show("There is no file to save.");
                return;
            }

            if (TabCommands.SelectedTab.FilePath.CompareTo("") == 0)
            {
                MessageBox.Show("There is no path to this file.");
                return;
            }

            string filePath = TabCommands.SelectedTab.FilePath;
            string fileContent = TabCommands.SelectedTab.Content;

            StreamWriter streamWriter = new StreamWriter(filePath);
            streamWriter.Write(fileContent);
            streamWriter.Dispose();
        }

        public void SaveFileAs(object parameter)
        {
            if (TabCommands.SelectedTab == null)
            {
                MessageBox.Show("There is no file to save.");
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = TabCommands.SelectedTab.Header,
                Filter = "Text document (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (saveFile.ShowDialog() == true)
            {
                string filePath = saveFile.FileName;
                string fileContent = TabCommands.SelectedTab.Content;

                File.WriteAllText(filePath, fileContent);
            }
        }

        public void ExitWindow(object parameter)
        {
            System.Environment.Exit(0);
        }

        public void PerformFind(object parameter)
        {
            if (FindWindowOn == true) return;
            FindWindow findWindow = new FindWindow();
            findWindow.Show();
            FindWindowOn = true;
        }

        public void PerformReplace(object parameter)
        {
            if (ReplaceWindowOn == true) return;
            ReplaceWindow replaceWindow = new ReplaceWindow();
            replaceWindow.Show();
            ReplaceWindowOn = true;
        }

        public void PerformReplaceAll(object parameter)
        {
            if (ReplaceAllWindowOn == true) return;
            ReplaceAllWindow replaceAllWindow = new ReplaceAllWindow();
            replaceAllWindow.Show();
            ReplaceAllWindowOn = true;
        }

        public void AboutDisplay(object parameter)
        {
            if (AboutWindowOn == true) return;
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
            AboutWindowOn = true;
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
    }
}
