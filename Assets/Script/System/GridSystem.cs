using UnityEngine;
using System.Collections;

public class GridSystem : MonoBehaviour {

    //public variables goes here

    public const float floFakegridwidth = 0.64f;
    public const float floFakegridheight = 0.32f;

    public GameObject gaobCurgrid;
    public float floCurgridX;
    public float floCurgridY;


    public GameObject gameobjMainCamera;

    private Vector3 vec3MousePos;
    public int intPregridX;
    public int intPregridY;

    public int intCurGridX;
    public int intCurGridY;

    private bool disabled = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void zoomin()
    {
        if (!disabled)
        {
            gameobjMainCamera.transform.position = new Vector3(gameobjMainCamera.transform.position.x, gameobjMainCamera.transform.position.y, -4);
            vec3MousePos.z = 4;
        }
    }

    public void zoomout()
    {
        if (!disabled)
        {
            gameobjMainCamera.transform.position = new Vector3(gameobjMainCamera.transform.position.x, gameobjMainCamera.transform.position.y, -10);
            vec3MousePos.z = 10;
        }
    }

    void sidescroll()
    {
        if (!disabled)
        {
            vec3MousePos = Input.mousePosition;

            //Debug.Log(vec3MousePos.y);
            if (vec3MousePos.x <= 30)
            {
                gameobjMainCamera.transform.position = gameobjMainCamera.transform.position - new Vector3(0.05f, 0, 0);
            }
            if (vec3MousePos.x >= Screen.width - 30)
            {
                gameobjMainCamera.transform.position = gameobjMainCamera.transform.position + new Vector3(0.05f, 0, 0);
            }
            if (vec3MousePos.y <= 30)
            {
                gameobjMainCamera.transform.position = gameobjMainCamera.transform.position - new Vector3(0, 0.05f, 0);
            }
            if (vec3MousePos.y >= Screen.width - 30)
            {
                gameobjMainCamera.transform.position = gameobjMainCamera.transform.position + new Vector3(0, 0.05f, 0);
            }
        }
    }

    void checkmouseposition()
    {
        vec3MousePos = Input.mousePosition;
        vec3MousePos.z = 10;
        vec3MousePos = Camera.main.ScreenToWorldPoint(vec3MousePos);
        intPregridX = Mathf.FloorToInt((vec3MousePos.x + 64) / floFakegridwidth) - 100;
        intPregridY = Mathf.FloorToInt((vec3MousePos.y + 32) / floFakegridheight) - 100;

        //to those who might want to read this part
        //just dont...

        if ((((Mathf.Abs(intPregridX) % 2) == 1) && ((Mathf.Abs(intPregridY) % 2) == 0)) || (((Mathf.Abs(intPregridX) % 2) == 0) && ((Mathf.Abs(intPregridY) % 2) == 1)))
        {
            if ((((vec3MousePos.y + 32) % floFakegridheight) * 2 + ((vec3MousePos.x + 64) % floFakegridwidth)) >= floFakegridwidth)
            {
                //right top
                //Debug.Log("right top");
                intPregridX += 1;
                intPregridY += 1;
            }
            else
            {
                //left bottom
                //Debug.Log("left bottom");
            }
        }
        else
        {

            if (((vec3MousePos.y + 32) % floFakegridheight) * 2 > ((vec3MousePos.x + 64) % floFakegridwidth))
            {
                //left top
                //Debug.Log("left top");
                intPregridY += 1;
            }
            else
            {
                //right bottom
                //Debug.Log("right bottom");
                intPregridX += 1;
            }


        }

        floCurgridX = (intPregridX) * floFakegridwidth;
        floCurgridY = (intPregridY) * floFakegridheight;


        intCurGridX = (intPregridX - intPregridY + 29) / 2;
        intCurGridY = intPregridY + intCurGridX - 5;

        Debug.Log("x:" + intCurGridX.ToString() + ",y:" + intCurGridY.ToString());
        //Debug.Log(floCurgridX);
        //Debug.Log(floCurgridY);
        //Debug.Log(gridXYtoVec(intCurGridX, intCurGridY));
        if ((intCurGridX < 1) || (intCurGridY < 1) || (intCurGridX > 28) || (intCurGridY > 18))
        {

        }
        else
        {
            gaobCurgrid.transform.position = new Vector3(floCurgridX, floCurgridY, 0);
        }
    }

    public Vector3 gridXYtoVec(int gridx, int gridy)
    {
        return new Vector3((gridx + gridy - 24) * 0.64f, (gridy - gridx + 5) * 0.32f, 0);
    }
}
