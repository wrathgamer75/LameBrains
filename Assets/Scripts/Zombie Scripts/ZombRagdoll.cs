using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombRagdoll : MonoBehaviour
{
    public float deathtimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        deathtimer += Time.deltaTime;
        if (deathtimer >=3f)
        {
            Destroy(this.gameObject);
            deathtimer = 0f;
        }
    }
}
