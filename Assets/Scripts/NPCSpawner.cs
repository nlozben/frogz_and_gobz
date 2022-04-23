using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    
    public GameObject goblinPrefrab;
    public GameObject frogPrefab;
    public float goblinInterval = 4f;
    public float frogInterval = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnNPC(frogInterval, frogPrefab));
        StartCoroutine(spawnNPC(goblinInterval, goblinPrefrab));
    }

    private IEnumerator spawnNPC(float interval, GameObject NPC) {
        yield return new WaitForSeconds(interval);
        int spawnY;
        if (Random.Range(0,2) == 1) {
            spawnY = 110;
        }
        else {
            spawnY = 33;
        }
        GameObject newNPC = Instantiate(NPC, new Vector3(Random.Range(10f, 990f), spawnY, 0), Quaternion.identity);
        StartCoroutine(spawnNPC(interval, NPC));
    }
}
