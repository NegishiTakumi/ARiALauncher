using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace CsStMT
{
	/// <summary>
	/// DateTimeUserControl.xaml の相互作用ロジック
	/// </summary>
	public partial class DateTimeUserControl : UserControl
	{
		public DateTimeUserControl()
		{
			this.InitializeComponent();
            StoryEventRegist();
            TimerUpdate();
		}

        private void TimerUpdate()
        {
            var timer = new DispatcherTimer();
            timer.Tick += (sender, args) =>
                {
                    textBlock3.Text = DateTime.Today.DayOfWeek.ToString().Substring(0, 3);
                    textBlock4.Text = DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day;
                    textBlock5.Text = DateTime.Now.ToString("HH:mm:ss");
                };
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void StoryEventRegist()
        {
            var dt_RingLoadStoryBoard = (Storyboard)FindResource("DT_RingLoadStoryBoard");
            dt_RingLoadStoryBoard.Completed += (s, e) =>
            {
                var DT_ContentLoadStoryBoard = (Storyboard)FindResource("DT_ContentLoadStoryBoard");
                DT_ContentLoadStoryBoard.Begin();
            };
        }
	}
}