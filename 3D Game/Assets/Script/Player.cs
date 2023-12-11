using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController charController;
    public GameObject hedgeDuckling;
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("SavePlayer()");
    }

    public void LoadPlayer()
    {
        Debug.Log("LoadPlayer()");
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 new_position;
        new_position.x = data.position[0];
        new_position.y = data.position[1];
        new_position.z = data.position[2];
        

        charController.enabled = false;
        charController.transform.position = new_position;
        charController.enabled = true;

        Debug.Log("player: loadPlayer(): new x = " + data.position[0]);
        Debug.Log("player: loadPlayer(): new y = " + data.position[1]);
        Debug.Log("player: loadPlayer(): new z = " + data.position[2]);

        Vector3 new_hedgeDuckling_position;
 
        new_hedgeDuckling_position.x = data.hedgeDucklingPosition[0];
        new_hedgeDuckling_position.y = data.hedgeDucklingPosition[1];
        new_hedgeDuckling_position.z = data.hedgeDucklingPosition[2];
        hedgeDuckling.transform.position = new_hedgeDuckling_position;

        bool new_hedgeDucklingFollow = data.hedgeDucklingFollow;
        hedgeDuckling.GetComponent<NavigationScript>()._isFollowing = new_hedgeDucklingFollow;
        

        
        
    }

}
