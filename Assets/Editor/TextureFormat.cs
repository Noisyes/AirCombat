using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class TextureFormat : AssetPostprocessor
{
    private static FolderData _folderData = null;
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
        if (assetPath.Contains(Paths.PLAYER))
        {
            string name = Path.GetFileNameWithoutExtension(assetPath);
            string pattern = "^[0-9]+_[0-9]+$";
            Match res = Regex.Match(name, pattern);
            if (!res.Success)
            {
                if (_folderData == null)
                {
                    _folderData = new FolderData();
                    _folderData.Path = Paths.PLAYER;
                    _folderData.NameTip = "命名例子:0_0";
                }
                Debug.LogError("文件命名不规范， 文件名:"+name);
                NamingMgrWindow.ShowWindow();
                NamingMgrData.Add(_folderData,assetPath);
            }
        }
    }

    private void SetTexturePara()
    {
        TextureImporter importer = assetImporter as TextureImporter;
        importer.textureType = TextureImporterType.Sprite;
    }
}
