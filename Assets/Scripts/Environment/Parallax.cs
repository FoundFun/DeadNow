using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    public Camera Camera;
    public float Speed;
    public Vector3 Position;

    private bool _isStop;
    
    private RawImage _image;
    private float _imagePositionX;

    private void Start()
    {
        _image = GetComponent<RawImage>();
        _imagePositionX = _image.uvRect.x;

        StartCoroutine(MoveParallax());
    }

    private IEnumerator MoveParallax()
    {
        while (!_isStop)
        {
            Position = Camera.transform.position;

            yield return null;
        
            if(Camera.transform.position.x > Position.x)
                _imagePositionX += Speed * Time.deltaTime;
            if(Camera.transform.position.x < Position.x)
                _imagePositionX -= Speed * Time.deltaTime;
        
            if (_imagePositionX >= 1) 
                _imagePositionX = 0;

            _image.uvRect = new Rect(_imagePositionX, _image.uvRect.y, _image.uvRect.width, _image.uvRect.height);
        }
    }
}
