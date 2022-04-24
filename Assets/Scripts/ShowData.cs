using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{
    public Text characterName;
    public Text goblinCounter;
    public Text frogCounter;
    public Text winNumber;

    // Start is called before the first frame update
    void Start()
    {
        characterName.text = Global_CharacterData.Instance.characterName;
        if (Global_CharacterData.Instance.difficulty == "Easy") {
            winNumber.text = "20";
        }
        else if (Global_CharacterData.Instance.difficulty == "Medium") {
            winNumber.text = "35";
        }
        else if (Global_CharacterData.Instance.difficulty == "Hard") {
            winNumber.text = "50";
        }
    }

    // Update is called once per frame
    void Update()
    {
        showGoblinCount();
        showFrogCount();
    }

    private void showGoblinCount() {
        goblinCounter.text = Global_CharacterData.Instance.goblinsKilled.ToString();
    }

    private void showFrogCount() {
        frogCounter.text = Global_CharacterData.Instance.frogsCollected.ToString();
    }

}
