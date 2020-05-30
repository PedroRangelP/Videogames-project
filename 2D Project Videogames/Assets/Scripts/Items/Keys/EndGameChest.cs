using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameChest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(KeysManager.CheckKeys())
        {
            SoundManager.PlaySound("UseEndGameChest", 1f);
            Debug.Log("The player has all the keys, the game ends");
            //End game
        }
        else
        {
            Debug.Log("Some keys are missing, cannot end the game");
        }
        
    }
}