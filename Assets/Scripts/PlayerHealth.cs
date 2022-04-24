using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    int health = 100;
    int damage;
    float barDelete;
    bool dead;
    int frogsNeeded;
    float healthBarSize = 1f;
    public HealthBar healthBar;
    public GameObject player;
    Color colorBase;
    
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        if (Global_CharacterData.Instance.difficulty == "Easy") {
            damage = 5;
            barDelete = 0.05f;
            frogsNeeded = 20;
        }
        else if (Global_CharacterData.Instance.difficulty == "Medium") {
            damage = 10;
            barDelete = 0.1f;
            frogsNeeded = 35;
        }
        else if (Global_CharacterData.Instance.difficulty == "Hard") {
            damage = 20;
            barDelete = 0.2f;
            frogsNeeded = 50;
        }

        if (Global_CharacterData.Instance.color == "Grey") {
            colorBase = Color.white;
            player.GetComponent<SpriteRenderer>().color = colorBase;
        }
        else if (Global_CharacterData.Instance.color == "Blue") {
            colorBase = Color.blue;
            player.GetComponent<SpriteRenderer>().color = colorBase;
        }
        else if (Global_CharacterData.Instance.color == "Green") {
            colorBase = Color.green;
            player.GetComponent<SpriteRenderer>().color = colorBase;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWin()) {
            SceneManager.LoadScene(6);
        }
    }

    private IEnumerator damageVisual(Color color) {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = colorBase;
    }

    public void takeDamage(int damage) {
        health -= damage;
        healthBarSize -= barDelete;
        FindObjectOfType<AudioManager>().play("Hurt");
        StartCoroutine(damageVisual(Color.red));
        healthBar.setSize(healthBarSize);
        if (health <= 0) {
            dead = true;
            SceneManager.LoadScene(5);
        }
        if (healthBarSize <= 0.4f) {
            healthBar.setColor(Color.red);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Goblin goblin = collision.GetComponent<Goblin>();
        if (goblin != null) {
            takeDamage(damage);
        }
    }

    public bool isDead() {
        return dead;
    }

    public bool isWin() {
        if (Global_CharacterData.Instance.frogsCollected == frogsNeeded) {
            return true;
        }
        else {
            return false;
        }
    }


}
