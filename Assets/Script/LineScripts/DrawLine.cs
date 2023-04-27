
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
            //PrefabsCreator();
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


    public void PrefabsCreator()
    {

        for (int i = 0; i < _positions.Count; i++)
        {
            Instantiate(PrefabCreated, _positions[i], Quaternion.identity);
        }

    }

}
