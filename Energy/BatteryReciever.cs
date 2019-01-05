using System;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Energy
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    public class BatteryReciever : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            int batteryLevel = intent.GetIntExtra(BatteryManager.ExtraLevel, -1);
            Toast.MakeText(context, $"Battery Level: {batteryLevel}%", ToastLength.Long);
            Console.WriteLine(batteryLevel);
        }
    }
}
