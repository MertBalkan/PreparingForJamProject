using PreparingForJamProject.Concretes.Enums;
using PreparingForJamProject.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PreparingForJamProject.Concretes.Controllers
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DoorController : MonoBehaviour
    {
        [SerializeField] private SceneDoorEnum sceneDoorEnum;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {

                if (this.sceneDoorEnum == SceneDoorEnum.HomeSceneDoor)
                {
                    GameManager.Instance.LoadGameScene(2);
                }
                if (this.sceneDoorEnum == SceneDoorEnum.MenuSceneDoor)
                {
                    GameManager.Instance.LoadGameScene(1);
                }
            }
        }
    }
}