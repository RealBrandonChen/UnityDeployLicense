using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using SKM.V3;
using SKM.V3.Methods;
using SKM.V3.Models;

public class RegistrationKey : MonoBehaviour
{
    //// Start is called before the first frame update
    private void Start()
    {
        // We recommend to review https://help.cryptolens.io/getting-started/unity for common errors and tips.
        var RSAPubKey = "<RSAKeyValue><Modulus>******</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        var auth = "WyIyMjcxMjQ1IiwiNjV6cWN0VWZ3dXJkQXhUQml2UEt4NUNVY3dIdit4SjkzUXdob0JlbSJd";
        Helpers.WindowsOnly = true;
        //var machineCode = Helpers.GetMachineCode();
        var machineCode = "default";
        var result = Key.Activate(token: auth, productId: 11605, key: "CTRXZ-AQECF-VBSWR-PXNFF", machineCode: machineCode);
    
        if (result == null || result.Result == ResultType.Error)
        {
            // an error occurred or the key is invalid or it cannot be activated
            // (eg. the limit of activated devices was achieved)
            Debug.Log(result?.Message);
            Debug.Log("The license does not work.");
        }
        else
        {
            // obtaining the license key (and verifying the signature automatically).
            var license = LicenseKey.FromResponse(RSAPubKey, result);
            // make sure to set Max Number of Machines (https://help.cryptolens.io/faq/index#maximum-number-of-machines)
            // if it's set to zero, please remove "!Helpers.IsOnRightMachinePI(license)".
            
            if (license == null || !Helpers.IsOnRightMachinePI(license))
            {
                Debug.Log("The license cannot be used on this device.");
                return;
            }
            // everything went fine if we are here!
            Debug.Log("The license is valid!");
        }

    }
}
