using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initilaPosition;
    private bool _birdWasLuncheded;
    private float _timeSettingAround;

    [SerializeField] private float _lunchPower = 500;
    
    private void Awake()
    {
        _initilaPosition = transform.position;
    }

    private void Update()
    {
        if(_birdWasLuncheded && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSettingAround += Time.deltaTime;
        }
        if (transform.position.y >  10 ||
            transform.position.y < -10 ||
            transform.position.x >  10 ||
            transform.position.x < -10 ||
            _timeSettingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directiontoInitialPosition = _initilaPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directiontoInitialPosition * _lunchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLuncheded = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
