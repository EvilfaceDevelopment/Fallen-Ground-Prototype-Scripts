using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectUIController : MonoBehaviour
{
    public Canvas _textCanvas;
    private bool _beinghit = false;
    public void OnTriggerEnter(Collider col)
    {
        _beinghit = true;
        Debug.Log("enabling canvas");
        _textCanvas.enabled = true;
    }

    public void OnTriggerExit(Collider col)
    {
        Debug.Log("disabling canvas");
        _textCanvas.enabled = false;
    }
}
