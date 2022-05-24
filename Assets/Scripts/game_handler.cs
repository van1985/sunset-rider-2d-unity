using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_handler : MonoBehaviour
{
    public List<GameObject> indice_objetos;
    public List<GameObject> spawns;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Billy = Instantiate(indice_objetos[0], spawns[0].transform.position, Quaternion.identity);
        Billy.name = "Billy";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
