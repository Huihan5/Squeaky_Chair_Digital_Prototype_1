using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public AudioSource mySource;
    public AudioClip kada;

    public float countDownTime = 5f;

    bool countDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            mySource.PlayOneShot(kada);
            countDown = true;
        }

        if (countDown)
        {
            countDownTime -= Time.deltaTime;
        }

        if(countDownTime <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
