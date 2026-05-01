using System;

namespace DatingApp
{

    // modeli i Perdoruesit
    // mban te gjitha te dhenat kryesore te rreshtit.
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Emri { get; set; } = string.Empty;
        public string AboutMe { get; set; } = string.Empty;
        public string Kontakti { get; set; } = string.Empty;
        public string Datelindja { get; set; } = string.Empty;
        public string SeksiIm { get; set; } = string.Empty;
        public string SeksiKerkoj { get; set; } = string.Empty;
        public string QytetiIm { get; set; } = string.Empty;
        public string QytetiKerkoj { get; set; } = string.Empty;
        public string FotoPath { get; set; } = string.Empty;

        public override string ToString() => $"{Emri}, {SeksiIm}";
    }
}