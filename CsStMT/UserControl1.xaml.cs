using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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

namespace CsStMT
{
	/// <summary>
	/// UserControl1.xaml の相互作用ロジック
	/// </summary>
	public partial class UserControl1 : UserControl
	{
	    private static int befAngle = 0;
		public UserControl1()
		{
			this.InitializeComponent();
            RegistEvent();
		}

	    private void RegistEvent()
	    {
	        VSButton.MouseEnter += (s, e) => ARiAParts3Rotate(0);
	        CmdButton.MouseEnter += (s, e) => ARiAParts3Rotate(30);
	        ThunderBirdButton.MouseEnter += (s, e) => ARiAParts3Rotate(60);
	        EvernoteButton.MouseEnter += (s, e) => ARiAParts3Rotate(90);
	        WMPButton.MouseEnter += (s, e) => ARiAParts3Rotate(120);
	        SteamButton.MouseEnter += (s, e) => ARiAParts3Rotate(150);
	        SkypeButton.MouseEnter += (s, e) => ARiAParts3Rotate(180);
	        PaintButton.MouseEnter += (s, e) => ARiAParts3Rotate(210);
	        IEButton.MouseEnter += (s, e) => ARiAParts3Rotate(240);
	        GoogleChromeButton.MouseEnter += (s, e) => ARiAParts3Rotate(270);
	        CloseButton.MouseEnter += (s, e) => ARiAParts3Rotate(300);
	        ZoomButton.MouseEnter += (s, e) => ARiAParts3Rotate(330);

            
	    }


	    private void ARiAParts3Rotate(int ang)
	    {
            var trans = new RotateTransform
            {
                CenterX = RenderTransformOrigin.X,
                CenterY = RenderTransformOrigin.Y,
                Angle = ang
            };
	        befAngle = ang;
            ARIAParts3.RenderTransform = trans;
	    }

        private void VSButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LayoutRoot_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Right)
                ARiAParts3Rotate(befAngle+30);
            if(e.Key == Key.Left)
                ARiAParts3Rotate(befAngle-30);
        }
	}
}