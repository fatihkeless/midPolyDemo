using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowLine : MonoBehaviour
{
    public ParticleSystem RobotRadius;
    public ParticleSystem RobotExp;
    public GameObject robot;
    
    public float minDistanceFollow = 0.1f;
    private float distance = 0;
    

    public Transform robotTransform = null;
    
    private Vector3 pos;
    public float speed = 7.5f;

    public static bool gameOver;
    public static bool vibration;

    private void Start()
    {
        gameOver = false;
        vibration = true;
        radiusPlay();
    }
    private void Update()
    {

    }

    public void radiusPlay()
    {
        if (!gameOver) 
        { 
        
            RobotRadius.Play();

        }
    }

    // delayMoLine i�lemini yaparken di�er bir listenin uzant�s�na atlamada bekleme yapmamas� i�in kullan�yoruz
    // delayMoLine We use it so that it does not wait while jumping to the extension of another list while doing the operation.
    public void moveToLine(List<Vector3> list, float time)
    {
        StartCoroutine(delayMoveLine(list,time));
    }

    //oyunu durdurmak i�in
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Room")
        {
            gameOver = true;
            RobotExp.Play();
            Destroy(robot, 1f);
            if (vibration)
            {
                StartCoroutine(vibrationPhone());
            }

        }

        if (other.gameObject.CompareTag("Garbage"))
        {
            Destroy(other.gameObject);
            PauseManager.starsDelete++;
           // Debug.Log(PauseManager.starsDelete);
            if (vibration)
            {
                StartCoroutine(vibrationPhone());
            }
            
        }


    }

    IEnumerator vibrationPhone()
    {
        long[] x = {15};
        Vibration.Vibrate(x, 1);
        yield return new WaitForSecondsRealtime(0.3f);
        Vibration.Cancel();

    }



    IEnumerator delayMoveLine(List<Vector3> List, float time)
    {

        yield return new WaitForSeconds(time);
        for(int i = 0; i < List.Count; i++)
        {

            

            // robotS�b�rge ile �izdi�imiz �izgideki kordinatlar�n aras�n� hesapl�yoruz
            // robot We calculate the distance between the coordinates on the line we drew with

            distance = Vector3.Distance(robotTransform.transform.position, List[i]);


            while (distance > minDistanceFollow && !gameOver)
            {
                //haraket noktas�n� ayarl�yoruz
                //we set the departure point
                pos =  Vector3.MoveTowards(robotTransform.transform.position, List[i], speed * Time.deltaTime);


                // rotasyon ayar�n� yap�yoruz
                // we set the rotation
                robotTransform.transform.LookAt(pos);

                // pozisyonu yeniliyoruz
                // renewing the position
                robotTransform.transform.position = pos;
                
                // uzakl��� yeniliyoruz
                // renwing the distance
                distance = Vector3.Distance(robotTransform.transform.position, List[i]);
                // ilk update fonksiyonu �al��t��� anda �al��mas�n� sa�l�yoruz
                // We make it work as soon as the first update function runs
                
                yield return null;

            }


            
            


        }
    }

}
