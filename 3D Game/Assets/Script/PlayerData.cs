using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position; // Vector3 position;
    public float[] hedgeDucklingPosition;
    public bool hedgeDucklingFollow;
    public float[] hidingDucklingPosition;
    public bool hidingDucklingFollow;
    public float[] treeDucklingPosition;
    public bool treeDucklingFollow;
    public float[] benchDucklingPosition;
    public bool benchDucklingFollow;
    

    public PlayerData(Player player)
    {
        // player data
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        // hedge Duckling data
        hedgeDucklingPosition = new float[3];
        hedgeDucklingPosition[0] = player.hedgeDuckling.transform.position.x;
        hedgeDucklingPosition[1] = player.hedgeDuckling.transform.position.y;
        hedgeDucklingPosition[2] = player.hedgeDuckling.transform.position.z;
        hedgeDucklingFollow = player.hedgeDuckling.GetComponent<NavigationScript>()._isFollowing;

        // hiding Duckling data
        hidingDucklingPosition = new float[3];
        hidingDucklingPosition[0] = player.hidingDuckling.transform.position.x;
        hidingDucklingPosition[1] = player.hidingDuckling.transform.position.y;
        hidingDucklingPosition[2] = player.hidingDuckling.transform.position.z;
        hidingDucklingFollow = player.hidingDuckling.GetComponent<NavigationScript>()._isFollowing;

        // tree Duckling data
        treeDucklingPosition = new float[3];
        treeDucklingPosition[0] = player.treeDuckling.transform.position.x;
        treeDucklingPosition[1] = player.treeDuckling.transform.position.y;
        treeDucklingPosition[2] = player.treeDuckling.transform.position.z;
        treeDucklingFollow = player.treeDuckling.GetComponent<NavigationScript>()._isFollowing;

        // bench Duckling data
        benchDucklingPosition = new float[3];
        benchDucklingPosition[0] = player.benchDuckling.transform.position.x;
        benchDucklingPosition[1] = player.benchDuckling.transform.position.y;
        benchDucklingPosition[2] = player.benchDuckling.transform.position.z;
        benchDucklingFollow = player.benchDuckling.GetComponent<NavigationScript>()._isFollowing;

        
    }


}
