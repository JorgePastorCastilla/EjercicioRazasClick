using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public string[] races = new string[4];
    public string[] enemyRaces = new string[2];
    public TextMeshProUGUI textLabel;
    bool gameWon = false;
    
    // Start is called before the first frame update
    void Start()
    {
        races[0] = "Humano";
        races[1] = "Elfo";
        races[2] = "Orco";
        races[3] = "Enano";


        for (int i = 0; i < enemyRaces.Length; i++)
        {
            int randomIndex = Random.Range(0, races.Length);
            if (!containsString(races[randomIndex], enemyRaces))
            {
                enemyRaces[i] = races[ randomIndex ];    
            }
            else
            {
                i--;
            }
        }
        
        // Esto es lo mismo que lo de arriba
        /*int i = 0;
        while (i < enemyRaces.Length)
        {
            int randomIndex = Random.Range(0, races.Length);
            if (!containsString(races[randomIndex], enemyRaces))
            {
                enemyRaces[i] = races[ randomIndex ];
                i++;
            }
        }*/

        string texte = "Los enemigos son: ";
        Debug.Log("Los enemigos son:");
        foreach (var enemy in enemyRaces)
        {
            texte += $"{enemy}, ";
            Debug.Log(enemy);
        }
        
        texte = texte.Substring(0, texte.Length - 2);
        textLabel.text = texte;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWin() && !gameWon)
        {
            Debug.Log("Has ganado");
            gameWon = true;
            // Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void killEnemy(GameObject enemy)
    {
        string enemyName = enemy.name;

        if (hasLost(enemyName))
        {
            Debug.Log("HAS PERDIDO");
            // Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Destroy(enemy);
        }
    }

    bool hasWin()
    {
        int totalEnemies = 0;

        GameObject[] racesGameObjects = GameObject.FindGameObjectsWithTag("races");
        for (int i= 0; i < enemyRaces.Length; i++)
        {
            foreach (var race in racesGameObjects)
            {
                if (enemyRaces[i] == race.name)
                {
                    totalEnemies++;
                }
            }
            
        }
        return (totalEnemies == 0);
    }

    bool hasLost(string enemy)
    {
        return !containsString(enemy, enemyRaces); 
    }

    bool containsString(string text, string[] lista)
    {
        for (int i = 0; i < lista.Length; i++)
        {
            if (text == lista[i])
            {
                return true;
            }
        }
        return false;
    }
}
