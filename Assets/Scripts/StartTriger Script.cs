using DG.Tweening;

using UnityEngine;
using UnityEngine.AI;
using FMODUnity;

public class StartTrigerScript : MonoBehaviour
{
    [SerializeField] GameObject[] Door;
    [SerializeField] GameObject[] StartEnemies;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        
        {
            
            foreach (GameObject go in Door)
            {
                go.transform.DORotate(new Vector3(0, 0, 0), 1);
                AudioManager.instance.PlayOneShot(AudioManager.instance.WorldWoodDoor, this.transform.position);
            }
            foreach (GameObject go in StartEnemies)
            {
                go.GetComponent<NavMeshAgent>().enabled = true;
                go.GetComponent<EnemyNavigationScript>().enabled = true;
                go.GetComponent<EnemyMelee>().enabled = true;
                AudioManager.instance.PlayOneShot(AudioManager.instance.PlayerVoiceOver, this.transform.position);
            }
            gameObject.SetActive(false);
        }
    }
}
