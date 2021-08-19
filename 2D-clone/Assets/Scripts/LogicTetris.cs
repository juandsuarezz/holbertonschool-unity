using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicTetris : MonoBehaviour
{
    private float tiempoAnterior;
    public float tiempoCaida = 0.8f;

    public static int alto = 60;
    public static int ancho = 30;

    public Vector3 puntoRotacion;

    private static Transform [,] grid = new Transform [ancho, alto];

    public static int score;
    public static int nivelDificultad = 0;
    public ScoreLogic scoreLogic;
    public LogicGenerator logicGenerator;
    public LogicPause logicPause;
    public ButtonLogic buttonLogic;
    public Sound sound;

    // Start is called before the first frame update
    void Start()
    {
        scoreLogic = FindObjectOfType<ScoreLogic>();
        logicGenerator = FindObjectOfType<LogicGenerator>();
        logicPause = FindObjectOfType<LogicPause>();
        buttonLogic = FindObjectOfType<ButtonLogic>();
        sound = FindObjectOfType<Sound>();
        buttonLogic.restartScore = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonLogic.restartScore)
        {
            score = 0;
        }
        scoreLogic.scoreValue = score;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !logicPause.pause)
        {
            sound.PlayMove();
            transform.position += new Vector3(-3,0,0);
            if (!Limites())
            {
                transform.position -= new Vector3(-3,0,0);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !logicPause.pause)
        {
            sound.PlayMove();
            transform.position += new Vector3(3,0,0);
            if (!Limites())
            {
                transform.position -= new Vector3(3,0,0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && logicGenerator.canHold && !logicPause.pause)
        {
            sound.PlayHold();
            FindObjectOfType<LogicGenerator>().AgregarHold();
            Destroy(gameObject);
        }

        if(Time.time - tiempoAnterior > (Input.GetKey(KeyCode.DownArrow) ? tiempoCaida / 20 : tiempoCaida) && !logicPause.pause)
        {
            score = score + 1;
            transform.position += new Vector3 (0, -3, 0);

            if (!Limites())
            {
                sound.PlayInsert();
                transform.position -= new Vector3(0, -3, 0);
                AnadirAlgrid();
                RevisarLineas();
                this.enabled = false;
                FindObjectOfType<LogicGenerator>().AgregarTetromino();
                FindObjectOfType<LogicGenerator>().NuevoTetromino();
            }
            tiempoAnterior = Time.time;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && !logicPause.pause)
        {
            transform.RotateAround(transform.TransformPoint(puntoRotacion), new Vector3 (0, 0, 1), -90);
            sound.PlayRotate();
            if(!Limites())
            {
                transform.RotateAround(transform.TransformPoint(puntoRotacion), new Vector3 (0, 0, 1), 90);
            }
        }
    }

    bool Limites()
    {
        foreach(Transform hijo in transform)
        {        
            int enteroX = Mathf.RoundToInt(hijo.transform.position.x);
            int enteroY = Mathf.RoundToInt(hijo.transform.position.y);

            if(enteroX < 0 || enteroX >= ancho || enteroY < 0 || enteroY >= alto)
            {
                return false;
            }

            if(grid[enteroX, enteroY] != null)
            {
                return false;
            }
        }
        return true;
    }

    void AnadirAlgrid()
    {
        foreach (Transform hijo in transform)
        {
            int enteroX = Mathf.RoundToInt(hijo.transform.position.x);
            int enteroY = Mathf.RoundToInt(hijo.transform.position.y);
            grid[enteroX, enteroY] = hijo;

            if(enteroY >= 57)
            {
                logicPause.SetGameOver();
            }
        }
    }

    void RevisarLineas()
    {
        int i = alto - 3;
        while(i >= 0)
        {
            if(TieneLinea(i))
            {
                BorrarLinea(i);
                BajarLinea(i);
            }
            i = i - 3;
        }
    }

    bool TieneLinea(int i)
    {
        int j = 0;
        while(j < ancho)
        {
            if(grid[j, i] == null)
            {
                return false;
            }
            j = j + 3;
        }
        score = score + 200;
        return true;
    }

    void BorrarLinea(int i)
    {
        int j = 0;
        while(j < ancho)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
            j = j + 3;
        }
        sound.PlayDeleteline();
    }

    void BajarLinea(int i)
    {
        int y = i;
        while(y < alto)
        {
            int j = 0;
            while(j < ancho)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 3] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 3].transform.position -= new Vector3(0, 3, 0);
                }
                j = j + 3;
            }
            y = y + 3;
        }        
    }
}
