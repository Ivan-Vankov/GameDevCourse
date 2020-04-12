using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerChanger : MonoBehaviour
{
    public RuntimeAnimatorController bigMario;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void changeAnimatorController()
    {
        animator.runtimeAnimatorController = bigMario; 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mushroom"))
        {
            Destroy(collision.gameObject);
            changeAnimatorController();
        }
    }
}
