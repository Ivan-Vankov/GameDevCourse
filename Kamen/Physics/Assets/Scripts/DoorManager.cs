using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    bool shouldOpen = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            shouldOpen = true;
            StartCoroutine(openDoor());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag.Equals("Player"))
        {
            shouldOpen = false;
            StartCoroutine(closeDoor());
        }
            
    }
    IEnumerator openDoor()
    {
        while (shouldOpen)
        {
            door.transform.Translate(Time.deltaTime * new Vector3(0, 3, 0));

            if (door.transform.position.y >= 3.771)
            {
                door.transform.position = new Vector3(door.transform.position.x, 3.771f, door.transform.position.z);
                yield break;
            }
            yield return null;
        }
    }
    IEnumerator closeDoor()
    {
        while (!shouldOpen)
        {
            door.transform.Translate(Time.deltaTime * new Vector3(0, -3, 0));

            if (door.transform.position.y <= 0.771)
            {
                door.transform.position = new Vector3(door.transform.position.x, 0.771f, door.transform.position.z);
                yield break;
            }
            yield return null;
        }
    }
}
