using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastAction : MonoBehaviour
{
    private RaycastController camerasRaycast; //This is the RaycastController script on the camera
    private bool hasEventBeenPerformed = false;


    public UnityEvent eventToPerformWhenLookedAt; //This is the event that will be performed when the object is looked at
    public UnityEvent eventToPerfomWhenNotLookedAt; //This is performed when we are no longer looking at the object


    private void Start()
    {
        camerasRaycast = Camera.main.GetComponent<RaycastController>(); //This finds the raycast controller script on the camera when we run the game. 
    }

    private void Update()
    {
        IsObjectBeingLookedAt(); //This gets called every frame so we are always checking to see if the camera is looking at this object
    }

    private void IsObjectBeingLookedAt()
    {
        if (camerasRaycast.objectWerAreLookingAt == gameObject) //This says 'if the object that the camera is looking at is this object...'
        {
            if (hasEventBeenPerformed == false) //This says 'if we have not just performed the actiion'... (we do this because if the camera keeps looking at the object we do not want to perform the action over and over. We just do it once)
            {
                eventToPerformWhenLookedAt.Invoke(); //Perform the actions that have set 
                hasEventBeenPerformed = true; //We then set this variable to be true, so we dont keep performing the action. 
            }
        }
        else { //Else if the camera is NOT looking at this object
            if(hasEventBeenPerformed == true) //If we have just perfomed the action for when we are looking at the object....
            {
                //Anything in here gets called when the camera was looking at the object but has just stopped looking at the object (i.e the camera is now looking away...)
                eventToPerfomWhenNotLookedAt.Invoke();
                hasEventBeenPerformed = false;
            }
        }
    }
}
