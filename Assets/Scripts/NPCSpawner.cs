using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    
    public GameObject goblinPrefrab;
    public GameObject frogPrefab;
    public float goblinInterval = 4f;
    public float frogInterval = 2f;
    IEnumerator goblinSpawn;
    IEnumerator frogSpawn;
    PlayerHealth playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        goblinSpawn = spawnNPC(goblinInterval, goblinPrefrab);
        frogSpawn = spawnNPC(frogInterval, frogPrefab);
        StartCoroutine(goblinSpawn);
        StartCoroutine(frogSpawn);
    }

    void Update() {
        if (playerHealth.isDead() || playerHealth.isWin()) {
            StopCoroutine(goblinSpawn);
            StopCoroutine(frogSpawn);
        }
    }

    private IEnumerator spawnNPC(float interval, GameObject NPC) {
        yield return new WaitForSeconds(interval);
        int spawnY;
        if (Random.Range(0,2) == 1) {
            spawnY = 140;
        }
        else {
            spawnY = 33;
        }
        GameObject newNPC = Instantiate(NPC, new Vector3(Random.Range(10f, 990f), spawnY, 0), Quaternion.identity);
        StartCoroutine(spawnNPC(interval, NPC));
    }
}
