using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterData {

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

}

public class UI_Controller : MonoBehaviour
{
    public Text CharNameOut;
    public Text alignmentOut;
    public Text currentXPOut;
    public Text currentHPOut;
    public Text maxXPOut;
    public Text maxHPOut;
    public Text armorOut;
    public InputField CharNameIn;
    public Text strengthOutput;
    public Text dexterityOutput;
    public Text constitutionOutput;
    public Text intelligenceOutput;
    public Text wisdomOutput;
    public Text charismaOutput;
    public Dropdown raceIn;
    public Dropdown classIn;
    public InputField alignmentIn;
    public InputField currentXPIn;
    public InputField maxXPIn;
    public InputField currentHPIn;
    public InputField maxHPIn;
    public InputField armorClassin;
    public Slider walkSpeedIn;
    public Slider runSpeedIn;
    public Slider jumpHeightIn;

    CharacterData characterData = new CharacterData();

    public void rollStrength() {
        int strength;
        List<int> d8 = new List<int>();
        List<int> d3 = new List<int>();

        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));

        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));

        d8.Sort();
        d3.Sort();
        d8.RemoveRange(0,2);
        d3.RemoveRange(0,3);

        strength = d8.Sum() + d3.Sum() + 2;
        strengthOutput.text = strength.ToString();
        characterData.Ability_Strength = strength;
    }


    
    public void rollDexterity() {
        int dexterity;
        List<int> d8 = new List<int>();
        List<int> d3 = new List<int>();

        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));

        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));

        d8.Sort();
        d3.Sort();
        d8.RemoveRange(0,2);
        d3.RemoveRange(0,3);

        dexterity = d8.Sum() + d3.Sum() + 2;
        dexterityOutput.text = dexterity.ToString();
        characterData.Ability_Dexterity = dexterity;
    }

    public void rollConstitution() {
        int constitution;
        List<int> d8 = new List<int>();
        List<int> d3 = new List<int>();

        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));

        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));

        d8.Sort();
        d3.Sort();
        d8.RemoveRange(0,2);
        d3.RemoveRange(0,3);

        constitution = d8.Sum() + d3.Sum() + 2;
        constitutionOutput.text = constitution.ToString();
        characterData.Ability_Constitution = constitution;
    }

    public void rollIntellignece() {
        int intelligence;
        List<int> d8 = new List<int>();
        List<int> d3 = new List<int>();

        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));

        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));

        d8.Sort();
        d3.Sort();
        d8.RemoveRange(0,2);
        d3.RemoveRange(0,3);

        intelligence = d8.Sum() + d3.Sum() + 2;
        intelligenceOutput.text = intelligence.ToString();
        characterData.Ability_Intelligence = intelligence;
    }

    public void rollWisdom() {
        int wisdom;
        List<int> d8 = new List<int>();
        List<int> d3 = new List<int>();

        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));

        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));

        d8.Sort();
        d3.Sort();
        d8.RemoveRange(0,2);
        d3.RemoveRange(0,3);

        wisdom = d8.Sum() + d3.Sum() + 2;
        wisdomOutput.text = wisdom.ToString();
        characterData.Ability_Wisdom = wisdom;
    }

    public void rollCharisma() {
        int charisma;
        List<int> d8 = new List<int>();
        List<int> d3 = new List<int>();

        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));
        d8.Add(Random.Range(1,9));

        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));
        d3.Add(Random.Range(1,4));

        d8.Sort();
        d3.Sort();
        d8.RemoveRange(0,2);
        d3.RemoveRange(0,3);

        charisma = d8.Sum() + d3.Sum() + 2;
        charismaOutput.text = charisma.ToString();
        characterData.Ability_Charisma = charisma;
    }

    public void back() {
        SceneManager.LoadScene(0);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        characterData.race = raceIn.options[0].text;
        characterData.characterClass = classIn.options[0].text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public InputField JSON;

    void saveCharacter() {
        Global_CharacterData.Instance.Ability_Charisma = characterData.Ability_Charisma;
        Global_CharacterData.Instance.Ability_Constitution = characterData.Ability_Constitution;
        Global_CharacterData.Instance.Ability_Dexterity = characterData.Ability_Dexterity;
        Global_CharacterData.Instance.Ability_Intelligence = characterData.Ability_Intelligence;
        Global_CharacterData.Instance.Ability_Strength = characterData.Ability_Strength;
        Global_CharacterData.Instance.Ability_Wisdom = characterData.Ability_Wisdom;
        Global_CharacterData.Instance.race = characterData.race;
        Global_CharacterData.Instance.characterName = characterData.characterName;
        Global_CharacterData.Instance.characterClass = characterData.characterClass;
        Global_CharacterData.Instance.alignment = characterData.alignment;
        Global_CharacterData.Instance.armorClass = characterData.armorClass;
        Global_CharacterData.Instance.currentHP = characterData.currentHP;
        Global_CharacterData.Instance.currentXP = characterData.currentXP;
        Global_CharacterData.Instance.maxHP = characterData.maxHP;
        Global_CharacterData.Instance.maxXP = characterData.maxXP;
        Global_CharacterData.Instance.runningSpeed = characterData.runningSpeed;
        Global_CharacterData.Instance.walkingSpeed = characterData.walkingSpeed;
        Global_CharacterData.Instance.jumpHeight = characterData.jumpHeight;
    }
    
    public void characterDataJSON() {
        JSON.text = JsonUtility.ToJson(characterData);
        saveCharacter();
        Global_CharacterData.Instance.characterCreated = true;
    }

    public void setCharName() {
        characterData.characterName = CharNameIn.text.ToString();
    }

    public void setRace() {
        characterData.race = raceIn.options[raceIn.value].text;
    }

    public void setClass() {
        characterData.characterClass = classIn.options[classIn.value].text;
    }

    public void setAlignment() {
        characterData.alignment = alignmentIn.text.ToString();
    }

    public void setCurrentXP() {
        characterData.currentXP = int.Parse(currentXPIn.text);
    }

    public void setMaxXP() {
        characterData.maxXP = int.Parse(maxXPIn.text);
    }

    public void setCurrentHP() {
        characterData.currentHP = int.Parse(currentHPIn.text);
    }

    public void setMaxHP() {
        characterData.maxHP = int.Parse(maxHPIn.text);
    }

    public void setArmorClass() {
        int armor = int.Parse(armorClassin.text);
        if(armor >= 100) {
            armor = 99;
        }
        else if (armor <= 0) {
            armor = 1;
        }
        else {
            characterData.armorClass = armor;
        }
    }

    public void setWalkSpeed() {
        characterData.walkingSpeed = (int) walkSpeedIn.value;
    }

    public void setRunSpeed() {
        characterData.runningSpeed = (int) runSpeedIn.value;
    }

    public void setJumpHeight() {
        characterData.jumpHeight = (int) jumpHeightIn.value;
    }

}
