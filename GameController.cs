using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Transform player;
    PlayerController playerController;
    Button gameBeginButton;
    Transform gbg;
    Button directionButton;
    Transform db;
    Transform course1;
    Transform course2;
    Transform settingButton;
    float gameTimer=10;
    public GameObject npcManager;
    GameObject ob;
    GameObject finish;
    public GameObject slider;
    public GameObject biaozhuText;
    TextMeshProUGUI textMeshPro;
    Transform rebirthButton;
    public bool GameIsOn { get => gameIsOn; set => gameIsOn = value; }
    bool gameIsOn;
    public bool Stop { get => stop; set => stop = value; }
    bool stop;
    public bool GameStop { get => gameStop; set => gameStop = value; }
    public float Level { get => level; set => level = value; }
    float level = 1;
    
    bool gameStop;
    Button rebirth;
    bool gameWin=false;
    Transform gamewin;

     AudioSource audioSourceBG;
    Transform soundButton;
    Button soundBG;
    public AudioSource soundDead;
    

    void Start()
    {
        GameIsOn = false;
        Stop = false;
        GameStop = false;
        soundIsOn = true;
        
        player = transform.Find("/Player");//��ȡ��Ҷ���
        playerController = player.GetComponent<PlayerController>();
        gbg = transform.Find("/Canvas/GameBeginButton");//��ȡ��ʼ��Ϸ��ť
        gameBeginButton = gbg.GetComponent<Button>();
        gameBeginButton.onClick.AddListener(OnButtonClickGameBegin);

         db = transform.Find("/Canvas/DirectionButton");//��ȡ���Ʒ���ť
        directionButton = db.GetComponent<Button>();
        directionButton.onClick.AddListener(OnButtonClickDirection);

        course1 = transform.Find("/Canvas/course1");//��ȡ�̳�ͼ�������
        course2 = transform.Find("/Canvas/course2");
        settingButton = transform.Find("/Canvas/setting");
        
         
        s=slider.GetComponent<Slider>();//��ȡ������
        textMeshPro=biaozhuText.GetComponent<TextMeshProUGUI>();

        rebirthButton  = transform.Find("/Canvas/RebirthButton");//��ȡ���ť
        rebirth=rebirthButton.GetComponent<Button>();
        rebirth.onClick.AddListener(OnButtonClickRebirth);

        gamewin=transform.Find("/Canvas/Win");//��ȡʤ��ͼ��
        rebirthButton.gameObject.SetActive(false);//���ֹرո��ť

        audioSourceBG=gameObject.GetComponent<AudioSource>();

        soundButton = transform.Find("/Canvas/setting/Sound");
        soundBG=soundButton.GetComponent<Button>();
        soundBG.onClick.AddListener(OnButtonClickSound);
        
    }


    Slider s;
    float winTimer = 3;
    public TextMeshProUGUI scoreText;
    
    private void FixedUpdate()
    {
        if (gameIsOn == true)
        {
            if (GameStop == false)
            {
                gameTimer -= Time.fixedDeltaTime;
                scoreText.text = Mathf.Floor(40 * (10-gameTimer)).ToString();//�Ʒְ�

                if (gameTimer < 2.5 && Stop == false)//�����յ���
                {
                    ob = (GameObject)Resources.Load("finish");
                    finish = Instantiate<GameObject>(ob);
                    finish.transform.position = npcManager.transform.position;
                    Stop = true;
                }
            }
        }
        s.value = (10 - gameTimer) / 10;
        float text = Mathf.Floor((10 - gameTimer) * 10);
        Mathf.Clamp(text, 0,100);
        textMeshPro.text = text.ToString() + "%";//�������ٷֱ�

        if (gameWin == true)
        {
            winTimer -= Time.fixedDeltaTime;
            if (winTimer < 0)
            {
                SceneManager.LoadScene(0);//���غ��ؿ���Ϸ
            }

        }
    }


    

    void Update()
    {
        //��ʼ��Ϸ��  �򿪻�ر���ӦUI
        if (GameIsOn == false)
        {
            gbg.gameObject.SetActive(true);
            db.gameObject.SetActive(false);
        }
            
        else 
        { 
            gbg.gameObject.SetActive(false);
            db.gameObject.SetActive(true);
            course1.gameObject.SetActive(false);
            course2.gameObject.SetActive(false);
            settingButton.gameObject.SetActive(false);
        }

        if (gameTimer < 0)//��������
        {
            GameWin();
        }    

        if (gameWin == true)
            gamewin.gameObject.SetActive(true);//����ʤ��ͼ��
        else gamewin.gameObject.SetActive(false);

        
        //Debug.Log(gameTimer);
        //Debug.Log(ob);
        //Debug.Log(finish);
    }
    

    
    void OnButtonClickGameBegin()//��ʼ��Ϸ��ť
    {
        GameIsOn = true;
        //Debug.Log(GameIsOn);
        gbg.gameObject.SetActive(false);
    }
    void OnButtonClickDirection()//���Ʒ���ť
    {
        if (playerController.DirectionRight == true)
            playerController.DirectionRight = false;
        else
            playerController.DirectionRight = true;

    }
    bool soundIsOn;
    void OnButtonClickSound()
    {
        if (soundIsOn == true)
        {
           audioSourceBG.volume = 0;
            soundIsOn = false;
        }
        else
        {
            audioSourceBG.volume = 0.5f;
            soundIsOn=true;
        }

    }

    private void OnButtonClickRebirth()//���ť
    {
        GameStop = false;
        playerController.gameObject.transform.position=new Vector3(0.137f,1.96f,-10);
        rebirthButton.gameObject.SetActive(false);//�����رո��ť
    }

    public void GameLose()//����
    {
        GameStop = true;
        rebirthButton.gameObject.SetActive(true);//�������ظ��ť
        soundDead.Play();
    }
     
    public void GameWin()//����
    {
        playerController.gameObject.SetActive(false);
        gameWin = true;
        level += 1;
    }
}
