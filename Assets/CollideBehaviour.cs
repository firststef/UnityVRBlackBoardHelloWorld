using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    LineRenderer currentLn;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        LineRenderer lr = new GameObject().AddComponent<LineRenderer>();
        lr.gameObject.transform.SetParent(transform, false);
        lr.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.widthMultiplier = 0.2f;
        lr.positionCount = 20;
        currentLn = lr;
        currentLn.positionCount = 0;
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        currentLn.positionCount = currentLn.positionCount + 1;
        currentLn.SetPosition(currentLn.positionCount - 1, collisionInfo.contacts[0].point);
    }

    void OnCollisionExit(Collision collisionInfo){
        currentLn = null;
    }
}
