using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    float npcCreateTimer=0f; 
    GameObject npc;
    public GameController gameController;
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (gameController.GameIsOn == true&&gameController.Stop==false)
        {
            if(gameController.GameStop==false)
            {
                npcCreateTimer -= Time.fixedDeltaTime;
                if (npcCreateTimer < 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        GameObject obj = (GameObject)Resources.Load("Npc");
                        npc = Instantiate<GameObject>(obj);
                        npc.transform.position = new Vector3(Random.Range(-3.7f, 3.6f), Random.Range(-8, -10), 0);
                        float rang = Random.Range(0.5f, 1);
                        npc.transform.localScale = new Vector3(rang, rang, rang);
                        npcCreateTimer = 0.5f;
                    }

                }
            }
        }
    }

    void Update()
    {
        
    }
}
