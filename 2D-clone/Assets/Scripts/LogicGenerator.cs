using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGenerator : MonoBehaviour
{
    public GameObject[] tetrominos;
    public int nextNumero;
    public NextGenerator nextGenerator;
    public int holdNumero;
    public int actualNumero;
    private int temp;
    public LogicTetris logicTetris;
    public bool canHold;

    // Start is called before the first frame update
    void Start()
    {
        nextNumero = Random.Range(0,7);
        actualNumero = nextNumero;
        AgregarTetromino();
        NuevoTetromino();
        holdNumero = 8;
    }

    // Update is called once per frame
    void Update()
    {
        ShowNext();
        ShowHold();
    }

    public void NuevoTetromino()
    {
        nextNumero = Random.Range(0,7);
    }

    public void AgregarTetromino()
    {
        actualNumero = nextNumero;
        Instantiate(tetrominos[nextNumero], transform.position, Quaternion.identity);
        canHold = true;
    }

    public void AgregarHold()
    {
        if (holdNumero == 8)
        {
            holdNumero = actualNumero;
            Instantiate(tetrominos[nextNumero], transform.position, Quaternion.identity);
            nextNumero = Random.Range(0,7);
        }

        else
        {
            temp = holdNumero;
            Instantiate(tetrominos[holdNumero], transform.position, Quaternion.identity);
            holdNumero = actualNumero;
            actualNumero = temp;
        }

        canHold = false;
    }

    public void ShowNext()
    {
        switch (nextNumero)
        {
        case 0:
            nextGenerator.nextValue = 0;
            break;
        case 1:
            nextGenerator.nextValue = 1;
            break;
        case 2:
            nextGenerator.nextValue = 2;
            break;
        case 3:
            nextGenerator.nextValue = 3;
            break;
        case 4:
            nextGenerator.nextValue = 4;
            break;
        case 5:
            nextGenerator.nextValue = 5;
            break;
        case 6:
            nextGenerator.nextValue = 6;
            break;
        }
    }

    public void ShowHold()
    {
        switch (holdNumero)
        {
        case 0:
            nextGenerator.holdValue = 0;
            break;
        case 1:
            nextGenerator.holdValue = 1;
            break;
        case 2:
            nextGenerator.holdValue = 2;
            break;
        case 3:
            nextGenerator.holdValue = 3;
            break;
        case 4:
            nextGenerator.holdValue = 4;
            break;
        case 5:
            nextGenerator.holdValue = 5;
            break;
        case 6:
            nextGenerator.holdValue = 6;
            break;
        }
    }
}