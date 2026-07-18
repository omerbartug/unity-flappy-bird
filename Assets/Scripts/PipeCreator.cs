using UnityEngine;

public class PipeCreator : MonoBehaviour
{

    public GameObject upperPipePrefab;
    public GameObject lowerPipePrefab;
    public GameObject emptyPrefab;

    public GameObject upperPipe1;
    public GameObject lowerPipe1;
    public GameObject empty1;

    public GameObject upperPipe2;
    public GameObject lowerPipe2;
    public GameObject empty2;

    public float minY = 3.0f;
    public float maxY = 9.0f;

    public float newPipeX = -0f;
 
    void Start()
    {
        createObject();
    }


    void Update()
    {
        handleActivate();
    }

   

    void createObject(){
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPointUpper = new Vector3(11.0f, -randomY+12, 0f);
        Vector3 spawnPointLower = new Vector3(11.0f, -randomY, 0f);
    

        upperPipe1 =  Instantiate(upperPipePrefab, spawnPointUpper, Quaternion.identity);
        upperPipe2 =  Instantiate(upperPipePrefab, spawnPointUpper, Quaternion.identity);
        lowerPipe1 =  Instantiate(lowerPipePrefab, spawnPointLower, Quaternion.identity);
        lowerPipe2 =  Instantiate(lowerPipePrefab, spawnPointLower, Quaternion.identity);
        empty1   =  Instantiate(emptyPrefab, spawnPointEmpty, Quaternion.identity);
        empty2   =  Instantiate(emptyPrefab, spawnPointEmpty, Quaternion.identity);

       
        upperPipe2.SetActive(false);
        lowerPipe2.SetActive(false);
        empty2.SetActive(false);
    }

    void handleActivate(){

       pipe1ActivateControls();
       pipe2ActivateControls();
       empty1ActivateControls();
       empty2ActivateControls();
    
    }

    //kontrol icin sadece ustboruyu kullandim cunku pairi olan alt boruyla ayni hareket ediyorlar
    void pipe1ActivateControls(){
        
        float randomY = Random.Range(minY, maxY);
        if(!upperPipe2.activeInHierarchy && upperPipe1 != null &&  upperPipe1.transform.position.x <= newPipeX){ 
            
            //ust boru
            Vector3 SpawnPoint1 = new Vector3(11.0f, -randomY+12, 0f);
            upperPipe2.transform.position = SpawnPoint1;
            upperPipe2.SetActive(true);

            //alt boru
            Vector3 SpawnPoint2 = new Vector3(11.0f, -randomY, 0f);
            lowerPipe2.transform.position = SpawnPoint2;
            lowerPipe2.SetActive(true);
        }


        if(upperPipe1 != null && upperPipe1.transform.position.x <= -12){
            upperPipe1.SetActive(false);
            lowerPipe1.SetActive(false);
        }

    }

    void pipe2ActivateControls(){
        
        if(!upperPipe1.activeInHierarchy && upperPipe2 != null &&  upperPipe2.transform.position.x <= newPipeX){ 

            float randomY = Random.Range(minY, maxY);

            Vector3 SpawnPoint1 = new Vector3(11.0f, -randomY+12, 0f);
            upperPipe1.transform.position = SpawnPoint1;
            upperPipe1.SetActive(true);

            Vector3 SpawnPoint2 = new Vector3(11.0f, -randomY, 0f);
            lowerPipe1.transform.position = SpawnPoint2;
            lowerPipe1.SetActive(true);
        }


        if(upperPipe2 != null && upperPipe2.transform.position.x <= -12){
            upperPipe2.SetActive(false);
            lowerPipe2.SetActive(false);
        }

    }

    Vector3 spawnPointEmpty   = new Vector3(11.0f, 0f, 0f);
    void empty1ActivateControls(){
        
        if (!empty2.activeInHierarchy && empty1 != null && empty1.transform.position.x <= newPipeX){

            empty2.transform.position = spawnPointEmpty;
            empty2.SetActive(true);
        } 

        if(empty1 != null && empty1.transform.position.x <= -12){
            empty1.SetActive(false);
        }
    
    }

    void empty2ActivateControls(){
        
        if (!empty1.activeInHierarchy && empty2 != null && empty2.transform.position.x <= newPipeX){

            empty1.transform.position = spawnPointEmpty;
            empty1.SetActive(true);
        } 

        if(empty2 != null && empty2.transform.position.x <= -12){
            empty2.SetActive(false);
        }
    
    }
}


