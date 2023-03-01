using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Juego {
    public class Gato
    {
        static char ganador = 'N';
        static int turn = 0;
        static char[] cuadricula = {'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'};
        
        public static int randNum()
        {
            System.Random randin = new System.Random();
            int rand = randin.Next(0,9);
            return rand;
        }
        
        public static int Jugar(){

            int rand = randNum();
            while (cuadricula[rand]!='N')
            {
                rand = randNum();
            }

            if (turn%2 == 0)
            {
                cuadricula[rand] = 'X';
            } else {
                cuadricula[rand] = 'O';
            }

            checarGanador();
            turn += 1;

            return rand;
        }

        public static void checarGanador()
        {
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

        public static int getTurn()
        {
            return turn;
        }

        public static char getGanador()
        {
            return ganador;
        }

        public static char getFigura(){
            if (turn%2 == 0)
            {
                return 'X';
            } else {
                return 'O';
            }
        }
    }
}