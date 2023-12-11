using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position; // Vector3 position;
    public float[] hedgeDucklingPosition;
    public bool hedgeDucklingFollow;
    

    public PlayerData(Player player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        hedgeDucklingPosition = new float[3];
        hedgeDucklingPosition[0] = player.hedgeDuckling.transform.position.x;
        hedgeDucklingPosition[1] = player.hedgeDuckling.transform.position.y;
        hedgeDucklingPosition[2] = player.hedgeDuckling.transform.position.z;
        hedgeDucklingFollow = player.hedgeDuckling.GetComponent<NavigationScript>()._isFollowing;
    }


}
