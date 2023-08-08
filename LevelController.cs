using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public GameObject gameController;
    TextMeshProUGUI text;
    

    void Start()
    {
       
        text = gameObject.GetComponent<TextMeshProUGUI>();
        GameController game = gameController.GetComponent<GameController>();
        float l = game.Level;
        text.text = l.ToString();
    }
        
        void Update()
    {
        
    }
}
