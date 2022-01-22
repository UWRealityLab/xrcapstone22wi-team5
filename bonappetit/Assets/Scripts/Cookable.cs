using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour
{
    public float cookedTemp;
    
    // materials for transitions
    public Material raw;
    public Material cooked;
    public Material burnt;
    public Temperature temp;
    public MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        temp = GetComponent<Temperature>();
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(temp.maxTemp >= cookedTemp * 1.15F) {
            mesh.material = burnt;
        }
        else if(temp.maxTemp >= cookedTemp) {
            mesh.material = cooked;
        } else if(temp.tempDelta > 0) {
            // transition between textures
        }
    }
}