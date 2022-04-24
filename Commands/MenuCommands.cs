using Microsoft.Win32;
using Notepad.View;
using Notepad.ViewModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using static Notepad.Model.DataProvider;

namespace Notepad.Commands
{
    internal class MenuCommands : BaseViewModel
    {
        private readonly TabCommands tabCommands;
        public MenuCommands(TabCommands tabCommands)
        {
            this.tabCommands = tabCommands;
        }

        #region New file
        private ICommand m_newFile;
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

        public void NewFile(object parameter)
        {
            tabCommands.AddNewFileTab();
        }
        #endregion

        #region Open file
        private ICommand m_openFile;
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
                tabCommands.AddNewTab(fileName, streamReader.ReadToEnd(), filePath);
                streamReader.Dispose();
            }
        }
        #endregion

        #region Save file
        private ICommand m_saveFile;
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

        public void SaveFile(object parameter)
        {
            if (tabCommands.SelectedTab == null)
            {
                MessageBox.Show("There is no file to save.");
                return;
            }

            if (tabCommands.SelectedTab.FilePath.CompareTo("") == 0)
            {
                MessageBox.Show("There is no path to this file.");
                return;
            }

            string filePath = tabCommands.SelectedTab.FilePath;
            string fileContent = tabCommands.SelectedTab.Content;

            tabCommands.SelectedTab.OldContent = fileContent;
            tabCommands.SelectedTab.BlankSpace = "   ";

            StreamWriter streamWriter = new StreamWriter(filePath);
            streamWriter.Write(fileContent);
            streamWriter.Dispose();
        }
        #endregion

        #region Save file as
        private ICommand m_saveFileAs;
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

        public void SaveFileAs(object parameter)
        {
            if (tabCommands.SelectedTab == null)
            {
                MessageBox.Show("There is no file to save.");
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = tabCommands.SelectedTab.Header,
                Filter = "Text document (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (saveFile.ShowDialog() == true)
            {
                string fileName = saveFile.SafeFileName;
                string filePath = saveFile.FileName;
                string fileContent = tabCommands.SelectedTab.Content;

                tabCommands.SelectedTab.Header = fileName;
                tabCommands.SelectedTab.FilePath = filePath;
                tabCommands.SelectedTab.OldContent = fileContent;
                tabCommands.SelectedTab.BlankSpace = "   ";

                File.WriteAllText(filePath, fileContent);
            }
        }

        #endregion

        #region Exit window
        private ICommand m_exitWindow;
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

        public void ExitWindow(object parameter)
        {
            System.Environment.Exit(0);
        }
        #endregion

        #region Find window
        private ICommand m_find;
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

        public void PerformFind(object parameter)
        {
            if (FindWindowOn == true) return;
            FindWindow findWindow = new FindWindow();
            findWindow.Show();
            FindWindowOn = true;
        }
        #endregion

        #region Replace window
        private ICommand m_replace;
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

        public void PerformReplace(object parameter)
        {
            if (ReplaceWindowOn == true) return;
            ReplaceWindow replaceWindow = new ReplaceWindow();
            replaceWindow.Show();
            ReplaceWindowOn = true;
        }
        #endregion

        #region About window
        private ICommand m_about;
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

        public void AboutDisplay(object parameter)
        {
            if (AboutWindowOn == true) return;
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
            AboutWindowOn = true;
        }
        #endregion
    }
}
