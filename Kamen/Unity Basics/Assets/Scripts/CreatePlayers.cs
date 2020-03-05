using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayers : MonoBehaviour
{
    float seconds;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 1)
        {
            seconds--;
            Vector3 position = new Vector3(10*Random.value, 10*Random.value, 10*Random.value);
            GameObject currentPlayer = Instantiate(player, position, Quaternion.identity);
            currentPlayer.AddComponent<Movement>();
        }
    }
}
