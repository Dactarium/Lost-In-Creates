using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private Color[] _colors;

    void Start(){
        if(_colors.Length > 0) GetComponent<MeshRenderer>().material.SetColor("_BaseColor", _colors[Random.Range(0, _colors.Length)]);
    }
}
