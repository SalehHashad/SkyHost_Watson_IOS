using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Draggable LastDragged => _lastDragged;
    public bool _isDragActive = false;
    public Vector2 _screenPosition;
    public Vector3 _worldPosition;
    public Draggable _lastDragged;
    public Vector3 InitialPos;

    // Start is called before the first frame update
    private void Awake()
    {
        //DragController[] controllers = FindObjectOfType<DragController>();
        //if (controllers.Length > 1)
        //{
        //    Destroy(gameObject);
        //}
    }


    // Update is called once per frame
    void Update()
    {
        if (_isDragActive && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }
        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);
        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }
    void InitDrag()
    {
         InitialPos = _lastDragged.transform.position ;
        _lastDragged.LastPosition = _lastDragged.transform.position;
        UpdateDragStatus(true);
       // _isDragActive = true;
    }
    void Drag()
    {
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
       
    }
    void Drop()
    {
        _lastDragged.transform.position = InitialPos;
        UpdateDragStatus(false);
       // _isDragActive = false;
    }

    void UpdateDragStatus(bool IsDragging)
    {
        _isDragActive = _lastDragged.IsDragging = IsDragging;
    }
}
