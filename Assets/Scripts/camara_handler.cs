using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara_handler : MonoBehaviour
{
    public GameObject min;
    public GameObject max;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Billy = GameObject.Find("Billy");
        if ((Billy.transform.position.x > max.transform.position.x) && (max.transform.position.x < GameObject.FindGameObjectWithTag("Level").GetComponent<level_handler>().max.transform.position.x))
        {
            transform.position += new Vector3(0.02f, 0, 0);
        }
    }
}
