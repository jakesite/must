using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishController : MonoBehaviour
{
    GameController gameController;
    AudioSource audioSource;
    
    
    void Start()
    {
        gameController=transform.Find("/GameController").GetComponent<GameController>();
        audioSource=gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.GameStop==false)
        {
            gameObject.transform.Translate(0, 4 * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GameWin();
        
            audioSource.Play();
    }
}
