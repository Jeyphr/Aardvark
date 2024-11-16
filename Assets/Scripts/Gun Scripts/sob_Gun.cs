using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName ="Gun", menuName ="Guns/Gun", order =0)]
public class sob_Gun : ScriptableObject
{
    [Header("Object References")]
    [SerializeField] public GameObject modelPrefab;
    [SerializeField] public sob_ShootConfig shootConfig;
    [SerializeField] public sob_TrailConfig trailConfig;

    [Header("Statistics")]
    [SerializeField] public enm_GunType gunType;
    [SerializeField] public string gunName;
    [SerializeField] public Vector3 position;
    [SerializeField] public Vector3 rotation;

    [Header("Ammo")]
    [SerializeField] public float damage = 10f;
    [SerializeField] public int ammo = 100;
    [SerializeField] public int maxammo = 100;

    //Private Vars
    private MonoBehaviour _activeMono;
    private GameObject _model;
    private float _lastShootTime;
    private float _initClickTime;
    private float _stopShootingTime;
    private bool _lastFrameWantedToShoot;
    private bool _rechambering;
    private ParticleSystem _shootSystem;
    private ObjectPool <TrailRenderer> _trailPool;

    

    //FUNCTIONS
    public void Spawn(Transform Parent, MonoBehaviour ActiveMonoBehavior)
    {
        //reset statistics
        this._activeMono = ActiveMonoBehavior;
        _lastShootTime = 0;
        _trailPool = new ObjectPool<TrailRenderer>(CreateTrail);

        //UI BULLSHIT


        //add gunmodel
        _model = Instantiate(modelPrefab);
        _model.transform.SetParent(Parent, false);
        _model.transform.localPosition = position;
        _model.transform.localRotation = Quaternion.Euler(rotation);

        //Setup the shoot system
        _shootSystem = _model.GetComponentInChildren<ParticleSystem>();

    }

    private TrailRenderer CreateTrail()
    {
        GameObject instance = new GameObject("Bullet Trail");
        TrailRenderer trail = instance.AddComponent<TrailRenderer>();

        //statistics
        trail.colorGradient = trailConfig.color;
        trail.material = trailConfig.material;
        trail.widthCurve = trailConfig.widthCurve;
        trail.time = trailConfig.lifespan;
        trail.minVertexDistance = trailConfig.minVertexDist;
        trail.emitting = false;
        trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        return trail;
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTime - shootConfig.fireRate > Time.deltaTime)
        {
            float lastDuration = Mathf.Clamp(
                0,
                (_stopShootingTime - _initClickTime),
                (shootConfig.maxSpreadTime));

            float lerpTime = (shootConfig.recoilRecoveryTime - (Time.time - _stopShootingTime) / shootConfig.recoilRecoveryTime);
            _initClickTime = Time.time - Mathf.Lerp(0, lastDuration, Mathf.Clamp01(lerpTime));
        }
        if((Time.time > shootConfig.fireRate + _lastShootTime))
        {
            _lastShootTime = Time.time;
            _shootSystem.Play();
            ammo--;

            //bloom
            Vector3 spreadAmount = shootConfig.getSpread(Time.time - _initClickTime);
            _model.transform.forward += _model.transform.TransformDirection(spreadAmount);

            Vector3 shootDirection = _model.transform.parent.forward;

            //where the magic happens
            if(Physics.Raycast(
                _shootSystem.transform.position,shootDirection,
                out RaycastHit hit, float.MaxValue,shootConfig.hitMask))
            {
                _activeMono.StartCoroutine(
                    PlayTrail(
                        _shootSystem.transform.position,
                        hit.point,
                        hit
                    )
                );
            }
            else
            {
                _activeMono.StartCoroutine(
                    PlayTrail(
                        _shootSystem.transform.position,
                        _shootSystem.transform.position + (shootDirection * trailConfig.missDist),
                        new RaycastHit()
                    )
                );
            }
        }
    }
    public void Tick(bool wantsToShoot)
    {
        _model.transform.localRotation = Quaternion.Lerp(
            _model.transform.localRotation,
            Quaternion.Euler(rotation),
            Time.deltaTime * shootConfig.recoilRecoveryTime
            );
        if (wantsToShoot)
        {
            if (ammo > 0)
            {
                _lastFrameWantedToShoot = true;
                Shoot();
            }
            
        }
        else if (!wantsToShoot && _lastFrameWantedToShoot)
        {
            //_lastShootTime += Time.time;
            _lastFrameWantedToShoot = false;
        }
    }
    private IEnumerator PlayTrail(Vector3 start, Vector3 end, RaycastHit hit)
    {
        //Activates the trail and pulls it from the pool
        TrailRenderer instance = _trailPool.Get();
        instance.gameObject.SetActive(true);
        instance.transform.position = start;
        yield return null;                      //You must wait a single frame because Unity is dumb
        instance.emitting = true;

        //Does all the fancy shit
        float dist = Vector3.Distance( start, end );
        float rDist = dist;                             //remaining distance
        while(rDist > 0){
            instance.transform.position = Vector3.Lerp(end,start,Mathf.Clamp01(1 - rDist));
            rDist -= trailConfig.simSpeed * Time.deltaTime;
            yield return null;
        }
        instance.transform.position = end;

        // THIS IS WHERE THE MAGIC HAPPENS!
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out gs_IDamagable damagable))
            {
                damagable.takeDamage(damage);
            }
        }

        yield return new WaitForSeconds(trailConfig.lifespan);
        yield return null;

        //De-Activates the trail.
        instance.emitting = false;
        instance.gameObject.SetActive(false);
        _trailPool.Release(instance);
    }
}
