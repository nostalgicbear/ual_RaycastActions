using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DistanceActionController : MonoBehaviour
{
    public Transform player; //The player. In this example I use the main camera as the player
    public UnityEvent onPlayerApproach; //These events will get called when the player is in range of whatever object this script is on
    public UnityEvent onPlayerDepart; //These events will get called when the player leaves the range of the object that this script is on 

    [SerializeField] //This tag means you can see private variables in the unity editor. (E.g usually if a variable is private, you cant see it, like you can when its public. This allows you to see private variables in the inspector too)
    private float inRangeDistance; //This is the distance that we consider 'in range'. (E.g if this is set to 5, then the player is in range if the distance between the player and this object is less than 5).
    private bool actionPerformed = false; //This keeps track of whether we have perfomrmed the 'onPlayerApproach' and 'onPlayerDepart' actions as we dont want to call them multiple times
    private float distanceToPlayer; //This stores the distance between the object this script is on and the player

    // Update is called once per frame
    void Update()
    {
        CheckDistanceToPlayer();
    }

    /// <summary>
    /// This function is called in the Update function. That means its called multiple times per second so we are always checking how far the player is from this object. This function checks to see if the player has come in range of this object, and if the player has, it calls whatever you put in the 'onPlayerApproach' events. When the player then moves away from this object, 
    /// </summary>
    private void CheckDistanceToPlayer()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position); //Stores the distance between the player and this object in the 'distanceToPlayer' variable. Google 'Unity Vector3.Distance' if you want to learn more
        Debug.Log("Distance to player is : " + distanceToPlayer); //This prints out to the console so we can see the distance

        if (distanceToPlayer < inRangeDistance) //If the distance to the player is less than than the range we have set...
        {
            if (actionPerformed == false) //...we check to see if we have not just called the 'onPlayerApproach' event, and if we have not...
            {
                onPlayerApproach.Invoke(); //...we perform the event
                actionPerformed = true; // and we set the actionPerformed to true, so we dont keep calling the event (E.g if we play an animation, we dont want to keep playing it over and over multiple times per second. We just play it once)
            }
        }
        else { //Else the player is NOT in range of the object
            if(actionPerformed == true)
            {
                onPlayerDepart.Invoke(); //So we perfom the action for when the player is no longer in range
                actionPerformed = false;
            }
        }
    }
}
