using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace FormApp0601
{
    // 自定义面板
    class SimpleLayoutPanel : Panel
    {
        // 布局器
        private LayoutEngine layoutEngine = new SimpleLayoutEngine();
        
        public override LayoutEngine LayoutEngine
        {
            get
            {                
                return layoutEngine;
            }
        }
    }

    // 自定义布局器
    class SimpleLayoutEngine :  LayoutEngine
    {
        public override bool Layout(
            object container,
            LayoutEventArgs layoutEventArgs)
        {
            // 容器
            SimpleLayoutPanel parent = (SimpleLayoutPanel)container;

            int w = parent.Width;
            int h = parent.Height;

            // 去除Padding
            int x = parent.Padding.Left;
            int y = parent.Padding.Top;
            w -= (parent.Padding.Left + parent.Padding.Right);
            h -= (parent.Padding.Top + parent.Padding.Bottom);

            int gap = 2;

            foreach (Control c in parent.Controls)
            {
                c.Location = new Point(x, y);
                c.Size = new Size(w, c.PreferredSize.Height);

                y += c.Size.Height;
                y += gap;
            }
           
            return false;
        }
    }


}
