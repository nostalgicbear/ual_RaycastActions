using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{

    private float secondsSinceSceneStarted; //How long it has been since the scene started running

    public Text timerText; //The UI element that will display the UI

    // Update is called once per frame
    void Update()
    {
        secondsSinceSceneStarted = Time.time; //Time.time is the time since the scene started. We cant pause this. It always increases
            timerText.text = secondsSinceSceneStarted.ToString(); //This just adds the time to the UI so we can see it
    }
}
