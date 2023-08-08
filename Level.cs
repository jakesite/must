using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject gameController;
    TextMeshProUGUI text;

    void Start()
    {
        float l = gameController.GetComponent<GameController>().Level;
        text=gameObject.GetComponent<TextMeshProUGUI>();
        text.text = l.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
