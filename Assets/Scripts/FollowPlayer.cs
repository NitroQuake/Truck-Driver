using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
        // creates a game object variable
    [SerializeField] Vector3 offset = new Vector3(0, 5, -7);
        // creates an instance (new Vector3(0, 5, -7)) and not a variable ((0, 5, -7)). Instance are usually used for only providing a value for a single line of code

    // Update is called once per frame
    void LateUpdate()
        // makes the camera less jittery 
    {
        transform.position = player.transform.position + offset;
            // the position of the camera is set to the game object's position
            // offset the camera behind the player by adding to the player's position 
    }
}
