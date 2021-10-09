using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{

    public Camera cam;
    public LineRenderer lineRenderer = null;
    


    //kullanaca��m�z de�i�kenleri tan�mlayal�m
    //Let's define the variables we will use

    private Vector3 mousePos;
    private Vector3 pos;
    private Vector3 prePos;



    //kordinatlar� at�lacak listeyi olu�turuyoruz
    public List<Vector3> linePositions = new List<Vector3>();

    //en d���k uzunlu�umuzu ve ilk uzunlu�umuzu tan�ml�yoruz
    //we define our lowest length and first length

    public float minDistance = 0.1f;
    private float distance = 0;


    void Update()
    {
            drawing();
           


    }

    private void drawing()
    {


        //pozisyonlar� belirleyip eskisinin i�ine yenisini at�p linePositions'a atal�m
        //let's specify the positions and insert the new one into the old one and assign it to linePositions

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 19;
            pos = cam.ScreenToWorldPoint(mousePos);
            prePos = pos;
            linePositions.Add(pos);

        }


        else
        {
            if (Input.GetMouseButton(0))
            {
                // uzunlu�u hesaplayal�m
                // let's calculate the length

                mousePos = Input.mousePosition;
                mousePos.z = 19;
                pos = cam.ScreenToWorldPoint(mousePos);
                distance = Vector3.Distance(pos, prePos);

                // uzunlu�umuz minimum de�erden b�y�k ise �izimi yap
                // make the drawing if our length is greater than the minimum

                if (distance >= minDistance)
                {

                    prePos = pos;
                    linePositions.Add(pos);
                    lineRenderer.positionCount = linePositions.Count;
                    lineRenderer.SetPositions(linePositions.ToArray());

                }

            }

            // gameManager kontrol� yap�p, followLine kodundaki moveToline kodunu kullanal�m 
            // Let's check the gameManager and use the moveToline code in the followLine code

            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    GameManager.instance.robot.moveToLine(linePositions, 0);
                }
            }
        }





    }

    
}

    
