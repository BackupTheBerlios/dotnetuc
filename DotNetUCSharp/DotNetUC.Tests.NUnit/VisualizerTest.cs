using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DotNetUC.Visualizer;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DotNetUC.Tests.NUnit
{
    [TestFixture()]
    class VisualizerTest
    {

        [Test()]
        public void GraphicsPathVisualizerTest()
        {
            GraphicsPath pth;
            pth = new GraphicsPath();
            List<Point> lst;
            lst = new List<Point>();
            lst.Add(new Point(10, 10));
            lst.Add(new Point(100, 100));
            lst.Add(new Point(100, 10));

            pth.AddPolygon(lst.ToArray());

            PathVisualizer.TestShowVisualizer(pth);
        }

    }
}
