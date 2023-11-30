using UnityEngine;

public class HelpPageManager : MonoBehaviour
{
    public GameObject[] helpPages;
    private int currentPageIndex = 0;

    void Start()
    {
        ShowCurrentPage();
    }

    void ShowCurrentPage()
    {
        // Hide all pages
        foreach (GameObject page in helpPages)
        {
            page.SetActive(false);
        }

        // Show the current page
        helpPages[currentPageIndex].SetActive(true);
    }

    public void NextPage()
    {
        if (currentPageIndex < helpPages.Length - 1)
        {
            currentPageIndex++;
            ShowCurrentPage();
        }
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            ShowCurrentPage();
        }
    }
}
