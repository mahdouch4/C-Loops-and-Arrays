using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_AI : MonoBehaviour
{
    [SerializeField] float movespeed;
    [SerializeField] float Zombie_Health = 30f;
    private Vector2 dir;
    Transform target;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		target = GameObject.Find("Player").transform;
        InvokeRepeating("Spawn",5f,7f);
    }
    void Update()
    {
        if (target){
            dir = target.position - transform.position;
        }
        if(Zombie_Health <= 0){
            Destroy(gameObject);
        }  
    //Debug.Log(Random.value);
    }
    Vector3 RandomCircle (Vector3 center,float radius){
	 float ang = Random.value * 360;
	 Vector3 pos;
	 pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
	 pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
	 pos.z = -1;
	 return pos;
    }
    void Spawn()
{
	Vector3 position = RandomCircle(Vector3.zero, 20);
    Vector3 spawn_postion = new Vector3(position.x,position.y,-0.1f);
	Instantiate(gameObject, spawn_postion, Quaternion.identity);
    
}
    private void FixedUpdate(){
        float angle = -(Mathf.Atan2(dir.x,dir.y) * Mathf.Rad2Deg)+90;
        rb.velocity = dir*movespeed * Time.fixedDeltaTime;
        rb.rotation = angle;
    }
       void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag == "Bullet")
    {
        Zombie_Health -= 10f;
        Destroy(collision.gameObject);

    }
}
}
