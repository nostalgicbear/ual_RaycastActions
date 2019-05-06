using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimeController : MonoBehaviour
{

    public List<GameObject> spheres; //This is a list of all the spheres in the scene

    public bool slowTime; //When this is TRUE, we slow time. When it is FALSE, time passes at a normal rate

    private float slowedTimeSpeed = 0.2f; //This is how slow we want time to pass when we slow time. Full speed = 1.0f. Half speed = 0.5f. I just randomly choose 0.2f as it is quite slow and clear to see that we are slowing time.
    
    // Start is called before the first frame update
    void Start()
    {
        SetRandomColorForSpheres(); //When we run the game, I generate random colours for the spheres. This will be different each time you run the game
    }

    /// <summary>
    /// This finction goes through all the spheres in our 'spheres' list and then generates a random colour for that sphere. 
    /// </summary>
    private void SetRandomColorForSpheres()
    {
        foreach(GameObject sphere in spheres)
        {
            Color newColour = GenerateRandomColor(); //Calls the 'GenerateRandomColor' method, and stores the generated color in the 'newColor' variable
            sphere.GetComponent<Renderer>().material.color = newColour; //Sets the color of the spheres material to be the color we generated
        }
    }


    /// <summary>
    /// This method returns a randonly generated color.
    /// </summary>
    /// <returns></returns>
    private Color GenerateRandomColor()
    {
        Color color = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f)); //This generated a random color. Every colour has an RGB (Red, Green, Blue) value. In this line, we generate a new colur with a random R value, a random G value, and a random B value. 
        return color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckForSlowTime(); //Every frame we check to see if the user has slowed time
    }


    /// <summary>
    /// This function sets the speed at which time passes. This is controlled by the 'slowTime' variable.
    /// </summary>
    private void CheckForSlowTime()
    {
        if (slowTime == true) //If slowTime is true...
        {
            if (Time.timeScale != slowedTimeSpeed)
                Time.timeScale = slowedTimeSpeed; //we set the the Time.timeScale value to be 
            Time.fixedDeltaTime = slowedTimeSpeed * 0.02f; //If you comment out this line, you will see that the game jitters. This is because we need to adjust the rate at which our physics update to match the newly slowed speed (I get that this is confusing, sont worry about it too much!)
        }
        else //Else slowTime is false, and we should run at the normal speed
        {
            if (Time.timeScale != 1.0f)
            {
                Time.timeScale = 1.0f;
            }
        }
    }
}
