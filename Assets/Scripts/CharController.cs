using System;
using UnityEngine;
using TMPro;

public class CharController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] public float speed = 5f;
    [SerializeField] public GameObject Player;
    public TextMeshProUGUI distanceMoved;
    public TextMeshProUGUI EndScoreText;
    public TextMeshProUGUI HscoreText;
    public float distanceUnit = 0f;
    public float HorizontalInput;
    private Quaternion targetRotation;

    public void Start()
    {
        HorizontalInput = 0.3f;
        anim = GetComponent<Animator>();
        InvokeRepeating("distance", 0, 1 / speed);
        targetRotation = Player.transform.rotation;
    }
    /*
    public void Update()
    {
        if (anim.GetBool("GameStart"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(HorizontalInput);
                HorizontalInput = -HorizontalInput;
                targetRotation = Quaternion.Euler(Player.transform.rotation.eulerAngles.x, Player.transform.rotation.eulerAngles.y * -1, Player.transform.rotation.eulerAngles.z);
            }
            Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, targetRotation, Time.deltaTime * speed);
            transform.Translate(Vector3.right * HorizontalInput * speed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (anim.GetBool("Dead"))
            {
                speed = 2;
            }
        }
        
        
    }*/
    public void Update()
    {
        if (anim.GetBool("GameStart"))
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log(HorizontalInput);
                HorizontalInput = -HorizontalInput;
                targetRotation = Quaternion.Euler(Player.transform.rotation.eulerAngles.x, Player.transform.rotation.eulerAngles.y * -1, Player.transform.rotation.eulerAngles.z);
            }
            Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, targetRotation, Time.deltaTime * speed);
            transform.Translate(Vector3.right * HorizontalInput * speed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (anim.GetBool("Dead"))
            {
                speed = 2;
            }
        }
    }


    public void distance()
        {

        if (anim.GetBool("GameStart"))
        {
            distanceUnit = distanceUnit + 1;
            distanceMoved.text = "Score \n" + distanceUnit.ToString();
            if (speed < 23)
            {
                speed = speed + 0.05f;
            }
            EndScoreText.text = "Your Score \n" +distanceUnit.ToString();
            HScore();
        }
    }
    public void ContinueGame()
    {
        anim.SetBool("GameStart", true);
    }

    public void HScore()
    {
        int highScore = PlayerPrefs.GetInt("High Score", 0);
        if (distanceUnit > highScore)
        {
            PlayerPrefs.SetInt("High Score", (int)distanceUnit);
            highScore = (int)distanceUnit;
        }
        HscoreText.text = "High Score \n" + highScore.ToString();
    }

}
