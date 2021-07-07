# UnityDeployLicense
## Integrated with Cryptolens to give Unity application a deploying licenese.

### This repository aims to integrate the Cryptolens to a full-grown Unity App/Game for deploying. [Cryptolens](https://cryptolens.io/) is a free-charging API which license your software securely. You may refer to the [Cryptolens docs](https://help.cryptolens.io/basics/index) for a comprehensive understanding of how it works. The quick set up for your Unity software is as following:

- ### Cryptolens Account Set Up
  - #### [Create an account](https://help.cryptolens.io/getting-started/create-account)
  - #### [Create a new product](https://help.cryptolens.io/getting-started/new-product) and [verification key](https://help.cryptolens.io/getting-started/create-license)
  - #### [Create auth/acess token](https://help.cryptolens.io/getting-started/access-token)
  - #### [Get the public key (optional)](https://help.cryptolens.io/getting-started/pubkey)
  - #### Now you have the `product id`(in the product detail view), `verification key`(20-char string) and the `auth/acess token`. We are ready.
  
- ### Unity editor Set Up
  - #### Import the [Cryptolens.Licensing.CrossPlatform](https://github.com/Cryptolens/cryptolens-dotnet/releases/tag/v4.0.34) package into the Unity assets. The version I use here is v4.0.34.You can import it in either two ways:
    #### 1. Import the [Nuget package](https://github.com/GlitchEnzo/NuGetForUnity/releases) for Unity editor. Nuget is the package manager for .NET language in Microsoft. The Unity package manager now does not contain this useful package, so you need to download and import it manually. After importing, search Cryptolens and install the crossplatform one.
    ![Nuget](https://user-images.githubusercontent.com/46734495/124692720-a673a680-df10-11eb-8bf9-0c050a849e1c.PNG)
    
    #### 2. Or you can download the [package](https://github.com/Cryptolens/cryptolens-dotnet/releases) directly, copy and paste it into the Unity assets. The files we need are `Cryptolens.Licensing.CrossPlatform.dll` and `Newtonsoft.Json`.

  - ### [Registration key script](docs/CONTRIBUTING.md)
  - ### verification key and auth token set up
  
- ### Web API Logs Monitoring
  - ### Key verification status
