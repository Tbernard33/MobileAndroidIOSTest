using Firebase;
using Firebase.Analytics;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;

public class FireBaseInit : MonoBehaviour
{
    public Text nameText;
    public string nameInput;
    public Text numberText;
    public int numberInput;

    public Text dataText;
    string weirdRefForUpdateText = "Data : ";

    DatabaseReference reference;

    void Start()
    {
        //Analytics init
        /*FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
        */
        //RealtimeDatabase init
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mobileandroidios-test-253114.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        
    }

    public void SaveData()
    {
        WriteNewUser(nameInput, numberInput);
    }


    private void Update()
    {
        dataText.text = weirdRefForUpdateText;
    }

    private void WriteNewUser(string name, int number)
    {
        string manualJson = "{\""+ name +"\":"+ number +"}";
        //Debug.Log(manualJson);
        
        //Rewrite full dataBase
        //reference.Child("sTh8ozru4nmL9OMGybSg").SetRawJsonValueAsync(manualJson);
        
        //Rewrite full dataBase
        reference.Child("sTh8ozru4nmL9OMGybSg").SetValueAsync(manualJson);

    }

    public void RetreiveData()
    {
        reference.GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
                // Handle the error...
                Debug.Log("Error Firebase no data retreived.");
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
                //Debug.Log("Data : " + snapshot.GetRawJsonValue());
                weirdRefForUpdateText = "Data : " + snapshot.GetRawJsonValue();
              // Do something with snapshot...
          }
      });

    }

    public void UpdateNameInput()
    {
        nameInput = nameText.text;
    }

    public void UpdateNumberInput()
    {
        numberInput = int.Parse(numberText.text);
    }
}
