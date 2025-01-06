using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotato : MonoBehaviour
{
    float moveInput;
    float moveBoost;
    float latestCdTime;
    bool flipper = false;

    // Update is called once per frame
    void Update()
    {
        if (flipper && Input.GetAxis("Horizontal") == 0)
        {
            transform.Rotate(0, 0, 40 * Time.deltaTime);
        }
        if (!flipper && Input.GetAxis("Horizontal") == 0)
        {
            transform.Rotate(0, 0, -40 * Time.deltaTime);
        }



        if (Input.GetAxis("Horizontal") < 0 && !Input.GetKey("space"))
        {
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -50 * Time.deltaTime);
            flipper = true;
        }
        else if (Input.GetAxis("Horizontal") > 0 && !Input.GetKey("space"))
        {
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -50 * Time.deltaTime);
            flipper = false;
        }
        else if (Input.GetAxis("Horizontal") < 0 && Input.GetKey("space"))
        {
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -500 * Time.deltaTime);
            flipper = true;
        }
        else if (Input.GetAxis("Horizontal") > 0 && Input.GetKey("space"))
        {
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -500 * Time.deltaTime);
            flipper = false;
        }


    }
}
