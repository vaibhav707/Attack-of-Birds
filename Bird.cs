using UnityEngine.SceneManagement;
using UnityEngine;

public class Bird : MonoBehaviour
{	
	private Vector3 _initialPosition;
	private bool _birdWasLaunched;
	private float _timeSittingAround;
	
	[SerializeField] private float _launchPower = 500;

	private void Awake()
	{
		_initialPosition = transform.position;
	}

	private void Update()
	{	GetComponent<LineRenderer>().SetPosition(0, _initialPosition);
		GetComponent<LineRenderer>().SetPosition(1, transform.position);
		if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
		{
			_timeSittingAround += Time.deltaTime;
		}


		if (transform.position.y > 10)
		{	
			string currentSceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(currentSceneName);
		}
		if (transform.position.y < -10)
		{	
			string currentSceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(currentSceneName);
		}
		if (transform.position.x > 12)
		{	
			string currentSceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(currentSceneName);
		}
		if(transform.position.x < -12)
		{	
			string currentSceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(currentSceneName);
		}
		if(_timeSittingAround > 2)
		{	
			string currentSceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(currentSceneName);
		}
	}

	private void OnMouseDown()
	{
		GetComponent<SpriteRenderer>().color = Color.red;
		GetComponent<LineRenderer>().enabled = true;
	}

	private void OnMouseUp()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
		Vector2 directionToinitialPosition = _initialPosition - transform.position;
		GetComponent<Rigidbody2D>().AddForce(directionToinitialPosition * _launchPower);
		GetComponent<Rigidbody2D>().gravityScale = 1;
		_birdWasLaunched = true;
		GetComponent<LineRenderer>().enabled = false;
	}
	private void OnMouseDrag()
	{
		Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(newPosition.x , newPosition.y);
	}
}
