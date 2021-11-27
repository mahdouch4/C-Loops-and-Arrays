using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health_manager : MonoBehaviour
{
    [SerializeField] Slider health_bar;
    [SerializeField] GameObject player;
    [SerializeField] float Player_Health = 100f;
    private Animator hit_animation;
    private float health_bar_num;
    //private float Player_Health = 100f;
    void Start()
    {
        
    }
    void Update()
    {
        if (Player_Health <= 0){
            Destroy(player,1f);
        }
    }
   void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Player")
    {
        Player_Health -= 0.001f;
        health_bar_num = health_bar_num / 100;
        health_bar.value = health_bar_num;
    }
}
}
