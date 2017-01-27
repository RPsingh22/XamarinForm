//the ViewRenderer class is instantiated, which in turn instantiates a native UIView control

using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MasterDetailPageNavigation.iOS;

using AVFoundation;
using Foundation;
using UIKit;
using CoreGraphics;
using AVKit;


//using XamarinFormsGestureRecognizers;
//using XamarinFormsGestureRecognizers.iOS;

//using Xamarin.Forms;
//using Xamarin.Forms.Platform.iOS;
//using MonoTouch.UIKit;

//using System;
//using GestureRecognizers;  
//using MasterDetailPageNavigation.iOS;
//using UIKit;

//http://arteksoftware.com/gesture-recognizers-with-xamarin-forms/

[assembly: ExportRenderer(typeof(Label), typeof(CoolImageRenderer))]

//namespace GestureRecognizers.iOS
namespace MasterDetailPageNavigation.iOS
{
	public class CoolImageRenderer : LabelRenderer//ImageRenderer //ViewRenderer
	{
		UILongPressGestureRecognizer longPressGestureRecognizer;
		UIPinchGestureRecognizer pinchGestureRecognizer;
		UIPanGestureRecognizer panGestureRecognizer;
		UISwipeGestureRecognizer swipeGestureRecognizer;
		UIRotationGestureRecognizer rotationGestureRecognizer;

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		//protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		//protected override void OnElementChanged(ElementChangedEventArgs<View> e)


		{
			base.OnElementChanged(e);

			//longPressGestureRecognizer = new UILongPressGestureRecognizer(() => Console.WriteLine("Long Press"));
			longPressGestureRecognizer = new UILongPressGestureRecognizer();

			//pinchGestureRecognizer = new UIPinchGestureRecognizer(() => Console.WriteLine("Pinch"));
			pinchGestureRecognizer = new UIPinchGestureRecognizer();

			//panGestureRecognizer = new UIPanGestureRecognizer(() => Console.WriteLine("Pan"));
			panGestureRecognizer = new UIPanGestureRecognizer();

			//swipeGestureRecognizer = new UISwipeGestureRecognizer(() => Console.WriteLine("Swipe"));
			swipeGestureRecognizer = new UISwipeGestureRecognizer();

			rotationGestureRecognizer = new UIRotationGestureRecognizer(() => Console.WriteLine("Rotation"));

			if (e.NewElement == null)
			{
				if (longPressGestureRecognizer != null)
				{
					this.RemoveGestureRecognizer(longPressGestureRecognizer);
				}
				if (pinchGestureRecognizer != null)
				{
					this.RemoveGestureRecognizer(pinchGestureRecognizer);
				}
				if (panGestureRecognizer != null)
				{
					this.RemoveGestureRecognizer(panGestureRecognizer);
				}
				if (swipeGestureRecognizer != null)
				{
					this.RemoveGestureRecognizer(swipeGestureRecognizer);
				}
				if (rotationGestureRecognizer != null)
				{
					this.RemoveGestureRecognizer(rotationGestureRecognizer);
				}
			}

			if (e.OldElement == null)
			{
				this.AddGestureRecognizer(longPressGestureRecognizer);
				this.AddGestureRecognizer(pinchGestureRecognizer);
				this.AddGestureRecognizer(panGestureRecognizer);
				this.AddGestureRecognizer(swipeGestureRecognizer);
				this.AddGestureRecognizer(rotationGestureRecognizer);
			}
		}
	}
}