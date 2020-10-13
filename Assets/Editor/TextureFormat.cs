using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class TextureFormat : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        NamingConvention();
        SetTexturePara();
    }

    private void NamingConvention()
    {
        NamingPlayer();
    }

    private void NamingPlayer()
    {
        if (assetPath.Contains(Paths.PICTURE))
        {
            string name = Path.GetFileNameWithoutExtension(assetPath);
            string pattern = "^[0-9]+_[0-9]+$";
            Match res = Regex.Match(name, pattern);
            if (!res.Success)
            {
                Debug.LogError("文件命名不规范， 文件名:"+name);
                NamingMgrWindow.ShowWindow();
            }
        }
    }

    private void SetTexturePara()
    {
        TextureImporter importer = assetImporter as TextureImporter;
        importer.textureType = TextureImporterType.Sprite;
    }
}
