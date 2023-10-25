namespace SPTLauncher.UIElements
{
    internal class Scroll : ListBox
    {
        const int WM_VSCROLL = 0x0115;
        private int lastInt = 0;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_VSCROLL)
            {
                int scrollAction = (int)m.WParam;
                bool scrolling = scrollAction > 100;
                bool downwards = scrolling && lastInt < scrollAction || scrollAction == 1;
                ModDownloader.form?.ScrollCheck(!downwards);
                if(lastInt > 10) lastInt = scrollAction;
            }
        }
    }
}
