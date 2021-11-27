using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] Transform bullet_postion;
    [SerializeField] float bulletForce = 5f;
    private Rigidbody2D rb_bullet;


    void Start()
    {
       rb_bullet = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       rb_bullet.AddForce(bullet_postion.up * bulletForce, ForceMode2D.Impulse);    
    }
    void OnTriggerEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Zombies")
    {
        Destroy(collision.gameObject);

    }
}
}
