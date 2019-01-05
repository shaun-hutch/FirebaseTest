using System;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Energy
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    public class BatteryReciever : BroadcastReceiver
    {
        MainActivity activity;

        public BatteryReciever() { }

        public BatteryReciever(MainActivity _activity)
        {
            activity = _activity;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            int batteryLevel = intent.GetIntExtra(BatteryManager.ExtraLevel, -1);

            
            activity.RunOnUiThread(() =>
            {
                Toast.MakeText(context, $"Battery Level: {batteryLevel}%", ToastLength.Short).Show();
            });
            Console.WriteLine(batteryLevel);
        }
    }
}
