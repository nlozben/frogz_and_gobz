using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwingNet : MonoBehaviour
{

    public Animator animator;
    public Transform netPoint;
    public float netRange;
    public LayerMask frogs;
    public float swingRate = 2f;
    float nextSwingTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSwingTime) {
            if (Input.GetButtonDown("Fire2")) {
                swing();
                nextSwingTime = Time.time + 1f / swingRate;
            }
        }
    }

    void swing() {
        animator.SetTrigger("swing");
        Collider2D[] caughtFrogs = Physics2D.OverlapCircleAll(netPoint.position, netRange, frogs);
        foreach (Collider2D frog in caughtFrogs) {
            frog.GetComponent<Frog>().getCaught();
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(netPoint.position, netRange);
    }

}
