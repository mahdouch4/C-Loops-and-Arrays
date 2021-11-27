using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    void Start()
    {
        
    }
    void Update()
    {
    gameObjects = GameObject.FindGameObjectsWithTag("Zombies");
        if(Input.GetKeyDown(KeyCode.L)){
        Debug.Log("L pressed");
        foreach (GameObject Zombie in gameObjects){
            Destroy(Zombie);
        }

        }
    }
}
