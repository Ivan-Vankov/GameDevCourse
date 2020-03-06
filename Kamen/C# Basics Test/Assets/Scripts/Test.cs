using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEngine.Mathf;

[RequireComponent(typeof(Camera))]
public class Test : MonoBehaviour {

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private TestSerializable testSerializable;

    [System.Serializable]
    public class PlayerStats {
        public int movementSpeed;
        public int hitPoints;
        public bool hasHealthPotion;
    }

    public PlayerStats playerStats;

    void Start() {
        var updateMethod = typeof(Test).GetMethod("Update", 
                                                  BindingFlags.NonPublic | BindingFlags.Instance);
  
        if (updateMethod != null) {
            updateMethod.Invoke(this, null);
        }

        print(typeof(Test).GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance));
        print(typeof(Test).GetCustomAttribute<RequireComponent>());
        foreach (var method in typeof(Test).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)) {
            if (method.DeclaringType == typeof(Test)) {
                print(method.Name);
            }
        }

        var speedField = typeof(Test)
            .GetField("speed", 
             BindingFlags.NonPublic | BindingFlags.Instance);
        if (speedField.GetCustomAttribute<SerializeField>() != null) {
            speedField.SetValue(this, 6);
            print($"The new values for speed is {speed}");
        }
        
        int a = 1, b = 2;
        print("a = " + a + "; b = " + b);
        print($"a = {a}; b = {b}");

    }

    public void TestMethod() {

    }

    void Update() {
        //print("In Update");
    }
}
