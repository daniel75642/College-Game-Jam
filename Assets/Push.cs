using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private CharacterController characterController;

    private Rigidbody rb;

    public GameObject player;

    public float pushForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("P1"))
        {
            StartCoroutine(Pause(other));
            StopCoroutine(Pause(other));
        }
        else if (other.gameObject.CompareTag("P2"))
        {
            StartCoroutine(Pause(other));
            StopCoroutine(Pause(other));
        }
        else if (other.gameObject.CompareTag("P3"))
        {
            StartCoroutine(Pause(other));
            StopCoroutine(Pause(other));
        }
        else if (other.gameObject.CompareTag("P4"))
        {
            StartCoroutine(Pause(other));
            StopCoroutine(Pause(other));
        }
    }

    private IEnumerator Pause(Collider other)
    {
        characterController = other.gameObject.GetComponent<CharacterController>();
        rb = other.gameObject.GetComponent<Rigidbody>();
        rb.rotation = Quaternion.identity;
        characterController.enabled = false;
        other.gameObject.transform.rotation = player.transform.rotation;
        rb.AddForce(rb.transform.forward * pushForce, ForceMode.Impulse);
        rb.AddForce(rb.transform.up * pushForce * Time.deltaTime, ForceMode.Impulse);
        rb.velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.8f);
        characterController.enabled = true;
    }
}
