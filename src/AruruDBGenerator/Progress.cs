﻿using System.Windows.Forms;

namespace AruruDB
{
    public class Progress
    {
        private ListBox _progressListBox;

        public Progress(ListBox view) {
            _progressListBox = view;
        }

        public void AddProgress(string text) {
            _progressListBox.Items.Add(text);
        }
    }
}
