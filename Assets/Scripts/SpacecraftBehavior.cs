using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftBehavior : MonoBehaviour
{
    public float gamefieldBoarderWidth, gamefieldBoarderHeight;

    public const float sideMarginParam = 5;
    public const float heightsMarginParam = 3;

    public const float maxCurrentHelathParametr = 100f;
    public float currentHealtParametr = maxCurrentHelathParametr;
    
    private float _xHorizontalAxis, _yVeticalAxis;
    public float horizontalSpeed = 30;
    public float verticalSpeed = 10;
    private float backSpeedMultiplayer = 3;
    public float rotationMultiplaier = 20;
    
    // Start is called before the first frame update
    void Awake()
    {
        gamefieldBoarderHeight = Camera.main.orthographicSize - heightsMarginParam;
        gamefieldBoarderWidth = (Camera.main.orthographicSize - sideMarginParam) * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        this.MovePlayer();
        this.RotateModel();
    }

    private void MovePlayer()
    {
        this._yVeticalAxis = Input.GetAxis("Vertical") > 0 ?
                             Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime : 
                             Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime * backSpeedMultiplayer;
        this._xHorizontalAxis = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x + _xHorizontalAxis, -gamefieldBoarderWidth, gamefieldBoarderWidth),
                                              Mathf.Clamp(this.transform.position.y + _yVeticalAxis, -gamefieldBoarderHeight, gamefieldBoarderHeight),
                                              this.transform.position.z);
    }

    private void RotateModel()
    {
        // float zCord = this.spacecraftModel.rotation.z;
        // this.spacecraftModel.rotation = Quaternion.Euler(this._xHorizontalAxis * rotationMultiplaier,
        //     -this._xHorizontalAxis * rotationMultiplaier, 0);
        // this.spacecraftModel.rotation.z = zCord;
    }

    public void PlayDeath()
    {
        //TODO: make player gp low and die in a fricking fire
        // Rigidbody spacecraftRigidbody = this.AddComponent(typeof(Rigidbody)) as Rigidbody;
        // spacecraftRigidbody.AddForce();
    }

    public void GetDamege(float damage)
    {
        currentHealtParametr -= damage;
    }
    
    void onTriggerEnter(Collider collider){
        Transform collidedObjectTransform = collider.gameObject.transform.root;
        if (collidedObjectTransform.gameObject.tag == "EnemySpacecraft")
        {
            
        }    
    }
}
 