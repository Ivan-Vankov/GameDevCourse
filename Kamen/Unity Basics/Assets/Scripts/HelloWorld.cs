using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField]
    private int speed = 15;
    // Start is called before the first frame update
    void Start() { 
        print(speed);
        //transform.position = new Vector3(-10, 10, 10);
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(3, 3, 3);
        
        
    }
    //Called every frame
    void Update(){
        //transform.Translate(speed*Time.deltaTime,0,0);
        
    }
}
