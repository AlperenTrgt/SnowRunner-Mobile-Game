using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] public Animator animat_;
    [SerializeField] public GameObject playerObject; // Reference to the player object
    public GameObject StartMenu;
    private void Start()
    {
        animat_ = playerObject.GetComponent<Animator>();
    }
    
    public void HomeButton()
    {
        animat_.SetBool("GameStart", true);
        StartMenu.SetActive(false);
        Debug.Log("restart öncesi");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;        
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReserCont()
    {
        animat_.SetBool("GameStart", true);
    }
}
