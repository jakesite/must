using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public GameObject gameController;
    TextMeshProUGUI text;
    void Start()
    {
        text=gameObject.GetComponent<TextMeshProUGUI>();
        float l = gameController.GetComponent<GameController>().Level;
        text.text=(l+1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
