using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "you done it\nin: " + Mathf.RoundToInt(Time.time).ToString() + "s"; 
    }
}
