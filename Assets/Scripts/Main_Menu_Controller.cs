using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu_Controller : MonoBehaviour
{
    
    public Button playGame;
    
    // Start is called before the first frame update
    void Start()
    {
       playGame = GameObject.Find("Play Game Button").GetComponent<Button>();
       playGame.interactable = Global_CharacterData.Instance.characterCreated;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadAbout() {
        SceneManager.LoadScene(1);
    }

    public void loadSettings() {
        SceneManager.LoadScene(2);
    }

    public void loadRollCharacter() {
        SceneManager.LoadScene(3);
    }

    public void loadGame() {
        SceneManager.LoadScene(4);
    }

    public void quit() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
