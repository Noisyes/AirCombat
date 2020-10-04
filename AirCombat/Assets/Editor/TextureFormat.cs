using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TextureFormat : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        TextureImporter importer = assetImporter as TextureImporter;
        importer.textureType = TextureImporterType.Sprite;
    }
}
