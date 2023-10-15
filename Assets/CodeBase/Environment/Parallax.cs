using System.Collections;
using System.Collections.Generic;
using CodeBase.Hero;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    public float Speed;

    private RawImage _image;
    private float _imagePositionX;

    private void Start()
    {
        _image = GetComponent<RawImage>();
        _imagePositionX = _image.uvRect.x;
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            _imagePositionX += Speed * Input.GetAxis("Horizontal") * Time.deltaTime;

            if (_imagePositionX >= 1)
            {
                _imagePositionX = 0;
            }

            _image.uvRect = new Rect(_imagePositionX, _image.uvRect.y, _image.uvRect.width, _image.uvRect.height);
        }
    }
}
