using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controller_2D : MonoBehaviour
{
[SerializeField] float mouvespeed;

[SerializeField] GameObject bullet;
[SerializeField] Transform bullet_postion;
private Vector2 Mouse_pos;
private Vector2 mouvement;
private Rigidbody2D rb2d;
private float angle;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        mouvement.x = Input.GetAxis("Horizontal");
        mouvement.y = Input.GetAxis("Vertical");
        Mouse_pos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        if (Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }
    private void FixedUpdate(){
        rb2d.MovePosition(rb2d.position + mouvement * mouvespeed * Time.fixedDeltaTime);
        Vector2 vector_look = Mouse_pos - rb2d.position;
        angle = -(Mathf.Atan2(vector_look.x ,vector_look.y) * Mathf.Rad2Deg) +90;
        // Debug.Log(angle  + vector_look.x +  vector_look.y);
        rb2d.rotation = angle;

    }
    void Shoot(){
       //bullet_rotation =  new Vector3 (transform.rotation.x ,transform.rotation.y ,transform.rotation.z -90);
       Instantiate(bullet ,new Vector3 (bullet_postion.position.x,bullet_postion.position.y,-0.1f) , bullet_postion.rotation);
    }
}