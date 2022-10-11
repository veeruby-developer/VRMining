using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionScript : MonoBehaviour
{
    public GameObject welcomeCanvas;
    GameObject benchHighlight;
    // Start is called before the first frame update
    void Start()
    {
        benchHighlight = GameObject.FindGameObjectWithTag("Bench");
        benchHighlight.SetActive(true);
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
        gameObject.transform.Rotate(0, 130, 0);
        gameObject.SetActive(true);
        
    }

    public void AirView()
    {
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(-97.9f, 20.2f, 18.4f);
        gameObject.transform.position = pos;
        //gameObject.transform.rotation = new Quaternion(27, -20, 0, 0);
        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.SetActive(true);
        welcomeCanvas.SetActive(true);

        StartCoroutine(WelcomeCanvasOff());
        
    }

    IEnumerator WelcomeCanvasOff()
    {
        yield return new WaitForSeconds(5);
        welcomeCanvas.SetActive(false);
        StartCoroutine(Bench());
    }
    IEnumerator Bench()
    {
        Debug.Log("bench");
        yield return new WaitForSeconds(5);
        
        //benchHighlight.SetActive(true);
        //Debug.Log("b");
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(-46.6f, 17.11f, -15f);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
        StartCoroutine(Crest());
    }
    IEnumerator Crest()
    {
        yield return new WaitForSeconds(5);
        GameObject highlight = GameObject.FindGameObjectWithTag("Crest");
        highlight.SetActive(true);
    }
}
