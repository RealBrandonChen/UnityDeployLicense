using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

using SKM.V3;
using SKM.V3.Methods;
using SKM.V3.Models;

public class ActivatingVerification : MonoBehaviour
{

    //// Start is called before the first frame update
    private void Start()
    {
        // We recommend to review https://help.cryptolens.io/getting-started/unity for common errors and tips.
        var RSAPubKey = "<RSAKeyValue><Modulus>uJA3GkwXifEWyyDXqr2fzQSPkbiH43y/xpxyNCapSHEQ6WHSE5gOc5r54sLtRCg7xTqZnwdJYb9wccYTVg3IqBk94bDfrMPLo6tM1O8MXAqaEYIUGfgExTPMP6ieFqAXSRdBuzaGm0dt2UKZljVtUjmFvsKqNPqSPAzNeRG3L3k1ZZaijCt6ors1yzye2Z09mSMITzqU4vYYI2Wib7N/BegNho54rC6oVNXmBILZXvL9882CMsGbhlMJhTwPFoFh7nJSolnf8Z3HXPdQh6k3H1US9TiPJwhW+9Gvq/jJnkkk7IGqqPB47t2k8873i5O2h3QstedeTbkn4o8Bzqlm5Q==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        var auth = "WyIzODM4NzA1IiwiWlVOZHBpVm5LWE5MMWtvTUJQdTdzR242OUs4VFlIalVFR2h4NFRnNiJd";
        //var machineCode = new DeviceIdBuilder().AddMachineName().ToString();
        //var machineCode = Helpers.GetMachineCodePI();
        var machineCode = SystemInfo.deviceName;
        var result = Key.Activate(token: auth, productId: 12304, key: "GPGGB-YOMXX-YZFMI-ZNDOR", machineCode: machineCode);

        if (result == null || result.Result == ResultType.Error)
        {
            // an error occurred or the key is invalid or it cannot be activated
            // (eg. the limit of activated devices was achieved)
            Debug.Log(result?.Message);
            Debug.Log("The license does not work.");
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
        }
        else
        {
            // obtaining the license key (and verifying the signature automatically).
            var license = LicenseKey.FromResponse(RSAPubKey, result);

            // make sure to set Max Number of Machines (https://help.cryptolens.io/faq/index#maximum-number-of-machines)
            // if it's set to zero, please remove "!Helpers.IsOnRightMachinePI(license)".
            if (license == null /*|| !Helpers.IsOnRightMachine(license)*/)
            {
                Debug.Log("The license cannot be used on this device.");
                return;
            }
            // everything went fine if we are here!
            Debug.Log("The license is valid!");
        }

    }
}
