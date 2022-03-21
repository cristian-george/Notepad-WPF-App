namespace Notepad.Model
{
    class Tab
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public string OldContent { get; set; }
        public string BlankSpace { get; set; } = "   ";
    }
}
