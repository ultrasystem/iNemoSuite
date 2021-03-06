﻿namespace ControlLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public class VirtualPanel
    {
        private Color backColor = Color.Red;
        private Panel localPanel;
        private UserControl mParent;
        private SingleSelection mSelected;
        private List<SingleSelection> mSelectionList = new List<SingleSelection>();

        public VirtualPanel(UserControl parent)
        {
            this.mParent = parent;
            this.localPanel = new Panel();
            this.mParent.Controls.Add(this.localPanel);
        }

        public void Add(Button btn, UserControl userControl, ToolStripMenuItem menu)
        {
            this.SelectionList.Add(new SingleSelection(btn, userControl, menu, this.mParent));
            SingleSelection local1 = this.SelectionList[this.SelectionList.Count - 1];
            local1.OnSelected = (SingleSelection.ControlSelectEvent) Delegate.Combine(local1.OnSelected, new SingleSelection.ControlSelectEvent(this.SelectSelection));
        }

        public void AdjustLayout(Size panelSize)
        {
            int num = 0;
            this.localPanel.Top = 0;
            this.localPanel.Left = this.SelectionList[0].Button.Width;
            this.localPanel.BackColor = Color.WhiteSmoke;
            this.localPanel.Height = panelSize.Height;
            this.localPanel.Width = 2;
            this.localPanel.BringToFront();
            foreach (SingleSelection selection in this.SelectionList)
            {
                selection.Button.Top = num;
                selection.Button.Left = 0;
                num += selection.Button.Height;
                selection.UserControl.Top = 0;
                selection.UserControl.Left = selection.Button.Width + 2;
                selection.UserControl.Width = panelSize.Width - selection.UserControl.Left;
                selection.UserControl.Height = panelSize.Height;
            }
        }

        private void SelectSelection(SingleSelection sel)
        {
            SingleSelection selected = this.Selected;
            this.Selected = sel;
            this.Selected.Selected = true;
            if ((selected != null) && (selected != this.Selected))
            {
                selected.Selected = false;
            }
        }

        public void SetBigButtons(bool bBig)
        {
            foreach (SingleSelection selection in this.SelectionList)
            {
                selection.SetBigButton(bBig);
            }
            this.AdjustLayout(this.mParent.Size);
        }

        public Color BackColor
        {
            get
            {
                return this.backColor;
            }
            set
            {
                this.backColor = value;
            }
        }

        public SingleSelection Selected
        {
            get
            {
                return this.mSelected;
            }
            set
            {
                this.mSelected = value;
            }
        }

        public List<SingleSelection> SelectionList
        {
            get
            {
                return this.mSelectionList;
            }
        }
    }
}

