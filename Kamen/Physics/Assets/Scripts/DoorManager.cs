using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
            openDoor();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
            closeDoor();
    }
    void openDoor()
    {
        //door.transform.Translate(new Vector3(0, 3, 0));
        //code below has interpolation for physics
        door.GetComponent<Rigidbody>().MovePosition(door.transform.position + new Vector3(0,3,0));
    }
    void closeDoor()
    {
        //door.transform.Translate(new Vector3(0, -3, 0));
        //code below has interpolation for physics
        door.GetComponent<Rigidbody>().MovePosition(door.transform.position + new Vector3(0,-3,0));
    }
}
