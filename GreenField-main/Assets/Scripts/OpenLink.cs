using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    // Remilekun's Socials
    public void OpenRemiTwitter()
    {
        Application.OpenURL("https://twitter.com/Rem_dev22?t=iGkHQywSS5v2ROOH6k3-pg&s=08");
    }
    public void OpenRemiGithub()
    {
        Application.OpenURL("https://github.com/Remilekun-Odegbami");
    }
    public void OpenRemiPortfolio()
    {
        Application.OpenURL("https://remilekun-odegbami.vercel.app/");
    }

    // Ajibike's Socials
    public void OpenJibikePortfolio()
    {
        Application.OpenURL("https://drive.google.com/file/d/1u6WzyBEPkpAimwjOG-pk5JCZis1d0tsD/view?usp=drivesdk");
    }

    public void OpenJibikeTwitter()
    {
        Application.OpenURL("https://twitter.com/Prunny_Jay?t=MBoYQY4_NaNYR-B3TTYf4g&s=09");
    }
    public void OpenJibikeGithub()
    {
        Application.OpenURL("https://github.com/Jaybee02");
    }
}
