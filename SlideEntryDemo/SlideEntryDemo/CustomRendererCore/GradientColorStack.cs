using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SlideEntryDemo.CustomRendererCore
{
    public class GradientColorStack : StackLayout
    {
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
    }
}
