using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ChairHolder;
    public GameObject[] ChairComponents;

    [SerializeField]
    int totalComponents = 0;

    [SerializeField]
    int correctComponents = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalComponents = ChairHolder.transform.childCount;

        ChairComponents = new GameObject[totalComponents];

        for (int i = 0; i < ChairComponents.Length; i++)
        {
            ChairComponents[i] = ChairHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(correctComponents);
    }

    public void correctAssemble()
    {
        correctComponents += 1;

        if(correctComponents == totalComponents)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void wrongAsseble()
    {
        correctComponents -= 1;
    }
}
