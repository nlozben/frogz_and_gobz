using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_CharacterData : MonoBehaviour
{
    public string characterName;
    public float Ability_Strength;
    public float Ability_Dexterity;
    public float Ability_Constitution;
    public float Ability_Intelligence;
    public float Ability_Wisdom;
    public float Ability_Charisma;
    public string race;
    public string characterClass;
    public string alignment;
    public int currentXP;
    public int maxXP;
    public int currentHP;
    public int maxHP;
    public int armorClass;
    public int walkingSpeed;
    public int runningSpeed;
    public int jumpHeight;
    public List<int> items;

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
