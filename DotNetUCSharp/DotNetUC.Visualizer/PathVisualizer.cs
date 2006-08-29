using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Drawing;

namespace DotNetUC.Visualizer
{
    /// <summary>
    /// 
    /// </summary>
    public class PathVisualizer : DialogDebuggerVisualizer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowService"></param>
        /// <param name="objectProvider"></param>
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            List<Point> obj = (List<Point>)objectProvider.GetObject();

            using (PathViewer frm = new PathViewer())
            {
                frm.Points = (List<Point>)obj;
                windowService.ShowDialog(frm);
                
                //objectProvider.ReplaceData(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectToVisualize"></param>
        public static void TestShowVisualizer(Object objectToVisualize)
        {
            VisualizerDevelopmentHost host;
            host = new VisualizerDevelopmentHost(objectToVisualize, typeof(PathVisualizer));

            host.ShowVisualizer();
        }
    }
}
