using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace DotNetUC.Visualizer
{

    /// <summary>
    /// 
    /// </summary>
    public partial class PathViewer : Form
    {

        private GraphicsPath path;

        /// <summary>
        /// 
        /// </summary>
        public PathViewer()
        {
            InitializeComponent();
            DrawPath();
        }

        private List<Point> points;

        /// <summary>
        /// 
        /// </summary>
        public List<Point> Points
        {
            get { return points; }
            set
            {
                points = value;
                DrawPath();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DrawPath()
        {
            this.Text = "GraphicsPath Viewer";
            txtPoints.Text = "";
            path = new GraphicsPath();
            if (points == null) return;

            foreach (Point pt in points)
            {
                txtPoints.Text = txtPoints.Text + pt.ToString() + "\r\n";
            }
            path.AddPolygon(points.ToArray());
        }

        private void pcbPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(Pens.Black, path);
        }

    }
}