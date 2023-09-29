using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public AudioSource mySource;
    public AudioClip kada;
    public AudioClip Horray;

    // Start is called before the first frame update
    void Start()
    {
        //mySource.PlayOneShot(Horray);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(0);

            //mySource.PlayOneShot(kada);
        }
    }
}
