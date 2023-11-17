using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject playerObject; // Reference to the player object
    [SerializeField] public Camera MCam;
    [SerializeField] public Camera SCam;
    public Animator anim_;

    private void Start()
    {
        anim_= playerObject.GetComponent<Animator>();
    }
    public void PLayGame()
    {
        mainMenu.SetActive(false);
        anim_.SetBool("GameStart", true);
        SCam.depth= 0;
        MCam.depth= 1;

    }
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}


