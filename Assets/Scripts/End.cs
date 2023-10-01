using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public AudioSource mySource;
    public AudioClip kada;
    public AudioClip Horray;

    public float countDownTime = 2f;

    bool countDown = false;

    // Start is called before the first frame update
    void Start()
    {
        mySource.PlayOneShot(Horray);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            countDown = true;

            mySource.PlayOneShot(kada);
        }

        if (countDown)
        {
            countDownTime -= Time.deltaTime;
        }

        if (countDownTime <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
