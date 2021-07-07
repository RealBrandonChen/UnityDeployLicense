# UnityDeployLicense
## Integrated with Cryptolens to give Unity application a deploying license.

### This repository aims to integrate the Cryptolens to a full-grown Unity App/Game for deploying. [Cryptolens](https://cryptolens.io/) is an open-source API which licenses your software securely. You may refer to the [Cryptolens docs](https://help.cryptolens.io/basics/index) for a comprehensive understanding of how it works. The quick set up for your Unity software is as following:

- ### Cryptolens Account Set Up
  - #### [Create an account](https://help.cryptolens.io/getting-started/create-account)
  - #### [Create a new product](https://help.cryptolens.io/getting-started/new-product) and [verification key](https://help.cryptolens.io/getting-started/create-license)
  - #### [Create auth/acess token](https://help.cryptolens.io/getting-started/access-token). The Key Lock and the Feature Lock should left blank when you create the token.
  - #### [Get the public key (optional)](https://help.cryptolens.io/getting-started/pubkey)
  - #### Notice that the `Maximum number of machines` when you create the key should be greater than zero, and the `Maximum number of devices` should also be edited to greater than zero in the customer's editing view. 
  - #### Now you have the `product id`(in the product detail view), `verification key`(20-char string) and the `auth/acess token`. We are ready.
  ![Create Key](https://user-images.githubusercontent.com/46734495/124695242-6662f280-df15-11eb-910f-8dfbd6dd56f8.PNG)
  
- ### Unity editor Set Up
  - #### Import the [Cryptolens.Licensing.CrossPlatform](https://github.com/Cryptolens/cryptolens-dotnet/releases/tag/v4.0.34) package into the Unity assets. The version I use here is v4.0.34.You can import it in either two ways:
    #### 1. Import the [Nuget package](https://github.com/GlitchEnzo/NuGetForUnity/releases) for Unity editor. Nuget is the package manager for .NET language in Microsoft. The Unity package manager now does not contain this useful package, so you need to download and import it manually. After importing, search Cryptolens and install the crossplatform one.
    ![Nuget](https://user-images.githubusercontent.com/46734495/124695207-56e3a980-df15-11eb-9760-c1d1afd90479.PNG)


    #### 2. Or you can download the [package](https://github.com/Cryptolens/cryptolens-dotnet/releases) directly, copy and paste it into the Unity assets. The files we need are `Cryptolens.Licensing.CrossPlatform.dll` and `Newtonsoft.Json`.

  - #### [Registration key script](RegistrationKey.cs/)
    #### Download the script and paste it in the Unity assets. 
    ```C#
    var RSAPubKey = "<RSAKeyValue><Modulus>***</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
    var auth = "WyIyMjcxMjQ1IiwiNjV6cWN0VW******QXhUQml2UEt4NUNVY3dIdit4SjkzUXdob0JlbSJd";
    Helpers.WindowsOnly = true;
    //var machineCode = Helpers.GetMachineCode();
    var machineCode = "default";
    var result = Key.Activate(token: auth, productId: 11605, key: "CTRXZ-AQECF-VBSWR-PXNFF", machineCode: machineCode);
    ```
  - #### verification key and auth token set up
    #### Replace the `product id`, `verification key` and the `auth/acess token` in the script with yours.
  
- ### Web API Logs Monitoring
  - ### Key verification status
    #### You can click and review the latest request in the product detail view, if your key verification is successful, you should get the information below:
  Status | Success
  -- | --
  ID | 83915679
  Time (UTC) | 2021-07-06 08:29:00
  IP | 116.**.***.0
  Product Id | 115**
  Key | CTRXZ-AQECF-VBSWR-PXNFF
  Machine Code | default
  Friendly Name |  
  Operation | The key was already activated on a machine with the given id
  State | 2011
  Anomaly | No
 
  - ### Turn back to the procut detail view and the activated devices should be updated.
  ![Activated Devices](https://user-images.githubusercontent.com/46734495/124695055-0cfac380-df15-11eb-9ae8-f0f30a08bd0d.PNG)



