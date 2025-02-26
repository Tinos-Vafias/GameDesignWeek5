using UnityEngine;
using UnityEngine.SceneManagement;

public class Hurtboxes: MonoBehaviour
{
    public static Hurtboxes Instance { get; private set; }

    private GameObject rightHurtbox;
    private GameObject leftHurtbox;
    private GameObject downHurtbox;

    private int rangeLevel = 0;   // ✅ Tracks the shovel range upgrade level
    private int rangeBasePrice = 10;  // ✅ Base price for upgrading range

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;  // ✅ Listen for scene changes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FindHurtboxes();  // ✅ Find hurtboxes dynamically
        DisableHurtboxes();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindHurtboxes();  // ✅ Find hurtboxes again in new scene
        ApplyHurtboxUpgrades();  // ✅ Reapply upgrade
    }

    private void FindHurtboxes()
    {
        rightHurtbox = GameObject.Find("RightHurtbox");
        leftHurtbox = GameObject.Find("LeftHurtbox");
        downHurtbox = GameObject.Find("DownHurtbox");

        if (rightHurtbox == null || leftHurtbox == null || downHurtbox == null)
        {
            Debug.LogWarning("Some hurtboxes could not be found! Make sure they exist in the scene.");
        }
    }

    private void DisableHurtboxes()
    {
        if (rightHurtbox != null) rightHurtbox.SetActive(false);
        if (leftHurtbox != null) leftHurtbox.SetActive(false);
        if (downHurtbox != null) downHurtbox.SetActive(false);
    }

    private void Update()
    {
        if (rightHurtbox != null && leftHurtbox != null && downHurtbox != null)
        {
            rightHurtbox.SetActive(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space));
            leftHurtbox.SetActive(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space));
            downHurtbox.SetActive(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.Space));
        }
    }

    public void UpgradeRange()
    {
        rangeLevel++;  // ✅ Increment level
        ApplyHurtboxUpgrades();
        Debug.Log("Shovel range upgraded! New Level: " + rangeLevel);
    }

    private void ApplyHurtboxUpgrades()
    {
        if (rightHurtbox == null || leftHurtbox == null || downHurtbox == null)
        {
            FindHurtboxes();  // ✅ Ensure hurtboxes are found before applying upgrades
        }

        float positionIncrease = 0.1f * rangeLevel;
        float scaleIncrease = 0.25f * rangeLevel;

        if (rightHurtbox != null)
        {
            rightHurtbox.transform.position += new Vector3(positionIncrease, positionIncrease, 0);
            rightHurtbox.transform.localScale += new Vector3(scaleIncrease, scaleIncrease, 0);
        }

        if (leftHurtbox != null)
        {
            leftHurtbox.transform.position -= new Vector3(positionIncrease, -positionIncrease, 0);
            leftHurtbox.transform.localScale += new Vector3(scaleIncrease, scaleIncrease, 0);
        }

        if (downHurtbox != null)
        {
            downHurtbox.transform.position -= new Vector3(0, positionIncrease, 0);
            downHurtbox.transform.localScale += new Vector3(scaleIncrease, scaleIncrease, 0);
        }
    }

    public int GetRangeLevel()
    {
        return rangeLevel;
    }

    public int GetRangePrice()
    {
        return rangeBasePrice * (int)Mathf.Pow(10, rangeLevel);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}