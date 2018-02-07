using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class DeleteMesh : MonoBehaviour
{
    public MeshRenderer mesh;
    public float timer;
    public GameManager gm;

	void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mesh.enabled = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Hero"))
        {
            StartCoroutine(ChangeScene(other));
        }
    }

    IEnumerator ChangeScene(Collider other)
    {
        other.gameObject.GetComponent<NavMeshAgent>().speed = 0;
        other.gameObject.GetComponent<HeroManager>().anim.SetTrigger("Victory");
        yield return new WaitForSeconds(timer);
        gm.SaveGameStatus();
        SceneManager.LoadScene("GM_SelectionMenu");

    }
}
