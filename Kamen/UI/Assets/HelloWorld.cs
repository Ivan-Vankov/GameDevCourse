using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{

   public UnityEvent ue; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void printHello()
    {

        Debug.Log("Hello world");
    }
}
