using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueBola : MonoBehaviour
{
    public GameObject Particulas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        Vector3 posactual = new Vector3(transform.position.x, 0.5f, transform.position.z);
        Instantiate(Particulas, posactual, Particulas.transform.rotation);
    }
}