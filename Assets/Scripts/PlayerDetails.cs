using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetails : MonoBehaviour
{
    public Text playerDetails;

    // Update is called once per frame
    void Update()
    {
        playerDetails.text = ConnectionManager.instance.id;
    }
}
