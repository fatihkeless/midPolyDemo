using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{

    public Camera cam;
    public LineRenderer lineRenderer = null;
    private bool firstDraw;
    public int lastPos;
    public Transform robot;


    //kullanacağımız değişkenleri tanımlayalım
    //Let's define the variables we will use

    private Vector3 mousePos;
    private Vector3 pos;
    private Vector3 prePos;
    private Vector3 lastPosVector3;



    //kordinatları atılacak listeyi oluşturuyoruz
    public List<Vector3> linePositions = new List<Vector3>();

    //en düşük uzunluğumuzu ve ilk uzunluğumuzu tanımlıyoruz
    //we define our lowest length and first length

    public float minDistance = 0.1f;
    private float distance = 0;

    private void Start()
    {
        firstDraw = true;
    }
    void Update()
    {
        
        if (firstDraw)
        {
            drawing();
        }
        
        if (FollowLine.gameOver)
        {
            linePositions.Clear();
            lineRenderer.SetPositions(linePositions.ToArray());
        }
        

        if(!firstDraw)
        {
            lastPos = linePositions.Count;
            Debug.Log(Vector3.Distance(robot.position, linePositions[lastPos -1]));
            if(Vector3.Distance(robot.position , linePositions[lastPos -1]) < 0.5f)
            {
                FollowLine.gameOver = true;
            }
            
        }
        
    }

    private void drawing()
    {


        //pozisyonları belirleyip eskisinin içine yenisini atıp linePositions'a atalım
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
                // uzunluğu hesaplayalım
                // let's calculate the length

                mousePos = Input.mousePosition;
                mousePos.z = 19;
                pos = cam.ScreenToWorldPoint(mousePos);
                distance = Vector3.Distance(pos, prePos);

                // uzunluğumuz minimum değerden büyük ise çizimi yap
                // make the drawing if our length is greater than the minimum

                if (distance >= minDistance)
                {

                    prePos = pos;
                    linePositions.Add(pos);
                    lineRenderer.positionCount = linePositions.Count;
                    lineRenderer.SetPositions(linePositions.ToArray());

                }

            }

            // gameManager kontrolü yapıp, followLine kodundaki moveToline kodunu kullanalım 
            // Let's check the gameManager and use the moveToline code in the followLine code

            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    GameManager.instance.robot.moveToLine(linePositions, 0);
                    firstDraw = false;


                }
            }
        }









    }
    




}

    
