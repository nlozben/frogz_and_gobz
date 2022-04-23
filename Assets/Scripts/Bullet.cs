using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    public Rigidbody2D rb;
    PlayerMovement playerMovement;
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        if (Global_CharacterData.Instance.difficulty == "Easy") {
            damage = 35;
        }
        else if (Global_CharacterData.Instance.difficulty == "Medium") {
            damage = 25;
        }
        else if (Global_CharacterData.Instance.difficulty == "Hard") {
            damage = 20;
        }
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (playerMovement.isFacingRight) {
            rb.velocity = transform.right * -speed;
        }
         else {
            rb.velocity = transform.right * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Goblin goblin = collision.GetComponent<Goblin>();
        if (goblin != null) {
            goblin.takeDamage(damage);
        }
        Destroy(gameObject);
    }

}
