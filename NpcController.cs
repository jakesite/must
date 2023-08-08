using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public float speed = 1f;
    float npcDestroyTimer=0;
    GameController gameController;
    PlayerController  player;
    GameObject damagetext;
    void Start()
    {
        gameController=transform.Find("/GameController").GetComponent<GameController>();

        player = transform.Find("/Player").gameObject.GetComponent<PlayerController>();
        
        

    }
    
    
    
    private void FixedUpdate()
    {
        if (gameController.GameStop == false)
        {
            npcDestroyTimer += Time.fixedDeltaTime;
            if (npcDestroyTimer > 5)
            {
                Destroy(gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.GameStop==false)
        transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.Damage();
        GameObject obj = (GameObject)Resources.Load("damagetext");
        damagetext=Instantiate<GameObject>(obj);
        damagetext.transform.position=this.transform.position;
    }
}
