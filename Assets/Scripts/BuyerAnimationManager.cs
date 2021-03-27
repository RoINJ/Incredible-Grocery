using UnityEngine;

public class BuyerAnimationManager : MonoBehaviour
{
    private Vector3 _finalPostion;

    private float _animationStartTime;

    private Vector3 _moveVector;
    private Vector3 _spawnPosition;
    private Vector3 _startPosition;

    public bool IsAnimationGoing { get; private set; }
    public bool IsLeaving { get; private set; }

    public void LeaveBuyer()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        
        _startPosition = transform.position;
        _finalPostion = _spawnPosition;
        IsLeaving = true;
        
        StartAnimation();
    }

    private void Start()
    {
        _startPosition = transform.position;
        _finalPostion = GameObject.FindWithTag("BuyerFinalPosition").transform.position;

        _spawnPosition = transform.position;
        
        StartAnimation();
    }

    private void Update()
    {
        if (Time.time >= _animationStartTime + Constants.BUYER_ANIMATION_DURATION)
        {
            if (IsLeaving)
            {
                Destroy(gameObject);
            }
            
            IsAnimationGoing = false;
        }
        else
        {
            transform.position = _startPosition +
                                 _moveVector * (Time.time - _animationStartTime) / Constants.BUYER_ANIMATION_DURATION;

            var deltaY = Mathf.Abs(Mathf.Sin((Time.time - _animationStartTime) * Mathf.PI * 5 / Constants.BUYER_ANIMATION_DURATION));
            transform.position += new Vector3(0, deltaY, 0);
        }
    }

    private void StartAnimation()
    {
        IsAnimationGoing = true;
        _animationStartTime = Time.time;
        _moveVector = _finalPostion - _startPosition;
    }
}