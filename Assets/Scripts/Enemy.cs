using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float movementSpeed = 15f, health = 10f, fireRateCooldown = 0.4f, scoreForDistruction=100; 
    public float radius = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.DefaultMovement();
        this.CheckForDeath();
    }

    private void DefaultMovement(){
        this.transform.position = new Vector3(this.transform.position.x,
                                              this.transform.position.y - movementSpeed * Time.deltaTime,
                                              this.transform.position.z);
    }

    void CheckForDeath(){
         if (this.transform.position.y < -Camera.main.orthographicSize ){
            Destroy(this.transform.gameObject);    
        }
    }
}
