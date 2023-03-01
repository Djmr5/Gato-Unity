using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PrimerObjeto : MonoBehaviour
{

    // Instanciar las variables iniciales
    public GameObject ficha1;
    public GameObject ficha2;
    int numberOfSeconds = 1, isRunning = 1;
    char ganador = 'N';
    int turn = 0;
    public char[] cuadricula = {'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'};

    int randNum()
    {
        System.Random randin = new System.Random();
        int rand = randin.Next(0,9);
        return rand;
    }

    void crearPrefab(char figura, int position ){

        Vector3 pos = new Vector3();

        if (figura=='X'){
            if (position==0){pos = new Vector3(-6, 10, 4);}
            else if (position==1){pos = new Vector3(0, 10, 4);}
            else if (position==2){pos = new Vector3(6, 10, 4);}
            else if (position==3){pos = new Vector3(-6, 10, -2);}
            else if (position==4){pos = new Vector3(0, 10, -2);}
            else if (position==5){pos = new Vector3(6, 10, -2);}
            else if (position==6){pos = new Vector3(-6, 10, -8);}
            else if (position==7){pos = new Vector3(0, 10, -8);}
            else if (position==8){pos = new Vector3(6, 10, -8);}
            GameObject go = Instantiate(ficha1, pos, Quaternion.identity);
        } else {
            if (position==0){pos = new Vector3(-6, 10, 6);}
            else if (position==1){pos = new Vector3(0, 10, 6);}
            else if (position==2){pos = new Vector3(6, 10, 6);}
            else if (position==3){pos = new Vector3(-6, 10, 0);}
            else if (position==4){pos = new Vector3(0, 10, 0);}
            else if (position==5){pos = new Vector3(6, 10, 0);}
            else if (position==6){pos = new Vector3(-6, 10, -6);}
            else if (position==7){pos = new Vector3(0, 10, -6);}
            else if (position==8){pos = new Vector3(6, 10, -6);}
            GameObject go = Instantiate(ficha2, pos, Quaternion.identity);
        }
    }

    void CrearFigura(char figura, int position)
    {
        // Instanciar
        GameObject miCubo = new GameObject();
        Color c = new Color();
        if (figura=='X'){
            miCubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            c = new Color(255f/255f, 1f/255f, 1f/255f);
        } else{
            miCubo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            c = new Color(1f/255f, 1f/255f, 255f/255f);
        }
        // Cambiar nombre
        miCubo.name = "Figurita xd";
        // Cambiar color
        MeshRenderer mr = miCubo.GetComponent<MeshRenderer>();
        mr.material.SetColor("_Color", c);
        // Cambiar posicion:
        Vector3 pos = new Vector3();
        if (position==0){pos = new Vector3(-6, 10, 6);}
        else if (position==1){pos = new Vector3(0, 10, 6);}
        else if (position==2){pos = new Vector3(6, 10, 6);}
        else if (position==3){pos = new Vector3(-6, 10, 0);}
        else if (position==4){pos = new Vector3(0, 10, 0);}
        else if (position==5){pos = new Vector3(6, 10, 0);}
        else if (position==6){pos = new Vector3(-6, 10, -6);}
        else if (position==7){pos = new Vector3(0, 10, -6);}
        else if (position==8){pos = new Vector3(6, 10, -6);}
        
        miCubo.transform.position = pos;
        
        // Cambiar tamanio:
        miCubo.transform.localScale = new Vector3(4, 4, 4);

        // Agregar motor de fisica:
        Rigidbody rb = miCubo.AddComponent<Rigidbody>();
        rb.mass = 15;

    }

    char[] Jugar(char[] cuadricula, char ganador, int turn){

        int rand = randNum();
        while (cuadricula[rand]!='N')
        {
            rand = randNum();
        }

        if (turn%2 == 0)
        {
            cuadricula[rand] = 'X';
            crearPrefab('X',rand);
        } else {
            cuadricula[rand] = 'O';
            crearPrefab('O',rand);
        }

        return cuadricula;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Primer Movimiento

        int rand = randNum();
        cuadricula[rand] = 'X';
        
        crearPrefab('X',rand);
        turn += 1;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning == 1)
        {
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter() {
        isRunning = 0;
        yield return new WaitForSeconds(numberOfSeconds);
        
        if (ganador=='N' && turn <9)
        {
            // Jugar
            Jugar(cuadricula, ganador, turn);
            // Checar ganadores
            if (cuadricula[0]==cuadricula[1] && cuadricula[1]==cuadricula[2])
            {
                ganador = cuadricula[0];
            }
            else if (cuadricula[3]==cuadricula[4] && cuadricula[4]==cuadricula[5])
            {
                ganador = cuadricula[3];
            }
            else if (cuadricula[6]==cuadricula[7] && cuadricula[7]==cuadricula[8])
            {
                ganador = cuadricula[6];
            }
            else if (cuadricula[0]==cuadricula[3] && cuadricula[3]==cuadricula[6])
            {
                ganador = cuadricula[0];
            }
            else if (cuadricula[1]==cuadricula[4] && cuadricula[4]==cuadricula[7])
            {
                ganador = cuadricula[1];
            }
            else if (cuadricula[2]==cuadricula[5] && cuadricula[5]==cuadricula[8])
            {
                ganador = cuadricula[2];
            }
            else if (cuadricula[0]==cuadricula[4] && cuadricula[4]==cuadricula[8])
            {
                ganador = cuadricula[0];
            }
            else if (cuadricula[2]==cuadricula[4] && cuadricula[4]==cuadricula[6])
            {
                ganador = cuadricula[2];
            }
        }
        turn += 1;
        isRunning = 1;
    }
}