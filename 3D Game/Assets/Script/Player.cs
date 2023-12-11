using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController charController;
    public GameObject hedgeDuckling;
    public GameObject hidingDuckling;
    public GameObject treeDuckling;
    public GameObject benchDuckling;
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        //Debug.Log("SavePlayer()");
    }

    public void LoadPlayer()
    {
        //Debug.Log("LoadPlayer()");

        PlayerData data = SaveSystem.LoadPlayer();

        // Load player data
        Vector3 new_position;
        new_position.x = data.position[0];
        new_position.y = data.position[1];
        new_position.z = data.position[2];
        

        charController.enabled = false;
        charController.transform.position = new_position;
        charController.enabled = true;

        // Debug.Log("player: loadPlayer(): new x = " + data.position[0]);
        // Debug.Log("player: loadPlayer(): new y = " + data.position[1]);
        // Debug.Log("player: loadPlayer(): new z = " + data.position[2]);

        // Load hedge Duckling data
        Vector3 new_hedgeDuckling_position;
 
        new_hedgeDuckling_position.x = data.hedgeDucklingPosition[0];
        new_hedgeDuckling_position.y = data.hedgeDucklingPosition[1];
        new_hedgeDuckling_position.z = data.hedgeDucklingPosition[2];
        hedgeDuckling.transform.position = new_hedgeDuckling_position;

        bool new_hedgeDucklingFollow = data.hedgeDucklingFollow;
        hedgeDuckling.GetComponent<NavigationScript>()._isFollowing = new_hedgeDucklingFollow;

        // Load hiding Duckling data
        Vector3 new_hidingDuckling_position;
 
        new_hidingDuckling_position.x = data.hidingDucklingPosition[0];
        new_hidingDuckling_position.y = data.hidingDucklingPosition[1];
        new_hidingDuckling_position.z = data.hidingDucklingPosition[2];
        hidingDuckling.transform.position = new_hidingDuckling_position;

        bool new_hidingDucklingFollow = data.hidingDucklingFollow;
        hidingDuckling.GetComponent<NavigationScript>()._isFollowing = new_hidingDucklingFollow;

        // Load tree Duckling data
        Vector3 new_treeDuckling_position;
 
        new_treeDuckling_position.x = data.treeDucklingPosition[0];
        new_treeDuckling_position.y = data.treeDucklingPosition[1];
        new_treeDuckling_position.z = data.treeDucklingPosition[2];
        treeDuckling.transform.position = new_treeDuckling_position;

        bool new_treeDucklingFollow = data.treeDucklingFollow;
        treeDuckling.GetComponent<NavigationScript>()._isFollowing = new_treeDucklingFollow;

        // Load bench Duckling data
        Vector3 new_benchDuckling_position;
 
        new_benchDuckling_position.x = data.benchDucklingPosition[0];
        new_benchDuckling_position.y = data.benchDucklingPosition[1];
        new_benchDuckling_position.z = data.benchDucklingPosition[2];
        benchDuckling.transform.position = new_benchDuckling_position;

        bool new_benchDucklingFollow = data.benchDucklingFollow;
        benchDuckling.GetComponent<NavigationScript>()._isFollowing = new_benchDucklingFollow;

        
        

        
        
    }

}
