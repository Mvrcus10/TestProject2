using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Character : MonoBehaviour
{
    // variable, pulic gives access to unity
    public float playerSpeed;
    public float minX, maxX, minY, maxY;
    public GameObject laserBeam;
    public GameObject laserBeamSpawner;
    public float fireRate = 0.25f;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("New Game");
        float horizontalmove;
        float verticalmove;
        horizontalmove = Input.GetAxis("Horizontal");
        verticalmove = Input.GetAxis("Vertical");
        Debug.Log("H: " + horizontalmove + " ,V" + verticalmove);
        Vector2 newvelocity=new Vector2(horizontalmove, verticalmove);
        GetComponent<Rigidbody2D>().velocity = newvelocity * playerSpeed;

        float newX, newY;
        
        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
        newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);

        GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);

        if (Input.GetAxis("Fire1") > 0 && timer > fireRate)
        {
            GameObject goObj;
            goObj=  GameObject.Instantiate(laserBeam, laserBeamSpawner.transform.position, laserBeamSpawner.transform.rotation);
            goObj.transform.Rotate( 0.0f, 0.0f, 90.0f);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
