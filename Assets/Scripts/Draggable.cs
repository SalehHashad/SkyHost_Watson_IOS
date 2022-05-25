using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDragging;
    private Collider2D _collider;
    private DragController _dragController;
    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;
    public  Vector3 LastPosition;
    public Vector3 InitialPos;
    // Start is called before the first frame update
    void Start()
    {
        InitialPos = transform.position;
        LastPosition = transform.position;
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }
    void FixedUpdate()
    {
        //if (_movementDestination.HasValue)
        //{
        //    if (IsDragging)
        //    {
        //        _movementDestination = null;
        //        return;
        //    }
        //    if (transform.position == _movementDestination)
        //    {
        //        _movementDestination = null;
        //    }
        //}
        //else
        //{
        //  //  transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
        //}
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drag"))
        {
            Debug.Log("trigger entred");
            transform.position = InitialPos;
            _movementDestination = LastPosition;
           // other.gameObject.GetComponent<BtnClick>().btnclk();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
