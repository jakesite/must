using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    GameController gamecontrolle;
    void Start()
    {
        Transform gameController=transform.Find("/GameController");
        gamecontrolle=gameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gamecontrolle.GameLose();
        //Debug.Log("11111111111111");
    }
}
