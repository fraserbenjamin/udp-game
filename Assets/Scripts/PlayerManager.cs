using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public string id;

    public void Initialize(string _id)
    {
        id = _id;
    }
}
