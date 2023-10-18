using System.Collections;
using UnityEngine;

public class SleepFade : MonoBehaviour
{
    public Animator animator;
    public bool fadecooldown = false;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadetoSleep()
    {
        fadecooldown = true;
        animator.SetBool("IsWhite", true);
        new WaitForSeconds(1);
        StartCoroutine("ResetFade");
    }

    IEnumerator ResetFade()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("IsWhite", false);
        yield return new WaitForSeconds(2);
        fadecooldown = false;
    }
}
