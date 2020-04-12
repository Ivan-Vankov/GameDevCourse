using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    public float speed;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
        RaycastHit2D[] hitInfo = Physics2D.RaycastAll(transform.position, direction, 0.1f);
        if (hitInfo.Length!=0)
        {
            bool shouldFlip=false;
            foreach (var item in hitInfo)
            {
                if (item.collider.gameObject.tag.Equals("Floor"))
                {
                    shouldFlip = true; 
                } 
            }
            if (shouldFlip) {
                direction *= -1;   
            }
        }
    }

}
