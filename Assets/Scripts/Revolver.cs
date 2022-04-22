using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    
    public Transform revolver;
    public GameObject bullet;

    PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
         Vector2 revolverPosition = transform.position;
         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector2 direction = mousePosition - revolverPosition;
         if (playerMovement.isFacingRight) {
            transform.right = -direction;
         }
         else {
            transform.right = direction;
         }
         if (Input.GetButtonDown("Fire1")) {
            shoot();
        }
    }

    void shoot() {
        Instantiate(bullet, revolver.position, revolver.rotation);
    }

}
