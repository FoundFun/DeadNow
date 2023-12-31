﻿using Agava.YandexGames;
using UnityEngine.UI;

namespace BasicTemplate.CodeBase.Services.Yandex
{
    public class YandexCloudService : IYandexCloudService
    {
        private InputField _cloudSaveDataInputField;
        
        public void OnSetCloudSave() => 
            PlayerAccount.SetCloudSaveData(_cloudSaveDataInputField.text);

        public void OnGetCloudSave() => 
            PlayerAccount.GetCloudSaveData((data) => _cloudSaveDataInputField.text = data);
    }
}