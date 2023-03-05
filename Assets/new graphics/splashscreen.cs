using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashscreen : MonoBehaviour
{
    public string nextLevelName = "Demo";
    public float waitTime = 3f;
    // Start is called before the first frame update
    private void Awake ()
    {
        Advertisements.Instance.Initialize();
    }
    private IEnumerator Start() {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(nextLevelName);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
