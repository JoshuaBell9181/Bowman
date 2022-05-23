using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CameraManager : MonoBehaviour
{

    [SerializeField] Referee referee;
    CinemachineVirtualCamera _camera;
    Arrow _arrow;
    

    void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update(){
        if(_arrow == null || _arrow.GetHasHit()){
            _camera.Follow = referee.GetPlayersTurn().transform;

            if(referee.GetPlayersTurn().playerName == "Computer"){
                referee.GetPlayersTurn().bow.SetIsComputerShooting(true);
            }
        }
    }

    public void FollowArrow(Arrow arrow){
        _arrow = arrow;
        _camera.Follow = _arrow.transform;
    }
}
