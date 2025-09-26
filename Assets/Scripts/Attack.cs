using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Attack : MonoBehaviour
{
    public Collider attackCollider;
    public Collider heavyCollider;

    private bool attacking;

    public PlayerInput input;

    private Animator animator;

    public float Combo;

    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        attackCollider.enabled = false;
        heavyCollider.enabled = false;
        Combo = 0;

        input = GetComponent<PlayerInput>();

        animator = GetComponentInChildren<Animator>();

        input.actions.FindAction("Default Attack").started += _ => LightAttacking();
        input.actions.FindAction("Heavy Attack").started += _ => HeavyAttacking();
    }
        
    public void LightAttacking ()
    {
        if (attacking == false && Combo == 0)
        {
            StartCoroutine(LightPause1());
            StopCoroutine(LightPause1());
            
            return;
        }
        else if (attacking == false && Combo == 1)
        {
            StartCoroutine(LightPause2());
            StopCoroutine(LightPause2());
            
            return;
        }
        else if (attacking == false && Combo == 2)
        {
            StartCoroutine(LightPause3());
            StopCoroutine(LightPause3());

            return;
        }
        if (Combo >= 3)
        {
            Combo = 0;
            return;
        }
    }
    public void HeavyAttacking()
    {
        if (attacking == false)
        {
            Debug.Log("heavyAttacking");
            StartCoroutine(HeavyPause());
            StopCoroutine(HeavyPause());
        }
    }

    private IEnumerator LightPause1()
    {
        attacking = true;
        animator.SetBool("DefaultAttack1", true);
        yield return new WaitForSecondsRealtime(0.3f);
        attackCollider.enabled = true;
        yield return new WaitForSecondsRealtime(0.01f);
        attackCollider.enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        animator.SetBool("DefaultAttack1", false);
        Combo += 1;
        attacking = false;
    }

    private IEnumerator LightPause2()
    {
        attacking = true;
        animator.SetBool("DefaultAttack2", true);
        yield return new WaitForSecondsRealtime(0.3f);
        attackCollider.enabled = true;
        yield return new WaitForSecondsRealtime(0.01f);
        attackCollider.enabled = false;
        yield return new WaitForSecondsRealtime(0.7f);
        animator.SetBool("DefaultAttack2", false);
        attacking = false;
        Combo += 1;
    }

    private IEnumerator LightPause3()
    {
        attacking = true;
        animator.SetBool("DefaultAttack3", true);
        yield return new WaitForSecondsRealtime(0.3f);
        attackCollider.enabled = true;
        yield return new WaitForSecondsRealtime(0.01f);
        attackCollider.enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        animator.SetBool("DefaultAttack3", false);
        attacking = false;
        Combo += 1;
    }

    private IEnumerator HeavyPause()
    {
        Debug.Log("Pause");
        attacking = true;
        animator.SetBool("DefaultAttack1", false);
        animator.SetBool("DefaultAttack2", false);
        animator.SetBool("DefaultAttack3", false);
        animator.SetBool("HeavyAttack", true);
        yield return new WaitForSecondsRealtime(0.3f);
        heavyCollider.enabled = true;
        animator.SetBool("DefaultAttack1", false);
        yield return new WaitForSecondsRealtime(0.01f);
        heavyCollider.enabled = false;
        yield return new WaitForSecondsRealtime(1.6f);
        animator.SetBool("HeavyAttack", false);
        attacking = false;
    }
}
