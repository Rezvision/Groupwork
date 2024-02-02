using UnityEngine;

public class pointInTime : MonoBehaviour
{
    public Vector3 position;
    //public Vector3 velocity;
    public Quaternion rotation;

    public pointInTime (Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
        //velocity = _velocity;

        //this.position = position;
        //this.velocity = velocity;
        //this.rotation = rotation;
    }
}
