using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextGenerator : MonoBehaviour
{
    public int nextValue;
    public GameObject nextI;
    public GameObject nextJ;
    public GameObject nextL;
    public GameObject nextS;
    public GameObject nextSquare;
    public GameObject nextT;
    public GameObject nextZ;

    public int holdValue = 8;
    public GameObject holdI;
    public GameObject holdJ;
    public GameObject holdL;
    public GameObject holdS;
    public GameObject holdSquare;
    public GameObject holdT;
    public GameObject holdZ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AgregarNext();
        AgregarHold();
    }

    public void AgregarNext()
    {
        if(nextValue == 0)
        {
            nextI.SetActive(true);
            nextJ.SetActive(false);
            nextL.SetActive(false);
            nextS.SetActive(false);
            nextSquare.SetActive(false);
            nextT.SetActive(false);
            nextZ.SetActive(false);
        }

        if(nextValue == 1)
        {
            nextI.SetActive(false);
            nextJ.SetActive(true);
            nextL.SetActive(false);
            nextS.SetActive(false);
            nextSquare.SetActive(false);
            nextT.SetActive(false);
            nextZ.SetActive(false);
        }

        if(nextValue == 2)
        {
            nextI.SetActive(false);
            nextJ.SetActive(false);
            nextL.SetActive(true);
            nextS.SetActive(false);
            nextSquare.SetActive(false);
            nextT.SetActive(false);
            nextZ.SetActive(false);
        }

        if(nextValue == 3)
        {
            nextI.SetActive(false);
            nextJ.SetActive(false);
            nextL.SetActive(false);
            nextS.SetActive(true);
            nextSquare.SetActive(false);
            nextT.SetActive(false);
            nextZ.SetActive(false);
        }
        if(nextValue == 4)
        {
            nextI.SetActive(false);
            nextJ.SetActive(false);
            nextL.SetActive(false);
            nextS.SetActive(false);
            nextSquare.SetActive(true);
            nextT.SetActive(false);
            nextZ.SetActive(false);
        }
        if(nextValue == 5)
        {
            nextI.SetActive(false);
            nextJ.SetActive(false);
            nextL.SetActive(false);
            nextS.SetActive(false);
            nextSquare.SetActive(false);
            nextT.SetActive(true);
            nextZ.SetActive(false);
        }
        if(nextValue == 6)
        {
            nextI.SetActive(false);
            nextJ.SetActive(false);
            nextL.SetActive(false);
            nextS.SetActive(false);
            nextSquare.SetActive(false);
            nextT.SetActive(false);
            nextZ.SetActive(true);
        }
    }


    public void AgregarHold()
    {
        if(holdValue == 0)
        {
            holdI.SetActive(true);
            holdJ.SetActive(false);
            holdL.SetActive(false);
            holdS.SetActive(false);
            holdSquare.SetActive(false);
            holdT.SetActive(false);
            holdZ.SetActive(false);
        }

        if(holdValue == 1)
        {
            holdI.SetActive(false);
            holdJ.SetActive(true);
            holdL.SetActive(false);
            holdS.SetActive(false);
            holdSquare.SetActive(false);
            holdT.SetActive(false);
            holdZ.SetActive(false);
        }

        if(holdValue == 2)
        {
            holdI.SetActive(false);
            holdJ.SetActive(false);
            holdL.SetActive(true);
            holdS.SetActive(false);
            holdSquare.SetActive(false);
            holdT.SetActive(false);
            holdZ.SetActive(false);
        }

        if(holdValue == 3)
        {
            holdI.SetActive(false);
            holdJ.SetActive(false);
            holdL.SetActive(false);
            holdS.SetActive(true);
            holdSquare.SetActive(false);
            holdT.SetActive(false);
            holdZ.SetActive(false);
        }
        if(holdValue == 4)
        {
            holdI.SetActive(false);
            holdJ.SetActive(false);
            holdL.SetActive(false);
            holdS.SetActive(false);
            holdSquare.SetActive(true);
            holdT.SetActive(false);
            holdZ.SetActive(false);
        }
        if(holdValue == 5)
        {
            holdI.SetActive(false);
            holdJ.SetActive(false);
            holdL.SetActive(false);
            holdS.SetActive(false);
            holdSquare.SetActive(false);
            holdT.SetActive(true);
            holdZ.SetActive(false);
        }
        if(holdValue == 6)
        {
            holdI.SetActive(false);
            holdJ.SetActive(false);
            holdL.SetActive(false);
            holdS.SetActive(false);
            holdSquare.SetActive(false);
            holdT.SetActive(false);
            holdZ.SetActive(true);
        }
    }
}
