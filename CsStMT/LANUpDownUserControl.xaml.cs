using System;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Diagnostics;
using System.Windows.Threading;
using Microsoft.VisualBasic;

namespace CsStMT
{
    /// <summary>
    /// LANUpDownUserControl.xaml の相互作用ロジック
    /// </summary>
    public partial class LANUpDownUserControl : UserControl
    {
        
        public LANUpDownUserControl()
        {
            this.InitializeComponent();
            RegistStoryBoard();
            TimerUpdate();
        }

        private  void TimerUpdate()
        {
            var info = new Microsoft.VisualBasic.Devices.ComputerInfo();

            Func<string> memNowUse = () => Math.Round((info.TotalPhysicalMemory-info.AvailablePhysicalMemory) / Math.Pow(2, 20), 2).ToString();
            Func<string> memTotal = () =>  Math.Round(info.TotalPhysicalMemory / Math.Pow(2, 20), 2).ToString();
            Func<string> memRate = () => Math.Round((Math.Round((info.TotalPhysicalMemory - info.AvailablePhysicalMemory)/Math.Pow(2, 20), 2)/
                                          Math.Round(info.TotalPhysicalMemory/Math.Pow(2, 20), 2)),3)*100+"%";
            
            var timer = new DispatcherTimer();
            timer.Tick += async (sender, args) =>
                {
                    textBlockMemoryUsage.Text = await Task.Run(memNowUse);
                    TextBlockTotal.Text = await Task.Run(memTotal);
                    textBlockRate.Text = await Task.Run(memRate);
                };
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }



        private void RegistStoryBoard()
        {
            var LUD_RingStoryboard = (Storyboard)FindResource("LUD_RingLoadStoryBoard");
            LUD_RingStoryboard.Completed += (s, e) =>
                {
                    var LUD_ContentStoryBoard = (Storyboard)FindResource("LUD_ContentLoadStoryBoard");
                    LUD_ContentStoryBoard.Begin();
                };
        }



    }
}