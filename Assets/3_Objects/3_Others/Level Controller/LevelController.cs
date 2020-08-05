using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //**********************************************************************ATRIVUTOS Y PROPIEDADES**********************************************************************
    //Configuracion General
    [Header("General Settings")]
    public GameMemory gamememory;
    public GameObject cinematic;
    public GameObject scenaryGO;
    private List<float> tracks;
    public int trackActual;
    [SerializeField]
    private bool active;
    public bool historyMode;
    [SerializeField]
    private float historyCounter;
    public float historyTime;
    public float speed; //Velocidad actual del escenario
    private float speedUpdate;
    private float speedCounter;
    public float speedTime; //Cuanto se tardara en actualizar la velocidad

    //Configuracion de Ordenes
    [Header("Orders Settings")]
    public Transform respawnGameObject1;
    public Transform respawnGameObject2;
    public GreatEll greatEli;
    public List<GameObject> enemies;
    public List<Vector3Int> ordensRespawns;
    private int ordenSave; //Guarda la numeracion de la ultima orden dada
    public int ordenRespawnLimitType; //Es el limite de creacion de una orden para crear el mismo objeto varia veces
    public int noRepeatUnit1 =0;
    public int noRepeatUnit2 =0;
    public bool anguilaAttack;

    //Configuracion de Scenarios
    [Header("Orders Scenaries")]
    public ImageScenary imageScenary1;
    public GameObject imageScenaryGO1;
    public ImageScenary imageScenary2;
    public GameObject imageScenaryGO2;
    public Sprite[] images;

    //**********************************************************************METODOS PRIMARIOS**********************************************************************
    //Preparar Clase
    void Start()
    {
        Active();

        tracks = new List<float>();
        tracks.Add(0);
        tracks.Add(122f);
        tracks.Add(0);
        tracks.Add(-122f);

        speedUpdate = 1;

        UpdateImage();
    }

    //Activar
    private void Active()
    {
        active = true;
    }
    
    //Desactivar
    private void Desactive()
    {
        active = false;
    }

    //Actualizador
    void FixedUpdate()
    {
        if (active == true)
        {
            //Modo Historia=
            {
                if (historyMode == true)
                {
                    if (historyCounter >= historyTime)
                    {
                        NextLevel();
                        Desactive();
                    }
                    else
                    {
                        historyCounter += 0.02f;
                    }
                }
            }

            //Velocidad Y Ordenes=
            //General:
            {
                if (imageScenaryGO1.transform.localPosition.x <= -2100)
                {
                    trackActual = 1;
                    OrdenCall(1);
                    imageScenaryGO1.transform.localPosition = new Vector2(2100, 0);
                    imageScenaryGO2.transform.localPosition = new Vector2(0, 0);
                }
                if (imageScenaryGO2.transform.localPosition.x <= -2100)
                {
                    trackActual = 2;
                    OrdenCall(2);
                    imageScenaryGO1.transform.localPosition = new Vector2(0, 0);
                    imageScenaryGO2.transform.localPosition = new Vector2(2100, 0);
                }
                imageScenaryGO1.transform.localPosition -= transform.right * Time.deltaTime * speed;
                imageScenaryGO2.transform.localPosition -= transform.right * Time.deltaTime * speed;
            }
            //Actualizar Velocidad:
            {
                if (speedCounter >= speedTime)
                {
                    speedCounter = 0;
                    SpeedUpdate();
                }
                else
                {
                    speedCounter += 0.02f;
                }
            }
        }
    }

    //**********************************************************************METODOS SECUNDARIOS**********************************************************************
    //Actualizar Velocidad
    private void SpeedUpdate()
    {
        if (speed < 600)
        {
            speed += speedUpdate;
        }
    }
    //Ejecutar Ordenes
    private void OrdenCall(int respawn)
    {
        if (active == true)
        {
            //Elegir Orden=
            int ordenRandom = Random.Range(-1, ordensRespawns.Capacity);
            //Evitar Repeticiones:
            if (ordenRandom == ordenSave)
            {
                ordenRandom = Random.Range(-1, ordensRespawns.Capacity);
            }
            //Ejecutar Orden:
            //crear enemigos=
            if (ordenRandom >= 0)
            {
                greatEli.Sleep();
                RespawnEnemies(ordensRespawns[ordenRandom].x, ordensRespawns[ordenRandom].y, ordensRespawns[ordenRandom].z, respawn);
            }
            //llamar anguila=
            else if (ordenRandom == -1)
            {
                if (anguilaAttack == true)
                {
                    greatEli.Go();
                }
            }
            //guardar numero de orden=
            ordenSave = ordenRandom;
        }
    }

    //Crear Enemigos
    public void RespawnEnemies(int number, int type, int distance, int respawn)
    {
        //Atrivutos=
        float Y = 0;
        int X = -2750;

        //Accion=
        for (int x = 0; x < number; x++)
        {

            //Señalar Pocision X:
            X += distance;
            {
                if (X < -950 || X < -2750)
                {
                    X += 150;
                }
                else
                {
                    X = -950;
                    number = 0;
                }
            }

            //Señalar Pocision Y:
            Y = tracks[Random.Range(0, 4)];

            //Verificar Pocisiones X,Y:
            Vector2 position = new Vector2(transform.localPosition.x + X, transform.position.y + Y);

            //Crear Enemigo:
            if (respawn == 1)
            {
                Instantiate(enemies[type], position, Quaternion.identity, respawnGameObject1);
            }
            if (respawn == 2)
            {
                Instantiate(enemies[type], position, Quaternion.identity, respawnGameObject2);
            }
            //Verificar Limites de Creacion:
            if (x == ordenRespawnLimitType || x == ordenRespawnLimitType + 3 || x == ordenRespawnLimitType + 6 || x == ordenRespawnLimitType + 9)
            {

                type = Random.Range(1, enemies.Capacity);
                if(type == noRepeatUnit1 || type == noRepeatUnit2)
                {
                    type = 1;
                }
            }
        }
    }

    //Actualizar Scenario
    public void UpdateImage()
    {
        imageScenary1.image1 = images[0];
        imageScenary1.image2 = images[0];
        imageScenary1.image3 = images[0];
        imageScenary1.UpdateImages();
        imageScenary2.image1 = images[0];
        imageScenary2.image2 = images[0];
        imageScenary2.image3 = images[0];
        imageScenary2.UpdateImages();
    }

    private void NextLevel()
    {
        gamememory.SaveLevel();
        cinematic.SetActive(true);
    }
}
