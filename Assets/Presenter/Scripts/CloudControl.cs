using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
 
public class CloudControl : MonoBehaviour
{
    [SerializeField] VolumeProfile volumeProfile;
    VolumetricClouds vClouds;
 
    public void Sparse()
    {
        if (volumeProfile.TryGet<VolumetricClouds>(out vClouds))
        {
            vClouds.cloudPreset.value = VolumetricClouds.CloudPresets.Sparse;
            Debug.Log(vClouds.cloudPreset);
        }
   
    }
    public void Cloudy()
    {
        if (volumeProfile.TryGet<VolumetricClouds>(out vClouds))
        {
            vClouds.cloudPreset.value = VolumetricClouds.CloudPresets.Cloudy;
            Debug.Log(vClouds.cloudPreset);
        }
 
    }
    public void Overcast()
    {
        if (volumeProfile.TryGet<VolumetricClouds>(out vClouds))
        {
            vClouds.cloudPreset.value = VolumetricClouds.CloudPresets.Overcast;
            Debug.Log(vClouds.cloudPreset);
        }
 
    }
    public void Stormy()
    {
        if (volumeProfile.TryGet<VolumetricClouds>(out vClouds))
        {
            vClouds.cloudPreset.value = VolumetricClouds.CloudPresets.Stormy;
            Debug.Log(vClouds.cloudPreset);
        }
 
    }
 
}