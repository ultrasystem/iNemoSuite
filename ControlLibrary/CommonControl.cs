﻿namespace ControlLibrary
{
    using AxiPlotLibrary;
    using iPlotLibrary;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class CommonControl : UserControl, CommonControlBase
    {
        private AxiPlotX axiPlotX;
        private IContainer components;
        private bool mInvertView;
        private double mMinX;
        private double mMinY;
        private double mSpanY;
        private bool mStacked;
        private IiPlotAxisX XAxe;
        private List<PlotYAxeInfo> YAxes = new List<PlotYAxeInfo>();

        public CommonControl()
        {
            InitializeComponent();

            axiPlotX.UserCanEditObjects = false;
            axiPlotX.RemoveAllChannels();
            axiPlotX.RemoveAllLabels();
            axiPlotX.RemoveAllXAxes();
            axiPlotX.RemoveAllYAxes();
            axiPlotX.Visible = true;
            mInvertView = true;
            base.Hide();
        }

        public void AddData(double[] dataarr)
        {
            int index = 1;
            double x = dataarr[0];
            if (base.Enabled)
            {
                foreach (PlotYAxeInfo info in YAxes)
                {
                    info.Channel.AddXY(x, dataarr[index]);
                    index++;
                }
            }
        }

        private void axiPlotX_OnXAxisMinChange(object sender, IiPlotXEvents_OnXAxisMinChangeEvent e)
        {
            if (axiPlotX.get_XAxis(0).Min < 0.0)
                axiPlotX.get_XAxis(0).Min = 0.0;
        }

        public void ClearData()
        {
            XAxe.Min = mMinX;
            foreach (PlotYAxeInfo info in YAxes)
            {
                info.Channel.Clear();
                info.Axe.Min = mMinY;
                info.Axe.Span = mSpanY;
            }
        }

        public void Configure(ControlComponentConfiguration ctrlConf)
        {
            double num2 = 0.0;
            XAxe = axiPlotX.get_XAxis(axiPlotX.AddXAxis());
            XAxe.Name = "T";
            XAxe.Title = "Time (s)";
            XAxe.TitleShow = true;
            XAxe.Min = 0.0;
            XAxe.Span = 10.0;
            mMinX = XAxe.Min;
            XAxe.PopupEnabled = false;
            double num = (1.0 / ((double) (ctrlConf.Axes.Count + 1))) * 100.0;
            foreach (AxeInformation information in ctrlConf.Axes)
            {
                PlotYAxeInfo item = new PlotYAxeInfo {
                    AxeName = information.Name
                };
                if (information.Unit != "")
                    item.AxeName = item.AxeName + " (" + information.Unit + ")";
                item.Axe = axiPlotX.get_YAxis(axiPlotX.AddYAxis());
                item.Axe.Name = information.Name;
                item.Axe.Title = item.AxeName;
                item.Axe.Min = information.MinValue;
                mMinY = item.Axe.Min;
                item.Axe.Span = information.MaxValue - information.MinValue;
                mSpanY = item.Axe.Span;
                item.Axe.TrackingEnabled = true;
                item.Axe.Enabled = true;
                item.Axe.Visible = information.Visible;
                item.Channel = axiPlotX.get_Channel(axiPlotX.AddChannel());
                item.Channel.Name = information.Name;
                item.Channel.YAxisName = information.Name;
                item.Channel.TitleText = item.AxeName;
                item.Channel.VisibleInLegend = information.Visible;
                item.Channel.Visible = information.Visible;
                item.Channel.Color = (uint) information.Color;
                item.Channel.TraceLineStyle = information.LineStyle;
                if (information.Precision > 0)
                {
                    item.Axe.LabelsPrecisionStyle = TxiPrecisionStyle.ipsFixedDecimalPoints;
                    item.Axe.LabelsPrecision = information.Precision;
                }
                item.Cursor = axiPlotX.get_DataCursor(axiPlotX.AddDataCursor());
                item.Cursor.ChannelName = information.Name;
                item.Cursor.Visible = false;
                item.Cursor.MenuUserCanChangeOptions = false;
                item.Cursor.SnapToDataPoint = true;
                item.Cursor.ChannelAllowAll = false;
                num2 += num;
                item.Cursor.Pointer1Position = num2;
                item.Visible = information.Visible;
                if (information.StrType == null)
                    ctrlConf.DataInMemory.Columns.Add(ctrlConf.GroupName + " " + item.AxeName, System.Type.GetType("System.Int16"));
                else
                    ctrlConf.DataInMemory.Columns.Add(ctrlConf.GroupName + " " + item.AxeName, System.Type.GetType(information.StrType));
                YAxes.Add(item);
            }
            ShowStacked = ctrlConf.ShowStacked;
        }

        public void Copy()
        {
            axiPlotX.CopyToClipBoard();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void GoTo(double timestamp)
        {
            if (timestamp <= axiPlotX.get_Channel(0).RunningXMax)
            {
                axiPlotX.get_XAxis(0).Min = Math.Max((double) 0.0, (double) (timestamp - (axiPlotX.get_XAxis(0).Span / 2.0)));
            }
        }

        public void GoToMax()
        {
            axiPlotX.get_XAxis(0).Min = Math.Max((double) 0.0, (double) (axiPlotX.get_Channel(0).RunningXMax - axiPlotX.get_XAxis(0).Span));
        }

        public void GoToMin()
        {
            axiPlotX.get_XAxis(0).Min = axiPlotX.get_Channel(0).GetXMin();
        }

        public void HideControl()
        {
            base.Hide();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(CommonControl));
            axiPlotX = new AxiPlotX();
            axiPlotX.BeginInit();
            base.SuspendLayout();
            axiPlotX.Dock = DockStyle.Fill;
            axiPlotX.Enabled = true;
            axiPlotX.Location = new Point(0, 0);
            axiPlotX.Name = "axiPlotX";
            axiPlotX.OcxState = (AxHost.State) resources.GetObject("axiPlotX.OcxState");
            axiPlotX.Size = new Size(564, 325);
            axiPlotX.TabIndex = 1;
            base.AutoScaleDimensions = new SizeF(111, 319);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            base.Controls.Add(axiPlotX);
            base.Name = "CommonControl";
            base.Size = new Size(564, 325);
            axiPlotX.EndInit();
            base.ResumeLayout(false);
        }

        public void SetVisbleDataAxe(int nYaxe, bool bVisible)
        {
            if ((nYaxe > 0) && (nYaxe < YAxes.Count))
            {
                YAxes[nYaxe].Visible = bVisible;
                YAxes[nYaxe].Axe.Visible = bVisible;
                YAxes[nYaxe].Channel.Visible = bVisible;
                YAxes[nYaxe].Channel.VisibleInLegend = bVisible;
                ShowStacked = ShowStacked;
                ShowCursor = ShowCursor;
            }
        }

        public void ShowControl()
        {
            base.Show();
        }

        private void StackedView(bool stacked)
        {
            int num = 0;
            int num2 = 0;
            foreach (PlotYAxeInfo info in YAxes)
            {
                if (info.Visible)
                {
                    num2++;
                }
            }
            if (stacked)
            {
                axiPlotX.DisableLayoutManager();
                foreach (PlotYAxeInfo info2 in YAxes)
                {
                    info2.Axe.TitleShow = true;
                    info2.Axe.Visible = info2.Visible;
                    info2.Axe.GridLinesVisible = true;
                    info2.Axe.ZOrder = 0;
                    info2.Axe.StackingEndsMargin = 0.5;
                    if (mInvertView)
                    {
                        info2.Axe.StopPercent = 100.0 - (((1.0 / ((double) num2)) * num) * 100.0);
                        info2.Axe.StartPercent = 100.0 - (((1.0 / ((double) num2)) * (num + 1)) * 100.0);
                    }
                    else
                    {
                        info2.Axe.StartPercent = ((1.0 / ((double) num2)) * num) * 100.0;
                        info2.Axe.StopPercent = ((1.0 / ((double) num2)) * (num + 1)) * 100.0;
                    }
                    info2.Axe.ForceStacking = true;
                    info2.Channel.YAxisName = info2.Axe.Name;
                    if (info2.Visible)
                    {
                        num++;
                    }
                }
                axiPlotX.EnableLayoutManager();
                axiPlotX.get_Legend(0).Visible = false;
            }
            else
            {
                foreach (PlotYAxeInfo info3 in YAxes)
                {
                    info3.Axe.Visible = false;
                    info3.Axe.TitleShow = false;
                    info3.Axe.GridLinesVisible = false;
                    info3.Axe.StartPercent = 0.0;
                    info3.Axe.StopPercent = 100.0;
                    info3.Channel.YAxisName = YAxes[0].Axe.Name;
                }
                YAxes[0].Axe.Visible = true;
                YAxes[0].Axe.GridLinesVisible = true;
                axiPlotX.get_Legend(0).Visible = true;
            }
        }

        public void ZoomIn()
        {
            if (axiPlotX.get_XAxis(0).Span > 0.2)
            {
                axiPlotX.get_XAxis(0).Zoom(0.5);
            }
        }

        public void ZoomInV()
        {
            for (int i = 0; i < axiPlotX.YAxisCount; i++)
            {
                axiPlotX.get_YAxis(i).Zoom(0.5);
            }
        }

        public void ZoomOut()
        {
            if (axiPlotX.get_XAxis(0).Max <= 2147483647.0)
            {
                axiPlotX.get_XAxis(0).Zoom(2.0);
            }
        }

        public void ZoomOutV()
        {
            for (int i = 0; i < axiPlotX.YAxisCount; i++)
            {
                axiPlotX.get_YAxis(i).Zoom(2.0);
            }
        }

        public void ZoomToFit()
        {
            axiPlotX.get_XAxis(0).ZoomToFitFast();
        }

        public void ZoomToFitV()
        {
            for (int i = 0; i < axiPlotX.YAxisCount; i++)
            {
                axiPlotX.get_YAxis(i).ZoomToFitFast();
            }
        }

        public int RingBufferSize
        {
            set
            {
                for (int i = 0; i < axiPlotX.ChannelCount; i++)
                {
                    axiPlotX.get_Channel(i).RingBufferSize = value;
                }
            }
        }

        public bool ShowCursor
        {
            get
            {
                return YAxes[0].Cursor.Visible;
            }
            set
            {
                foreach (PlotYAxeInfo info in YAxes)
                {
                    if (info.Visible)
                    {
                        info.Cursor.Visible = value;
                    }
                    else
                    {
                        info.Cursor.Visible = false;
                    }
                }
            }
        }

        public bool ShowStacked
        {
            get
            {
                return mStacked;
            }
            set
            {
                mStacked = value;
                StackedView(value);
            }
        }

        public bool TrackingEnabled
        {
            get
            {
                return axiPlotX.get_XAxis(0).TrackingEnabled;
            }
            set
            {
                axiPlotX.get_XAxis(0).TrackingEnabled = value;
            }
        }

        public bool TrackingVerticalEnabled
        {
            set
            {
                for (int i = 0; i < axiPlotX.YAxisCount; i++)
                {
                    axiPlotX.get_YAxis(i).TrackingEnabled = value;
                }
            }
        }

        private class PlotYAxeInfo
        {
            public IiPlotAxisX Axe;
            public string AxeName;
            public IiPlotChannelX Channel;
            public IiPlotDataCursorX Cursor;
            public bool Visible;
        }
    }
}

