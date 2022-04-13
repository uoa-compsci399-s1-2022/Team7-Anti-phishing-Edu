using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EmailDataStructure
{
    #region Data Part

    public bool isChecked; // Whether this mail has been checked. 

    // Sender Information
    public string senderName; 
    public string senderEmailAddress;

    // Email Information
    public string emailTitle;
    public string emailContent;

    #endregion

    #region Function Part 
    // Construct Email Data Structure. 
    public EmailDataStructure(bool isChecked, string senderName, string senderEmailAddress, string emailTitle, string emailContent)
    {
        this.isChecked = isChecked;

        this.senderName = senderName;
        this.senderEmailAddress = senderEmailAddress;
       
        this.emailTitle = emailTitle;
        this.emailContent = emailContent;
    }
    #endregion

}
