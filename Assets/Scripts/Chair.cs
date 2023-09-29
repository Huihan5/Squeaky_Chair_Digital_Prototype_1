using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{

    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;

    [SerializeField]
    bool isPlaced = false;

    int possibleRots = 1;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        possibleRots = correctRotation.Length;

        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if(possibleRots > 1)
        {
            if(transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                gameManager.correctAssemble();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                gameManager.correctAssemble();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Counterclockwise
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, 90));

            Checked();
        }

        //Clockwise
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.Rotate(new Vector3(0, 0, -90));

            Checked();
        }
    }

    void Checked()
    {
        if(possibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && !isPlaced)
            {
                isPlaced = true;
                gameManager.correctAssemble();
            }
            else if (isPlaced)
            {
                isPlaced = false;
                gameManager.wrongAsseble();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0] && !isPlaced)
            {
                isPlaced = true;
                gameManager.correctAssemble();
            }
            else if (isPlaced)
            {
                isPlaced = false;
                gameManager.wrongAsseble();
            }
        }
    }
}
