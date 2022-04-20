using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_CharacterData : MonoBehaviour
{
    public string characterName;
    public string difficulty;
    public int color;
    
    public bool characterCreated;

    public static Global_CharacterData Instance {get; private set;}
    
    void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            characterCreated = false;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
