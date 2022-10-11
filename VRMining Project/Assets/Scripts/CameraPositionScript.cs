using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CaveFrontPos()
    {
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(32.08f, -9.8f, -9.39f);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
        
    }

    public void AirView()
    {
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(-14.7f, 2.7f, -19.760f);
        gameObject.transform.position = pos;
        //gameObject.transform.rotation = new Quaternion(27, -20, 0, 0);
        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.SetActive(true);

    }
}
