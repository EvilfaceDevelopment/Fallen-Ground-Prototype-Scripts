#pragma warning disable
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    //TODO: remove pragma
    //HACK:
    private CursorLockMode lm = CursorLockMode.Confined;

    public void OnGUI()
    {
        Cursor.visible = true;
    }

}
