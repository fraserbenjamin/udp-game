using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    [System.Serializable]
    public class Position
    {
        public float x;
        public float y;
        public float z;
    }    
    
    [System.Serializable]
    public class Rotation
    {
        public float x;
        public float y;
        public float z;
        public float w;
    }

    public string id;
    public Rotation rotation;
    public Position position;

    public PlayerData(string _id, Vector3 _position, Quaternion _rotation)
    {
        id = _id;
        position = new Position();
        position.x = _position.x;
        position.y = _position.y;
        position.z = _position.z;
        
        rotation = new Rotation();
        rotation.x = _rotation.x;
        rotation.y = _rotation.y;
        rotation.z = _rotation.z;
        rotation.w = _rotation.w;
    }

    public string getJson()
    {
        return JsonUtility.ToJson(this);
    }

    public static PlayerData getPlayerData(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);
    }

    public Vector3 getPosition()
    {
        return new Vector3(position.x, position.y, position.z);
    }    
    
    public Quaternion getRotation()
    {
        return new Quaternion(rotation.x, rotation.y, rotation.z, rotation.w);
    }
}