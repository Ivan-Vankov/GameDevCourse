using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mushroom;
    public Sprite usedSprite;

    private bool hasSpawned;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hasSpawned = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && !hasSpawned)
        {
            hasSpawned = true;
            GameObject.Instantiate(mushroom);
            spriteRenderer.sprite = usedSprite;
        }
    }
}
