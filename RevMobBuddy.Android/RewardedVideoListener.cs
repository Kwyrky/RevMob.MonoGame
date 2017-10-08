using Android.App;
using Com.Revmob;
using System;

namespace RevMobBuddy.Android
{
	internal class RewardedVideoListener : BaseRevMobListener
	{
		public event EventHandler OnVideoLoaded;
		public event EventHandler<RewardedVideoEventArgs> OnVideoReward;

		public RewardedVideoListener()
		{
			Console.WriteLine("CallbackVideoRewarded");
		}

		public override void OnRevMobRewardedVideoLoaded()
		{
			Console.WriteLine("Rewarded Video loaded.");
			if (null != OnVideoLoaded)
			{
				OnVideoLoaded(this, new EventArgs());
			}
		}

		public override void OnRevMobRewardedVideoStarted()
		{
			Console.WriteLine("Rewarded Video started.");
		}

		public override void OnRevMobRewardedVideoCompleted()
		{
			Console.WriteLine("Rewarded Video completed.");
			if (null != OnVideoReward)
			{
				OnVideoReward(this, new RewardedVideoEventArgs(true));
			}
		}

		public override void OnRevMobRewardedVideoNotCompletelyLoaded()
		{
			Console.WriteLine("Rewarded Video not completely loaded.");
			if (null != OnVideoReward)
			{
				OnVideoReward(this, new RewardedVideoEventArgs(false));
			}
		}

		public override void OnRevMobAdNotReceived(String error)
		{
			Console.WriteLine("Rewarded Video failed to load.");
			if (null != OnVideoReward)
			{
				OnVideoReward(this, new RewardedVideoEventArgs(false));
			}
		}
	}
}