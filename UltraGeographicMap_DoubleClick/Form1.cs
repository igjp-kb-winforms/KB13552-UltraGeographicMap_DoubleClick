﻿using Infragistics.Graphics;
using Infragistics.Portable.Components.Data;
using Infragistics.Win.DataVisualization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltraGeographicMap_DoubleClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ultraGeographicMap1.Zoomable = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //緯度35.68095、経度139.76712の地点を中心としてマップをズームする
            Infragistics.Win.DataVisualization.Rectangle geoRect = geographicFromCentered(35.68095, 139.76712, 0.01);
            ultraGeographicMap1.ZoomToGeographic(geoRect);
        }

        private void ultraGeographicMap1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Infragistics.Win.DataVisualization.Point pt = ultraGeographicMap1.GetGeographicPoint(e.Location);
            MessageBox.Show("緯度:" + pt.Y + ", 経度:" + pt.X);
        }

        private Infragistics.Win.DataVisualization.Rectangle geographicFromCentered(double latitude, double longitude, double radius)
        {
            Infragistics.Win.DataVisualization.Rectangle rect = new Infragistics.Win.DataVisualization.Rectangle()
            {
                X = longitude - radius,
                Y = latitude - radius,
                Width = radius * 2,
                Height = radius * 2,
            };

            return rect;
        }
    }
}
