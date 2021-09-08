using Blazored.Toast.Services;
using GestioneTurniAgenti.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class TurniMassivo
    {
        [Inject]
        public ITurniService TurniService { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        private bool _filesent;

        private async Task CaricaFile(InputFileChangeEventArgs e)
        {
            if (e.FileCount == 1 && e.File.Size > 0)
            {
                try
                {
                    using var ms = e.File.OpenReadStream();
                    var content = new MultipartFormDataContent();
                    content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                    content.Add(new StreamContent(ms), "file", e.File.Name);

                    _filesent = true;
                    await TurniService.CreateFromMassivo(content);
                }
                catch (Exception ex)
                {
                    ToastService.ShowError($"Si è verificato un errore nel caricamento dei dati da file: {ex.Message}");
                }
            }
        }
    }
}