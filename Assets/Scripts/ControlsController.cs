using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlsController : MonoBehaviour
{
    public void back() {
        SceneManager.LoadScene(0);
    }
}
