using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwingNet : MonoBehaviour
{

    public Animator animator;
    public Transform netPoint;
    public float netRange;
    public LayerMask frogs;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) {
            swing();
        }
    }

    void swing() {
        animator.SetTrigger("swing");
        Collider2D[] caughtFrogs = Physics2D.OverlapCircleAll(netPoint.position, netRange, frogs);
        foreach (Collider2D frog in caughtFrogs) {
            Destroy(gameObject);
            Global_CharacterData.Instance.frogsCollected++;
        }
    }

}
