using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    float speed = 8f;
    float jumpingPower = 20f;
    public Rigidbody2D rb;
    public GameObject player;
    PlayerHealth playerHealth;

    int health = 100;

    void Start() {
        player = GameObject.Find("Player");
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        followPlayer();
        if (playerHealth.isDead() || playerHealth.isWin()) {
            Destroy(gameObject);
        }
    }

    private IEnumerator damageVisual(Color color) {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void takeDamage (int damage) {
        health -= damage;
        FindObjectOfType<AudioManager>().play("Hurt");
        StartCoroutine(damageVisual(Color.red));
        if (health <= 0) {
            Destroy(gameObject);
            Global_CharacterData.Instance.goblinsKilled++;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    void followPlayer() {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
