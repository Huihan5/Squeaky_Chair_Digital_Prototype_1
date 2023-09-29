using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    public int currentPiece = 0;

    [SerializeField]
    Chair[] allPieces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentPiece += 1;

            if (currentPiece >= allPieces.Length)
            {
                currentPiece = 0;
            }

            for (int i = 0; i < allPieces.Length; i++)
            {
                allPieces[i].isEnabled = false;
            }

            allPieces[currentPiece].isEnabled = true;

            Debug.Log("CurrentPiece = " + currentPiece);
        }
    }
}
