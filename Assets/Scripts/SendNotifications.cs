using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendNotifications : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        // Schedules a notification for some time in the future
        // Figure out how to schedule just one notification per day,
        // and not schedule one when there is one scheduled for today already.
        var notification = new AndroidNotification();
        notification.Title = "Quote of the Day";
        notification.Text = "Populate this field with today's quote.";
        notification.FireTime = System.DateTime.Now.;

        AndroidNotificationCenter.SendNotification(notification, "channel_id");




    }

    // Update is called once per frame
    void Update() {
        
    }
}
