using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfinerController : MonoBehaviour
{
    [SerializeField] private GameObject confiner;
    private Cinemachine.CinemachineConfiner2D cf;
    private GameObject boundingShape;
    // Start is called before the first frame update
    private void Awake()
    {
        cf = gameObject.GetComponent<Cinemachine.CinemachineConfiner2D>();
    }

    void Start()
    {
        boundingShape = Instantiate(confiner, new Vector3(0f, 0f, 0f), Quaternion.identity);
        PolygonCollider2D pc = boundingShape.GetComponent<PolygonCollider2D>();
        cf.m_BoundingShape2D = pc;
    }
}
