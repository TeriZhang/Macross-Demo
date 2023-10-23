using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    public bool isjet;
    public GameObject playerplane;
    public GameObject playerMech;

    public GameObject normal, ultimate;
    public GameObject fx1, fx2, fx3, fx4;
    // Start is called before the first frame update
    void Start()
    {
        isjet = true;
        fx1.SetActive(false);
        fx2.SetActive(false);
        fx3.SetActive(false);
        fx4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //switching controls
        if(isjet == true)
        {
            playerplane.SetActive(true);
            playerMech.SetActive(false);
            this.gameObject.GetComponent<HeneGames.Airplane.SimpleAirPlaneController>().enabled = true;
            this.gameObject.GetComponent<MechMovement>().enabled = false;
            this.gameObject.GetComponent<CharacterController>().enabled = false;
            this.gameObject.GetComponent<HeneGames.Airplane.SimpleAirPlaneController>().reStart();
            
        }
        else
        {
            playerplane.SetActive(false);
            playerMech.SetActive(true);
            this.gameObject.GetComponent<HeneGames.Airplane.SimpleAirPlaneController>().enabled = false;
            this.gameObject.GetComponent<MechMovement>().enabled = true;
            this.gameObject.GetComponent<CharacterController>().enabled = true;
        }

        //switch function
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(isjet == true)
            {
                isjet = false;
            }
            else
            {
                isjet = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            fx1.SetActive(true);
            fx2.SetActive(true);
            fx3.SetActive(true);
            fx4.SetActive(true);
            normal.SetActive(false);
            ultimate.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            fx1.SetActive(false);
            fx2.SetActive(false);
            fx3.SetActive(false);
            fx4.SetActive(false);
            normal.SetActive(true);
            ultimate.SetActive(false);
        }
    }
}
