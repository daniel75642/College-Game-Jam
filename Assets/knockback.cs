using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public Collider attackCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Push());
            StopCoroutine(Push());
        }
    }

    private IEnumerator Push()
    {
        attackCol.enabled = true;
        yield return new WaitForSeconds(1f);
        attackCol.enabled = false;
        yield return new WaitForSeconds(4f);
    }
}
