using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSize(float size) {
        bar.localScale = new Vector3(size, 1f);
    }

    public void setColor(Color color) {
        bar.Find("Bar Sprite").GetComponent<SpriteRenderer>().color = color;
    }

}