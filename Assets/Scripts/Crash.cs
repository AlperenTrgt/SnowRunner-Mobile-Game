using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    private Animator anim_;
    [SerializeField] public GameObject GameOverMenu;
    public AudioSource CrashSound;
    public AudioSource GameOverSound;



    private void Start()
    {
        
        anim_ = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("zorttt");
            anim_.SetBool("Dead", true);
            CrashSound.Play();
            StartCoroutine(WaitForAnimation());

        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2.0f);
        GameOverMenu.SetActive(true);
        GameOverSound.Play();
        Time.timeScale = 0f;
    }

}
