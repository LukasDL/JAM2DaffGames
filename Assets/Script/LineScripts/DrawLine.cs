
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum LineStatus
{
    None,
    Drawing,
    Created

}

public class DrawLine : MonoBehaviour
{
    [Header("Draw Line")]
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _planeTransform;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private Transform _pointer;
    [SerializeField] private List<Vector3> _positions = new();
    private Vector3 _oldPoint;
    private float stepPoint = 0.2f;

    [Header("Prefabs Creator")]
    [SerializeField] public List<Vector3> PointsoCreate = new();
    [SerializeField] private GameObject PrefabCreated;


    public LineStatus LineStatus = LineStatus.None;
    private MeshCollider _collider;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float maxDistanceToPlayer = 25f;




    private void Start()
    {
        _collider = GetComponent<MeshCollider>();
    }

    private void LateUpdate()
    {

        Vector3 position = GetProjection();
        _pointer.position = position;

        if (Input.GetMouseButtonDown(0))
        {
            BreakLine();
            Time.timeScale = 0.2f;
            LineStatus = LineStatus.Drawing;

        }


        if (LineStatus == LineStatus.Drawing)
        {


            if (Input.GetMouseButton(0))
            {
                _collider.enabled = true;
                if (Vector3.Distance(position, _oldPoint) > stepPoint)
                {

                    _positions.Add(position);
                    _lineRenderer.positionCount = _positions.Count;
                    _lineRenderer.SetPositions(_positions.ToArray());
                    _oldPoint = position;

                    GenerateMeshCollider();

                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(PrefabsCreator());
            LineStatus = LineStatus.Created;
            Time.timeScale = 1f;
            //Invoke(nameof(BreakLine), 3f);


        }

        //проверка на дальность линии оть игрока

        if (_playerTransform.position.x - transform.position.x > maxDistanceToPlayer)
        {

        }
    }


    private Vector3 GetProjection()
    {
        Plane plane = new(_planeTransform.up, _planeTransform.position);
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 position = ray.GetPoint(distance);

        return position;
    }

    public void GenerateMeshCollider()
    {
        Mesh mesh = new Mesh();
        mesh.name = "LineMesh";
        _lineRenderer.BakeMesh(mesh);
        _collider.sharedMesh = mesh;
    }


    public void GenerateRigidbody()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
    }



    public void BreakLine()
    {
        _lineRenderer.positionCount = 0;

        for (int i = 0; i < _positions.Count; i++)
        {
            PointsoCreate.Add(_positions[i]);
        }

        _positions.Clear();
        PointsoCreate.Clear();

    }


    IEnumerator PrefabsCreator()
    {


        for (int i = 0; i < _positions.Count; i++)
        {
            Instantiate(PrefabCreated, _positions[i], Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
        }
        
    }


    //public static Vector3[] SmoothLine(Vector3[] points, int smoothness)
    //{
    //    if (points == null || points.Length < 4)
    //    {
    //        Debug.LogError("Not enough points to create a Catmull-Rom spline");
    //        return points;
    //    }

    //    int segments = points.Length - 3;
    //    int numVertices = segments * smoothness;

    //    Vector3[] vertices = new Vector3[numVertices];
    //    int vertexIndex = 0;

    //    for (int i = 0; i < segments; i++)
    //    {
    //        for (int j = 0; j < smoothness; j++)
    //        {
    //            float t = (float)j / (float)smoothness;
    //            vertices[vertexIndex] = CatmullRomSpline.Interpolate(points[i], points[i + 1], points[i + 2], points[i + 3], t);
    //            vertexIndex++;
    //        }
    //    }

    //    return vertices;
    //}


    //private static Vector3 Interpolate(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    //{
    //    float t2 = t * t;
    //    float t3 = t2 * t;

    //    Vector3 v0 = (p2 - p0) / 2f;
    //    Vector3 v1 = (p3 - p1) / 2f;

    //    Vector3 a = 2 * t3 - 3 * t2 + 1;
    //    Vector3 b = t3 - 2 * t2 + t;
    //    Vector3 c = t3 - t2;
    //    Vector3 d = -2 * t3 + 3 * t2;

    //    return a * p1 + b * v0 + c * v1 + d * p2;
    //}



}
