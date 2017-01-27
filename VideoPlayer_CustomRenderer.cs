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

//ExportRenderer attribute to the custom renderer class to specify that it will be used to render the Xamarin.Forms custom control. 
//1This attribute is used to register the custom renderer with Xamarin.Forms.
[assembly: ExportRenderer(typeof(ContentView), typeof(VideoPlayer_CustomRenderer))]

namespace MasterDetailPageNavigation.iOS
{
	// The first type argument is the custom control the renderer is for
	//The second type argument is the native control that will implement the custom control.
	public class VideoPlayer_CustomRenderer : ViewRenderer
	{
		//declare class variables
		AVAsset _asset;
		AVPlayerItem _playerItem;
		AVPlayer _player;

		AVPlayerLayer _playerLayer;
		UIButton playButton;
		//UISlider videoSlider; 
		//UIButton stopButton;

		protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				// check for current videos and if e.OldElement has content 
				//stops current video n replace with NULL if exist. 
				_player.ReplaceCurrentItemWithPlayerItem(null);
				_player.Pause();
			}

			//save below for reference to control current videoPlayer
			//if (Control == null)
			//{
			//	uiCameraPreview = new UICameraPreview(e.NewElement.Camera);
			//	SetNativeControl(uiCameraPreview);
			//}
			//if (e.OldElement != null)
			//{
			//	// Unsubscribe
			//	uiCameraPreview.Tapped -= OnCameraPreviewTapped;
			//}
			//if (e.NewElement != null)
			//{
			//	// Subscribe
			//	uiCameraPreview.Tapped += OnCameraPreviewTapped;
			//}

			//Get the video
			//bubble up to the AVPlayerLayer

			//toothID from App.ToothIDforIOS
			var ToothIDforIOS = App.ToothIDforIOS;

			//use local file for ToothVideo
			//concatenate two objects to get video title
			//var ToothVideo = ToothIDforIOS + ".mp4";

			//get video path from global class/app.c
			var videoLocation = ToothIDforIOS;

			_asset = AVAsset.FromUrl(NSUrl.FromFilename(videoLocation));

			_playerItem = new AVPlayerItem(_asset);

			//use below to instantiate new objects 

			//create new player 
			_player = new AVPlayer(_playerItem);
			_playerLayer = AVPlayerLayer.FromPlayer(_player);

			//Create the play button
			playButton = new UIButton();
			playButton.SetTitle("Play", UIControlState.Normal);
			//playButton.BackgroundColor = UIColor.Gray;
			//_playerLayer.CurrentTime = (sender as UIKit.UISlider).Value;

			//may not need logic below. 
			if (Tooth.playVideo == "true") //App.playVideoforIOS
			{
				_player.Play();

			}
			else {
				//_playerLayer.Dispose();
				_player.ReplaceCurrentItemWithPlayerItem(null);
				_player.Pause();
			}
			//only play video if tooth has legit toothID


			////slider
			//videoSlider = new UISlider();
			////videoSlider.Value = 10; 
			//videoSlider.MinimumTrackTintColor = UIColor.Blue;
			//videoSlider.MaximumTrackTintColor = UIColor.Red;
			//videoSlider.MaxValue = (float)_playerLayer.Duration;
			////videoSlider.MinValue = 0;
			//videoSlider.Continuous=true;

			//videoSlider.Value = (float)_player.CurrentTime.TimeScale;
			////slider
		
			//videoSlider.SetValue((float)_playerLayer.Duration, true);

			//CoreMedia.CMTime duration = _playerItem.CurrentTime;


			//goooooood
			//videoSlider.SetValue((float)_player.CurrentTime.TimeScale, true);
			//videoSlider.Value = (float)_player.CurrentTime.TimeScale;


			//videoSlider.Value = (float)duration.Seconds.ToString();
			//videoSlider.Value = (float)_playerLayer.Position;
			//videoSlider.MaxValue = (float)_playerLayer.Duration;
			//videoSlider.MaxValue = CoreMedia.CMTime.FromSeconds(_playerItem.Duration);
			//videoSlider.Value = (float)_playerLayer.
			//videoSlider.SetValue(CoreMedia.CMTime.FromSeconds(_player.CurrentTime.Value, 1));

			//method that triggers when slider is touched
			//videoSlider.TouchDown += (object sender, EventArgs arg) =>
			//{
			//	//_player.PlayImmediatelyAtRate(9);
			//	//_player.Rate = 9;
			//	//_player.Seek(CoreMedia.CMTime.FromSeconds(25,1));
			//	//_player.Seek(CoreMedia.CMTime.FromSeconds(videoSlider.Value/3600, 1));

			//	//videoSlider.SetValue((float)_player.CurrentTime.TimeScale, true);
			//	//videoSlider.Value = (float)_player.CurrentTime.TimeScale;

			//	//_player.Seek(CoreMedia.CMTime.FromSeconds(videoSlider.Value, 1));

			//	//_player.Seek(CoreMedia.CMTime.FromSeconds((float)_player.CurrentTime.TimeScale, 1));
			//}; 			

			//videoSlider.MaxValue = (float)_playerLayer.Duration;
			//videoSlider.Value = (double)_playerLayer.Duration;

			//[seekbar setValue:CMTimeGetSeconds(audioPlayer.currentTime)];


			//total time of video
			//videoSlider.MaxValue = (float)_playerLayer.Duration;
			//videoSlider.Value = (float)_player.CurrentTime;


			//do not need Pause button so comment out
			////Set the trigger on the play button to play the video
			//playButton.TouchUpInside += (object sender, EventArgs arg) =>
			//{
			//	_player.Play();
			//};

			////Create the STOP button
			//stopButton = new UIButton();
			//stopButton.SetTitle("Stop", UIControlState.Normal);
			////stopButton.BackgroundColor = UIColor.Red;

			////do not need Pause button so comment out
			////Set the trigger on the play button to play the video
			//stopButton.TouchUpInside += (object sender, EventArgs arg) =>
			//{
			//	_player.Pause();
			//};
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			 	_playerLayer.Frame = NativeView.Frame;
				NativeView.Layer.AddSublayer(_playerLayer);

			//playButton.Frame = new CGRect(1, 2, 3, 4);
			//   NativeView.Add(playButton);

			//videoSlider.Frame = new CGRect(1, 2, 3, 4);
			//   NativeView.Add(videoSlider);

			//create buttonS but do not need buttons at the moment 
			//playButton.Frame = new CGRect(0, NativeView.Frame.Bottom - 34, NativeView.Frame.Width, 24);
			//stopButton.Frame = new CGRect(58, NativeView.Frame.Bottom - 24, NativeView.Frame.Width, 24);
			//stopButton.Frame = new CGRect(0, NativeView.Frame.Bottom - 34, NativeView.Frame.Width, 24);
			//videoSlider.Frame = new CGRect(0, NativeView.Frame.Bottom - 34, NativeView.Frame.Width, 24);

			//add elemets to screen 
			_playerLayer.Frame = NativeView.Frame;
			NativeView.Layer.AddSublayer(_playerLayer);
			//NativeView.Add(videoSlider);

			//NativeView.Add(playButton);
			//NativeView.Add(stopButton);

			//original codes below not working 
			//layout the elements depending on what screen orientation we are. 
			//if (DeviceHelper.iOSDevice.Orientation == UIDeviceOrientation.Portrait)
			//{
			//	playButton.Frame = new CGRect(0, NativeView.Frame.Bottom - 50, NativeView.Frame.Width, 50);
			//	_playerLayer.Frame = NativeView.Frame;
			//	NativeView.Layer.AddSublayer(_playerLayer);
			//	NativeView.Add(playButton);
			//}
			//else if (DeviceHelper.iOSDevice.Orientation == UIDeviceOrientation.LandscapeLeft || DeviceHelper.iOSDevice.Orientation == UIDeviceOrientation.LandscapeRight)
			//{
			//	_playerLayer.Frame = NativeView.Frame;
			//	NativeView.Layer.AddSublayer(_playerLayer);
			//	playButton.Frame = new CGRect(0, 0, 0, 0);

			//}
		}
	}
}