using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Management;

namespace CsStMT
{
    /// <summary>
    /// CPUCalcWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CPUCalcWindow : UserControl
    {
        private PerformanceCounter m_CPUCounter;

        public CPUCalcWindow()
        {
            InitializeComponent();
            StoryEventRegist();
            TimerUpdate();
        }

        private void TimerUpdate()
        {
            m_CPUCounter = new PerformanceCounter
                {
                    CategoryName = "Processor",
                    CounterName = "% Processor Time",
                    InstanceName = "_Total"
                };
            Func<string> CPUPerRead = () => "Now:" + Math.Round(m_CPUCounter.NextValue(), 3) + "%";
           

            var timer = new DispatcherTimer();
            timer.Tick += async (s,e)=>
            {
                CPUUsagetextBlock.Text = await Task.Run(CPUPerRead);
                CDriveResourceRead();
            };
            timer.Interval = new TimeSpan(0, 0, 0, 0,500);
            timer.Start();
        }


        private void StoryEventRegist()
        {
            var ringLoadStory = (Storyboard)FindResource("RingLoadStoryBoard");
            ringLoadStory.Completed += ringLoadStory_Completed;
        }

        void ringLoadStory_Completed(object sender, EventArgs e)
        {
            var contentLoadStory = (Storyboard)FindResource("ContentLoadStoryBoard");
            contentLoadStory.Begin();
        }

        private void CDriveResourceRead()
        {
            var drive = new System.IO.DriveInfo("C");

            if (drive.IsReady)
            {
                CDriveTextBlock.Text =
                    Math.Round(drive.TotalSize / Math.Pow(2, 30), 2) - Math.Round(drive.TotalFreeSpace / Math.Pow(2, 30), 2)
                    + "/"
                    + Math.Round(drive.TotalSize / Math.Pow(2, 30), 2) + "TB";
            }
        }


    }
}
