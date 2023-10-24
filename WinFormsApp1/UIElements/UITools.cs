namespace SPTLauncher.UIElements
{
    internal class UITools
    {
        public static void AppendText(TextBoxBase TextElement, string TextToAppend)
        {
            TextElement.Text = TextElement.Text.Insert(TextElement.SelectionStart, TextToAppend);
        }
    }
}
