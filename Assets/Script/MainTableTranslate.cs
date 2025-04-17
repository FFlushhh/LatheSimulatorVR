using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTableTranslate : MonoBehaviour
{
    [SerializeField]private GameObject TargetTransform;
    [SerializeField]private GameObject MoveTarget;
    [SerializeField]private Vector3 MovementDirection;
    private Vector3 currentpositon;
    private Vector3 previousposition;
    private Vector3 movementDelta;
    private Vector3 crossProduct;

    // Start is called before the first frame update
    void Start()
    {
        previousposition = TargetTransform.transform.position;
        currentpositon = TargetTransform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentpositon = TargetTransform.transform.position;

        movementDelta = currentpositon - previousposition;

        crossProduct = Vector3.Cross(previousposition - currentpositon, Vector3.forward);

        if (crossProduct.y > 0){
            MoveTarget.transform.position += MovementDirection * movementDelta.magnitude * Time.deltaTime;
        } else if (crossProduct.y < 0){
            MoveTarget.transform.position -= MovementDirection * movementDelta.magnitude * Time.deltaTime;
        }
        
        previousposition = currentpositon;
    }
}
