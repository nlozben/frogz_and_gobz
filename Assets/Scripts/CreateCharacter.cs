using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateCharacter : MonoBehaviour
{
    public InputField characterName;
    public Dropdown difficulty;
    public Dropdown color;
    public GameObject preview;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showPreview();
    }

    void saveCharacter() {
        Global_CharacterData.Instance.characterName = characterName.text.ToString();
        Global_CharacterData.Instance.difficulty = difficulty.options[difficulty.value].text;
        Global_CharacterData.Instance.color = color.options[color.value].text;
        SceneManager.LoadScene(0);
    }
    
    public void createCharacter() {
        saveCharacter();
        Global_CharacterData.Instance.characterCreated = true;
    }

    public void showPreview() {
        if (color.options[color.value].text == "Grey") {
            preview.GetComponent<Image>().color = Color.white;
        }
        else if (color.options[color.value].text == "Blue") {
            preview.GetComponent<Image>().color = Color.blue;
        }
        else if (color.options[color.value].text == "Green") {
            preview.GetComponent<Image>().color = Color.green;
        }
    }
}
