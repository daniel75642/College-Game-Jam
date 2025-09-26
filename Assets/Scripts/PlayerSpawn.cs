using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{
    private int playersJoined = 0;

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    public PlayerInputManager manager;

    private void Start()
    {
        manager.enabled = true;
    }

    void Update()
    {

    }
    private void OnPlayerJoined(PlayerInput player)
    {
        Debug.Log(player.name);

        player.gameObject.tag = "P" + ++playersJoined;

        P1 = GameObject.FindGameObjectWithTag("P1");
        P2 = GameObject.FindGameObjectWithTag("P2");
        P3 = GameObject.FindGameObjectWithTag("P3");
        P4 = GameObject.FindGameObjectWithTag("P4");

        if (player.gameObject.tag == "P1")
        { 
            P1.GetComponentInChildren<Renderer>().material.color = Color.red;
            GameManager.Instance.playersLeft++;
        }
        if (player.gameObject.tag == "P2")
        {
            P2.GetComponentInChildren<Renderer>().material.color = Color.yellow;
            GameManager.Instance.playersLeft++;
        }
        if (player.gameObject.tag == "P3")
        {
            P3.GetComponentInChildren<Renderer>().material.color = Color.green;
            GameManager.Instance.playersLeft++;
        }
        if (player.gameObject.tag == "P4")
        {
            P4.GetComponentInChildren<Renderer>().material.color = Color.blue;
            GameManager.Instance.playersLeft++;
        }
    }

}
