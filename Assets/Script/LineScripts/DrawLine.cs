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
    [SerializeField] private Transform _pointer;
    [SerializeField] private List<Vector3> _positions = new();
    private Vector3 _oldPoint;
    private float stepPoint = 0.2f;

    [Header("Prefabs Creator")]
    [SerializeField] private GameObject PrefabCreated;

    //public PlayerStats _playerStats;

    public LineStatus LineStatus = LineStatus.None;
    private MeshCollider _collider;

    private void Start()
    {
        _collider = GetComponent<MeshCollider>();
    }

    private void LateUpdate()
    {
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
                if (Vector3.Distance(_pointer.position, _oldPoint) > stepPoint)
                {
                    //_playerStats.DecrementMana(Time.deltaTime);

                    _positions.Add(_pointer.position);
                    _lineRenderer.positionCount = _positions.Count;
                    _lineRenderer.SetPositions(_positions.ToArray());
                    _oldPoint = _pointer.position;
                    //_playerStats.DecrementMana(Time.deltaTime);
                    GenerateMeshCollider();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(PrefabsCreator());
            LineStatus = LineStatus.Created;
            Time.timeScale = 1f;
            Invoke(nameof(BreakLine), 1f);
        }
    }
    public void GenerateMeshCollider()
    {
        Mesh mesh = new Mesh();
        mesh.name = "LineMesh";
        _lineRenderer.BakeMesh(mesh);
        _collider.sharedMesh = mesh;
    }


    public void BreakLine()
    {
        _lineRenderer.positionCount = 0;
        _positions.Clear();

    }
    IEnumerator PrefabsCreator()
    {
        for (int i = 0; i < _positions.Count; i++)
        {
            Instantiate(PrefabCreated, _positions[i], Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
        }     
    }
}
