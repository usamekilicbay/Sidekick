using UnityEngine;

public class PoolManagerBase : EventProvider
{
	[Range(1, 60)]
	[SerializeField] private int itemCount;

	[SerializeField] private GameObject itemPrefab;
	[SerializeField] private MeshRenderer wayMeshRenderer;
	public static Bounds S_itemBounds;

	[SerializeField] private GameObject[] items;

    #region UNITY METHOD

    protected override void Awake()
	{
		base.Awake();
	}

	private void Start()
	{
		Init();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}

    #endregion

    #region EVEMT

    protected override void Subscribe()
	{
		EventManager.Instance.Restart += Init;
		EventManager.Instance.RespawnItem += Respawn;
	}

	protected override void Unsubscribe()
	{
		EventManager.Instance.Restart -= Init;
		EventManager.Instance.RespawnItem -= Respawn;
	}

	#endregion

	private void Init()
	{
		if (items != null)
		{
			for (int i = items.Length - 1; i >= 0; i--)
				Destroy(items[i]);
		}

		items = new GameObject[itemCount];

		S_itemBounds = wayMeshRenderer.bounds;

		SpawnPlatforms();
	}

	private void SpawnPlatforms()
	{
		for (int i = 0; i < itemCount; i++)
		{
			GameObject newPlatform = Instantiate(itemPrefab, transform);

			newPlatform.transform.position = new Vector3
			{
				x = 0,
				y = 0,
				z = S_itemBounds.size.z * i
			};

			items[i] = newPlatform;
		}
	}

	private void Respawn(Transform itemTransform)
	{
		itemTransform.gameObject.SetActive(false);

		// Set respawn position here

		itemTransform.gameObject.SetActive(true);
	}
}
