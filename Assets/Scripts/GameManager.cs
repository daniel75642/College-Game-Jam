using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject cam;
    [Space(2), Header("Map Locations")]
    public Transform moon;
    public Transform tree;
    public Transform forge;
    public Transform ufo;
    [Space(2), Header("Player Objects")]
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    [Space(2), Header("Moon Spawns")]
    public Transform moon1;
    public Transform moon2; 
    public Transform moon3;
    public Transform moon4;
    [Space(2), Header("Tree Spawns")]
    public Transform tree1;
    public Transform tree2;
    public Transform tree3;
    public Transform tree4;
    [Space(2), Header("Forge Spawns")]
    public Transform forge1;
    public Transform forge2;
    public Transform forge3;
    public Transform forge4;
    [Space(2), Header("UFO Spawns")]
    public Transform ufo1;
    public Transform ufo2;
    public Transform ufo3;
    public Transform ufo4;

    public PlayerInput input;

    public int mapChoice;

    private bool done;

    public int playersLeft;

    public PlayerSpawn spawn;

    [SerializeField] public static GameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);

        input.actions.FindAction("Start Game").started += _ => StartGame();

        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        P1 = GameObject.FindGameObjectWithTag("P1");
        P2 = GameObject.FindGameObjectWithTag("P2");
        P3 = GameObject.FindGameObjectWithTag("P3");
        P4 = GameObject.FindGameObjectWithTag("P4");
    }

    public void StartGame()
    {
        if (done == false && playersLeft > 1)
        {
            mapChoice = Random.Range(3, 4);
            if (mapChoice == 1)
            {
                cam.transform.position = moon.position;
                cam.transform.rotation = moon.rotation;
                if (P1 != null)
                {
                    P1.GetComponent<CharacterController>().enabled = false;
                    P1.transform.SetPositionAndRotation(moon1.position, Quaternion.identity);
                    P1.GetComponent<CharacterController>().enabled = true;
                }
                if (P2 != null)
                {
                    P2.GetComponent<CharacterController>().enabled = false;
                    P2.transform.SetPositionAndRotation(moon2.position, Quaternion.identity);
                    P2.GetComponent<CharacterController>().enabled = true;
                }
                if (P3 != null)
                {
                    P3.GetComponent<CharacterController>().enabled = false;
                    P3.transform.SetPositionAndRotation(moon3.position, Quaternion.identity);
                    P3.GetComponent<CharacterController>().enabled = true;
                }
                if (P4 != null)
                {
                    P4.GetComponent<CharacterController>().enabled = false;
                    P4.transform.SetPositionAndRotation(moon4.position, Quaternion.identity);
                    P4.GetComponent<CharacterController>().enabled = true;
                }
                done = true;
                spawn.manager.enabled = false;
                StartCoroutine(WaitForLastPlayer());
                return;
            }

            else if (mapChoice == 2)
            {
                cam.transform.position = tree.position;
                cam.transform.rotation = tree.rotation;
                if (P1 != null)
                {
                    P1.GetComponent<CharacterController>().enabled = false;
                    P1.transform.SetPositionAndRotation(tree1.position, Quaternion.identity);
                    P1.GetComponent<CharacterController>().enabled = true;

                }
                if (P2 != null)
                {
                    P2.GetComponent<CharacterController>().enabled = false;
                    P2.transform.SetPositionAndRotation(tree2.position, Quaternion.identity);
                    P2.GetComponent<CharacterController>().enabled = true;

                }
                if (P3 != null)
                {
                    P3.GetComponent<CharacterController>().enabled = false;
                    P3.transform.SetPositionAndRotation(tree3.position, Quaternion.identity);
                    P3.GetComponent<CharacterController>().enabled = true;

                }
                if (P4 != null)
                {
                    P4.GetComponent<CharacterController>().enabled = false;
                    P4.transform.SetPositionAndRotation(tree4.position, Quaternion.identity);
                    P4.GetComponent<CharacterController>().enabled = true;

                }
                done = true;
                spawn.manager.enabled = false;
                StartCoroutine(WaitForLastPlayer());
                return;
            }

            else if (mapChoice == 3)
            {
                cam.transform.position = forge.position;
                cam.transform.rotation = forge.rotation;
                if (P1 != null)
                {
                    P1.GetComponent<CharacterController>().enabled = false;
                    P1.transform.SetPositionAndRotation(forge1.position, Quaternion.identity);
                    P1.GetComponent<CharacterController>().enabled = true;

                }
                if (P2 != null)
                {
                    P2.GetComponent<CharacterController>().enabled = false;
                    P2.transform.SetPositionAndRotation(forge2.position, Quaternion.identity);
                    P2.GetComponent<CharacterController>().enabled = true;

                }
                if (P3 != null)
                {
                    P3.GetComponent<CharacterController>().enabled = false;
                    P3.transform.SetPositionAndRotation(forge3.position, Quaternion.identity);
                    P3.GetComponent<CharacterController>().enabled = true;

                }
                if (P4 != null)
                {
                    P4.GetComponent<CharacterController>().enabled = false;
                    P4.transform.SetPositionAndRotation(forge4.position, Quaternion.identity);
                    P4.GetComponent<CharacterController>().enabled = true;

                }
                done = true;
                spawn.manager.enabled = false;
                StartCoroutine(WaitForLastPlayer());
                return;
            }

            else if (mapChoice == 4)
            {
                cam.transform.position = ufo.position;
                cam.transform.rotation = ufo.rotation;
                if (P1 != null)
                {
                    P1.GetComponent<CharacterController>().enabled = false;
                    P1.transform.SetPositionAndRotation(ufo1.position, Quaternion.identity);
                    P1.GetComponent<CharacterController>().enabled = true;

                }
                if (P2 != null)
                {
                    P2.GetComponent<CharacterController>().enabled = false;
                    P2.transform.SetPositionAndRotation(ufo2.position, Quaternion.identity);
                    P2.GetComponent<CharacterController>().enabled = true;

                }
                if (P3 != null)
                {
                    P3.GetComponent<CharacterController>().enabled = false;
                    P3.transform.SetPositionAndRotation(ufo3.position, Quaternion.identity);
                    P3.GetComponent<CharacterController>().enabled = true;

                }
                if (P4 != null)
                {
                    P4.GetComponent<CharacterController>().enabled = false;
                    P4.transform.SetPositionAndRotation(ufo4.position, Quaternion.identity);
                    P4.GetComponent<CharacterController>().enabled = true;

                }
                done = true;
                spawn.manager.enabled = false;
                StartCoroutine(WaitForLastPlayer());
                return;
            }
        }
    }

    public IEnumerator WaitForLastPlayer()
    {
        while (playersLeft > 1)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(playersLeft);
        }

        // Game end stuff here

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(0);

        yield return null;
    }
}
