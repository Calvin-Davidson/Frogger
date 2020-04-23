using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public PlayerData playerData = new PlayerData();
    public Camera camera;

    [SerializeField] private GameObject MovementCheckerFront;
    [SerializeField] private GameObject MovementCheckerBack;
    [SerializeField] private GameObject MovementCheckerRight;
    [SerializeField] private GameObject MovementCheckerLeft;

    [SerializeField] private GameObject PlayerModel;
    public bool canmove = true;

    private void Start()
    {
        playerData = this.gameObject.GetComponent<PlayerData>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (MovementCheckerFront.GetComponent<AllowMovementChecker>().getCanMove())
            {
                this.transform.rotation = new Quaternion(0, 0, 0, 0);
                move(new Vector3(0, 0, speed));
                playerData.addScore(1);
                //camera.transform.position = camera.transform.position + new Vector3(0, 0, speed);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (this.transform.position.z <= -10)
            {
                return;
            }
            if (MovementCheckerBack.GetComponent<AllowMovementChecker>().getCanMove())
            {
                this.transform.rotation = new Quaternion(0, -180, 0, 0);
                move(new Vector3(0, 0, -speed));
                // if (!(camera.transform.position.z <= -35))
                // {
                //     camera.transform.position = camera.transform.position + new Vector3(0, 0, -speed);
                // }

                playerData.removeScore(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (this.transform.position.x <= -10)
            {
                return;
            }
            this.transform.rotation = new Quaternion(0, -90, 0, 0);
            if (MovementCheckerLeft.GetComponent<AllowMovementChecker>().getCanMove())
            {
                move(new Vector3(-speed, 0, 0));
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (this.transform.position.x >= 10)
            {
                return;
            }

            if (MovementCheckerRight.GetComponent<AllowMovementChecker>().getCanMove())
            {
                this.transform.rotation = new Quaternion(0, , 0, 0);
                move(new Vector3(speed, 0, 0));
            }
        }
    }

    public void move(Vector3 dir)
    {
        if (canmove == true)
        {
            transform.position = transform.position + dir;
            canmove = false;
            StartCoroutine(movetimer());
        }
    }

    public IEnumerator movetimer()
    {
        yield return new WaitForSeconds(0.1f);
        canmove = true;
    }
}