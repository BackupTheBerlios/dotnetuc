using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DotNetUC.Visualizer
{
    /// <summary>
    /// 
    /// </summary>
    class PathSerializer : VisualizerObjectSource
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="outgoingData"></param>
        public override void GetData(Object target, System.IO.Stream outgoingData)
        {
            GraphicsPath pth = (GraphicsPath) target;

            List<Point> lst = new List<Point>();
            foreach (PointF pt in pth.PathPoints)
            {
                lst.Add(new Point((int)pt.X, (int)pt.Y));
            }

            base.GetData(lst, outgoingData);
        }
    }
}
