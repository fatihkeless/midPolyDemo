using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{

    public Camera cam;
    public LineRenderer lineRenderer = null;
    


    //kullanacaðýmýz deðiþkenleri tanýmlayalým
    //Let's define the variables we will use

    private Vector3 mousePos;
    private Vector3 pos;
    private Vector3 prePos;



    //kordinatlarý atýlacak listeyi oluþturuyoruz
    public List<Vector3> linePositions = new List<Vector3>();

    //en düþük uzunluðumuzu ve ilk uzunluðumuzu tanýmlýyoruz
    //we define our lowest length and first length

    public float minDistance = 0.1f;
    private float distance = 0;


    void Update()
    {
            drawing();
           


    }

    private void drawing()
    {


        //pozisyonlarý belirleyip eskisinin içine yenisini atýp linePositions'a atalým
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
                // uzunluðu hesaplayalým
                // let's calculate the length

                mousePos = Input.mousePosition;
                mousePos.z = 19;
                pos = cam.ScreenToWorldPoint(mousePos);
                distance = Vector3.Distance(pos, prePos);

                // uzunluðumuz minimum deðerden büyük ise çizimi yap
                // make the drawing if our length is greater than the minimum

                if (distance >= minDistance)
                {

                    prePos = pos;
                    linePositions.Add(pos);
                    lineRenderer.positionCount = linePositions.Count;
                    lineRenderer.SetPositions(linePositions.ToArray());

                }

            }

            // gameManager kontrolü yapýp, followLine kodundaki moveToline kodunu kullanalým 
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

    
