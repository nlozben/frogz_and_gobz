using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateCharacter : MonoBehaviour
{
    public InputField characterName;
    public Dropdown difficulty;
    public Slider color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back() {
        SceneManager.LoadScene(0);
    }

    void saveCharacter() {
        Global_CharacterData.Instance.characterName = characterName.text.ToString();
        Global_CharacterData.Instance.difficulty = difficulty.options[difficulty.value].text;
        Global_CharacterData.Instance.color = (int) color.value;
    }
    
    public void createCharacter() {
        saveCharacter();
        Global_CharacterData.Instance.characterCreated = true;
    }
}
