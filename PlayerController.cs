using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameController gameController;
    public float speed = 3f;
    bool directionRight = true;
    int hp;

    public bool DirectionRight { get => directionRight; set => directionRight = value; }

    void Start()
    {
        hp = 150;
    }

   
    void Update()
    {
        if (gameController.GameIsOn == true && DirectionRight==true)
        {
            if(gameController.GameStop == false)
            transform.Translate(speed * Time.deltaTime,0 , 0, Space.World);
        }
        else if(gameController.GameIsOn==true&& DirectionRight==false)
        {
            if( gameController.GameStop == false)
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
        }
        
         if (hp < 0)
        {
            gameController.GameLose();
            hp = 150;
        }
        

    }

    public void Damage()
    {
        hp -= 30;
    }
}
