using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controlls;
public class CheckForIncomingAttacks : MonoBehaviour
{
    //distance treshold from the player which will check for incoming attacks and crouch
    private float distanceTreshold = 0.4f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            GameObject player = GameObject.Find("Monk");
            float random = Random.value;
            if (random <= 0.2f 
                && (player.transform.position - transform.position).magnitude < distanceTreshold
                && GetComponent<Health>().getHealth()>0)
            {
                animator.SetTrigger("shouldCrouch");
            }
        }
    }
}
