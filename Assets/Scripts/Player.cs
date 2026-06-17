using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float gravity = -9.8f;
    private Vector3 direction;
    public float strength = 2f;
    public Sprite[] sprites;
    public int SpriteIndex;
    private GameManager gm;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        gm = GameManager.instance;
        InvokeRepeating(nameof(AnimateSprite), 0.15f,0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction  = Vector3.up * strength ;
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }


    private void AnimateSprite()
    {
        SpriteIndex++;
        if(SpriteIndex >= sprites.Length)
        {
            SpriteIndex= 0;
        }
       spriteRenderer.sprite = sprites[SpriteIndex];

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            gm.GameOver();
        }
        else if(collision.gameObject.tag == "ScoreCounter")
        {
            gm.IncreasingScore();
        }
    }

}
