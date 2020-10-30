using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    private Camera myCamera;
    private Purse myPurse;
    public GameObject tower;
    public Transform towerParent;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
        myPurse = GameObject.Find("Purse").GetComponent<Purse>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseClick = Input.mousePosition;
            //Debug.Log(mouseClick);
            Ray ray = myCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));


            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print("I'm looking at " + hit.transform.name);
                if (hit.transform.tag == "EasyEnemy")
                {
                    hit.transform.GetComponent<Enemy>().TakeDamage(20);
                }
            }
            else
            {
                print("I'm looking at nothing!");
            }

            if (hit.transform.tag == "TowerPosition")
            {
                if (myPurse.PlaceTower(500))
                {
                    Instantiate(tower, hit.transform.position, Quaternion.identity, towerParent);
                    Destroy(hit.transform.gameObject);
                }
                //Debug.Log(hit.transform.name + " Hit!");
               
            }
        }
    }
}
