using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastController : MonoBehaviour
{
    private RaycastHit hit; //stores the info on the object the raycast hits

    private float rayLength = 100f; //This is the length of the raycast. Make this as long or short as you want. E.g if this is 100, the raycast will cast out 100 units in length
    // Start is called before the first frame update

    public GameObject objectWerAreLookingAt;

    // Update is called once per frame
    void Update()
    {
        PerformRaycast();
    }

    private void PerformRaycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength)) //casts a ray from this object (that the script is on) position. Casts the ray in the forward direction. Stores what we hit in the 'hit' object. Casts the ray out for as long as you set the rayLength to be. 
        {
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.green);
            objectWerAreLookingAt = hit.transform.gameObject;

        }
        else
        {
            //Anything you put in here will get called if you are NOT hitting ANY object with your raycast
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red); //we make the ray red when not hitting anything
            objectWerAreLookingAt = null;
        }   
    }
}
