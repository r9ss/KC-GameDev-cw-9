using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    SpriteRenderer sprite;
    bool facingRight = true;
    Animator anim;
    public float BulletSpeed;

    public GameObject bulletPrefab;
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        flipSprite();
        playerAnimations();
        Fire();
    }

    void flipSprite()
    {
        if(facingRight == true && Input.GetKeyDown(KeyCode.A))
        {
            sprite.flipX = true;
            facingRight = false;
        }
        else if(facingRight == false && Input.GetKeyDown(KeyCode.D))
        {
            sprite.flipX = false;
            facingRight = true;
        }
    }

    void playerAnimations()
    {
        float speed = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(speed));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    }

    void Fire()
    {
        if(Input.GetMouseButtonDown(0)&& facingRight)
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed, 0f);
            Destroy(bullet, 4f);
        }
        else if(Input.GetMouseButtonDown(0)&& !facingRight)
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-BulletSpeed, 0f);
            Destroy(bullet, 4f);
        }
    }
}
