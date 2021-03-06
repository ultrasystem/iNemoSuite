﻿namespace ControlLibrary
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class CommonDataView : UserControl, CommonControlBase
    {
        private IContainer components;
        private DataGridView dataGridView1;
        private BindingSource mTemp;

        public CommonDataView()
        {
            this.InitializeComponent();
            base.Hide();
        }

        public void Configure(ControlComponentConfiguration ctrlConf)
        {
            this.mTemp = ctrlConf.Source;
        }

        public void Copy()
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.dataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    Clipboard.SetDataObject(this.dataGridView1.GetClipboardContent());
                }
                catch
                {
                    Clipboard.SetDataObject("");
                }
            }
            this.Cursor = Cursors.Default;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void GoTo(double timestamp)
        {
            if (((BindingSource) this.dataGridView1.DataSource).SupportsSearching)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
                {
                    if (((double) row.Cells[0].Value) == timestamp)
                    {
                        ((BindingSource) this.dataGridView1.DataSource).Position = this.dataGridView1.Rows.IndexOf(row);
                        break;
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }

        public void GoToMax()
        {
            ((BindingSource) this.dataGridView1.DataSource).MoveLast();
        }

        public void GoToMin()
        {
            ((BindingSource) this.dataGridView1.DataSource).MoveFirst();
        }

        public void HideControl()
        {
            base.Hide();
            this.dataGridView1.DataSource = null;
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new DataGridView();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(0x237, 340);
            this.dataGridView1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = SystemColors.ControlDark;
            base.Controls.Add(this.dataGridView1);
            base.Name = "CommonDataView";
            base.Size = new Size(0x237, 340);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        public void SetVisbleDataAxe(int nYaxe, bool bVisible)
        {
        }

        public void ShowControl()
        {
            this.dataGridView1.DataSource = this.mTemp;
            base.Show();
        }

        public void ZoomIn()
        {
        }

        public void ZoomInV()
        {
        }

        public void ZoomOut()
        {
        }

        public void ZoomOutV()
        {
        }

        public void ZoomToFit()
        {
        }

        public void ZoomToFitV()
        {
        }
    }
}

