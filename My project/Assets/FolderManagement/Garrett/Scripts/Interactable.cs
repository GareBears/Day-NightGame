using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Teleporting teleporting;
    GameObject watch;

    // Start is called before the first frame update
    void Start()
    {
        teleporting = GameObject.FindGameObjectWithTag("Player").GetComponent<Teleporting>();
        watch = GameObject.FindGameObjectWithTag("Watch");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyMethod()
    {
        Destroy(gameObject);
    }

    public void OnPickUp()
    {
        Destroy(gameObject);
    }

    public void WatchPickUp()
    {
        teleporting.hasWatch = true;
        Destroy(watch);
    }
}
