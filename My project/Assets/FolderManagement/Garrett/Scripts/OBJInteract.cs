using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJInteract : MonoBehaviour
{
    private Animator objAnim;

    private bool objRotated = false;

    public Material glow;
    public Material defaultMat;

    private void Awake()
    {
        objAnim = gameObject.GetComponent<Animator>();
    }

    public void RotateOBJ()
    {
        if (!objRotated)
        {
            objAnim.Play("ObjRotate", 0, 0.0f);
            objRotated = true;
        }
        else
        {
            objAnim.Play("ObjUnRotate", 0, 0.0f);
            objRotated = false;
        }
    }

    public void GlowObj()
    {
        GetComponent<MeshRenderer>().material = glow;
    }

    public void ResetMat()
    {
        GetComponent<MeshRenderer>().material = defaultMat;
    }
}
