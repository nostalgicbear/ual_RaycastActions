using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script controlls how spheres get created in our scene. We create spheres, and then add a rigidbody which we add force to (to shoot it against a wall). This script introduces you to the InvokeRepeating method which allows you to call 
/// a function constantly every X seconds. It also shows you how we can create objects, how to add components to an object, how to add force to an object, and how to delete an object after X amount of time
/// </summary>
public class SpawnController : MonoBehaviour
{

    float force = 20.0f; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 2.0f, 5.0f); //Google 'Unity Invoke Repeating'. This function calls the SPAWNOBJECT function after 2.0 seconds, and then it calls it every 5.0 seconeds after that
    }

    /// <summary>
    /// This function spawns a new sphere, adds some components to it, and then shoots it off in the forward direction by adding force to the spheres rigidbody
    /// </summary>
    void SpawnObject()
    {
        GameObject newlyCreatedObject = GameObject.CreatePrimitive(PrimitiveType.Sphere); //Creates a new sphere that is stored in the 'newlyCreatedSphere' variable. 
        newlyCreatedObject.transform.position = transform.position; //The spheres position is set to wherever this object (that has this script on it ) is positioned
        newlyCreatedObject.AddComponent<SphereCollider>(); //Adds a sphere collider to the sphere
        newlyCreatedObject.AddComponent<Rigidbody>(); //Adds a rigidbody to the sphere so we can add force to the rigidbody
        newlyCreatedObject.GetComponent<Rigidbody>().AddForce(newlyCreatedObject.transform.forward * force, ForceMode.Impulse); //We get the rigidbody and add force to that rigidbody

        Destroy(newlyCreatedObject, 8.0f); //This deletes the sphere after 8 seconds (so we dont end up with loads of spheres)
    }
}
