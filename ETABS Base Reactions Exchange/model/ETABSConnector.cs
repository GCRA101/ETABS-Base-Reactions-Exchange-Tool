
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using CSiAPIv1;
using ETABSv1;

using System.Threading;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.ComponentModel;


public class ETABSConnector : ETABSConnection {

    /*ATTRIBUTES ************************************************************************************/

    //Private Instance - SINGLETON PATTERN
	private static ETABSConnector instance;
    //ETABS OAPI Interoperability Variables
    private ETABSv1.cHelper helperObject;     // Helper Class Object Variable                  //O(1)
    private ETABSv1.cOAPI ETABSApp;           // ETABS Application Object Variable             //O(1)
    //Utility Variables
    private int ret;                                                                    	   //O(1)
    const boolean etabsVisibility =false;      	   											   //O(1)


    /*PRIVATE CONSTRUCTOR ***************************************************************************/
    //Default
	private ETABSConnector() {}


    /*METHODS ***************************************************************************************/

    //GETINSTANCE() METHOD - SINGLETON PATTERN
	public static ETABSConnector getInstance() {
		if instance==null {
			instance = new ETABSConnector();}
		return instance;}
 

    //INITIALIZEETABS() METHOD
    public void initialize() {
		//Helper Class Object Variable
        helperObject = New ETABSv1.Helper                                                      //O(1)
		helperObject=new ETABSv1.Helper;
		//ETABS Application Object Variable                                                    //O(1)
		ETABSApp=null;
		ETABSApp=helperObject.CreateObjectProgID("CSI.ETABS.API.ETABSObject");                 //O(1)
        //ETABSApp = helperObject.CreateObject("c:\Program Files\Computers and Structures\ETABS 20\ETABS.exe");
        //ETABSApp = helperObject.GetObject("CSI.ETABS.API.ETABSObject");                      //O(1)
    }


    // DISPOSEETABS() METHOD
	public void dispose() {
		//Close the ETABS Application
		ETABSApp.ApplicationExit(false);  														//O(1)
		//Release Memory
		ETABSApp=null;  																		//O(1)
	}


    // SETETABSVISIBILITY() METHOD
	private void setEtabsVisibility(boolean bool) {
		if (bool==false) {
			ret=ETABSApp.Hide();}
		else {
			ret=ETABSApp.Unhide();
		}
	}

    //Getters

    //GET ETABS APP
    public ETABSApp getEtabsApp() {return this.ETABSApp;}

}
