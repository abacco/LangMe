using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AquireNationality : MonoBehaviour
{
    [SerializeField] GameObject selectedNationalityPanel; 
    [SerializeField] GameObject whereIsMyNationalityPanel; // whereIsMyNationalityPanel
    [SerializeField] GameObject noNationalityFoundPanel; // noNationalityFoundPanel
    
    [SerializeField] TMP_Text nationalitySelectedText;
    [SerializeField] TMP_InputField nationalityInputField;


    public void AquireNationalityOnClick(string selectedNationality) // used in scene2
    {
        if (!string.IsNullOrEmpty(selectedNationality))
        {
            selectedNationalityPanel.SetActive(true);
            GameManager.Instance.userNationality = selectedNationality;
            nationalitySelectedText.text = selectedNationality;
            GameManager.Instance.SaveData();
            //GameManager.Instance.GameManagerDebugLogData();
        }
    }

    public void ReturnToNationalitySelection()
    {
        selectedNationalityPanel.SetActive(false);
    }

    public void CannotFindMyNationality()
    {
        // say sorry using a panel saying it is a work in progress!
        // If you do not see your nationality do not worry! It is still a work in progress feature
        // please leave your nationality on play/ios store comment section
        // you can set your nationality via text ATM, thank you!
        // and aquire nationality via user input
        whereIsMyNationalityPanel.SetActive(true);
    }

    public void SubmitNationality()
    {
        // check se la nazionalità esiste o no -> https://www.countries-ofthe-world.com/all-countries.html#:~:text=Today%2C%20there%20are%20197%20countries%20in%20the%20world.,list%20of%20all%20countries%20from%20A%20to%20Z.
        if (GetAllCountries().Contains(nationalityInputField.text))
        {
            AquireNationalityOnClick(nationalityInputField.text); // fa paur
        }
        else {
            noNationalityFoundPanel.SetActive(true);
            Debug.Log("It does not seem to be a nationality");
        }
    }

    public void GotitBtn()
    {
        noNationalityFoundPanel.SetActive(false);
    }

    /*
        ATTENTION!! OLD TEXT - put it into some sort of credits toward who downloaded the app!

            Hi! Before Continuing please read this! 
            Thank You very much for choosing LangMe!
            You do not know how glad I am!

            I'am assuming you are an English Native!
            If you wanna see your native Language on the app

            Please leave a comment on the store!

            Simply because I am a solo-dev

            Thank you very much!

     */

    public static List<string> GetAllCountries()
    {
        return new List<string>
        {
            "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria",
            "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan",
            "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cabo Verde", "Cambodia",
            "Cameroon", "Canada", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "Congo (Congo-Brazzaville)", "Costa Rica",
            "Croatia", "Cuba", "Cyprus", "Czechia", "Democratic Republic of the Congo", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "Ecuador",
            "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini", "Ethiopia", "Fiji", "Finland", "France",
            "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau",
            "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland",
            "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Kuwait", "Kyrgyzstan",
            "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar",
            "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia",
            "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Myanmar (Burma)", "Namibia", "Nauru", "Nepal",
            "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "North Korea", "North Macedonia", "Norway", "Oman", "Pakistan",
            "Palau", "Palestine", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar",
            "Romania", "Russia", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia",
            "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa",
            "South Korea", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Sweden", "Switzerland", "Syria", "Tajikistan",
            "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu",
            "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela",
            "Vietnam", "Yemen", "Zambia", "Zimbabwe"
        };
    }
}
