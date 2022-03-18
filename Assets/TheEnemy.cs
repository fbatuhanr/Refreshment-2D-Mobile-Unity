using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemy : MonoBehaviour
{
    private Transform ball;

    private Transform[] wayPoints = new Transform[4];
    private Vector2[] cornersPositions = new Vector2[4];


    private int wayPointSteps = 0;
    private float randomAcceleration = 1f;

    public GameObject enemyBullet;

    private void Start()
    {

        ball = GameObject.Find("/TheBall").transform;

        Transform cornersParent = GameObject.Find("/CornersParent").transform;
        for (int i = 0; i <= cornersParent.childCount-1; i++){
            wayPoints[i] = cornersParent.GetChild(i);
        }
        
        // Debug.Log(wayPoints[0].name);
        // Debug.Log(wayPoints[1].name);
        // Debug.Log(wayPoints[2].name);
        // Debug.Log(wayPoints[3].name);


        cornersPositions[0] = new Vector2(wayPoints[3].position.x, wayPoints[0].position.y); // top-left corner
        cornersPositions[1] = new Vector2(wayPoints[1].position.x, wayPoints[0].position.y); // top-right corner
        cornersPositions[2] = new Vector2(wayPoints[1].position.x, wayPoints[2].position.y); // bottom-right corner
        cornersPositions[3] = new Vector2(wayPoints[3].position.x, wayPoints[2].position.y); // bottom-left corner

        cornersPositions[0] = setCornersPositionsOffset(cornersPositions[0], 1f);
        cornersPositions[1] = setCornersPositionsOffset(cornersPositions[1], 1f);
        cornersPositions[2] = setCornersPositionsOffset(cornersPositions[2], 1f);
        cornersPositions[3] = setCornersPositionsOffset(cornersPositions[3], 1f);


        StartCoroutine(EnemyFire());
    }

    private Vector2 setCornersPositionsOffset(Vector2 cornerPosition, float offsetAmount){
        
        float offsetX = cornerPosition.x > 0 ? cornerPosition.x - offsetAmount : cornerPosition.x + offsetAmount;
        float offsetY = cornerPosition.y > 0 ? cornerPosition.y - offsetAmount : cornerPosition.y + offsetAmount;
        return new Vector2(offsetX, offsetY);
    }

    // Update is called once per frame
    // void Update(){}


    private void FixedUpdate() {

       /*
        follow the ball
       transform.position = Vector2.Lerp(transform.position, ball.transform.position, Time.deltaTime);
       */ 

        EnemyMovement();

    }

    private void EnemyMovement(){

        // Debug.Log(Vector2.Distance(transform.position, cornersPositions[wayPointSteps]));

        if( Vector2.Distance(transform.position, cornersPositions[wayPointSteps]) <= 0 ){

            int randomCorner = Random.Range(0, 2);
            wayPointSteps = (wayPointSteps == 0 || wayPointSteps == 2) ? (randomCorner == 0 ? 1 : 3) : (randomCorner == 0 ? 0 : 2); // enemy goes to random corner
            // wayPointSteps = wayPointSteps < 3 ? wayPointSteps+1 : 0; // enemy goes to next corner

            randomAcceleration = Random.Range(2f, 5f);
        }
        transform.position = 
        Vector2.MoveTowards(transform.position, cornersPositions[wayPointSteps], Time.deltaTime*randomAcceleration);
    }

    private IEnumerator EnemyFire()
    {
        while (ball != null)
        {
            float randomDelayTime = Random.Range(0.5f, 2.5f);
            yield return new WaitForSeconds(randomDelayTime);
            if(ball != null){

                GameObject newBullet = Instantiate (enemyBullet, transform.position, Quaternion.Euler(0,0,0)); // bullet creation
                newBullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, ball.position - newBullet.transform.position); // set bullet rotation by ball

                Vector2 shootDir = ball.position - transform.position;
                newBullet.GetComponent<Rigidbody2D>().AddForce(shootDir*1.25f, ForceMode2D.Impulse); // shoot to ball

                ball.GetComponent<TheBall>().playerPoint++;
            } 
        }
    }

}
