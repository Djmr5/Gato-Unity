using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Juego.Gato;

namespace Juego {
    public class JugarGato : MonoBehaviour
    {
        public GameObject ficha1;
        public GameObject ficha2;
        int numberOfSeconds = 1, isRunning = 1;
        Gato gato = new Gato();


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

        // Start is called before the first frame update
        void Start()
        {

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
            
            char ganador = Juego.Gato.getGanador();
            if (ganador=='N' && Juego.Gato.getTurn() <9)
            {
                // Jugar
                int pos = Juego.Gato.Jugar();
                crearPrefab(Juego.Gato.getFigura(), pos);
            }
            isRunning = 1;
        }
    }
}