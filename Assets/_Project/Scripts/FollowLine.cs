using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLine : MonoBehaviour
{
    public ParticleSystem RobotRadius;
    
    public float minDistanceFollow = 0.1f;
    private float distance = 0;

    public Transform robotTransform = null;
    
    private Vector3 pos;
    public float speed = 7.5f;

    private void Start()
    {
        radiusPlay();
    }

    public void radiusPlay()
    {
        RobotRadius.Play();
    }

    // delayMoLine i�lemini yaparken di�er bir listenin uzant�s�na atlamada bekleme yapmamas� i�in kullan�yoruz
    // delayMoLine We use it so that it does not wait while jumping to the extension of another list while doing the operation.
    public void moveToLine(List<Vector3> list, float time)
    {
        StartCoroutine(delayMoveLine(list,time));
    }


    IEnumerator delayMoveLine(List<Vector3> List, float time)
    {

        yield return new WaitForSeconds(time);
        for(int i = 0; i < List.Count; i++)
        {

            // robotS�b�rge ile �izdi�imiz �izgideki kordinatlar�n aras�n� hesapl�yoruz
            // robot We calculate the distance between the coordinates on the line we drew with

            distance = Vector3.Distance(robotTransform.transform.position, List[i]);

            

            while (distance > minDistanceFollow)
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
