using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{

    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;

    [SerializeField]
    bool isPlaced = false;

    [SerializeField]
    bool isEnabled = false;

    int possibleRots = 1;

    GameManager gameManager;

    //float[] states = { 0, 1, 2, 3 };

    public int rotationStates = 0;

    public int correctStates = 0;

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

        rotationStates = rand;

        if(rotationStates == correctStates)
        {
            isPlaced = true;
            gameManager.correctAssemble();
        }

        //if (possibleRots > 1)
        //{
        //    if(transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
        //    {
        //        isPlaced = true;
        //        gameManager.correctAssemble();
        //    }
        //}
        //else
        //{
        //    if (transform.eulerAngles.z == correctRotation[0])
        //    {
        //        isPlaced = true;
        //        gameManager.correctAssemble();
        //    }
        //}

    }

    // Update is called once per frame
    void Update()
    {

        //Counterclockwise
        if (Input.GetKeyDown(KeyCode.D) && !isPlaced)
        {
            transform.Rotate(new Vector3(0, 0, 90));

            if(rotationStates < 3)
            {
                rotationStates++;
            }
            else if(rotationStates == 3)
            {
                rotationStates = 0;
            }

            Checked();
        }

        //Clockwise
        if (Input.GetKeyDown(KeyCode.C) && !isPlaced)
        {
            transform.Rotate(new Vector3(0, 0, -90));

            if (rotationStates > 0)
            {
                rotationStates--;
            }
            else if (rotationStates == 0)
            {
                rotationStates = 3;
            }

            Checked();
        }
    }

    void Checked()
    {
        if(possibleRots > 1)
        {
            if (rotationStates == correctStates && !isPlaced)
            {
                isPlaced = true;
                gameManager.correctAssemble();
            }
            //if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && !isPlaced)
            //{
            //    isPlaced = true;
            //    gameManager.correctAssemble();
            //}
            //else if (isPlaced)
            //{
            //    isPlaced = false;
            //    gameManager.wrongAsseble();
            //}
        }
        else
        {
            if (rotationStates == correctStates && !isPlaced)
            {
                isPlaced = true;
                gameManager.correctAssemble();
            }

            //if (transform.eulerAngles.z == correctRotation[0] && !isPlaced)
            //{
            //    isPlaced = true;
            //    gameManager.correctAssemble();
            //}
            //else if (isPlaced)
            //{
            //    isPlaced = false;
            //    gameManager.wrongAsseble();
            //}
        }
    }
}
