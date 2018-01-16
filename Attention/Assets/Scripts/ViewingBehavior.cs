using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that simulates a recipient viewing a thread on a messaging platform like WhatsApp.
/// </summary>
public class ViewingBehavior : MonoBehaviour {

    private IEnumerator hapticRoutine;

    /// <summary>
    /// Public method used by a toggle on the canvas. It simulates a gaze on the phone while the user is actively in the messaging view.
    /// </summary>
    /// <param name="isViewing">Is the recipient viewing the messaging thread?</param>
    public void OnActiveView(bool isViewing)
    {
        if (isViewing) //if the recipient is viewing the messages
        {
            //play haptics
            if (Vibration.HasVibrator())
            {
                hapticRoutine = VibrateHeartBeat(); //store an instance of the coroutine for later use
                StartCoroutine(hapticRoutine);
            }

        } else
        {
            //stop haptics
            if (Vibration.HasVibrator())
                StopCoroutine(hapticRoutine);
        }
    }

    /// <summary>
    /// Create a heartbeat effect.
    /// </summary>
    /// <returns></returns>
    IEnumerator VibrateHeartBeat()
    {
        while (true) //loop until I stop the coroutine
        {
            //this creates a heartbeat pattern
            Vibration.Vibrate(200);
            yield return new WaitForSeconds(0.3f);
            Vibration.Vibrate(100);
            yield return new WaitForSeconds(1);
        }

    }
}
