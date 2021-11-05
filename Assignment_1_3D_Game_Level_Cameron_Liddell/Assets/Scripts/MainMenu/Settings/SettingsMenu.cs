using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    Resolution[] resolutions;
    public Dropdown resDropDown;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions; // Get all resolutions and store as array

        resDropDown.ClearOptions(); // Clear the placeholders from the dropdown

        List<string> options = new List<string>(); // Create a new list

        int currentResIndex = 0; // Current index for resolutions

        for(int i = 0; i < resolutions.Length; i++) // Loop for as many times as there are resolutions
        {
            string option = resolutions[i].width + "x" + resolutions[i].height; // Create string with resolution options
            options.Add(option); // Add resolutions to the "options" StringList

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) // Check for current screen resolutions against selected
            {
                currentResIndex = i; // Change index 
            }
        }

        resDropDown.AddOptions(options); // Add to drop down
        resDropDown.value = currentResIndex; // Ensure correct index
        resDropDown.RefreshShownValue(); // Refresh the shown value on the drop down
    }

    void Brightness()
    {
        // Broken
    }

    public void SetFullScreen(bool fs)
    {
        Screen.fullScreen = fs; // Sets fullscreen using the built in events
    }

    // Update is called once per frame
    void Update()
    {
     // Nothing    
    }

    public void SetResolution(int resIndex) // Sets the resolution for the game
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
