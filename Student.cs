using System;

namespace Student_MeetUp
{

    // modeli i Studentit
    // mban te gjitha te dhenat kryesore te rreshtit.
    public class Student
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Emri { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public string Kontakti { get; set; } = string.Empty;
        public string Datelindja { get; set; } = string.Empty;
        public string SeksiIm { get; set; } = string.Empty;
        public string SeksiKerkoj { get; set; } = string.Empty;
        public int FakultetiIm { get; set; }
        public int FakultetiKerkoj { get; set; }
        public string FotoPath { get; set; } = string.Empty;
        public override string ToString() => $"{Emri}, {SeksiIm}";
    }
}