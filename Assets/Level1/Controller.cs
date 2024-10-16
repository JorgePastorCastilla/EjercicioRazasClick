using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] enemies;
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        int[] ages = new int[5];
        ages[0] = 23;
        ages[1] = 14;
        ages[2] = 20;
        ages[3] = 16;
        ages[4] = 10;
        
        //solo menores de edad
        for (int i = 0; i < ages.Length; i++)
        {
            if (ages[i] < 18)
            {
              // Debug.Log($"El jugador en la posición {i} es {ages[i]}");
            }
        }
        //edades en orden inverso
        for (int i = ages.Length-1; i >= 0; i--)
        {
             //   Debug.Log($"El jugador en la posición {i} es {ages[i]}");
        }
        //Ordenar de mayor a menor
        int[] tmp = new int[ages.Length];
        int numPetit = -1;
        for (int i = 0; i < ages.Length; i++)
        {
            if (numPetit == -1)
            {
                numPetit = ages[i];
            }
            
            for (int j = 0; j < ages.Length; j++)
            {
                if (ages[j] < numPetit && !( tmp.Contains(ages[j]) ) )
                {
                    numPetit = ages[j];
                }
            }
            tmp[i] = numPetit;
        }
        ages = tmp;
        for (int i = 0; i < ages.Length; i++)
        {
            Debug.Log($"El jugador en la posición {i} es {ages[i]}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float tiempo = 1.0f;
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i], tiempo);
                tiempo += 0.2f;
            }
        }
    }
}
